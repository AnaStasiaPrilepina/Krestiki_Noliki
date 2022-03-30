using MediaManager;//
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace Krestiki_Noliki
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoundPage : ContentPage
    {
        public IList<string> Mp3List => new[]
        {
            "https://ia800806.us.archive.org/15/items/Mp3Playlist_555/AaronNeville-CrazyLove.mp3",
            "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/CelineDion-IfICould.mp3",
            "https://ia800605.us.archive.org/32/items/Mp3Playlist_555/Daughtry-Homeacoustic.mp3"
        };
        Button play, pause, stop;
        Grid grid1x3;
        public SoundPage()
        {
            InitializeComponent();
            grid1x3 = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            play = new Button
            {
                Text = "play",
                CornerRadius = 100
            };
            play.Clicked += Play_Clicked;
            pause = new Button
            {
                Text = "pause",
                CornerRadius = 100
            };
            pause.Clicked += Pause_Clicked;
            stop = new Button
            {
                Text = "stop",
                CornerRadius = 100
            };
            stop.Clicked += Stop_Clicked;

            grid1x3.Children.Add(play, 0, 0);
            grid1x3.Children.Add(pause, 1, 0);
            grid1x3.Children.Add(stop, 2, 0);

            Content = grid1x3;
        }

        private async void Stop_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Stop();
        }

        private async void Pause_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Pause();
        }

        private async void Play_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Play(Mp3List);
        }
    }
}