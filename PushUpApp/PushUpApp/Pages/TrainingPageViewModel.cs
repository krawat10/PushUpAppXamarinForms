using System.Windows.Input;
using DeviceMotion.Plugin;
using PushUpApp.Services;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace PushUpApp.Pages
{
    internal class TrainingPageViewModel : ViewModel
    {
        private readonly AcceleratorReader _acceleratorReader;
        private int _upCount;
        private int _downCount;

        public TrainingPageViewModel()
        {
            _acceleratorReader = new AcceleratorReader(CrossDeviceMotion.Current);
            OnSettingClickCommand = new Command(OnSettingClick);
        }

        public int UpCount
        {
            get => _upCount;
            set
            {
                _upCount = value;
                NotifyPropertyChanged(nameof(UpCount));
            }
        }

        public int DownCount
        {
            get => _downCount;
            set
            {
                _downCount = value;
                NotifyPropertyChanged(nameof(DownCount));
            }
        }

        public ICommand OnSettingClickCommand { get; set; }

        public async void OnSettingClick()
        {
            //Navigation.PushAsync(new SettingsPage())
        }

        private void OnPositionReached(Position e)
        {
            switch (e)
            {
                case Services.Position.Up:
                {
                    UpCount++;
                    break;
                }
                case Services.Position.Down:
                {
                    DownCount++;
                    break;
                }
            }
        }
    }
}