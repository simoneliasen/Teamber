#pragma checksum "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "03464b48438e1757d97db9827c6bda3fad831e31"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContosoUniversity.Pages.Questionnaires.Pages_Questionnaires_Details), @"mvc.1.0.razor-page", @"/Pages/Questionnaires/Details.cshtml")]
namespace ContosoUniversity.Pages.Questionnaires
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\simon\source\repos\Teamber\Pages\_ViewImports.cshtml"
using ContosoUniversity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"03464b48438e1757d97db9827c6bda3fad831e31", @"/Pages/Questionnaires/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4c0473ebe7d620ab1ae06d83bc5bc87bf314407", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Questionnaires_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
  
    ViewData["Title"] = "Details";
    if (String.IsNullOrEmpty(Model.Login) || String.IsNullOrEmpty(Model.Manager))
                Response.Redirect("/Login/Login");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n<div>\r\n    <h4>Questionnaire</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 16 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Questionnaire.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 19 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
       Write(Html.DisplayFor(model => model.Questionnaire.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>Competences</th>\r\n                </tr>\r\n");
#nullable restore
#line 28 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
                 foreach (var item in Model.Questionnaire.QuestionnaireCompetences)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 32 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Competence));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 35 "C:\Users\simon\source\repos\Teamber\Pages\Questionnaires\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </dd>\r\n    </dl>\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContosoUniversity.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.DetailsModel>)PageContext?.ViewData;
        public ContosoUniversity.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
