/* GoogleMapsHelpers: Custom ASP.NET MVC Helpers for Google Maps
 * http://googlemapshelpers.namedquery.com
 * 
 * Author: Won Song (NamedQuery@NamedQuery.com)
 * Contributors: N/A
 * 
 * Description: 
 * ============================================================= */

using GoogleMapsHelpers.Models;
using GoogleMapsHelpers.Resources;
using System.Text;

namespace GoogleMapsHelpers.Factories
{
    /// <summary>
    /// Creates Google Maps API Source Address string
    /// </summary>
    public static class SourceAddressFactory
    {
        private readonly static StringBuilder SourceAddressBuilder;

        /// <summary>
        /// Static constructor that initializes source address string builder
        /// </summary>
        static SourceAddressFactory()
        {
            SourceAddressBuilder = new StringBuilder();
        }

        /// <summary>
        /// Creates source address based on parameters
        /// </summary>
        /// <param name="apiKey">Google Maps API Key</param>
        /// <param name="sensor"></param>
        /// <param name="libraries"></param>
        /// <returns></returns>
        public static string GetSourceAddress(string apiKey, bool sensor, Libraries libraries)
        {
            SourceAddressBuilder.Clear();
            SourceAddressBuilder.Append(Constants.ApiAddress);

            if (!string.IsNullOrEmpty(apiKey))
            {
                SourceAddressBuilder
                    .Append(Constants.ApiAttribute)
                    .Append(apiKey)
                    .Append(Constants.Amp);
            }

            SourceAddressBuilder
                .Append(Constants.SensorAttribute)
                .Append(sensor.ToString().ToLower());

            switch (libraries)
            {
                case Libraries.Places :
                    SourceAddressBuilder
                        .Append(Constants.Amp)
                        .Append(Constants.LibrariesKey)
                        .Append(libraries.ToString().ToLower());
                    break;
            }

            return SourceAddressBuilder.ToString();
        }
    }
}
