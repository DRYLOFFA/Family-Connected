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
using Android.Widget;

namespace Family_App
{
    [Activity(Label = "Family App", Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainPage : Activity
    {
        // Declearing used items \\
        Button FamilyCalender;
        Button GroceryList;
        ListView HappeningToday;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.MainPage);

            // Declearing used items \\
            FamilyCalender = FindViewById<Button>(Resource.Id.btnCalenderMain);
            GroceryList = FindViewById<Button>(Resource.Id.btnGroceryMain);
            HappeningToday = FindViewById<ListView>(Resource.Id.lstHappeningToday);

            // Click events \\
            FamilyCalender.Click += FamilyCalender_Click;
            GroceryList.Click += GroceryList_Click;
        }
        
        // Only 2 buttons on this page currently heaps of room for more \\
        private void GroceryList_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(GroceryList));
            StartActivity(nextActivity);
        }

        private void FamilyCalender_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(Calender));
            StartActivity(nextActivity);
        }
    }
}