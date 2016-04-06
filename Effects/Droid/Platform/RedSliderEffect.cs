using System;
using Android.Graphics;
using Android.Widget;
using Effects.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("EffectsSample")]
[assembly: ExportEffect(typeof(RedSliderEffect), "RedSliderEffect")]
namespace Effects.Droid
{
	public class RedSliderEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			var seekBar = (SeekBar)Control;
			seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));
			seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));
		}

		protected override void OnDetached()
		{
			// Use this method if you wish to reset the control to orginal state
		}
	}
}


//mySeekBar.getProgressDrawable().setColorFilter(new PorterDuffColorFilter(srcColor, PorterDuff.Mode.MULTIPLY));

