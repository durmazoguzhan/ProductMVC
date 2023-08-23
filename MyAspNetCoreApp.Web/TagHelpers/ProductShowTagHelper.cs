using Microsoft.AspNetCore.Razor.TagHelpers;
using MyAspNetCoreApp.Web.ViewModels;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    public class ProductShowTagHelper : TagHelper
    {
        public ProductViewModel Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetHtmlContent($"" +
                $"<ul class=\"list-group mb-3\">" +
                $"<li class=\"list-group-item\">{Product.Name}</li>" +
                $"<li class=\"list-group-item\">{Product.Color}</li>" +
                $"<li class=\"list-group-item\">{Product.Price}</li>" +
                $"<li class=\"list-group-item\">{Product.Stock}</li>" +
                $"</ul>");
        }
    }
}
