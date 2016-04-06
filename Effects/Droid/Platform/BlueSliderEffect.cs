using System;
using Android.Graphics;
using Android.Widget;
using Effects.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(BlueSliderEffect), "BlueSliderEffect")]
namespace Effects.Droid
{
	public class BlueSliderEffect : PlatformEffect
	{
		public BlueSliderEffect()
		{
		}

		protected override void OnAttached()
		{
			var seekBar = (SeekBar)Control;
			seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));
			seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Blue.ToAndroid(), PorterDuff.Mode.SrcIn));
		}

		protected override void OnDetached()
		{

		}
	}
}