using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
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
	public partial class StartPage : ContentPage, IAcceleratorSubscriber
	{
	    private readonly IAcceleratorReader _acceleratorReader;
	    private readonly PushUpPositions _pushUpPositions;
	    private IPushUpObservable _pushUpObservable;
	    public int UpCounter { get; set; }
	    public int DownCounter { get; set; }

	    public StartPage ()
		{
		    InitializeComponent();
		    _pushUpPositions = new PushUpPositions();
		    _pushUpObservable = new PushUpObservable(_pushUpPositions);

            _acceleratorReader = new AcceleratorReader(CrossDeviceMotion.Current);
		    _acceleratorReader.AddSubscriber(this);
            _acceleratorReader.AddSubscriber(_pushUpObservable);

		    _settingsButton.Clicked += OnSettingsButtonClick;
            _pushUpObservable.OnUpPositionReached += OnUpPositionReached;
		}

	    private void OnUpPositionReached(object sender, Position e)
	    {
	        switch (e)
	        {
                case Position.Up:
                    {
                        UpCounter++;
                        _upPositionLabel.Text = UpCounter.ToString();
                        break;
                    }
                case Position.Down:
                    DownCounter++; _downPositionLabel.Text = DownCounter.ToString(); break;
	        }
	    }

	    private async void OnSettingsButtonClick(object sender, EventArgs e)
	    {
	        await Navigation.PushAsync(new SettingsPage(_acceleratorReader, _pushUpPositions));
	    }

	    public void Update(ThreeDimPosition position)
	    {
	        if (position != null)
	        {
                _xPosition.Text = position.X.ToString("F");
                _yPosition.Text = position.Y.ToString("F");
                _zPosition.Text = position.Z.ToString("F");
	        }
	    }
	}
}