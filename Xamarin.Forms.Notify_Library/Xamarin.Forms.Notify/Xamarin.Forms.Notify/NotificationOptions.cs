using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin.Forms.Notify
{
    /// <summary>
    /// sets options for notifications (this is identical to Android.App.NotificationFlags, for now)
    /// </summary>
    [Flags]
    public enum NotificationOptions
    {
        //
        // Summary:
        //     ///
        //     /// /// Android.App.Notification.Flags /// /// /// /// To turn the LED off, pass
        //     0 in the alpha channel for colorARGB /// or 0 for both ledOnMS and ledOffMS.
        //     /// /// /// To turn the LED on, pass 1 for ledOnMS and 0 for ledOffMS. /// ///
        //     /// To flash the LED, pass the number of milliseconds that it should /// be on
        //     and off to ledOnMS and ledOffMS. /// /// ///
        //     ///
        //     ///
        //     /// The alpha channel must be set for forward compatibility. /// ///
        //     ///
        ShowLights = 1,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that should
        //     be /// set if this notification is in reference to something that is ongoing,
        //     /// like a phone call. It should not be set if this notification is in /// reference
        //     to something that happened at a particular point in time, /// like a missed phone
        //     call. ///
        //     ///
        OngoingEvent = 2,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that if
        //     set, /// the audio will be repeated until the notification is /// cancelled or
        //     the notification window is opened. ///
        //     ///
        Insistent = 4,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that should
        //     be /// set if you want the sound and/or vibration play each time the /// notification
        //     is sent, even if it has not been canceled before that. ///
        //     ///
        OnlyAlertOnce = 8,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that should
        //     be /// set if the notification should be canceled when it is clicked by the ///
        //     user. /// ///
        //     ///
        AutoCancel = 16,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that should
        //     be /// set if the notification should not be canceled when the user clicks ///
        //     the Clear all button. ///
        //     ///
        NoClear = 32,
        //
        // Summary:
        //     ///
        //     Bit to be bitwise-ored into the Android.App.Notification.Flags field that should
        //     be /// set if this notification represents a currently running service. This
        //     /// will normally be set for you by Android.App.Service.StartForeground(System.Int32,
        //     Android.App.Notification). ///
        //     ///
        ForegroundService = 64,
        //
        // Summary:
        //     ///
        //     Obsolete flag indicating high-priority notifications; use the priority field
        //     instead.
        //     ///
        HighPriority = 128
    }
}
