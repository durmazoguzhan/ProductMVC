using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MyAspNetCoreApp.Web.TagHelpers
{
    [HtmlTargetElement("thumbnail")]
    public class ImageThumbnailTagHelper : TagHelper
    {
        public string ImageSrc { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string fileName = ImageSrc.Split(".")[0];
            string fileExtension = Path.GetExtension(ImageSrc); // .png or .jpg or ...

            output.TagName = "img"; // <img></img>
            output.Attributes.SetAttribute("src", $"{fileName}-128x128{fileExtension}");
        }
    }
}
