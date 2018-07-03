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
    // My database classes linked by the Family name which is unique \\
    public class Family
    {
        public List<Groceries> Groceries { get; set; }
        public int FamilyID { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }

    public class Groceries
    {
        public Family Family { get; set; }
        public int ListID { get; set; }
        public int FamilyID { get; set; }
        public string Grocery1 { get; set; }
    }
}