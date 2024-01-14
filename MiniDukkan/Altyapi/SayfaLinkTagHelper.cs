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
        private IUrlHelperFactory urlHelperFactory;

        public SayfaLinkTagHelper(IUrlHelperFactory HelperFactory)
        {
            urlHelperFactory = HelperFactory;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public SayfalamaBilgi SayfaModel { get; set; }

        public string SayfaAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix ="page-url-")]
        public Dictionary<string,object> PageUrlValues {  get; set; } 
        =new Dictionary<string, object>();

        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
            TagBuilder sonuc = new TagBuilder("div");
            for (int i = 0; i < SayfaModel.ToplamSayfalar; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                PageUrlValues["urunSayfa"] = i;
                tag.Attributes["href"] = urlHelper.Action(SayfaAction,PageUrlValues);
                tag.Attributes["href"]=urlHelper.Action(SayfaAction,new {urunSayfa =i});
                if (PageClassEnabled) 
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == SayfaModel.GuncelSayfa ? PageClassSelected:PageClassNormal);
                }
                tag.InnerHtml.Append(i.ToString());
                sonuc.InnerHtml.AppendHtml(tag);



            }
            output.Content.AppendHtml(sonuc.InnerHtml);
        }
    }
}
