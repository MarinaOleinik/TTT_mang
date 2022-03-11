using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TTT_mang
{
    public partial class MainPage : ContentPage
    {
        Grid grid4X1, grid3X3;
        Button uus_mang, esimene, teema;
        BoxView b;
        bool esi=false;
        public MainPage()
        {
            grid4X1 = new Grid
            {
                BackgroundColor=Color.Blue,
                VerticalOptions=LayoutOptions.FillAndExpand,
                HorizontalOptions=LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(3,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions=
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            //Uus_mang();
            uus_mang = new Button()
            {
                Text = "UUS MÄNG"
            };
            uus_mang.Clicked += Uus_mang_Clicked;
            esimene = new Button()
            {
                Text = "KES ON ESIMENE?"
            };
            esimene.Clicked += Esimene_Clicked;
            teema = new Button()
            {
                Text = "TEEMA"
            };
            
            grid4X1.Children.Add(uus_mang, 0, 1);
            grid4X1.Children.Add(esimene, 0, 2);
            grid4X1.Children.Add(teema, 0, 3);
            Content = grid4X1;
        }

        private void Esimene_Clicked(object sender, EventArgs e)
        {
            Kes_esimene();
        }
        public async void Kes_esimene()
        {
            string e_valik = await DisplayPromptAsync("Kes on esimene?", "Tee oma valik 1-valge,2-kollane", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }
        private void Uus_mang_Clicked(object sender, EventArgs e)
        {
            Kes_esimene();
            Uus_mang();
        }

        public void Uus_mang()
        {
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Red,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    b = new BoxView { Color = Color.Green };//
                    grid3X3.Children.Add(b, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    b.GestureRecognizers.Add(tap);
                }
            }
            grid4X1.Children.Add(grid3X3, 0, 0);
        }
        private void Tap_Tapped(object sender, EventArgs e)
        {
            var b = (BoxView)sender;
            var r = Grid.GetRow(b);
            var c = Grid.GetColumn(b);
            if (esi)
            {
                b.Color = Color.White;
                esi = false;
            }
            else
            {
                b.Color = Color.Yellow;
                esi = true;
            }
            
        }
    }
}
