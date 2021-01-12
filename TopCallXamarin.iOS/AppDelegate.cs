using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using NativeLibrary;
using Sharpnado.MaterialFrame.iOS;
using UIKit;

namespace TopCallXamarin.iOS
{

	public class Constants
	{
		public static string PhoneEvent = "NOTIFICATION_PHONE_EVENT";
		public static string CallEvent = "NOTIFICATION_CALL_EVENT";

		public static string EventArg = "EVENT";
		public static string StatusCodeArg = "STATUS_CODE";
		public static string StatusTextArg = "STATUS_TEXT";
		public static string RemoteArg = "REMOTE_CONTACT";
		public static string CallArg = "CALL_ID";

		public static NSNumber PhoneEventsRegSuccess = 1;
		public static NSNumber PhoneEventsRegFailed = 2;
		public static NSNumber PhoneEventsUnregSuccess = 3;
		public static NSNumber PhoneEventsUnregFailed = 4;
		public static NSNumber PhoneEventsRemoteAlerting = 5;

		public static NSNumber CallEventsConnected = 10;
		public static NSNumber CallEventsDisconnected = 20;
		public static NSNumber CallEventsAlerting = 30;
		public static NSNumber CallEventsIncoming = 40;
		public static NSNumber CallEventsTransfering = 50;
		public static NSNumber CallEventsHeld = 60;
	}

	public class AppDelegateObserver : AbtoPhoneInterfaceObserver
	{
		readonly AppDelegate parent;

		public AppDelegateObserver(AppDelegate parent)
		{
			this.parent = parent;
		}

		public override void OnRegistered(nint accId)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.PhoneEvent, Constants.PhoneEventsRegSuccess);
		}

		public override void OnRegistrationFailed(nint accId, int statusCode, string statusText)
		{
			var args = new NSDictionary(Constants.StatusCodeArg, statusCode, Constants.StatusTextArg, statusText);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.PhoneEvent, Constants.PhoneEventsRegFailed, args);
		}

		public override void OnUnRegistered(nint accId)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.PhoneEvent, Constants.PhoneEventsUnregSuccess);
		}

		public override void OnRemoteAlerting(nint accId, int statusCode)
		{
			var args = new NSDictionary(Constants.StatusCodeArg, statusCode);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.PhoneEvent, Constants.PhoneEventsRemoteAlerting, args);
		}

		public override void OnIncomingCall(nint callId, string remoteContact)
		{
			var args = new NSDictionary(Constants.CallArg, callId, Constants.RemoteArg, remoteContact);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsIncoming, args);
		}

		public override void OnCallConnected(nint callId, string remoteContact)
		{
			var args = new NSDictionary(Constants.CallArg, callId, Constants.RemoteArg, remoteContact);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsConnected, args);
		}

		public override void OnCallDisconnected(nint callId, string remoteContact, nint statusCode, string message)
		{
			var args = new NSDictionary(Constants.CallArg, callId, Constants.StatusCodeArg, statusCode, Constants.StatusTextArg, message, Constants.RemoteArg, remoteContact);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsDisconnected, args);
		}

		public override void OnCallAlerting(nint callId, int statusCode)
		{
			var args = new NSDictionary(Constants.CallArg, callId, Constants.StatusCodeArg, statusCode);
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsAlerting, args);
		}

		public override void OnCallHeld(nint callId, bool state)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsHeld);
		}

		public override void OnToneReceived(nint callId, nint tone)
		{
			NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsTransfering);
		}

		public override void OnTextMessageReceived(string from, string to, string body)
		{
		}

		public override void OnTextMessageStatus(string address, string reason, bool status)
		{
		}

		public override void OnPresenceChanged(string uri, PhoneBuddyStatus status, string note)
		{
		}

		public override void OnTransferStatus(nint callId, int statusCode, string message)
		{
		}

		public override void OnZrtpSas(nint callId, string sas, bool verified)
		{
		}

		public override void OnZrtpSecureState(nint callId, bool secured)
		{
		}

		public override void OnZrtpError(nint callId, nint error, nint subcode)
		{
		}

		public override void onNetworkStateChanged(PhoneNetworkEventType evt, bool ipv6)
		{
		}

	}

	// The UIApplicationDelegate for the application. This class is responsible for launching the 
	// User Interface of the application, as well as listening (and optionally responding) to 
	// application events from iOS.
	[Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
		public UILocalNotification LocalNotification { get; set; }

		public bool CheckIconLaunch { get; set; }

		public AbtoPhoneInterface Phone { get; set; }

		public static AppDelegate SharedInstance
		{
			get
			{
				return UIApplication.SharedApplication.Delegate as AppDelegate;
			}
		}

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.SetFlags("CollectionView_Experimental");
            global::Xamarin.Forms.Forms.Init();
			XF.Material.iOS.Material.Init();
			iOSMaterialFrameRenderer.Init();
			FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
			LoadApplication(new App());

			SetupAbto();

			return base.FinishedLaunching(app, options);
        }

		public override void DidEnterBackground(UIApplication application)
		{
			// Use this method to release shared resources, save user data, invalidate timers and store the application state.
			// If your application supports background exection this method is called instead of WillTerminate when the user quits.
			Phone.KeepAwake(true);
		}

		public override void WillEnterForeground(UIApplication application)
		{
			// Called as part of the transiton from background to active state.
			// Here you can undo many of the changes made on entering the background.
			Phone.KeepAwake(false);

			UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
		}

		public override void OnActivated(UIApplication application)
		{
			// Restart any tasks that were paused(or not yet started) while the application was inactive. 
			// If the application was previously in the background, optionally refresh the user interface.
			if (CheckIconLaunch)
			{
				CheckIconLaunch = false;
				if (LocalNotification != null)
				{
					NSNotificationCenter.DefaultCenter.PostNotificationName(Constants.CallEvent, Constants.CallEventsIncoming, LocalNotification.UserInfo);
					LocalNotification = null;
				}
			}
		}

		public override void WillTerminate(UIApplication application)
		{
			// Called when the application is about to terminate. Save data, if needed. See also DidEnterBackground.
		}

		void SetupAbto()
        {
			var settings = UIUserNotificationSettings.GetSettingsForTypes(
											UIUserNotificationType.Alert
											| UIUserNotificationType.Badge
											| UIUserNotificationType.Sound,
											new NSSet());
			UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);

			NSNotificationCenter center = NSNotificationCenter.DefaultCenter;
			center.AddObserver(UIApplication.DidFinishLaunchingNotification, OnAppResume, null);
			center.AddObserver(UIApplication.WillEnterForegroundNotification, OnAppResume, null);

			Phone = new AbtoPhoneInterface();
			Phone.Initialize(new AppDelegateObserver(this));

			Console.WriteLine("SDK version = {0}", Phone.LibVersion);
		}

		void OnAppResume(NSNotification notification)
		{
			CheckIconLaunch = notification.UserInfo == null || notification.UserInfo[UIApplication.LaunchOptionsLocalNotificationKey] == null;
		}

	}
}
