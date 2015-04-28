using Android.App;
using Android.OS;

namespace FRC_Scouting_V2.Mobile
{
    [Activity(Label = "FRC Scouting V2", MainLauncher = true, Icon = "@drawable/FRC_LOGO")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

