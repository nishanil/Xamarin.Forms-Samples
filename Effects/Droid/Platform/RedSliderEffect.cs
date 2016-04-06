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
		public RedSliderEffect()
		{
		}

		protected override void OnAttached()
		{
			var seekBar = (SeekBar)Control;
			seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));
			seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Red.ToAndroid(), PorterDuff.Mode.SrcIn));
		}

		protected override void OnDetached()
		{
			
		}
	}
}


//mySeekBar.getProgressDrawable().setColorFilter(new PorterDuffColorFilter(srcColor, PorterDuff.Mode.MULTIPLY));

