using System.Windows.Input;
using ConsoleHost.Core;

namespace ConsoleHost.View
{
    public class ContainerViewModel : ObservableObject
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set
            {
                if (value == _path) return;
                _path = value;
                OnPropertyChanged();
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        private HwndControl _content;
        public HwndControl Content
        {
            get { return _content; }
            set
            {
                if (Equals(value, _content)) return;
                _content = value;
                OnPropertyChanged();
            }
        }

        public ICommand StartCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (Content == null)
                    {
                        var content = new HwndControl(Path);
                        Content = content;
                    }
                });
            }
        }

        public ICommand StopCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    if (Content != null)
                    {
                        Content.Dispose();
                        Content = null;    
                    }
                });
            }
        }
    }
}
