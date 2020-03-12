using System.ComponentModel;
using System.Runtime.CompilerServices;
using App1.Annotations;

namespace App1.ViewModels.Region
{
    public class RegionViewModel : INotifyPropertyChanged
    {
        private int _regionId;
        private string _name;
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public RegionViewModel(int regionId, string name)
        {
            _regionId = regionId;
            _name = name;
        }

        public RegionViewModel()
        {
            
        }

        public int RegionId
        {
            get => _regionId;
            set
            {
                _regionId = value;
                OnPropertyChanged(nameof(RegionId));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
    }
}