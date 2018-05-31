using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjCRuntime;
using PushUpApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PushUpApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrainingPageView : ContentPage
	{
	    public TrainingPageView ()
		{
		    InitializeComponent();
		    BindingContext = new TrainingPageViewModel();
		}
	}
}