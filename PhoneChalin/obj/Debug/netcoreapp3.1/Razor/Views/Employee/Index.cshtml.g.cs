#pragma checksum "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15208f341c4c091c6bdfbe1e1872984b374af710"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee_Index), @"mvc.1.0.view", @"/Views/Employee/Index.cshtml")]
namespace AspNetCore
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
#line 1 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/_ViewImports.cshtml"
using PhoneChalin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/_ViewImports.cshtml"
using PhoneChalin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15208f341c4c091c6bdfbe1e1872984b374af710", @"/Views/Employee/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"421a62a42c65cb5e42e910ce782c7ed902e358e9", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PhoneChalin.Models.Employee>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/employee.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 4 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
  
    ViewData["Title"] = "Data Employee";
    Layout = "_LayoutAdmin";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h1 class=\"h3 mb-4 text-gray-800\">DATA Employee</h1>\n\n<div class=\"row\">\n    <div class=\"col\">\n\n        <div class=\"text-center\">\n            ");
#nullable restore
#line 15 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
       Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </div>
        
        <a class=""btn btn-primary"" style=""float:left;margin-right:5px;"" href=""#"" target=""_blank"">Export : </a>
        <table class=""table table-striped table-bordered dataTable"" style=""width: 100%;"" id=""employee"">
            <thead class=""theadColor"">
                <tr>
                    <th>
                        No
                    </th>
                    <th>
                        ");
#nullable restore
#line 26 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NipEmployee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        ");
#nullable restore
#line 29 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.NameEmployee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        ");
#nullable restore
#line 32 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.GenderEmployee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        ");
#nullable restore
#line 35 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.AgeEmployee));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        ");
#nullable restore
#line 38 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.StatusEmployer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                    </th>\n                    <th>\n                        Action\n                    </th>\n                </tr>\n            </thead>\n            <tbody>\n\n            </tbody>\n        </table>\n    </div>\n</div>\n\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "15208f341c4c091c6bdfbe1e1872984b374af7106947", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 53 "/Volumes/DATA Dev/METRODATA CODING CAMP /PhoneChalinss/PhoneChalin/Views/Employee/Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PhoneChalin.Models.Employee>> Html { get; private set; }
    }
}
#pragma warning restore 1591
