namespace CaliburnMetro.ViewModels
{
    using Caliburn.Micro;

    public class ImageViewModel : PropertyChangedBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; NotifyOfPropertyChange(() => Name); }
        }

        private string _url;
        public string Url
        {
            get { return _url; }
            set { _url = value; NotifyOfPropertyChange(() => Url); }
        }

        private string _latitude;
        public string Latitude
        {
            get { return _latitude; }
            set { _latitude = value; NotifyOfPropertyChange(() => Latitude); }
        }

        private string _longtitude;
        public string Longtitude
        {
            get { return _longtitude; }
            set { _longtitude = value; NotifyOfPropertyChange(() => Longtitude); }
        }

        public void SayHello()
        {
            
        }
    }
}