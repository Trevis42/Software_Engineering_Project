/*
    This class is an adapter class that is able to link the UI that handles the client info with the UI that is a ListView.
*/
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

namespace LoginPage.Droid
{
    class ClientListAdapter : BaseAdapter<Client>
    {

        public List<Client> clients;        //list to hold client info

        private Context context;

        public ClientListAdapter(Context context, List<Client> items)   //constructor
        {
            clients = items;
            this.context = context;
        }


        public override Java.Lang.Object GetItem(int position)  //returns the item as an object
        {
            return position;
        }

        public override long GetItemId(int position)   //returns the position of the item
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row == null)
                row = LayoutInflater.From(context).Inflate(Resource.Layout.ClientListItems, null, false);   //"inflates" the list as more clients are added

            TextView clientFirst = row.FindViewById<TextView>(Resource.Id.textClientFirst);                 //client first name
            clientFirst.Text = clients[position].First_Name;

            TextView clientLast = row.FindViewById<TextView>(Resource.Id.textClientLast);                   //client last name
            clientLast.Text = clients[position].Last_Name;

            TextView clientPhone = row.FindViewById<TextView>(Resource.Id.textClientPhone);                 //client phone number
            clientPhone.Text = clients[position].Phone_Number;

            return row;

        }

        public override int Count               //returns how many clients in the list
        {
            get
            {
                return clients.Count;   
            }
        }

        public override Client this[int position]           //return all client info by providing the list position
        {
            get { return clients[position]; }
        }
    }
}