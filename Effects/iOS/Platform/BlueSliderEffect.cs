
using System;
using Effects.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(BlueSliderEffect), "BlueSliderEffect")]
namespace Effects.iOS
{
	public class BlueSliderEffect : PlatformEffect
	{
		public BlueSliderEffect()
		{
		}

		protected override void OnAttached()
		{
			var slider = (UISlider)Control;
			slider.ThumbTintColor = UIColor.FromRGB(0, 0, 255);
			slider.MinimumTrackTintColor = UIColor.FromRGB(165, 165, 255);
			slider.MaximumTrackTintColor = UIColor.FromRGB(14, 14, 255);
		}

		protected override void OnDetached()
		{

		}
	}
}

