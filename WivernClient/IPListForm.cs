using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace WivernClient
{
    public partial class IPListForm : Form
    {
        private RoomManager roommanager;

        public IPListForm(List<MacData> macList,RoomManager rm)
        {
            InitializeComponent();
            InitializeListView(macList);
            roommanager = rm;
        }

        private List<DeviceData> devicelist;

        private void InitializeListView(List<MacData> list)
        {
            // ListViewコントロールのプロパティを設定
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.Sorting = SortOrder.Ascending;
            listView1.View = View.Details;

            // 列（Column）ヘッダの作成
            ColumnHeader[] columnHead = new ColumnHeader[4];
            for (int i = 0; i < 4; i++)
                columnHead[i] = new ColumnHeader();
            columnHead[0].Text = "IPアドレス";
            columnHead[0].Width = 100;
            columnHead[1].Text = "macアドレス";
            columnHead[1].Width = 150;
            columnHead[2].Text = "デバイス名";
            columnHead[2].Width = 150;
            columnHead[3].Text = "製造者";
            columnHead[3].Width = 100;
            listView1.Columns.AddRange(columnHead);

            devicelist = list.Select(v => new DeviceData(v)).ToList();

            //デバイス名の取得
            foreach(var e in devicelist)
            {
                try
                {
                    var iphe = Dns.GetHostEntry(e.ip);
                    e.deviceName = iphe.HostName;
                }
                catch
                {
                    e.deviceName = "不明";
                }

            }

            RefleshList(devicelist);
        }

        private void RefleshList(List<DeviceData> list)
        {
            listView1.Items.Clear();
            //アイテムの追加
            foreach (var e in list)
            {
                listView1.Items.Add(new ListViewItem(new string[] { e.ip, e.mac, e.deviceName,e.maker }));
            }
        }

        private async void findMakerButton_Click(object sender, EventArgs e)
        {
            var http = new HttpClient();
            for (var i = 0; i < devicelist.Count; i++)
            {
                var url = $"https://macvendors.co/api/{devicelist[i].mac}/json";
                Console.WriteLine(url);
                try
                {
                    var result = await http.GetStringAsync(url);
                    dynamic json = JsonConvert.DeserializeObject(result);

                    var company = json.result.company;

                    devicelist[i].maker = company;
                }
                catch
                {
                    devicelist[i].maker = "不明";
                }
                RefleshList(devicelist);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            var index = listView1.SelectedItems[0].Index;
            Console.WriteLine("選択" + devicelist[index].ip);
            var encoded = MacStore.GetEncodedMacAddress(devicelist[index].mac);
            roommanager.SubmitDevice(encoded);
        }
    }

    public class DeviceData
    {
        public string mac;
        public string ip;
        public string deviceName = "不明";
        public string maker = "不明";

        public DeviceData(MacData md)
        {
            ip = md.ip;
            mac = md.mac;
        }
    }
}
