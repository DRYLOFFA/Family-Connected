using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace Family_App
{
    [Activity(Label = "Family App", MainLauncher = false, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Calender : Activity
    {

        public class Family_App : WebViewClient
        {
            // For API level 24 and later
            public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
            {
                view.LoadUrl(request.Url.ToString());
                return false;
            }
        }
        WebView CalenderWeb;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Calender);

            // Pre set web view to load to Google calander this can be changed to anything really \\
            CalenderWeb = FindViewById<WebView>(Resource.Id.wvCalenderCal);
            CalenderWeb.Settings.JavaScriptEnabled = true;
            CalenderWeb.SetWebViewClient(new Family_App());
            CalenderWeb.LoadUrl("https://www.google.com/calendar/");
        }
    }
}