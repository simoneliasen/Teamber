#pragma checksum "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a15dfb0349346255bdcabcc8b8f3c55cda741813"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContosoUniversity.Pages.Employees.Pages_Employees_Dashboard), @"mvc.1.0.razor-page", @"/Pages/Employees/Dashboard.cshtml")]
namespace ContosoUniversity.Pages.Employees
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
#line 1 "C:\Users\Daniel\Teamber\Pages\_ViewImports.cshtml"
using ContosoUniversity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a15dfb0349346255bdcabcc8b8f3c55cda741813", @"/Pages/Employees/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4c0473ebe7d620ab1ae06d83bc5bc87bf314407", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employees_Dashboard : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/employees/TakeQuestionnaire", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("color:white;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("fade-in"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
  
    ViewData["Title"] = "Dashboard";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a15dfb0349346255bdcabcc8b8f3c55cda7418134214", async() => {
                WriteLiteral(@"

    <div class=""container removePad"" style=""padding-bottom: 1%"">
        <div class=""row"">
            <div class=""col-xl"">
                <h2 class=""padTwoTop headerAlign"">Employee dashboard</h2>
            </div>
        </div>
    </div>

    <div class=""container-fluid padTwo"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col"">
                    <div class=""border padTwo lightBG dropShadow"">
                        <div class=""bodyBlock"">
                            <h4>Employee info</h4>
                            <dl class=""row"">
                                <dt class=""col-sm-2"">
                                    ");
#nullable restore
#line 25 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Employee.LastName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 28 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(model => model.Employee.LastName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 31 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Employee.FirstMidName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 34 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(model => model.Employee.FirstMidName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 37 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Employee.EmpTeamDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 40 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(model => model.Employee.EmpTeamDate));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 43 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Employee.JobTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 46 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(model => model.Employee.JobTitle));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dd>\r\n                                <dt class=\"col-sm-2\">\r\n                                    ");
#nullable restore
#line 49 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayNameFor(model => model.Employee.PersonalityType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dt>\r\n                                <dd class=\"col-sm-10\">\r\n                                    ");
#nullable restore
#line 52 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(model => model.Employee.PersonalityType));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </dd>\r\n                            </dl>\r\n                            <hr />\r\n                            <h4>Your teams</h4>\r\n\r\n");
#nullable restore
#line 58 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                             foreach (var item in Model.Employee.EmpTeams)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <ul>");
#nullable restore
#line 60 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                               Write(Html.DisplayFor(modelItem => item.Team.Title));

#line default
#line hidden
#nullable disable
                WriteLiteral("</ul>\r\n");
#nullable restore
#line 61 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <hr />\r\n\r\n                            <h4>Take questionnaires</h4><br>\r\n");
#nullable restore
#line 65 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                             if (Model.Id.Count != 0)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                <div class=""border padTwo lightBG dropShadow padThreeTop"" style=""width:33%"">
                                    <div class=""bodyBlock"">
                                        <div class=""text-center"">
                                            <b>Questionnaire title</b><br>
                                            <p class=""padThreeTop"">
                                                Due date: 01/04/2020
                                            </p>
                                            <button type=""button"" class=""btn btn-success"" style=""width:80%; margin-top:3%"">
                                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a15dfb0349346255bdcabcc8b8f3c55cda74181311162", async() => {
                    WriteLiteral("Take Questionaire");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                            </button>\r\n                                        </div>\r\n                                    </div>\r\n                                </div>\r\n");
#nullable restore
#line 80 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div>\r\n                                    <a>All questionaire taken</a>\r\n                                </div>\r\n");
#nullable restore
#line 86 "C:\Users\Daniel\Teamber\Pages\Employees\Dashboard.cshtml"

                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </div>
                    </div>
                </div>
            </div>
        </div>
        <br>
    </div>
    <footer id=""sticky-footer"" class=""py-4 bg-dark text-white-50 fixed-bottom"">
        <div class=""container text-center"">
            <small>Copyright &copy; Teamber 2020</small>
        </div>
    </footer>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContosoUniversity.Pages.Employees.DashboardModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Employees.DashboardModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Employees.DashboardModel>)PageContext?.ViewData;
        public ContosoUniversity.Pages.Employees.DashboardModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
