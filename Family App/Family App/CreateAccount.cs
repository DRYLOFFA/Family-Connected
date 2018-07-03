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
    [Activity(Label = "Family App", MainLauncher = false, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class CreateAccount : Activity
    {
        // Declearing used items \\
        EditText FamilyNameCre;
        Button CreateFamilyCre;
        ListView FamilyCre;
        EditText PasswordCre;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.CreateAccount);

            // Declearing used items \\
            FamilyNameCre = FindViewById<EditText>(Resource.Id.txtFamilyNameCre);
            CreateFamilyCre = FindViewById<Button>(Resource.Id.btnCreateCre);
            FamilyCre = FindViewById<ListView>(Resource.Id.lstFamilyCre);
            PasswordCre = FindViewById<EditText>(Resource.Id.txtPasswordCre);

            // Click events \\
            CreateFamilyCre.Click += CreateFamilyCre_Click;
        }

        private void CreateFamilyCre_Click(object sender, EventArgs e)
        {
            RestHandler objRest = new RestHandler();
            var families = objRest.ExecuteGetRequestF();

            // Check is texts boxes are empty \\
            if (FamilyNameCre.Text == "")
            {
                Toast.MakeText(this, "Please enter Family Name", ToastLength.Short).Show();
                return;
            }
            if (PasswordCre.Text == "")
            {
                Toast.MakeText(this, "Please enter a Password", ToastLength.Short).Show();
                return;
            }

            int index = families.FindIndex(f => f.FamilyName == FamilyNameCre.Text);

            // Check if Family name is already taken \\
            if (index >= 0)
            {
                Toast.MakeText(this, "This name is taken" +
                "\n       Please try again", ToastLength.Short).Show();
                return;
            }
            else
            {
                // Add a new family and post it the online database \\
                Family f = new Family();

                f.FamilyName = FamilyNameCre.Text;
                f.UserPassword = PasswordCre.Text;

                objRest.ExecutePostRequestF(f);

                // Toast message for user to know its worked \\
                Toast.MakeText(this, FamilyNameCre.Text + " family created", ToastLength.Short).Show();
                return;
            }
        }
    }
}