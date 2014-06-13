using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows;
using System.Windows.Input;
using ConsoleHost.Core;

namespace ConsoleHost.View
{
    public class ShellViewModel : ObservableObject
    {
        private ObservableCollection<ContainerViewModel> _containers;
        public ObservableCollection<ContainerViewModel> Containers
        {
            get { return _containers; }
            set
            {
                if (Equals(value, _containers)) return;
                _containers = value;
                OnPropertyChanged("Containers");
            }
        }


        public ICommand StartAllCommand
        {
            get 
            {
                return new DelegateCommand(() =>
                {
                    foreach (var container in Containers)
                    {
                        container.StartCommand.Execute(null);
                    }
                });
            }
        }

        public ICommand StopAllCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    foreach (var container in Containers)
                    {
                        container.StopCommand.Execute(null);
                    }
                });
            }
        }

        public ShellViewModel()
        {
            Containers = new ObservableCollection<ContainerViewModel>();

            var paths = ConfigurationManager.AppSettings.Get("Paths").Split(';');
            foreach (var path in paths)
            {
                var containerViewModel = new ContainerViewModel();
                containerViewModel.Path = path;
                containerViewModel.Name = System.IO.Path.GetFileName(path);
                Containers.Add(containerViewModel);
            }
        }
    }
}
