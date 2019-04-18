using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace client_list
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //Title label
            Label clientList_Title = new Label();
            clientList_Title.Text = "Client List";
            Content = clientList_Title;

            //Home button
            Button home_BTN = new Button();
            home_BTN.Content = "Home page";
            Content.ChildAdded(home_BTN);

            //search bar
            private void mySearchBox_QuerySubmitted(SearchBox sender, SearchBoxQuerySubmittedEventArgs args)
            {
                this.Frame.Navigate(typeof(SearchResultsPage1), args.QueryText);
            }
            //Client names with button that goes to their profiles

            //
        }
    }
}
