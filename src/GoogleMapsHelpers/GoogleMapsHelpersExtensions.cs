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
using System.Collections.Generic;
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
            IDictionary<string, object> attributes =
                HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var builder = new TagBuilder(Constants.Div);
            builder.MergeAttributes(attributes);
            builder.MergeAttribute(Constants.Id, Constants.MapId);

            return new HtmlString(builder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// Renders ScriptTags needed to display Static Google Maps
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="apiKey"></param>
        /// <param name="sensor"></param>
        /// <param name="libraries"></param>
        /// <param name="mapOptions"></param>
        /// <returns></returns>
        public static IHtmlString StaticMapsApi(
            this HtmlHelper helper, string apiKey, bool sensor, Libraries libraries, MapOptions mapOptions)
        {
            var apiScriptTagBuilder = new ScriptTagBuilder();

            apiScriptTagBuilder.SetScriptSource(
                SourceAddressFactory.GetSourceAddress(apiKey, sensor, libraries));

            var mapOptionsScriptTagBuilder = new ScriptTagBuilder();

            mapOptionsScriptTagBuilder.AddScriptBody(
                MapOptionsScriptBodyFactory.GetMapOptionsScriptBody(mapOptions));

            return new HtmlString(apiScriptTagBuilder.GetResult() + mapOptionsScriptTagBuilder.GetResult());
        }
    }
}