using System.Text;

namespace Senzory.Pages;

public partial class DeviceInfoPage : ContentPage
{
	public DeviceInfoPage()
	{
        DeviceDisplay.MainDisplayInfoChanged += ReadDeviceInfo;
		InitializeComponent();
        ReadDeviceInfo();
	}

    private void ReadDeviceInfo(object? sender = null, DisplayInfoChangedEventArgs? e = null)
    {
        // Θαst funkce z: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/information?view=net-maui-8.0&tabs=android
        StringBuilder sb = new();

        sb.AppendLine($"Model: {DeviceInfo.Current.Model}");
        sb.AppendLine($"Manufacturer: {DeviceInfo.Current.Manufacturer}");
        sb.AppendLine($"Name: {DeviceInfo.Current.Name}");
        sb.AppendLine($"OS Version: {DeviceInfo.Current.VersionString}");
        sb.AppendLine($"Idiom: {DeviceInfo.Current.Idiom}");
        sb.AppendLine($"Platform: {DeviceInfo.Current.Platform}");

        //Θαst funkce z: https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/display?view=net-maui-8.0&tabs=android
        sb.AppendLine($"Pixel width: {DeviceDisplay.Current.MainDisplayInfo.Width} / Pixel Height: {DeviceDisplay.Current.MainDisplayInfo.Height}");
        sb.AppendLine($"Density: {DeviceDisplay.Current.MainDisplayInfo.Density}");
        sb.AppendLine($"Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}");
        sb.AppendLine($"Rotation: {DeviceDisplay.Current.MainDisplayInfo.Rotation}");
        sb.AppendLine($"Refresh Rate: {DeviceDisplay.Current.MainDisplayInfo.RefreshRate}");

        bool isVirtual;

        switch( DeviceInfo.Current.DeviceType )
        {
            case DeviceType.Physical:
                isVirtual = false;
                break;
            case DeviceType.Virtual:
                isVirtual = true;
                break;
            default:
                isVirtual = false;
                break;
        };

        sb.AppendLine($"Virtual device: {isVirtual}");

        infoLabel.Text = sb.ToString();
    }
}