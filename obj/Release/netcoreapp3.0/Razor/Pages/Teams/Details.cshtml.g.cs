#pragma checksum "D:\teamberting\v2\Pages\Teams\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fbe6a6f2f3772b14d7882e3e577bb36cd2626b2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ContosoUniversity.Pages.Teams.Pages_Teams_Details), @"mvc.1.0.razor-page", @"/Pages/Teams/Details.cshtml")]
namespace ContosoUniversity.Pages.Teams
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fbe6a6f2f3772b14d7882e3e577bb36cd2626b2", @"/Pages/Teams/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4c0473ebe7d620ab1ae06d83bc5bc87bf314407", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Teams_Details : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
  
    ViewData["Title"] = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Team</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 15 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Team.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 18 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Team.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 21 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Team.Synergy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 24 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
       Write(Html.DisplayFor(model => model.Team.Synergy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 27 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Team.EmpTeams));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>Team members</th>\r\n                </tr>\r\n");
#nullable restore
#line 34 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                 foreach (var item in Model.Team.EmpTeams)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 38 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Employee.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 41 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Employee.JobTitle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 44 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </table>\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <table class=\"table\">\r\n                <tr>\r\n                    <th>Questionnaire Title</th>\r\n                </tr>\r\n");
#nullable restore
#line 54 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                 foreach (var item in Model.Team.TeamQuestionnaires)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 58 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Questionnaire.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 61 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </table>
        </dd>

        <dt class=""col-sm-2"">
        </dt>
        <dd class=""col-sm-10"">
            <table class=""table"">
                <tr>
                    <th>Team Criterias</th>
                    <th>Criteria Priority</th>
                </tr>
");
#nullable restore
#line 73 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                 foreach (var criteria in Model.AssignedTeamCriteriaDataList)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 77 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => criteria.Criteria));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 80 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                   Write(Html.DisplayFor(modelItem => criteria.Priority));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 83 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </table>
        </dd>

        <!-- Import chart.js framework-->
        <script src=""https://cdn.jsdelivr.net/npm/chart.js@2.8.0""></script>

        <!-- Import icons-->
        <script src=""https://kit.fontawesome.com/c869845de6.js"" crossorigin=""anonymous""></script>

        <!-- Stacked canvases provinding a customized radar chart.-->
        <div class=""canvasWrapper"" width=""400"" heigth=""400"">
            <canvas id=""myCanvas"" width=""400"" height=""400""></canvas>
            <canvas id=""myChart"" width=""400"" height=""400""></canvas>

            <p id=""Analysts"">
                Analysts
                <i class=""far fa-question-circle"" type=""button"" data-toggle=""tooltip"" data-placement=""top""
                   title=""Intuitive (N) and Thinking (T) personality types, known for their rationality, impartiality and intellectual excellence"">
                </i>
            </p>

            <p id=""Diplomats"">
                Diplomats
                <i class=""far fa-question-c");
            WriteLiteral(@"ircle"" type=""button"" data-toggle=""tooltip"" data-placement=""top""
                   title=""Intuitive (N) and Feeling (F) personality types, known for their empathy, diplomatic skills, and passionate idealism"">
                </i>
            </p>

            <p id=""Sentinels"">
                Sentinels
                <i class=""far fa-question-circle"" type=""button"" data-toggle=""tooltip"" data-placement=""top""
                   title=""Observant (S) and Judging (J) personality types, known for their practicality and focus on order, security, and stability"">
                </i>
            </p>

            <p id=""Explorers"">
                Explorers
                <i class=""far fa-question-circle"" type=""button"" data-toggle=""tooltip"" data-placement=""top""
                   title=""Observant (S) and Prespecting (P) persoanlity types, known for their spontaneity, ingenuity, and ability to live in the moments"">
                </i>
            </p>
        </div>
        </tr>

");
#nullable restore
#line 128 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
          
            // Hardcoded list of possible personality types.
            var personalityoptions = new List<string>() { "INTJ", "INTP", "ENTJ", "ENTP", "ISTP", "ISFP", "ESTP", "ESFP", "ISTJ", "ISFJ", "ESTJ", "ESFJ", "INFJ", "INFP", "ENFJ", "ENFP" };

            // List to hold output to insert into radar-chart
            var personalityOccurence = new List<int>(new int[16]);

            // Get list w. employees personality types
            var personalitiesInSystem = new List<string>();
            foreach (var item in Model.Team.EmpTeams)
            {
            personalitiesInSystem.Add(item.Employee.PersonalityType);
            }

            // Iterate over possible personalities, if employee has persoanlity, +1 to occurrence list
            int index = 0;
            foreach (var item in personalityoptions)
            {
            int occurenceOfTypes = personalitiesInSystem.FindAll(personalities => personalities == item).Count();
            personalityOccurence[index] = occurenceOfTypes;
            index++;
            }
        

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <!--Configuration of radar chart-->\r\n        <script>\r\n         // Convert c# lists to javascript arrays to insert into radar-chart\r\n            var EmployeeCompetenceOccurence = ");
#nullable restore
#line 155 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                                         Write(Html.Raw(Json.Serialize(personalityOccurence)));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n            var EmployeeLabels = ");
#nullable restore
#line 156 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                            Write(Html.Raw(Json.Serialize(personalityoptions)));

#line default
#line hidden
#nullable disable
            WriteLiteral(@";

            Chart.defaults.global.legend.display = false;
            var ctx = document.getElementById(""myChart"").getContext(""2d"");
            var myRadarChart = new Chart(ctx, {
                type: 'radar',
                options: {
                    startAngle: 12,
                    scale: {
                         ticks: {
                            display: false,
                        }
                      }
                },
                data: {
                    labels: EmployeeLabels,
                    datasets: [{
                        data: EmployeeCompetenceOccurence,
                        backgroundColor: ""rgba(40, 167, 69, 0.2)"",
                        borderColor: ""rgba(40, 167, 69, 1)"",
                        responsive: true
                    }],
                }
            });

            // Stacked canvas to provide an axis to categorize personality types.
            var c = document.getElementById(""myCanvas"");
            var ");
            WriteLiteral(@"ctx = c.getContext(""2d"");
            ctx.setLineDash([5]);
            // X-axis
            ctx.moveTo(0, 200);
            ctx.lineTo(400, 200);
            ctx.stroke();
            // Y-axis
            ctx.moveTo(200, 0);
            ctx.lineTo(200, 400);
            ctx.stroke();
        </script>

        <style>
            .canvasWrapper {
                position: relative;
                width: 400px;
                height: 400px;
            }

                .canvasWrapper canvas {
                    position: absolute;
                    text-align: center;
                    align-items: center;
                    align-content: center;
                    top: 0;
                    left: 0;
                }

            #Analysts {
                position: absolute;
                top: 0;
                right: 0;
            }

            #Diplomats {
                position: absolute;
                top: 0;
                left: 0;
       ");
            WriteLiteral(@"     }

            #Sentinels {
                position: absolute;
                bottom: 0;
                left: 0;
            }

            #Explorers {
                position: absolute;
                bottom: 0;
                right: 0;
            }

            .fa-question-circle:hover {
                color: lightgrey;
            }
        </style>




    </dl>
</div>
<div>
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fbe6a6f2f3772b14d7882e3e577bb36cd2626b215623", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 246 "D:\teamberting\v2\Pages\Teams\Details.cshtml"
                           WriteLiteral(Model.Team.TeamID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6fbe6a6f2f3772b14d7882e3e577bb36cd2626b217739", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContosoUniversity.Pages.Teams.DetailsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Teams.DetailsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ContosoUniversity.Pages.Teams.DetailsModel>)PageContext?.ViewData;
        public ContosoUniversity.Pages.Teams.DetailsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
