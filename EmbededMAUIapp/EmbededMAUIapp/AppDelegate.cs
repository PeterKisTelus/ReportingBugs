using CoreGraphics;
using Foundation;
using Microsoft.Maui.Embedding;
using Microsoft.Maui.Platform;
using UIKit;

namespace EmbededMAUIapp;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

        var builder = MauiApp.CreateBuilder();
        builder.UseMauiEmbedding<Microsoft.Maui.Controls.Application>();
        builder.Services.Add(new Microsoft.Extensions.DependencyInjection.ServiceDescriptor(typeof(UIKit.UIWindow), Window));
        var mauiApp = builder.Build();
        var MauiContext = new MauiContext(mauiApp.Services);

        var vc = new UIViewController ();

		StackLayout sl = new StackLayout();
		Button button = new Button();
		button.Text = "Test button";
		button.WidthRequest = 300;
		button.HeightRequest = 100;
		button.BackgroundColor = Colors.Wheat;
		button.Margin = new Thickness(500, 300, 300, 0);
        button.Clicked += Button_Clicked;
		sl.Add(button);
		UIView view = sl.ToPlatform(MauiContext);
		//UIViewController controller = sl.ToUIViewController(MauiContext);
        vc.View!.AddSubview(view);

		Window.RootViewController = vc;
        //Window.RootViewController = controller;

        // make the window visible
        Window.MakeKeyAndVisible ();

		return true;
	}

    private void Button_Clicked(object? sender, EventArgs e)
    {
        throw new NotImplementedException();
    }
}

