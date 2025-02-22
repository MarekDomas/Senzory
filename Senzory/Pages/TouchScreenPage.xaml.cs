using System.Diagnostics;

namespace Senzory.Pages;

public partial class TouchScreenPage : ContentPage
{
    private static int sideLength = 50;
    private static double panX = 0;
    private static double panY = 0;

    public TouchScreenPage()
	{
		InitializeComponent();

        PanGestureRecognizer panGestureRecognizer = new();
        panGestureRecognizer.PanUpdated += OnPanUpdated;

        MainLayout.GestureRecognizers.Add(panGestureRecognizer);
    }


    private void OnPanUpdated(object? sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Started:
                // Uložíme aktuální polohu ètverce
                panX = AbsoluteLayout.GetLayoutBounds(boxView).X;
                panY = AbsoluteLayout.GetLayoutBounds(boxView).Y;
                break;

            case GestureStatus.Running:
                // Pøièítáme posun k pùvodní poloze
                var newX = panX + e.TotalX;
                var newY = panY + e.TotalY;
                AbsoluteLayout.SetLayoutBounds(boxView, new(newX, newY, sideLength, sideLength));
                break;
        }
    }
}