using System;
using Android.Graphics;
using Android.Widget;
using Effects.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(GreenSliderEffect), "GreenSliderEffect")]
namespace Effects.Droid
{
	public class GreenSliderEffect : PlatformEffect
	{
		public GreenSliderEffect()
		{
		}

		protected override void OnAttached()
		{
			var seekBar = (SeekBar)Control;
			seekBar.ProgressDrawable.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Green.ToAndroid(), PorterDuff.Mode.SrcIn));
			seekBar.Thumb.SetColorFilter(new PorterDuffColorFilter(Xamarin.Forms.Color.Green.ToAndroid(), PorterDuff.Mode.SrcIn));
		}

		protected override void OnDetached()
		{

		}
	}
}