namespace CaliburnMetro.Views
{
    using System;
    using System.Collections.Generic;
    using Dto;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Media.Imaging;
    using Windows.UI.Xaml.Navigation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly List<Camera> _cameras;
        private int _count = 0;

        public MainPage()
        {
            this.InitializeComponent();

            //_cameras = Windows.Storage.ApplicationData.Current.LocalSettings.Values["Cameras"] as List<Camera>;
            
            if(_cameras == null)
            {
                var agent = new Agent();
                _cameras = agent.GetCameras();
                //Windows.Storage.ApplicationData.Current.LocalSettings.Values["Cameras"] = _cameras;
            }

            //var agent = new Agent();
            //_cameras = agent.GetCameras();

            //string url = _cameras[_count].Url;

            //var bitmapImage = new BitmapImage();
            //theImage.Source = bitmapImage;
            //((BitmapImage) theImage.Source).UriSource = new Uri(url);
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _count--;

            string url = _cameras[_count].Url;
            ((BitmapImage)theImage.Source).UriSource = new Uri(url);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _count++;

            string url = _cameras[_count].Url;
            ((BitmapImage)theImage.Source).UriSource = new Uri(url);
        }
    }
}
