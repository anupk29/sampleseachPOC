using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Search_POC.Views
{
    public class Model
    {
        public string Name { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public static List<Model> lstModel;
        public static List<Model> SearchResultitems;
        public HomePage()
        {
            InitializeComponent();
            lstModel = new List<Model>();
            SearchResultitems = new List<Model>();
            lstModel.Add(new Model { Name = "Abigail" });
            lstModel.Add(new Model { Name = "Bob" });
            lstModel.Add(new Model { Name = "Cathy" });
            lstModel.Add(new Model { Name = "David" });
            lstModel.Add(new Model { Name = "Eugenie" });
            lstModel.Add(new Model { Name = "Freddie" });
            lstModel.Add(new Model { Name = "Greta" });
            lstModel.Add(new Model { Name = "Harold" });
            lstModel.Add(new Model { Name = "Irene" });
            lstModel.Add(new Model { Name = "Ramesh" });
            lstModel.Add(new Model { Name = "Raj" });
            lstModel.Add(new Model { Name = "Rahul" });

        }

        //private void LoadData()
        //{
        //    lstModel = new List<Model>();
        //    SearchResultitems = new List<Model>();
        //    lstModel.Add(new Model { Name = "Abigail" });
        //    lstModel.Add(new Model { Name = "Bob" });
        //    lstModel.Add(new Model { Name = "Cathy" });
        //    lstModel.Add(new Model { Name = "David" });
        //    lstModel.Add(new Model { Name = "Eugenie" });
        //    lstModel.Add(new Model { Name = "Freddie" });
        //    lstModel.Add(new Model { Name = "Greta" });
        //    lstModel.Add(new Model { Name = "Harold" });
        //    lstModel.Add(new Model { Name = "Irene" });
        //    lstModel.Add(new Model { Name = "Ramesh" });
        //    lstModel.Add(new Model { Name = "Raj" });
        //    lstModel.Add(new Model { Name = "Rahul" });
        //}

        public void Handle_Event(Object sender, EventArgs e)
        {
            var searchItem = searchbar.Text;
            if (!string.IsNullOrEmpty(searchItem))
            {
                SearchResultitems = lstModel.Where(x => x.Name.ToLower().Contains(searchItem.ToLower())).ToList();
            }
            else
            {
                SearchResultitems = null;
            }
            if (SearchResultitems != null && SearchResultitems.Count > 0)
            {
                lstSuggestion.IsVisible = true;
                lstSuggestion.ItemsSource = SearchResultitems;
            }
            else
            {
                lstSuggestion.ItemsSource = null;
                lstSuggestion.IsVisible = false;

            }

        }

        public void lstSuggestion_Tapped(Object sender, EventArgs e)
        {


        }
    }
}