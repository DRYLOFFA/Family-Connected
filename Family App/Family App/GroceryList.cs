using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Family_App
{
    [Activity(Label = "Family App", MainLauncher = false, Theme = "@android:style/Theme.DeviceDefault.NoActionBar", ScreenOrientation = ScreenOrientation.Portrait)]
    //[Activity(Label = "GroceryList")]
    public class GroceryList : Activity
    {
        // Declearing used items \\
        TextView FamilyGrocery;
        EditText AddItemtext;
        ListView FoodList;
        Button ClearList;
        Button AddItem;
        List<Groceries> familylist = new List<Groceries>();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here \\
            SetContentView(Resource.Layout.GroceryList);

            // Declearing used items \\
            FamilyGrocery = FindViewById<TextView>(Resource.Id.txtFamilyNameGrocery);
            AddItemtext = FindViewById<EditText>(Resource.Id.txtAddItemHere);
            FoodList = FindViewById<ListView>(Resource.Id.lstGroceryList);
            ClearList = FindViewById<Button>(Resource.Id.btnClearGroceryList);
            AddItem = FindViewById<Button>(Resource.Id.btnAddGroceryItem);

            // CLick events \\
            ClearList.Click += ClearList_Click;
            AddItem.Click += AddItem_Click;
            FoodList.ItemLongClick += FoodList_ItemLongClick;

            // Load usefull thigs eg Family name and their grocery list \\
            FamilyGrocery.Text = FamilySingleton.Instance.FamilyName + " family grocery list";
            LoadAllItems();
        }

        private void FoodList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            var grocery = familylist[e.Position];
            //Toast.MakeText(this, grocery.ListID + " " + grocery.Family.FamilyName + " " + grocery.Grocery1, ToastLength.Long).Show();
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetMessage("Delete " + grocery.Grocery1 + "??");
            alert.SetButton("YES", (c, ev) =>
            {
                RestHandler objRest = new RestHandler();
                var items = objRest.ExecuteDeleteRequestG(grocery.ListID);
                LoadAllItems();
            });
            alert.SetButton2("NO", (c, ev) => { });
            alert.Show();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            RestHandler objRest = new RestHandler();
            Groceries item = new Groceries();

            item.Grocery1 = AddItemtext.Text;
            item.FamilyID = FamilySingleton.Instance.FamilyID;

            bool result = objRest.ExecutePostRequestG(item);

            if (result == true)
            {
                Toast.MakeText(this, AddItemtext.Text + " added to grocery list", ToastLength.Short).Show();
                LoadAllItems();
                AddItemtext.Text = "";
            }
            else
            {
                Toast.MakeText(this, "Error adding item", ToastLength.Long).Show();
            }
        }

        private void ClearList_Click(object sender, EventArgs e)
        {
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(this);
            AlertDialog alert = dialog.Create();
            alert.SetMessage("Delete ALL grocery items?" +
                "\n" + "This cannot be undone!!!");
            alert.SetButton("YES", (c, ev) =>
            {
                RestHandler objRest = new RestHandler();
                var items = objRest.ExecuteDeleteRequestAllGrocery(FamilySingleton.Instance.FamilyName);
                LoadAllItems();
            });
            alert.SetButton2("NO", (c, ev) => { });
            alert.Show();
        }

        public void LoadAllItems()
        {
            RestHandler objRest = new RestHandler();
            var items = objRest.ExecuteGetRequestG();

            familylist = items.FindAll(p => p.Family.FamilyName == FamilySingleton.Instance.FamilyName);

            List<string> flList = new List<string>();

            foreach (var item in familylist)
            {
                string line;
                line = item.Grocery1;
                flList.Add(item.Grocery1);
            }
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, flList);
            FoodList.Adapter = adapter;
        }
    }
}
