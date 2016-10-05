using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DroidNotify = Android.Support.V4.App.NotificationCompat;//Android.App.Notification;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin.Forms.Notify.Droid.Notifier))]

namespace Xamarin.Forms.Notify.Droid
{
    public class Notifier : Xamarin.Forms.Notify.Notifier
    {
        NotificationManager noteMan;
        DroidNotify.Builder builder;

        public Notifier()
        {
            using (ContextWrapper AppContext = new ContextWrapper(Xamarin.Forms.Forms.Context)) //Android.App.Application.Context))
                noteMan = AppContext.GetSystemService(Context.NotificationService) as NotificationManager;

            builder = new DroidNotify.Builder(Xamarin.Forms.Forms.Context) //Android.App.Application.Context)
                        .SetContentTitle("Title")
                        .SetContentText("Text")
                        .SetSmallIcon(Resource.Drawable.info)
                        .SetVibrate(new long[] { 0, 250, 100, 250 })
                        .SetPriority(0)
                        .SetVisibility(0);
        }

        protected override void DisplayOnPlatform(Notification n)
        {
            try
            {

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        builder.SetContentText(n.Text)
                               .SetContentTitle(n.Title);

                        //one(or) both() of these guys were leaking mem
                        using (var not = builder.Build())
                        {
                            not.Flags |= (NotificationFlags)n.Options;

                            noteMan.Notify(n.ID, not);
                        }
                    }
                    catch(Exception e)
                    {
                        var exc = e;
                    }
                });
            }
            catch (Exception ex)
            {
                var s = ex.ToString();
            }
        }

        protected override void Dispose(bool disposing)
        {
            noteMan.Dispose();

            base.Dispose(disposing);
        }
    }
}