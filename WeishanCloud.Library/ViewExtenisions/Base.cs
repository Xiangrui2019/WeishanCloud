using Microsoft.AspNetCore.Html;

namespace WeishanCloud.Library.ViewExtenisions
{
    public static class Base
    {
        public static IHtmlContentBuilder JavaScript(this IHtmlContentBuilder content, string path)
        {
            return content.AppendHtml($"\n<script src='{path}'></script>");
        }

        public static IHtmlContentBuilder StyleSheet(this IHtmlContentBuilder content, string path)
        {
            return content.AppendHtml($"\n<link href='{path}' rel='stylesheet' />");
        }
    }
}