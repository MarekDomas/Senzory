namespace Senzory.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        
        Battery.BatteryInfoChanged += checkBattery;
    }

    private void checkBattery(object sender, BatteryInfoChangedEventArgs e)
    {
        double stavBaterie = Battery.ChargeLevel;
        //Nabití baterie je uvedeno v rozsahu od 0 do 1 proto se násobí 100
        lbl.Text = $"Stav baterie: {stavBaterie * 100}%";

        box.WidthRequest = stavBaterie * 200;

        switch (stavBaterie * 100)
        {
            case > 50:
                box.BackgroundColor = Colors.Green;
                break;
            case < 20:
                box.BackgroundColor = Colors.Red;
                break;
            default:
                box.BackgroundColor = Colors.Yellow;
                break;
        }
    }
}