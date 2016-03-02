using System;

using Android.App;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ImageCircle.Forms.Plugin.Droid;

namespace DataTemplateSelector.Droid
{
    [Activity(Label = "Monkey Chat", Icon = "@drawable/icon", Theme= "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

