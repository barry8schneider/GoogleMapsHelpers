using System.Collections.Generic;
using System.Text;

namespace GoogleMapsHelpers.Builders
{
    /// <summary>
    /// Creates JavaScript code that goes in between script tags to display Google Maps
    /// </summary>
    public class MapOptionsScriptBodyFactory
    {
        private static MapOptions _mapOptions;
        private readonly static StringBuilder MapOptionsScritBodyBuilder;

        /// <summary>
        /// Initializes the StringBuilder object
        /// </summary>
        static MapOptionsScriptBodyFactory()
        {
            MapOptionsScritBodyBuilder = new StringBuilder();
        }

        /// <summary>
        /// Creates and returns the JavaScript code
        /// </summary>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static string GetMapOptionsScriptBody(MapOptions mapOptions)
        {
            _mapOptions = mapOptions;
            MapOptionsScritBodyBuilder.Clear();
           
            MapOptionsScritBodyBuilder.Append(
                "var m;" +
                "var g;" +
                "var b;" +
                "function i(){" +
                    "g=new google.maps.Geocoder();");

            SetMapOptions();

            if (_mapOptions.Address != null)
            {
                AddMarker(_mapOptions.Address);
            }
            else if (_mapOptions.Addresses != null && _mapOptions.Addresses.Length > 0)
            {
                AddMarkers(_mapOptions.Addresses);
            }

            MapOptionsScritBodyBuilder.Append(
                     "m=new google.maps.Map(document.getElementById('map-canvas'),o);").Append(
                     "b=new google.maps.LatLngBounds();");

            MapOptionsScritBodyBuilder.Append(
             "}").Append(
             "google.maps.event.addDomListener(window, 'load', i);");

            return MapOptionsScritBodyBuilder.ToString();
        }

        /// <summary>
        /// Set Google Map Options
        /// </summary>
        private static void SetMapOptions()
        {
            MapOptionsScritBodyBuilder.Append(
                     "var o={");

            if (_mapOptions.Zoom.HasValue)
                MapOptionsScritBodyBuilder.Append(
                        "zoom:").Append(_mapOptions.Zoom.Value).Append(",");
            else
                MapOptionsScritBodyBuilder.Append(
                        "zoom:8,");

            if (_mapOptions.MapType == null)
                MapOptionsScritBodyBuilder.Append(
                    "mapTypeId:google.maps.MapTypeId.ROADMAP");
            else
                MapOptionsScritBodyBuilder.Append(
                    "mapTypeId:google.maps.MapTypeId.").Append(_mapOptions.MapType.ToString().ToUpper());

            MapOptionsScritBodyBuilder.Append(
                "};");
        }

        /// <summary>
        /// Adds a single marker for Google Map
        /// </summary>
        /// <param name="address"></param>
        /// <param name="useFitBound"></param>
        private static void AddMarker(string address, bool useFitBound = false)
        {
            MapOptionsScritBodyBuilder.Append(
                    "g.geocode({'address':'").Append(address).Append("'},function(r,s){").Append(
                        "if(s==google.maps.GeocoderStatus.OK){").Append(
                            "m.setCenter(r[0].geometry.location);").Append(
                            "var k=new google.maps.Marker({").Append(
                                "map:m,").Append(
                                "position:r[0].geometry.location,").Append(
                                "title:'").Append(address).Append("'").Append(
                            "});");

            if (useFitBound)
                MapOptionsScritBodyBuilder.Append(
                            "b.extend(r[0].geometry.location);").Append(
                            "m.fitBounds(b);");

            MapOptionsScritBodyBuilder.Append(
                        "}").Append(
                    "});");
        }

        /// <summary>
        /// Adds markers on the Google Map
        /// </summary>
        /// <param name="addresses">Array of addresses the markers will be put</param>
        private static void AddMarkers(IEnumerable<string> addresses)
        {
            foreach (var t in addresses)
                AddMarker(t, true);
        }
    }
}
