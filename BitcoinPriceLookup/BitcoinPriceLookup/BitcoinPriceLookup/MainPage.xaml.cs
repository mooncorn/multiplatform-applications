using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BitcoinPriceLookup
{
    public partial class MainPage : ContentPage
    {
        private KucoinClient _kucoinClient;

        public MainPage()
        {
            InitializeComponent();
            _kucoinClient = new KucoinClient();
        }

        public async void SearchBar_SearchButtonPressed(Object sender, EventArgs e)
        {
            activityIndicator.IsRunning = true;
            var stats = await _kucoinClient.Get24hStats(searchBar.Text);
            lblBuy.Text = stats.Data.Buy.ToString();
            activityIndicator.IsRunning = false;
        }
    }
}

