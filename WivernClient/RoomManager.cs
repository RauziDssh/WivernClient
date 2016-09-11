using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace WivernClient
{
    public class RoomManager
    {
        public Room room { get; private set; }
        public Subject<Status> statusStream { get; set; }
        private Form1 form;

        public RoomManager(Room r, Form1 f)
        {
            this.room = r;
            form = f;
            statusStream = new Subject<Status>();
        }

        public void ChangeRoom(Room r)
        {
            this.room = r;
        }

        //ユーザの状態を取得して帰ってきたStatusを処理する
        public async void SendMessage(string CardId)
        {
            try
            {
                var status = await DXTServer.GetStatusAsync(CardId, room);
                if (status == null) { return; }
                Console.WriteLine("[DEBUG:Status]" + status.InOrOut + status.room.DisplayName() + status.username);
                if (status.room != Room.None)
                {
                    statusStream.OnNext(status);
                }
                else
                {
                    form.ShowMessage("「検出したデバイス」より登録してください","未登録ユーザ");
                    //System.Diagnostics.Process.Start(status.username);
                }
            }
            catch (Exception e)
            {
                form.ShowErrorMessage(e.Message);
            }
        }

        //ユーザの状態を取得して帰ってきたStatusを処理する
        public async void SendMessage(string CardId,bool InOrOut)
        {
            try
            {
                var status = await DXTServer.GetStatusAsync(CardId, room);
                if (status == null) { return; }
                Console.WriteLine("[DEBUG:Status]" + status.InOrOut + status.room.DisplayName() + status.username);

                if (status.InOrOut != InOrOut && status.room != Room.None) SendMessage(CardId, InOrOut); return;

                if (status.room != Room.None)
                {
                    statusStream.OnNext(status);
                }
                else
                {
                    form.ShowMessage("「検出したデバイス」より登録してください", "未登録ユーザ");
                    //System.Diagnostics.Process.Start(status.username);
                }
            }
            catch (Exception e)
            {
                form.ShowErrorMessage(e.Message);
            }
        }

        public async void SubmitDevice(string address)
        {
            try
            {
                var status = await DXTServer.GetStatusAsync(address, room);
                if (status == null) { return; }
                if (status.room != Room.None)
                {
                    form.ShowMessage("登録済みです","情報");
                }
                else
                {
                    //form.ShowMessage("「検出したデバイス」より登録してください", "未登録ユーザ");
                    System.Diagnostics.Process.Start(status.username);
                }
            }
            catch (Exception e)
            {
                form.ShowErrorMessage(e.Message);
            }
        }
    }

    public class Status
    {
        public Room room { get; private set; }
        public string username { get; private set; }
        public bool InOrOut { get; private set; }

        public Status(Room r, bool io, string t)
        {
            this.room = r;
            this.InOrOut = io;
            this.username = t;
        }
    }
}
