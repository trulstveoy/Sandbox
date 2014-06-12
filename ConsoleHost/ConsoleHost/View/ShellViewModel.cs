using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ConsoleHost.Core;

namespace ConsoleHost.View
{
    public class ShellViewModel : ObservableObject
    {
        private ObservableCollection<string> _theCollection;

        public ObservableCollection<string> TheCollection
        {
            get { return _theCollection; }
            set
            {
                if (Equals(value, _theCollection)) return;
                _theCollection = value;
                OnPropertyChanged("TheCollection");
            }
        }


        public ICommand StartAllCommand
        {
            get 
            {
                return new DelegateCommand(() =>
                {
                    TheCollection.Add("abc");
                });
            }
        }

        public ICommand StopAllCommand
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    MessageBox.Show("barfoo");
                });
            }
        }

        public ShellViewModel()
        {
            TheCollection = new ObservableCollection<string>();
            
            //TheCollection.Add("def");
            //TheCollection.Add("ghi");
        }
    }
}
