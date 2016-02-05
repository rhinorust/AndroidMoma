using System;

using UIKit;
using Mapbox;
using System.Linq;
using CoreLocation;
using Foundation;

namespace MapBoxSampleiOS
{
    public partial class ViewController : UIViewController, IMapViewDelegate
    {
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        MapView mapView;

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();

            // Create a MapView and set the coordinates/zoom
            mapView = new MapView (View.Bounds);
            mapView.SetCenterCoordinate (new CLLocationCoordinate2D (45.520486, -122.673541), false);
            mapView.SetZoomLevel (11, false);

            // Add new annotation
//            mapView.AddAnnotation (new PointAnnotation {
//                Coordinate = new CLLocationCoordinate2D (40.7326808, -73.9843407),
//                Title = "Sample Marker",
//                Subtitle = "This is the subtitle"
//            });
                
            var coordinates = new [] {
                new CLLocationCoordinate2D (45.522585, -122.685699),
                new CLLocationCoordinate2D (45.534611, -122.708873),
                new CLLocationCoordinate2D (45.530883, -122.678833),
                new CLLocationCoordinate2D (45.547115, -122.667503),
                new CLLocationCoordinate2D (45.530643, -122.660121),
                new CLLocationCoordinate2D (45.533529, -122.636260),
                new CLLocationCoordinate2D (45.521743, -122.659091),
                new CLLocationCoordinate2D (45.510677, -122.648792),
                new CLLocationCoordinate2D (45.515008, -122.664070),
                new CLLocationCoordinate2D (45.502496, -122.669048),
                new CLLocationCoordinate2D (45.515369, -122.678489),
                new CLLocationCoordinate2D (45.506346, -122.702007),
                new CLLocationCoordinate2D (45.522585, -122.685699),
            };
            //nuint numberOfCoordinates = (nuint) (coordinates.Length /  sizeof(CLLocationCoordinate2D));

            // Create our shape with the formatted coordinates array
            var shape = Polygon.WithCoordinates (coordinates, (nuint)coordinates.Length);

            mapView.AddAnnotation (shape);

            // Set ourselves as the delegate
            mapView.Delegate = this;

            View.AddSubview (mapView);
        }

        // Delegate for an annotation to be selected
        [Export ("mapView:didSelectAnnotation:")]
        public void DidSelectAnnotation (MapView mapView, Annotation annotation)
        {
            // Just show the user which one was pressed
            new UIAlertView ("Annotation Tapped", "You tapped on: " + annotation.Title, null, "OK")
                .Show ();
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();

            // Cleanup anything possible
            mapView.EmptyMemoryCache ();
        }
    }
}

