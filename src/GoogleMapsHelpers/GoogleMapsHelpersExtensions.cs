/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

using System.Text;
using GoogleMapsHelpers.Builders;
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
    }
}