using System.Text;
using BnsShopWeb.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using TagBuilder = Microsoft.AspNetCore.Mvc.Rendering.TagBuilder;
using TagRenderMode = Microsoft.AspNetCore.Mvc.Rendering.TagRenderMode;

namespace BnsShopWeb.HtmlHelpers;

using System.Web;

public static class PagingHelpers
{
    public static HtmlString PageLinks(this IHtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
    {
        TagBuilder tag = new TagBuilder("a");
        string rezult = "<ul class=hr>";
        for (int i = 1; i <= pagingInfo.TotalPages; i++)
        {
            rezult += "<li>";
            rezult += $"<a href={pageUrl(i)} class=bblock>{i}";
            
            rezult += "</a>";
            rezult += "</li>";
        }

        return new HtmlString(rezult);
    }
}