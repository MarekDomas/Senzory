using System.Diagnostics;
using System.Text;

namespace Senzory.Pages;

public partial class DeviceInfoPage : ContentPage
{
	public DeviceInfoPage()
	{
        DeviceDisplay.Current.MainDisplayInfoChanged += ReadDeviceInfo;
		InitializeComponent();
        ReadDeviceInfo();
	}

    private void ReadDeviceInfo(object? sender = null, DisplayInfoChangedEventArgs? e = null)
    {
        var text =
            $"Model: {DeviceInfo.Current.Model}\n" +
            $"Manufacturer: {DeviceInfo.Current.Manufacturer}\n" +
            $"Name: {DeviceInfo.Current.Name} \n" +
            $"OS Version: {DeviceInfo.Current.VersionString}\n" +
            $"Idiom: {DeviceInfo.Current.Idiom} \n" +
            $"Platform: {DeviceInfo.Current.Platform} \n" +
            $"Device type: {DeviceInfo.Current.DeviceType}\n"+
            $"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} /" +
            $" Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}\n" +
            $"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}\n" +
            $"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}\n" +
            $"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation} \n" +
            $"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}";

        infoLabel.Text = text;
    }
}