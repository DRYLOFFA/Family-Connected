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
    //[Activity(Label = "Login")]
    [Activity(Label = "Family Connected", MainLauncher = true, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class Login : Activity
    {
        // Declearing used items \\
        EditText UNLIP;
        EditText PLIP;
        Button SILIP;
        Button BCALIP;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Login);

            // Declearing used items \\
            UNLIP = FindViewById<EditText>(Resource.Id.txtUserNameLog);
            PLIP = FindViewById<EditText>(Resource.Id.txtPasswordLog);
            SILIP = FindViewById<Button>(Resource.Id.btnSignInLog);
            BCALIP = FindViewById<Button>(Resource.Id.btnCreateNewLog);

            // Click events \\
            SILIP.Click += SILIP_Click;
            BCALIP.Click += BCALIP_Click;
        }

        private void BCALIP_Click(object sender, EventArgs e)
        {
            // Create a new Family hidden button background \\
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetMessage("Create a new family?");
            alert.SetButton("YES", (c, ev) =>
            {
                // Ok button opens below task (create account) \\  
                Intent nextActivity = new Intent(this, typeof(CreateAccount));
                StartActivity(nextActivity);
            });
            alert.SetButton2("NO", (c, ev) => { });
            alert.Show();
        }

        private void SILIP_Click(object sender, EventArgs e)
        {
            // Sign in click events \\
            Family db = new Family();
            RestHandler objRest = new RestHandler();

            // Username or password empty \\
            if (UNLIP.Text == "")
            {
                Toast.MakeText(this, "Please enter your family name", ToastLength.Short).Show();
                return;
            }
            if (PLIP.Text == "")
            {
                Toast.MakeText(this, "Please enter the password", ToastLength.Short).Show();
                return;
            }

            var families = objRest.ExecuteGetRequestF();

            // Check username and password is correct \\
            int index = families.FindIndex(f => f.FamilyName == UNLIP.Text && f.UserPassword == PLIP.Text);
            
            // If correct logs you in and opens main page \\
            if (index >= 0 )
            {
                Intent nextActivity = new Intent(this, typeof(MainPage));

                int tempid = families.Find(p => p.FamilyName == UNLIP.Text).FamilyID;

                // Stores FamilyID and FamilyName in singleton class \\
                FamilySingleton f = FamilySingleton.Instance;
                f.FamilyID = tempid;
                f.FamilyName = UNLIP.Text;

                // Starts main page activity \\
                StartActivity(nextActivity);
            }
            else
            {
                // If incorrect tost message for user to reaslise they got something wrong \\
                Toast.MakeText(this, "Wrong family name or password sorry" +
                "\n Please try again", ToastLength.Short).Show();
                return;
            }
        }
    }
}