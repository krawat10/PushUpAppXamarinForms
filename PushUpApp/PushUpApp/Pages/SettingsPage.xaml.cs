using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PushUpApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushUpApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsPage : ContentPage
	{
	    private readonly IAcceleratorObtainer _acceleratorObtainer;
	    private readonly PushUpPositions _pushUpPositions;
	    public ThreeDimPosition UpPosition { get; set; }
	    public ThreeDimPosition DownPosition { get; set; }

        public SettingsPage(IAcceleratorObtainer acceleratorObtainer, PushUpPositions pushUpPositions)
		{
		    InitializeComponent ();
            _backButton.Clicked += OnBackButtonClick;
            _upPositionButton.Clicked += OnUpPositionButtonClick;
            _downPositionButton.Clicked += OnDownPositionButtonClick;
		    _acceleratorObtainer = acceleratorObtainer;
		    _pushUpPositions = pushUpPositions;
        }

        private async void OnBackButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrainingPageView());
        }

        private async void OnUpPositionButtonClick(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            var position = _acceleratorObtainer.Position;

            _pushUpPositions.Up = new ThreeDimPosition(position.X, position.Y, position.Z);
        }

        private async void OnDownPositionButtonClick(object sender, EventArgs e)
        {
            await Task.Delay(3000);
            var position = _acceleratorObtainer.Position;
            _pushUpPositions.Down = new ThreeDimPosition(position.X, position.Y, position.Z);
        }
    }
}