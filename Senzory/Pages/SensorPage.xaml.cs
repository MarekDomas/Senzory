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
    }

    private void Accelerometer_ReadingChanged(object sender, AccelerometerChangedEventArgs e)
    {
        accelLabel.Text = $"Accel: {e.Reading}";
    }

    private void Gyroscope_ReadingChanged(object sender, GyroscopeChangedEventArgs e)
    {
        rotLabel.Text = $"Gyroscope: {e.Reading}";
    }
}