using System.Collections.Generic;
using System.Text;

namespace GoogleMapsHelpers.Factories
{
    public static class PlaceOptionsScriptBodyFactory
    {
        private static PlaceOptions _placeOptions;
        private readonly static StringBuilder MapOptionsScritBodyBuilder;

        /// <summary>
        /// Initializes the StringBuilder object
        /// </summary>
        static PlaceOptionsScriptBodyFactory()
        {
            MapOptionsScritBodyBuilder = new StringBuilder();
        }

        /// <summary>
        /// Creates and returns the JavaScript code
        /// </summary>
        /// <param name="placeOptions"></param>
        /// <returns></returns>
        public static string GetPlaceOptionsScriptBody(PlaceOptions placeOptions)
        {
            _placeOptions = placeOptions;
            MapOptionsScritBodyBuilder.Clear();

            MapOptionsScritBodyBuilder.Append(
                "var m;" +
                "var g;" +
                "var b;" +
                "var ps=[];" +
                "var ds=new google.maps.DirectionsService();" +
                "function i(){" +
                    "g=new google.maps.Geocoder();" +
                    "var dr=new google.maps.DirectionsRenderer();");

            SetMapOptions();

            AddMarkers(_placeOptions.Addresses);

            MapOptionsScritBodyBuilder.Append(
                    "m=new google.maps.Map(document.getElementById('map-canvas'),o);").Append(
                    "dr.setMap(m);").Append(
                    "dr.setPanel(document.getElementById('direction-panel'));").Append(
                    "b=new google.maps.LatLngBounds();").Append(
                    "var input=/** @type {HTMLInputElement} */(document.getElementById('pac-input'));").Append(
                    "m.controls[google.maps.ControlPosition.TOP_LEFT].push(input);").Append(
                    "var sb=new google.maps.places.SearchBox(/** @type {HTMLInputElement} */(input));").Append(
                    "var k;").Append(
                    "google.maps.event.addListener(sb,'places_changed',function(){").Append(
                        "var p=sb.getPlaces();if(p.length == 1){").Append(
                            "if(k!=undefined){k.setMap(null);}").Append(
                            "var de;var di=0;for(var z in ps){").Append(
                                "var cdi=google.maps.geometry.spherical.computeDistanceBetween(p[0].geometry.location,ps[z]);").Append(
                                "if(di==0||di>cdi){di=cdi;de=ps[z];}").Append(
                            "}").Append(
                            "var re={origin:p[0].geometry.location,destination:de,travelMode:google.maps.TravelMode.DRIVING};").Append(
                            "ds.route(re, function(r,s){if(s==google.maps.DirectionsStatus.OK){dr.setDirections(r);}else{alert('Direction is not available for your address.');}});").Append(
                        "}else{").Append(
                            "alert('We found more than one location for the address.')").Append(
                        "}").Append(
                     "});");

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

            if (_placeOptions.MapType == null)
                MapOptionsScritBodyBuilder.Append(
                    "mapTypeId:google.maps.MapTypeId.ROADMAP");
            else
                MapOptionsScritBodyBuilder.Append(
                    "mapTypeId:google.maps.MapTypeId.").Append(_placeOptions.MapType.ToString().ToUpper());

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
                            "});").Append(
                            "ps.push(r[0].geometry.location);").Append(
                            "b.extend(r[0].geometry.location);").Append(
                            "m.fitBounds(b);").Append(
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