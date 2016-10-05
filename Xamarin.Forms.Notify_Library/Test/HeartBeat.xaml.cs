using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin.Forms.Notify
{
    public partial class HeartBeat : ContentView
    {
        Notification n;
        public HeartBeat()
        {
            InitializeComponent();
            n = new Notification() { Title = "notice!" };
        }

        int clicked;
        public async void OnClicked(object sender, EventArgs e)
        {
            //re-use a notification
            //n.UpdateAndNotify("click count: " + (++clicked));
//
//            //show a new one every time.
              Notify.Notification.DisplayNotification("new test", "clicks " + (++clicked));
//
//            await lbl1.RelScaleTo(.25, 250, Easing.BounceIn);
//            await lbl1.RelScaleTo(-.25, 250, Easing.BounceIn);
        }
    }
}