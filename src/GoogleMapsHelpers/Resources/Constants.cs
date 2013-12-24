/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * ============================================================= */

namespace GoogleMapsHelpers.Resources
{
    /// <summary>
    /// Collection of string constants used in GoogleMapsHelpers
    /// </summary>
    internal static class Constants
    {
        /* HTML Tag Name Constants
         * ======================= */

        internal static string Div = "div";
        internal static string Script = "script";
        internal static string Input = "input";

        /* HTML Tag Attribute Name Constants
         * ================================= */

        internal static string Type = "type";
        internal static string Src = "src";
        internal static string Id = "id";
        internal static string Style = "style";
        internal static string Placeholder = "placeholder";
        internal static string SearchBoxId = "pac-input";

        /* HTML Tag Attribute Value Constants
         * ================================== */

        internal static string TextJavaScript = "text/javascript";
        internal static string Text = "text";
        internal static string MapId = "map-canvas";
        internal static string SearchBoxStyle = "background-color: white; margin-top: 10px; padding: 5px; width: 300px; font-size: medium; font-family: segoe ui; text-overflow: ellipsis";
        internal static string SearchPlaceHolderText = "Search Box";

        /* Google Maps API Constants
         * ========================= */

        internal static string ApiAddress = "https://maps.googleapis.com/maps/api/js?";
        internal static string SensorAttribute = "sensor=";
        internal static string Amp = "&";
        internal static string ApiAttribute = "key=";
        internal static string LibrariesKey = "libraries=";
        internal static string PlacesAPI = "places";
    }
}
