using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Family_App
{
    // Local temperary data storeage, resets on app close \\
    public class FamilySingleton
    {
        static readonly FamilySingleton _instance = new FamilySingleton();
        public string FamilyName { get; set; }
        public int FamilyID { get; set; }

        public static FamilySingleton Instance
        {
            get
            {
                return _instance;
            }
        }
        FamilySingleton()
        {
            // Initialize.
        }

    }
    
}