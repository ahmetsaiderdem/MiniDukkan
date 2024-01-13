using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MiniDukkan.Models.ViewModels;

namespace MiniDukkan.Altyapi
{
    [HtmlTargetElement("div", Attributes = "sayfa-model")]
    public class SayfaLinkTagHelper: TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;

        public SayfaLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public SayfalamaBilgi SayfaModel { get; set; }

        public string SayfaAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder sonuc = new TagBuilder("div");
            for (int i = 0; i < SayfaModel.ToplamSayfalar; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"]=urlHelper.Action(SayfaAction,new {urunSayfa =i});
                tag.InnerHtml.Append(i.ToString());
                sonuc.InnerHtml.AppendHtml(tag);



            }
            output.Content.AppendHtml(sonuc.InnerHtml);
        }
    }
}
