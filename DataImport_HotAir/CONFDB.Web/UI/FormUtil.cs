#region Using Directives
using System;
using System.Web;

#endregion

namespace CONFDB.Web.UI
{
	/// <summary>
	/// Provides helper methods for use in web pages and controls.
	/// </summary>
	/// <remarks>
	/// This file is generated once and will never be overwritten.
	/// </remarks>
	[CLSCompliant(true)]
	public partial class FormUtil : FormUtilBase
	{
        /// <summary>
        /// Gets a <see cref="HttpRequest"/> parameter value from the current request or it returns the default value.
        /// </summary>
        /// <param name="requestParameterName">The <see cref="HttpRequest"/> parameter name.</param>
        /// <param name="defaultValue">The defaultValue parameter name.</param>
        /// <returns>The value of item or the default value if nothing found.</returns>
        public static string GetRequestParameter(String requestParameterName, string defaultValue)
        {
            String value = HttpContext.Current.Request[requestParameterName];

            if (!String.IsNullOrEmpty(value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }
	}
}
