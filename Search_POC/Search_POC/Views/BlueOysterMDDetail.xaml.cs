using Search_POC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;

namespace Search_POC.Views
{
    public class Model
    {
        public string Name { get; set; }
    }
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlueOysterMDDetail : ContentPage, IBasePage<TagEntryViewExamplePageModel>
    {
        public static List<Model> lstModel;
        public static List<Model> SearchResultitems;
        public static List<Model> Selecteditems;
        public bool IsFirstTime ;
        public BlueOysterMDDetail()
        {
            //Resources = new ResourceDictionary();
            //Resources.Add("TagValidatorFactory", new Func<string, object>(
            //    (arg) => (BindingContext as TagEntryViewExamplePageModel)?.ValidateAndReturn(arg)));
            InitializeComponent();
            IsFirstTime = true;
            LoadData();
        }

        private void LoadData()
        {
            lstModel = new List<Model>();
            SearchResultitems = new List<Model>();
            Selecteditems = new List<Model>();
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

        public void lstSuggestion_Tapped(Object sender, ItemTappedEventArgs e)
        {
            var obj = e.Item as Model;
            if (!string.IsNullOrEmpty(obj.Name))
            {
                //if (IsFirstTime)
                //{

                //}
                //else
                //{

                //}
                //contentpagecontrol.HeightRequest=
                Selecteditems.Add(obj);
                StackLayout stkmainparent1 = new StackLayout();
                stkmainparent1.Orientation = StackOrientation.Vertical;
                stkmainparent1.HeightRequest = 100;
                var btn = new Button();
                btn.Text = obj.Name;
                btn.Clicked += Btn_Clicked;
                stkmainparent1.Children.Add(btn);
                //stkmainparent1.Children.Add(
                //                             new StackLayout()
                //                             {
                //                                 BackgroundColor = Color.FromHex("#FFFFFF"),
                //                                 Orientation = StackOrientation.Horizontal,
                //                                 Children = {
                //                                                        new Button(){
                //                                                            Text=obj.Name
                //                                                        }
                //                                                        }

                //                             }
                //                            );
                contentpagecontrol.Children.Add(stkmainparent1);
                searchbar.Text = "";
            }
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            var item = sender as Button;
            var res = item.Text;
            contentpagecontrol.Children.Clear();
            var ItemToRemove = Selecteditems.Where(x => x.Name == res).FirstOrDefault();
            var position = Selecteditems.IndexOf(ItemToRemove);
            Selecteditems.RemoveAt(position);
            foreach (var items in Selecteditems)
            {
                StackLayout stkmainparent1 = new StackLayout();
                stkmainparent1.Orientation = StackOrientation.Vertical;
                stkmainparent1.HeightRequest = 50;
                var btn = new Button();
                btn.Text = items.Name;
                btn.Clicked += Btn_Clicked;
                stkmainparent1.Children.Add(btn);
                //stkmainparent1.Children.Add(
                //                             new StackLayout()
                //                             {
                //                                 BackgroundColor = Color.FromHex("#FFFFFF"),
                //                                 Orientation = StackOrientation.Horizontal,
                //                                 Children = {
                //                                                        new Button(){
                //                                                            Text=items.Name
                //                                                        }
                //                                                        }

                //                             }
                //                            );
                contentpagecontrol.Children.Add(stkmainparent1);
            }
        }

        ////private void btnsearch_Clicked(object sender, EventArgs e)
        ////{

        ////}
    }
}