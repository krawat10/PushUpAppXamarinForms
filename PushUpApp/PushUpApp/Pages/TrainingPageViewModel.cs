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
        private readonly PushUpPositions PushUpPositions;
        private int _downCount;
        private int _upCount;

        public TrainingPageViewModel()
        {
            _acceleratorReader = new AcceleratorReader(CrossDeviceMotion.Current);
            LoadSavedPositionsAsync();

            var pushUpObserver = new PushUpObserver(PushUpPositions);
            pushUpObserver.OnPositionReached = OnPositionReached;

            _acceleratorReader.AddSubscriber(pushUpObserver);

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

        private void OnPositionReached(object sender, Position e)
        {
            switch (e)
            {
                case Position.Down:
                {
                    _downCount++;
                    break;
                }
                case Position.Up:
                {
                    _upCount++;
                    break;
                }
            }
        }

        public async void OnSettingClick()
        {
            var viewModel = new SettingPageViewModel(_acceleratorReader, PushUpPositions);
            await Navigation.PushAsync(new SettingsPage(viewModel));
        }

        public void LoadSavedPositionsAsync()
        {
            PushUpPositions positions = null; // Get from DB

            if (positions == null)
            {
                var viewModel = new SettingPageViewModel(_acceleratorReader, PushUpPositions);
                Navigation.PushAsync(new SettingsPage(viewModel));
            }
        }
    }
}