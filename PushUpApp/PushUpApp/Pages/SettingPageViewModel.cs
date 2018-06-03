using System.Threading.Tasks;
using System.Windows.Input;
using DeviceMotion.Plugin.Abstractions;
using PushUpApp.Services;
using Xamarin.Forms;
using XLabs.Forms.Mvvm;

namespace PushUpApp.Pages
{
    public class SettingPageViewModel : ViewModel
    {
        private readonly IAcceleratorReader _acceleratorReader;
        private readonly PushUpPositions _pushUpPositions;

        public SettingPageViewModel(IAcceleratorReader acceleratorReader, PushUpPositions pushUpPositions)
        {
            _acceleratorReader = acceleratorReader;
            _pushUpPositions = pushUpPositions;
            OnPushUpButtonClickCommand = new Command(OnPushUpButtonClick);
            OnBackButtonClickCommand = new Command(OnBackButtonClick);
        }

        public ICommand OnPushUpButtonClickCommand { get; set; }
        public ICommand OnBackButtonClickCommand { get; set; }

        private async void OnBackButtonClick()
        {
            await Navigation.PopAsync();
        }

        private async void OnPushUpButtonClick()
        {
            await Task.Delay(3000);
            var position = _acceleratorReader.Position;

            _pushUpPositions.Up = new MotionVector
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            };


            await Task.Delay(3000);
            position = _acceleratorReader.Position;
            _pushUpPositions.Down = new MotionVector
            {
                X = position.X,
                Y = position.Y,
                Z = position.Z
            };
        }
    }
}