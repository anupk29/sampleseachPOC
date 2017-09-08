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
        public static List<Model> Selecteditems;
        public HomePage()
        {
            InitializeComponent();
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
                //searchbar.Text = "";
                Selecteditems = new List<Model>();
                Selecteditems.Add(obj);
                //searchplaceholder.IsVisible = true;
                //Label lbl = new Label();
                //lbl.Text = obj.Name;
                //lbl.FontSize = 20;
                //Button btn = new Button();
                //btn.Text = "X";
                //StackLayout customstacklayout = new StackLayout();
                //customstacklayout.Orientation = StackOrientation.Horizontal;
                //customstacklayout.Padding = new Thickness(1, 1, 1, 1);
                //customstacklayout.Children.Add(lbl);
                //customstacklayout.Children.Add(btn);
                //StackLayout sl = new StackLayout();
                //sl.Orientation = StackOrientation.Vertical;
                //sl.Children.Add(customstacklayout);
                //sl.Padding = new Thickness(1,1,1,1);
                //searchplaceholder.Children.Add(sl);
                StackLayout stkmainparent1 = new StackLayout();
                stkmainparent1.Orientation = StackOrientation.Vertical;
                //stkmainparent1.Padding = new Thickness(0,15,0,0);

                stkmainparent1.HeightRequest = 50;
                var btn = new Button();
                btn.Text = obj.Name;
                btn.Clicked += Btn_Clicked;
                stkmainparent1.Children.Add(btn);
                stkmainparent1.Children.Add(
                     new StackLayout()
                     {
                         BackgroundColor = Color.FromHex("#FFFFFF"),
                         //HeightRequest = 25,
                         Orientation = StackOrientation.Horizontal,
                         //Padding= new Thickness(0,10,0,0),
                         Children = {
                                               
                    //                           new Frame()
                    //                           {
                    //                                 Content = new Label { Text = obj.Name },
                    //OutlineColor = Color.Silver,
                    //VerticalOptions = LayoutOptions.CenterAndExpand,
                    //HorizontalOptions = LayoutOptions.Center

                    //                           }
                    new Button()
                    {
                        Text=obj.Name,
                        
                        //Command=Actionon(),
                        //Clicked+=Btn_Clicked()
                
                    }
                                    }


                     }
             );

                //StackLayout cp = new ContentPage();
                //cp.HeightRequest=
                //cp.Content=new Frame
                //{
                //    Content = new Label { Text = obj.Name },
                //    OutlineColor = Color.Silver,
                //    VerticalOptions = LayoutOptions.CenterAndExpand,
                //    HorizontalOptions = LayoutOptions.Center
                //};
                contentpagecontrol.Children.Add(stkmainparent1);

            }
        }

        private void Btn_Clicked(object sender, EventArgs e)
        {
            var item = sender as Model;
            contentpagecontrol.Children.Clear();
            var ItemToRemove = Selecteditems.Where(x => x.Name == item.Name).FirstOrDefault();
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
                stkmainparent1.Children.Add(
                                             new StackLayout()
                                             {
                                                 BackgroundColor = Color.FromHex("#FFFFFF"),
                                                 Orientation = StackOrientation.Horizontal,
                                                 Children = {
                                                                        new Button(){
                                                                            Text=items.Name
                                                                        }
                                                                        }

                                             }
                                            );
                contentpagecontrol.Children.Add(stkmainparent1);
            }
        }
    }
}