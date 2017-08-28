using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using FilmStation.WebUI.Models;

namespace FilmStation.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            int FirstPage = 1;
            //确定起始页
            if(pagingInfo.CurrentPage<4)
            {
                FirstPage = 1;
            }
            else if(pagingInfo.CurrentPage>(pagingInfo.TotalPages-3))
            {
                FirstPage = pagingInfo.TotalPages - 6;
            }
            else
            {
                FirstPage = pagingInfo.CurrentPage - 3;
            }
            //构造分页结构并使用bootStrap
            TagBuilder tagUl = new TagBuilder("ul");
            tagUl.AddCssClass("pagination");
            TagBuilder tagPreLi = new TagBuilder("li");
            TagBuilder tagPreLink = new TagBuilder("a");
            if (pagingInfo.CurrentPage <= 1)
            {
                tagPreLi.AddCssClass("disabled");
            }
            else
            {
                tagPreLink.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage - 1));
            }
            tagPreLink.InnerHtml = "上一页";
            tagPreLi.InnerHtml = tagPreLink.ToString();
            
            result.Append(tagPreLi);
            //从起始页起十页的链接
            for(int i = FirstPage; i <= (pagingInfo.TotalPages < 7 ? (pagingInfo.TotalPages > 0 ? pagingInfo.TotalPages : 1) : FirstPage + 6); i++)
            {
                TagBuilder tagA = new TagBuilder("a");
                TagBuilder tagLi = new TagBuilder("li");
                tagA.MergeAttribute("href", pageUrl(i));
                tagA.InnerHtml = i.ToString();
                tagLi.InnerHtml = tagA.ToString();
                if(i == pagingInfo.CurrentPage)
                {
                    tagLi.AddCssClass("active");
                }
                result.Append(tagLi.ToString());
            }
            //
            TagBuilder tagNextLi = new TagBuilder("li");
            TagBuilder tagNextLink = new TagBuilder("a");
            if (pagingInfo.CurrentPage >= pagingInfo.TotalPages)
            {
                tagNextLi.AddCssClass("disabled");
            }
            else
            {
                tagNextLink.MergeAttribute("href", pageUrl(pagingInfo.CurrentPage + 1));
            }
            tagNextLink.InnerHtml = "下一页";
            tagNextLi.InnerHtml = tagNextLink.ToString();
            
            result.Append(tagNextLi);
            tagUl.InnerHtml = result.ToString();

            return MvcHtmlString.Create(tagUl.ToString());
        }
    }
}