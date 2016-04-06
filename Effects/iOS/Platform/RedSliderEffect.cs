
using System;
using CoreImage;
using Effects.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("EffectsSample")]
[assembly: ExportEffect(typeof(RedSliderEffect), "RedSliderEffect")]
namespace Effects.iOS
{
	public class RedSliderEffect : PlatformEffect
	{
		
		protected override void OnAttached()
		{
			var slider = (UISlider)Control;
			slider.ThumbTintColor = UIColor.FromRGB(255, 0, 0);
			slider.MinimumTrackTintColor = UIColor.FromRGB(255, 120, 120);
			slider.MaximumTrackTintColor = UIColor.FromRGB(255, 14, 14);
		}

		protected override void OnDetached()
		{
			// Use this method if you wish to reset the control to orginal state
		}
	}
}

