using System.Diagnostics;

namespace Senzory.Pages;

public partial class SensorPage : ContentPage
{ 
	public SensorPage()
	{
		InitializeComponent();
        ToggleAccelerometer();
        ToggleGyroscope();
	}

    //Funkce z https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/sensors?view=net-maui-8.0&tabs=android
    public void ToggleAccelerometer()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Accelerometer.Default.ReadingChanged += Accelerometer_ReadingChanged;
                Accelerometer.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ReadingChanged -= Accelerometer_ReadingChanged;
            }
        }
        else
        {
            DisplayAlert("Error", "Akcelerometr není podporován", "Ok");
        }
    }
    private void ToggleGyroscope()
    {
        if (Gyroscope.Default.IsSupported)
        {
            if (!Gyroscope.Default.IsMonitoring)
            {
                // Turn on gyroscope
                Gyroscope.Default.ReadingChanged += Gyroscope_ReadingChanged;
                Gyroscope.Default.Start(SensorSpeed.UI);
            }
            else
            {
                // Turn off gyroscope
                Gyroscope.Default.Stop();
                Gyroscope.Default.ReadingChanged -= Gyroscope_ReadingChanged;
            }
        }
        else
        {
            DisplayAlert("Error", "Gyroskop není podporován", "Ok");
        }
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        accelLabel.Text = $"Accel: {e.Reading}";
    }

    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        rotLabel.Text = $"Gyroscope: {e.Reading}";
    }

    private void HapticBtn_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var secondsToVibrate = Random.Shared.Next(1, 7);
            var vibrationLength = TimeSpan.FromSeconds(secondsToVibrate);

            Vibration.Default.Vibrate(vibrationLength);
        }
        catch
        {
            DisplayAlert("Error", "Haptika není podporována", "Ok");
        }
    }

    private void LongHapticBtn_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            Vibration.Default.Cancel();
        }
        catch
        {
            DisplayAlert("Error", "Vibrace nejsou podporovány", "Ok");
        }
    }

    private async void FlashLightBtn_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            if (FlashLightSwitch.IsToggled)
                await Flashlight.Default.TurnOnAsync();
            else
                await Flashlight.Default.TurnOffAsync();
        }
        catch (FeatureNotSupportedException ex)
        {
            FlashLightLabel.Text = "Flashlight not supported on this device";
        }

    }
}