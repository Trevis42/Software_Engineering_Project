using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;



namespace phone_call
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            Entry numEntry = new Entry
            {
                Placeholder = "Contact number",
                Text = "",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Button call_btn = new Button
            {
                BackgroundColor = Color.FromRgb(102, 204, 102),
                Text = "Call",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children = { numEntry, call_btn }
            };
        }
    }
}
