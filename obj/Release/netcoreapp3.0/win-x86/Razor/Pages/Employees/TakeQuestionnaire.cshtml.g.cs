#pragma checksum "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b3ba363f6cd67cb4fc66c769875393a3af7df787"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContosoUniversity.Pages.Employees.Pages_Employees_TakeQuestionnaire), @"mvc.1.0.razor-page", @"/Pages/Employees/TakeQuestionnaire.cshtml")]
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
#line 1 "D:\teamberting\v2\Pages\_ViewImports.cshtml"
using ContosoUniversity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b3ba363f6cd67cb4fc66c769875393a3af7df787", @"/Pages/Employees/TakeQuestionnaire.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4c0473ebe7d620ab1ae06d83bc5bc87bf314407", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Employees_TakeQuestionnaire : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", new global::Microsoft.AspNetCore.Html.HtmlString("Employee.PersonalityType"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString(" return ValidateCheckboxes()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
  
    ViewData["Title"] = "Take Questionnaire";

#line default
#line hidden
#nullable disable
            WriteLiteral("<link");
            BeginWriteAttribute("href", " href=\"", 131, "\"", 181, 1);
#nullable restore
#line 6 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
WriteAttributeValue("", 138, Url.Content("~/css/TakeQuestionnaire.css"), 138, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n<script src=\"https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.3/jquery.min.js\"></script>\r\n\r\n<h1>Take questionnaire</h1>\r\n<h4>");
#nullable restore
#line 10 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
Write(Html.DisplayFor(model => model.Employee.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n\r\n<hr />\r\n<div class=\"row\">\r\n    <div class=\"col-md-6\">\r\n\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3ba363f6cd67cb4fc66c769875393a3af7df7876958", async() => {
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3ba363f6cd67cb4fc66c769875393a3af7df7877228", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 17 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "b3ba363f6cd67cb4fc66c769875393a3af7df7878886", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 18 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Employee.ID);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n\r\n            <h4>Personality type</h4>\r\n            <div class=\"form-group\">\r\n                <select name=\"Employee.PersonalityType\" required>\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3ba363f6cd67cb4fc66c769875393a3af7df78710749", async() => {
                    WriteLiteral("Select a type");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 24 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                       string[] personalityTypes = { "ISTJ", "INFJ", "INTJ", "ENFJ", "ISTP", "ESFJ", "INFP", "ESFP", "ENFP", "ESTP", "ESTJ", "ENTJ", "INTP", "ISFJ", "ENTP", "ISFP" };
                        int cnt1 = 0;
                        foreach (var personality in personalityTypes)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3ba363f6cd67cb4fc66c769875393a3af7df78712500", async() => {
#nullable restore
#line 28 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                                                                                             Write(Html.Raw(personality));

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                            WriteLiteral(Html.Raw(personality));

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 29 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                        cnt1++;
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </select>
                <p>Take the <a href=""https://www.16personalities.com/"" target=""_blank"">Personality test</a> and enter your personality-type</p>
            </div>
            <hr />

            <h4>Competences</h4>
            <br />
            <div class=""form-group"">
                <table id=""competenceRating"">

                    <!-- Rating values-->
                    <tr>
                        <th></th>
                        <th>Not good</th>
                        <th>Pretty good</th>
                        <th>Good</th>
                        <th>Very good</th>
                        <th>Excellent</th>
                    </tr>

                    <!-- Itterator that gives each checkbox group a unique class, so the javascript can refference it and only make one checkbox clickable in each group-->
");
#nullable restore
#line 53 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                       int cnt = 1;
                        foreach (var competence in Model.AssignedEmployeeCompetenceDataList)
                        {

                        // Hidden refference to assign elements correctly

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <input type=\"hidden\" name=\"selectedCompetences\"");
                BeginWriteAttribute("value", " value=\"", 2597, "\"", 2642, 1);
#nullable restore
#line 58 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
WriteAttributeValue("", 2605, competence.QuestionnaireCompetenceID, 2605, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n                        <tr>\r\n\r\n                            <!--Component name-->\r\n                            <td>");
#nullable restore
#line 62 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                           Write(competence.Criteria);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n\r\n                            <!-- five checkboxes for each component -->\r\n");
#nullable restore
#line 65 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                             for (int i = 1; i < 6; i++)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td>\r\n                                <label class=\"containercheck\">\r\n                                    <input type=\"checkbox\"");
                BeginWriteAttribute("class", " class=\"", 3110, "\"", 3140, 2);
                WriteAttributeValue("", 3118, "option", 3118, 6, true);
#nullable restore
#line 69 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
WriteAttributeValue("", 3124, Html.Raw(cnt), 3124, 16, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("value", " value=\"", 3141, "\"", 3163, 1);
#nullable restore
#line 69 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
WriteAttributeValue("", 3149, Html.Raw(i), 3149, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" name=\"selectedCompetencesValue\" required>\r\n                                    <span class=\"checkmark\"></span>\r\n                                </label>\r\n                            </td>\r\n");
                WriteLiteral("                            <!--Only make it possible to check one checkbox in each row -->\r\n                            <script type=\"text/javascript\">\r\n                                                $(\'.option");
#nullable restore
#line 76 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                                                      Write(Html.Raw(cnt));

#line default
#line hidden
#nullable disable
                WriteLiteral("\').on(\'change\', function () {\r\n                                                    $(\'.option");
#nullable restore
#line 77 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                                                          Write(Html.Raw(cnt));

#line default
#line hidden
#nullable disable
                WriteLiteral("\').not(this).prop(\'checked\', false);\r\n                                                });\r\n                            </script>\r\n");
#nullable restore
#line 80 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 82 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                        cnt++;
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                </table>
            </div>
            <hr />

            <!--Because of the unorthodox checkbox setup, we need a dedicated Validation method for the checkboxes-->
            <script>
                function ValidateCheckboxes() {
                    var inputElems = document.getElementsByTagName(""input""),
                        checkBoxCount = 0;

                    for (var i = 0; i < inputElems.length; i++) {
                        if (inputElems[i].type == ""checkbox"" && inputElems[i].checked == true) {
                            checkBoxCount++;
                        }
                    }
                    if (checkBoxCount < ");
#nullable restore
#line 100 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
                                   Write(Model.AssignedEmployeeCompetenceDataList.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral(@") {
                        alert(""Looks like you forgot to fill out some parts of the form"");
                        return false;
                    }
                }
            </script>

            <!-- Sumbit-->
            <div class=""form-group"">
                <input type=""submit"" value=""Save"" class=""btn btn-primary"" />
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n    </div>\r\n</div>\r\n<div>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b3ba363f6cd67cb4fc66c769875393a3af7df78722458", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 120 "D:\teamberting\v2\Pages\Employees\TakeQuestionnaire.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContosoUniversity.Pages.Employees.TakeQuestionnaireModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Employees.TakeQuestionnaireModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Employees.TakeQuestionnaireModel>)PageContext?.ViewData;
        public ContosoUniversity.Pages.Employees.TakeQuestionnaireModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
