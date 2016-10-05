using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Notify
{

    //public interface INotification
    //{
    //    string Text { get; set; }
    //    string Title { get; set; }

    //    Task DisplayNotification();
    //}

    public class Notification
    {
        static protected volatile int notificationID;
        public static int GenerateUniqueId() { return ++notificationID; }

        public Notification()
        {
            ID = GenerateUniqueId();
        }

        public string Text { get; set; }

        public string Title { get; set; }

        public int ID { get; private set; }

        public NotificationOptions Options { get; set; }

        static public Task<Notification> DisplayNotification(string title, string text)
        {
            return Task<Notification>.Run(() =>
            {
                var note = new Notification()
                {
                    Title = title,
                    Text = text,
                };

                Notifier.DisplayNotification(note);

                return note;
            });
        }


        public Task DisplayNotification()
        {
            return Notifier.DisplayNotification(this);
        }

        public Task UpdateAndNotify(string text)
        {
            Text = text;

            return DisplayNotification();
        }
    }

    /// <summary>
    /// Defines the a generic API for building/creating notifications on any platform
    /// </summary>
    public abstract class Notifier: IDisposable
    {
        /// <summary>
        /// provides platform specific impl for notifications
        /// </summary>
        /// <param name="title"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected abstract void DisplayOnPlatform(Notification notification);


        //static internal Task DisplayNotification(int id, string title, string text)
        //{
        //    return Task.Run(() => Xamarin.Forms.DependencyService.Get<Notifier>()
        //                                        .DisplayOnPlatform(id, title, text));
        //}

        static public Task DisplayNotification(Notification notification)
        {
            return Task.Run(() =>
            {
                Xamarin.Forms.DependencyService.Get<Notifier>().DisplayOnPlatform(notification);
            });
        
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        ////TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        //~Notifier()
        //{
        //    Do not change this code.Put cleanup code in Dispose(bool disposing) above.
        //  Dispose(false);
        //}

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}