using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using WeishanCloud.Library.Services;

namespace WeishanCloud.Library.ViewExtenisions
{
    public static class WeishanUI
    {
        public static IHtmlContent UseDashboardStyleSheet(this RazorPage page, bool includeCore = true)
        {
            var serviceLocation = page.Context.RequestServices.GetService<ServiceLocation>();
            var builder = new HtmlContentBuilder()
                .AppendHtml($"<meta name=\"theme-color\" content=\"#0082c9\">");
            if (includeCore)
            {
                return builder
                    .StyleSheet($"{serviceLocation.UI}/dist/Core.min.css")
                    .StyleSheet($"{serviceLocation.UI}/dist/Dashboard.min.css");
            }
            else
            {
                return builder
                    .StyleSheet($"{serviceLocation.UI}/dist/Dashboard.min.css");
            }
        }

        public static IHtmlContent UseDashboardJavaScript(this RazorPage page, bool includeCore = true)
        {
            var serviceLocation = page.Context.RequestServices.GetService<ServiceLocation>();
            if (includeCore)
            {
                return new HtmlContentBuilder()
                    .JavaScript($"{serviceLocation.UI}/dist/Core.min.js")
                    .JavaScript($"{serviceLocation.UI}/dist/Dashboard.min.js");
            }
            else
            {
                return new HtmlContentBuilder()
                    .JavaScript($"{serviceLocation.UI}/dist/Dashboard.min.js");
            }
        }
    }
}