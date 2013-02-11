namespace CaliburnMetro.ViewModels
{
    using System.Linq;
    using Caliburn.Micro;

    public class MainPageViewModel : Screen
    {
        private IObservableCollection<ImageViewModel> _images;
        public IObservableCollection<ImageViewModel> Images
        {
            get { return _images; }
            set { _images = value; NotifyOfPropertyChange(() => Images); }
        }

        public MainPageViewModel()
        {
            var agent = new Agent();
            Images = new BindableCollection<ImageViewModel>(agent.GetCameras().Take(20).Select(x => new ImageViewModel()
                                                                                               {
                                                                                                   Name = x.Name, 
                                                                                                   Url = x.Url,
                                                                                                   Longtitude = x.Longtitude,
                                                                                                   Latitude = x.Latitude
                                                                                               }));
         
        }
    }
}