using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive;

namespace WivernClient
{
    public partial class Form1 : Form
    {
        public RoomManager roomManager { get; set; }

        public Form1()
        {
            //初期設定
            InitializeComponent();
            var pc = new PingChecker();
            
            //DEBUG
            var debug = new Debug(pc);
            debug.Show();

            //利用可能な部屋を登録
            var availavleRoom = new Room[] { Room.box233, Room.box234, Room.box412 };

            //利用可能な部屋をそれぞれ項目として使用可能にする
            foreach (var element in availavleRoom)
            {
                var name = element.DisplayName();
                var tsmi = new ToolStripMenuItem();
                tsmi.Text = name;
                //部屋名クリック時の処理
                tsmi.Click += (s, o) =>
                {
                    //部屋が変更されたときの処理
                    InitializeRoom(element);

                    toolStripMenuItem_room.Text = $"選択：{name}";
                    Properties.Settings.Default.PreserveRoomNum = (int)element;
                    Properties.Settings.Default.Save();
                };
                toolStripMenuItem_room.DropDownItems.Add(tsmi);
            }

            //部屋の設定の読み込み
            var proom = Properties.Settings.Default.PreserveRoomNum;
            if (proom == -1)
            {
                toolStripMenuItem_room.Text = $"選択：なし";
                this.ShowErrorMessage("部屋が設定されていません");
            }
            else
            {
                //部屋の設定が完了しているとき
                roomManager = InitializeRoom((Room)proom);

                toolStripMenuItem_room.Text = $"選択：{roomManager.room.DisplayName()}";
                this.ShowMessage("起動しました", "Wivern");
            }

            pc.StartPingAllAsync(Enumerable.Range(2,254));
            Console.WriteLine("poll start");
            notifyIcon1.Visible = true;
            pc.DetectIpStream
                .Select(v =>
                    {
                        var ipInfo = v;
                        var macInfo = v.connected ? MACConverter.ConvertToMAC(v.ip) : null;
                        return new { ipInfo, macInfo };
                    }
                )
                .Subscribe(v => 
                {
                    if (v.ipInfo.connected)
                    {
                        ShowMessage(v.macInfo,"入室");
                        var encoded = MacStore.GetEncodedMacData(new MacData(v.ipInfo.ip.ToString(), v.macInfo));
                        if (MacStore.macList.Select(x => x.mac).Contains(v.macInfo)) return;
                        MacStore.macList.Add(new MacData(v.ipInfo.ip.ToString(), v.macInfo));
                        Console.WriteLine($"入室_{v.macInfo}_{encoded.ip}");
                        var sendmessage = MacStore.GetEncodedMacData(new MacData(v.ipInfo.ip.ToString(), v.macInfo));
                        roomManager.SendMessage(sendmessage.mac,true);
                        Console.WriteLine(sendmessage.mac);
                    }
                    else
                    {
                        Console.WriteLine($"退室_{v.ipInfo.ip}");
                        var message = MacStore.GetEncodedMacData(MacStore.macList.Where(d => d.ip == v.ipInfo.ip.ToString()).First());
                        roomManager.SendMessage(message.mac,false);
                        MacStore.macList.Remove(MacStore.macList.Where(d => d.ip == v.ipInfo.ip.ToString()).First());
                        Console.WriteLine(message.mac);
                    }
                }
            );
        }

        private RoomManager InitializeRoom(Room r)
        {
            roomManager = new RoomManager(r, this);
            roomManager.statusStream
                .DistinctUntilChanged()
                .Subscribe(v =>
                {
                    var InOut = v.InOrOut ? "入室" : "退室";
                    ShowMessage($"{InOut}:{v.username}", "Wivern");
                }
                );
            return roomManager;
        }

        public void ShowMessage(string message, string title)
        {
            notifyIcon1.BalloonTipTitle = title;
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(200);
        }

        public void ShowErrorMessage(string message)
        {
            notifyIcon1.BalloonTipTitle = "エラー";
            notifyIcon1.BalloonTipText = message;
            notifyIcon1.ShowBalloonTip(200);
        }

        private void toolStripMenuItem_info_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"author:@Rauziii\nverison:{Application.ProductVersion}",
                "Information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void toolStripMenuItem_detected_Click(object sender, EventArgs e)
        {
            IPListForm ipListForm = new IPListForm(MacStore.macList,roomManager);
            ipListForm.Show();
        }

        private void toolStripMenuItem_roomInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"{DXTServer.serverUrl}/places");
        }
    }
}
