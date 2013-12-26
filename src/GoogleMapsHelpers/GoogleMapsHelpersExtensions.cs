/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

using GoogleMapsHelpers.Builders;
using GoogleMapsHelpers.Factories;
using GoogleMapsHelpers.Models;
using GoogleMapsHelpers.Resources;
using System.Web;
using System.Web.Mvc;

namespace GoogleMapsHelpers
{
    /// <summary>
    /// HTML Helper extensions that can be used from ASP.NET MVC views to display Google Maps
    /// </summary>
    public static class GoogleMapsHelpersExtensions
    {
        /// <summary>
        /// Displays the placeholder for the Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="htmlAttributes">Html attributes for the Google Maps place holder</param>
        /// <returns>Completed map container div tag</returns>
        public static IHtmlString GoogleMaps(
            this HtmlHelper helper,
            object htmlAttributes)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder(Constants.Div);
            builder.MergeAttributes(attributes);
            builder.MergeAttribute(Constants.Id, Constants.MapId);

            return new HtmlString(builder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Displays the placeholder for the Google Maps with Search Box
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="htmlAttributes"></param>
        /// <returns></returns>
        public static IHtmlString GoogleMapsWithSearch(
            this HtmlHelper helper,
            object htmlAttributes)
        {
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder(Constants.Div);
            builder.MergeAttributes(attributes);
            builder.MergeAttribute(Constants.Id, Constants.MapId);

            var searchBoxBuilder = new TagBuilder(Constants.Input);
            searchBoxBuilder.MergeAttribute(Constants.Id, Constants.SearchBoxId);
            searchBoxBuilder.MergeAttribute(Constants.Type, Constants.Text);
            searchBoxBuilder.MergeAttribute(Constants.Placeholder, Constants.SearchPlaceHolderText);
            searchBoxBuilder.MergeAttribute(Constants.Style, Constants.SearchBoxStyle);

            var directionBoxBuilder = new TagBuilder(Constants.Div);
            directionBoxBuilder.MergeAttribute(Constants.Id, "direction-panel");

            return new HtmlString(
                searchBoxBuilder.ToString(TagRenderMode.SelfClosing) +
                builder.ToString(TagRenderMode.Normal) +
                directionBoxBuilder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Renders ScriptTags needed to display Static Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="apiKey"></param>
        /// <param name="sensor"></param>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static IHtmlString StaticMapsApi(
            this HtmlHelper helper,
            string apiKey,
            bool sensor,
            MapOptions mapOptions)
        {
            var apiScriptTagBuilder = new ScriptTagBuilder();

            apiScriptTagBuilder.SetScriptSource(
                SourceAddressFactory.GetSourceAddress(apiKey, sensor, Libraries.None));

            var mapOptionsScriptTagBuilder = new ScriptTagBuilder();

            mapOptionsScriptTagBuilder.AddScriptBody(
                MapOptionsScriptBodyFactory.GetMapOptionsScriptBody(mapOptions));

            return new HtmlString(apiScriptTagBuilder.GetResult() + mapOptionsScriptTagBuilder.GetResult());
        }

        /// <summary>
        /// Renders ScriptTags needed to display Static Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="sensor"></param>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static IHtmlString StaticMapsApi(
            this HtmlHelper helper,
            bool sensor,
            MapOptions mapOptions)
        {
            return StaticMapsApi(helper, null, sensor, mapOptions);
        }

        /// <summary>
        /// Renders ScriptTags needed to display Static Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="apiKey"></param>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static IHtmlString StaticMapsApi(
            this HtmlHelper helper,
            string apiKey,
            MapOptions mapOptions)
        {
            return StaticMapsApi(helper, apiKey, false, mapOptions);
        }

        /// <summary>
        /// Renders ScriptTags needed to display Static Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static IHtmlString StaticMapsApi(
            this HtmlHelper helper,
            MapOptions mapOptions)
        {
            return StaticMapsApi(helper, null, false, mapOptions);
        }

        /// <summary>
        /// Generates scripts for static Google Maps with API KEY.
        /// If API exists in the configuration file, it will be overriden
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="apiKey"></param>
        /// <param name="sensor"></param>
        /// <param name="placeOptions"></param>
        /// <returns></returns>
        public static IHtmlString PlacesApi(this HtmlHelper helper, string apiKey, bool sensor,
            PlaceOptions placeOptions)
        {
            var apiScriptTagBuilder = new ScriptTagBuilder();

            apiScriptTagBuilder.SetScriptSource(
                SourceAddressFactory.GetSourceAddress(apiKey, sensor, Libraries.Places));

            var placeOptionsScriptTagBuilder = new ScriptTagBuilder();

            placeOptionsScriptTagBuilder.AddScriptBody(
                PlaceOptionsScriptBodyFactory.GetPlaceOptionsScriptBody(placeOptions));

            return new HtmlString(
                apiScriptTagBuilder.GetResult() +
                placeOptionsScriptTagBuilder.GetResult());
        }

        /// <summary>
        /// Creates Places API scripts
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="sensor"></param>
        /// <param name="placeOptions"></param>
        /// <returns></returns>
        public static IHtmlString PlacesApi(this HtmlHelper helper, bool sensor,
            PlaceOptions placeOptions)
        {
            return PlacesApi(helper, null, sensor, placeOptions);
        }

        /// <summary>
        /// Creates Places API Scripts
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="apiKey"></param>
        /// <param name="placeOptions"></param>
        /// <returns></returns>
        public static IHtmlString PlacesApi(this HtmlHelper helper, string apiKey,
            PlaceOptions placeOptions)
        {
            return PlacesApi(helper, apiKey, false, placeOptions);
        }

        /// <summary>
        /// Creates Places API Scripts
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="placeOptions"></param>
        /// <returns></returns>
        public static IHtmlString PlacesApi(this HtmlHelper helper, PlaceOptions placeOptions)
        {
            return PlacesApi(helper, null, false, placeOptions);
        }
    }
}