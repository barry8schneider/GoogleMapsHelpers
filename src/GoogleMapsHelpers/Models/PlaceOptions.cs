/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

namespace GoogleMapsHelpers
{
    /// <summary>
    /// Represents options used to create Google Places Map
    /// </summary>
    public class PlaceOptions
    {
        public string[] Addresses { get; set; }
        public MapTypes? MapType { get; set; }

        /// <summary>
        /// Initializes a new PlaceOptions class
        /// </summary>
        /// <param name="addresses"></param>
        public PlaceOptions(string[] addresses)
        {
            Addresses = addresses;
        }

        /// <summary>
        /// Initializes a new PlaceOptions class
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="mapTypes"></param>
        public PlaceOptions(string[] addresses, MapTypes? mapTypes)
        {
            Addresses = addresses;
            MapType = mapTypes;
        }
    }
}
