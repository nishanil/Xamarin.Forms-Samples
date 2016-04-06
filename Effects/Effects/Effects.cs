using System;

using Xamarin.Forms;

namespace Effects
{
	public class App : Application
	{
		public App()
		{

			var greenSlider = new Slider
			{
				Minimum = 0,
				Maximum = 100
			};

			var redSlider = new Slider
			{
				Minimum = 0,
				Maximum = 100
			};

			var blueSlider = new Slider
			{
				Minimum = 0,
				Maximum = 100
			};

			// The root page of your application
			var content = new ContentPage
			{
				Title = "Effects",
				Content = new StackLayout
				{
					VerticalOptions = LayoutOptions.Start,
					Padding = 50,
					Children = {
						redSlider,
						greenSlider,
						blueSlider
					}
				}
			};


			greenSlider.Effects.Add(Effect.Resolve("EffectsSample.GreenSliderEffect"));
			redSlider.Effects.Add(Effect.Resolve("EffectsSample.RedSliderEffect"));
			blueSlider.Effects.Add(Effect.Resolve("EffectsSample.BlueSliderEffect"));


			MainPage = new NavigationPage(content);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

