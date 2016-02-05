using Android.OS;
using Android.App;
using Mapbox.Views;
using Mapbox.Annotations;
using Mapbox.Geometry;


[assembly: UsesPermission(Android.Manifest.Permission.AccessNetworkState)]
[assembly: UsesPermission(Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]

[assembly: UsesPermission(Android.Manifest.Permission.AccessCoarseLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessFineLocation)]
[assembly: UsesPermission(Android.Manifest.Permission.AccessWifiState)]


namespace MomaAndroid
{
    [Activity(Label = "MomaAndroid")]
    public class MapViewer : Activity
    {
        MapView mapView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MapView);

            mapView = FindViewById<MapView>(Resource.Id.mapview);
            mapView.StyleUrl = Mapbox.Constants.Style.Emerald;
            mapView.CenterCoordinate = new LatLng(41.885, -87.679);
            mapView.ZoomLevel = 11;

            mapView.OnCreate(bundle);

            mapView.AddMarker(new MarkerOptions()
                .SetTitle("Test Marker")
                .SetPosition(new LatLng(41.885, -87.679)));
        }

        protected override void OnStart()
        {
            base.OnStart();
            mapView.OnStart();
        }

        protected override void OnStop()
        {
            base.OnStop();
            mapView.OnStop();
        }

        protected override void OnPause()
        {
            base.OnPause();
            mapView.OnPause();
        }

        protected override void OnResume()
        {
            base.OnResume();
            mapView.OnResume();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            mapView.OnDestroy();
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            mapView.OnSaveInstanceState(outState);
        }
    }
}
