/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

using System.Collections.Generic;

namespace GoogleMapsHelpers
{
    /// <summary>
    /// Represents the options used to create static Google Maps
    /// </summary>
    public class MapOptions
    {
        /// <summary>
        /// Address used to display a single marker on Google Maps
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Addresses used to display multiple markers on Google Maps
        /// </summary>
        public string[] Addresses { get; set; }
        /// <summary>
        /// Addresses used to display multiple markers and descriptions displayed on the marker on Google Maps
        /// </summary>
        public Dictionary<string, string> AddressesWithDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public KeyValuePair<string, string> AddressWithDescription { get; set; } 
        /// <summary>
        /// Int value reprsenting Zoom of Google Maps
        /// </summary>
        public int? Zoom { get; set; }
        /// <summary>
        /// Google Map Types
        /// </summary>
        public MapTypes? MapType { get; set; }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="address"></param>
        public MapOptions(string address)
        {
            Address = address;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="address"></param>
        /// <param name="zoom"></param>
        public MapOptions(string address, int? zoom)
        {
            Address = address;
            Zoom = zoom;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="address"></param>
        /// <param name="zoom"></param>
        /// <param name="mapType"></param>
        public MapOptions(string address, int? zoom, MapTypes? mapType)
        {
            Address = address;
            Zoom = zoom;
            MapType = mapType;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addresses"></param>
        public MapOptions(string[] addresses)
        {
            Addresses = addresses;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addresses"></param>
        /// <param name="zoom"></param>
        /// <param name="mapType"></param>
        public MapOptions(string[] addresses, MapTypes? mapType)
        {
            Addresses = addresses;
            MapType = mapType;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addressWithDesc"></param>
        public MapOptions(KeyValuePair<string, string> addressWithDesc)
        {
            AddressWithDescription = addressWithDesc;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addressWithDesc"></param>
        /// <param name="mapType"></param>
        public MapOptions(KeyValuePair<string, string> addressWithDesc, MapTypes? mapType)
        {
            AddressWithDescription = addressWithDesc;
            MapType = mapType;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addressesWithDesc"></param>
        public MapOptions(Dictionary<string, string> addressesWithDesc)
        {
            AddressesWithDescription = addressesWithDesc;
        }

        /// <summary>
        /// Initializes a new instance of MapOptions class
        /// </summary>
        /// <param name="addressesWithDesc"></param>
        /// <param name="mapType"></param>
        public MapOptions(Dictionary<string, string> addressesWithDesc, MapTypes? mapType)
        {
            AddressesWithDescription = addressesWithDesc;
            MapType = mapType;
        }
    }
}
