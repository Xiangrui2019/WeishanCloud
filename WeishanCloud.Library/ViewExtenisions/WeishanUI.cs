using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using WeishanCloud.Library.Services;

namespace WeishanCloud.Library.ViewExtenisions
{
    public static class WeishanUI
    {
        public static IHtmlContent UseCoreStyleSheet(this RazorPage page)
        {
            var serviceLocation = page.Context.RequestServices.GetService<ServiceLocation>();
            var builder = new HtmlContentBuilder()
                .AppendHtml($"<meta name=\"theme-color\" content=\"#0082c9\">");
            
            return builder
                .StyleSheet($"{serviceLocation.UI}/dist/Core.min.css");
        }

        public static IHtmlContent UseCoreJavaScript(this RazorPage page)
        {
            var serviceLocation = page.Context.RequestServices.GetService<ServiceLocation>();
            
            return new HtmlContentBuilder()
                .JavaScript($"{serviceLocation.UI}/dist/Core.min.js");
        }
        
        public static IHtmlContent UseDashboardStyleSheet(this RazorPage page)
        {
            var serviceLocation = page.Context.RequestServices.GetService<ServiceLocation>();
            var builder = new HtmlContentBuilder()
                .AppendHtml($"<meta name=\"theme-color\" content=\"#0082c9\">");
            
            return builder
                    .StyleSheet($"{serviceLocation.UI}/dist/Dashboard.min.css");
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