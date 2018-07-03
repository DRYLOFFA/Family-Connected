using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System;
using Android.Content;
using Android.Content.PM;

namespace Family_App
{
    [Activity(Label = "Family App", MainLauncher = false, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        EditText Username;
        EditText Password;
        Button SignIn;
        EditText CreateAccount;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.MainPage);

            Username = FindViewById<EditText>(Resource.Id.txtUserNameLog);
            Password = FindViewById<EditText>(Resource.Id.txtPasswordLog);
            SignIn = FindViewById<Button>(Resource.Id.btnSignInLog);
            CreateAccount = FindViewById<EditText>(Resource.Id.txtCreateNewLog);


            SignIn.Click += SignIn_Click;
            CreateAccount.Click += CreateAccount_Click;
        }

        private void CreateAccount_Click(object sender, EventArgs e)
        {
            Intent nextActivity = new Intent(this, typeof(CreateAccount));
            StartActivity(nextActivity);
            //async void OnAlertYesNoClicked(object sender, EventArgs e)
            //{
            //    var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
            //    Debug.WriteLine("Answer: " + answer);
            //}
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if (Username.Text == "")
            {
                Toast.MakeText(this, "Please enter User Name", ToastLength.Short).Show();
                return;
            }
            if (Password.Text == "")
            {
                Toast.MakeText(this, "Please enter Password", ToastLength.Short).Show();
                return;
            }


            //foreach (var user in db.Users)
            //{
            //    if (user.Username == Username.Text && user.Password == Password.Text)
            //    {
            //        Toast.MakeText(this, "Welcome " + Username.Text, ToastLength.Short).Show();

            //        Intent nextActivity = new Intent(this, typeof(MainPage));
            //        StartActivity(nextActivity);
            //    }
            //    if (user.Username != Username.Text)
            //    {
            //        Toast.MakeText(this, "Wrong Username sorry" +
            //            "\n       Please try again", ToastLength.Short).Show();
            //        return;
            //    }
            //    if (user.Password != Password.Text)
            //    {
            //        Toast.MakeText(this, "Wrong Password sorry" +
            //            "\n       Please try again", ToastLength.Short).Show();
            //        return;
            //    }
            //}

        }
        //async void OnAlertYesNoClicked(object sender, EventArgs e)
        //{
        //    var answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes", "No");
        //    Debug.WriteLine("Answer: " + answer);
        //}
    }
}

