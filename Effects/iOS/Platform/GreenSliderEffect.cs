using System;
using Effects.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(GreenSliderEffect), "GreenSliderEffect")]
namespace Effects.iOS
{
	public class GreenSliderEffect : PlatformEffect
	{
		public GreenSliderEffect()
		{
		}

		protected override void OnAttached()
		{
			var slider = (UISlider)Control;
			slider.ThumbTintColor = UIColor.FromRGB(0, 127, 70);
			slider.MinimumTrackTintColor = UIColor.FromRGB(66, 255, 63);
			slider.MaximumTrackTintColor = UIColor.FromRGB(197, 255, 132);
		}

		protected override void OnDetached()
		{
			
		}
	}
}

