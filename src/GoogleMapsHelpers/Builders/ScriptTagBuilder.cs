/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

using System.Web;
using System.Web.Mvc;
using GoogleMapsHelpers.Resources;

namespace GoogleMapsHelpers.Builders
{
    public class ScriptTagBuilder
    {
        /// <summary>
        /// Tag builder used to create Script Tag
        /// </summary>
        protected TagBuilder TagBuilder;

        /// <summary>
        /// Creates a new instance of ScriptTagBuilder class.
        /// Creates opening script tag.
        /// </summary>
        public ScriptTagBuilder()
        {
            TagBuilder = new TagBuilder(Constants.Script);
            TagBuilder.MergeAttribute(Constants.Type, Constants.TextJavaScript);
        }

        /// <summary>
        /// Sets the source(src=) for the script tag 
        /// </summary>
        /// <param name="scriptSource">Script Source Address</param>
        public virtual void SetScriptSource(string scriptSource)
        {
            TagBuilder.MergeAttribute(Constants.Src, scriptSource);    
        }

        /// <summary>
        /// Adds JavaScript code inside the script tag
        /// </summary>
        /// <param name="scriptBody">JavaScript code to go inside the script tag</param>
        public virtual void AddScriptBody(string scriptBody)
        {
            TagBuilder.SetInnerText(scriptBody);
        }

        /// <summary>
        /// Closes the script tag with normal closing tag
        /// </summary>
        /// <returns>The script tag created</returns>
        public virtual string GetResult()
        {
            return HttpUtility.HtmlDecode(TagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}
