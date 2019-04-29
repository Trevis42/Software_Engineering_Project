using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace LoginPage.Droid
{
    [Activity(Theme = "@theme/MainTheme")]
    public class ClientListActivity : Activity , Android.Text.ITextWatcher
    {

        ArrayAdapter listAdapter;

        public void AfterTextChanged(IEditable s)
        {
            throw new NotImplementedException();
        }

        public void BeforeTextChanged(ICharSequence s, int start, int count, int after)
        {
            throw new NotImplementedException();
        }

        public void OnTextChanged(ICharSequence s, int start, int before, int count)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ClientListView);

            var editSearch = FindViewById<EditText>(Resource.Id.searchBar);
            var listAdapter = FindViewById<ListView>(Resource.Id.listSearchView);

            editSearch.AddTextChangedListener(this);

            
        }
    }
}