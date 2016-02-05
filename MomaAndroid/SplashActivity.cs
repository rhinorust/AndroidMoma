using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace MomaAndroid
{
    [Activity(Theme = "@style/Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            Log.Debug(TAG, "SplashActivity.OnCreate");
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() =>
            {
                Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                Thread.Sleep(4000); // Simulate a bit of startup work.
                //Task.Delay(5000);
                Log.Debug(TAG, "Working in the background - important stuff.");
            });
            //startupWork.Wait(5000);
            startupWork.ContinueWith(t =>
            {
                Log.Debug(TAG, "Work is finished - start MapViewer");
                StartActivity(new Intent(Application.Context, typeof(MapViewer)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }
    }
}