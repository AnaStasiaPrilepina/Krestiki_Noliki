using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Krestiki_Noliki
{
    public partial class MainPage : ContentPage
    {
        Button uus_mang, esimene, teema, music;
        Grid grid4x1, grid3x3;
        //Boxview box;
        Image img;
        bool esi = false;
        bool vali = false;
        //Random rnd;
        //Color color;
        int[,] T = new int[3, 3];
        public MainPage()
        {
            //color = new Color();
            //color = Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

            grid4x1 = new Grid
            {
                BackgroundColor = Color.Orange,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(3, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            uus_mang = new Button
            {
                Text = "Uus mang",
            };
            uus_mang.Clicked += Uus_Clicked;
            esimene = new Button
            {
                Text = "Kes on esimene?"
            };
            esimene.Clicked += Esimene_Clicked;
            teema = new Button
            {
                Text = "Teema"
            };
            teema.Clicked += Teema_Clicked;
            music = new Button
            {
                Text = "Sound",
            };
            music.Clicked += Music_Clicked;

            grid4x1.Children.Add(music, 0, 0);
            grid4x1.Children.Add(uus_mang, 0, 2);
            grid4x1.Children.Add(esimene, 0, 3);
            grid4x1.Children.Add(teema, 0, 4);

            Content = grid4x1;
        }

        private async void Music_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new media());
        }

        int voit = 0;
        //mozet bit private; vozvrawaet celoe chislo 1/2
        //kombinacii: 
        //00 10 20 
        //01 11 21  
        //02 12 22  
        //00 01 02  
        //10 11 12  
        //20 21 22  
        //00 11 22  
        //02 11 20
        public int Kontroll()
        {
            // 1 - pobedil
            if (T[0, 0] == 1 && T[1, 0] == 1 && T[2, 0] == 1 || T[0, 1] == 1 && T[1, 1] == 1 && T[2, 1] == 1 || T[0, 2] == 1 && T[1, 2] == 1 && T[2, 2] == 1)
            {
                voit = 1;
            }
            else if (T[0, 0] == 1 && T[0, 1] == 1 && T[0, 2] == 1 || T[1, 0] == 1 && T[1, 1] == 1 && T[1, 2] == 1 || T[2, 0] == 1 && T[2, 1] == 1 && T[2, 2] == 1)
            {
                voit = 1;
            }
            else if (T[0, 0] == 1 && T[1, 1] == 1 && T[2, 2] == 1 || T[0, 2] == 1 && T[1, 1] == 1 && T[2, 0] == 1)
            {
                voit = 1;
            }
            // 2 - pobedil
            else if (T[0, 0] == 2 && T[1, 0] == 2 && T[2, 0] == 2 || T[0, 1] == 2 && T[1, 1] == 2 && T[2, 1] == 2 || T[0, 2] == 2 && T[1, 2] == 2 && T[2, 2] == 2)
            {
                voit = 2;
            }
            else if (T[0, 0] == 2 && T[0, 1] == 2 && T[0, 2] == 2 || T[1, 0] == 2 && T[1, 1] == 2 && T[1, 2] == 2 || T[2, 0] == 2 && T[2, 1] == 2 && T[2, 2] == 2)
            {
                voit = 2;
            }
            else if (T[0, 0] == 2 && T[1, 1] == 2 && T[2, 2] == 2 || T[0, 2] == 2 && T[1, 1] == 2 && T[2, 0] == 2)
            {
                voit = 2;
            }
            // nikto ne pobedil
            else if (T[0, 0] != 0 && T[1, 0] != 0 && T[2, 0] != 0 && T[0, 1] != 0 && T[1, 1] != 0 && T[2, 1] != 0 && T[0, 2] != 0 && T[1, 2] != 0 && T[2, 2] != 0)
            {
                voit = 3;
            }
            return voit;
        }
        public void Lopp()
        {
            voit = Kontroll();
            if (voit == 1)
            {
                DisplayAlert("Võit", "Esimene on võitja", "Ok");
            }
            else if (voit == 2)
            {
                DisplayAlert("Võit", "Teine on võitja", "Ok");
            }
            else if (voit == 3)
            {
                DisplayAlert("Võit", "Viik", "Ok");
            }
        }

        private async void Teema_valik()
        {
            string e_valik = await DisplayPromptAsync("Milline teema?", "Tee oma valik: 1-cube/star, 2-cross/circle", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                vali = true;
            }
            else
            {
                vali = false;
            }
        }
        private void Teema_Clicked(object sender, EventArgs e)
        {
            Teema_valik();
        }

        public async void Kes_esimene()
        {
            if (vali)
            {
                string e_valik = await DisplayPromptAsync("Kes on esimene?", "Tee oma valik: 1-cube, 2-star", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
                if (e_valik == "1")
                {
                    esi = true;
                }
                else
                {
                    esi = false;
                }
            }
            else
            {
                string e_valik = await DisplayPromptAsync("Kes on esimene?", "Tee oma valik: 1-circle, 2-cross", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
                if (e_valik == "1")
                {
                    esi = true;
                }
                else
                {
                    esi = false;
                }
            }
        }
        private void Esimene_Clicked(object sender, EventArgs e)
        {
            Kes_esimene();
        }

        private async void Comment()
        {
            await DisplayAlert("Uue mängu loomine", "Vali teema ja pärast vali, kes on esimene.", "Peida");
        }
        private void Uus_Clicked(object sender, EventArgs e)
        {
            //Kes_esimene();
            Uus_mang();
            Comment();
        }

        public void Uus_mang()
        {
            T = new int[3,3];
            //for (int i = 0; i< 3; i++)
            //{
            //    for (int j = 0; j < 3; j++)
            //    {
            //        T[i,j] = 0;
            //    }
            //}
            voit = 0;
            grid3x3 = new Grid
            {
                BackgroundColor = Color.LightGreen,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //b = new BoxView { Color = Color.Pink };
                    img = new Image { Source = "white.png" };
                    //grid3x3.Children.Add(b, j, i);
                    grid3x3.Children.Add(img, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    //b.GestureRecognizers.Add(tap);
                    img.GestureRecognizers.Add(tap);
                    T[i, j] = 0;
                }
            }
            grid4x1.Children.Add(grid3x3, 0, 1);
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            //var b = (BoxView)sender;
            var img = (Image)sender;
            var r = Grid.GetRow(img);
            var c = Grid.GetColumn(img);

            if (vali)
            {
                if (esi)
                {
                    //b.Color = Color.White;
                    img.Source = "cube.png";
                    esi = false;
                    T[r, c] = 1;
                }
                else
                {
                    //b.Color = Color.Yellow
                    img.Source = "star.png";
                    esi = true;
                    T[r, c] = 2;
                }
                Lopp();
            }
            else
            {
                if (esi)
                {
                    img.Source = "circle.png";
                    esi = false;
                    T[r, c] = 1;
                }
                else
                {
                    img.Source = "cross.png";
                    esi = true;
                    T[r, c] = 2;
                }
                Lopp();
            }
        }
    }
}