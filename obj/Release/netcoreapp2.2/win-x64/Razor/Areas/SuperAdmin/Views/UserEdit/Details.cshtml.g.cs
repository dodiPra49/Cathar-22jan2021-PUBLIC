#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0cf8742bc29ecaff9b5e9cd5ba92c035b923a6a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_UserEdit_Details), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/UserEdit/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/SuperAdmin/Views/UserEdit/Details.cshtml", typeof(AspNetCore.Areas_SuperAdmin_Views_UserEdit_Details))]
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
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\_ViewImports.cshtml"
using New;

#line default
#line hidden
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\_ViewImports.cshtml"
using New.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0cf8742bc29ecaff9b5e9cd5ba92c035b923a6a", @"/Areas/SuperAdmin/Views/UserEdit/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/SuperAdmin/Views/_ViewImports.cshtml")]
    public class Areas_SuperAdmin_Views_UserEdit_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<New.Models.Pegawai>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(27, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(119, 130, true);
            WriteLiteral("\r\n<h1>Details</h1>\r\n\r\n<div>\r\n    <h4>Pegawai</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(250, 40, false);
#line 15 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(290, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(354, 36, false);
#line 18 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(390, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(453, 46, false);
#line 21 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GelarDepan));

#line default
#line hidden
            EndContext();
            BeginContext(499, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(563, 42, false);
#line 24 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.GelarDepan));

#line default
#line hidden
            EndContext();
            BeginContext(605, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(668, 49, false);
#line 27 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.GelarBelakang));

#line default
#line hidden
            EndContext();
            BeginContext(717, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(781, 45, false);
#line 30 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.GelarBelakang));

#line default
#line hidden
            EndContext();
            BeginContext(826, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(889, 47, false);
#line 33 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TempatLahir));

#line default
#line hidden
            EndContext();
            BeginContext(936, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1000, 43, false);
#line 36 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.TempatLahir));

#line default
#line hidden
            EndContext();
            BeginContext(1043, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1106, 44, false);
#line 39 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TgLLahir));

#line default
#line hidden
            EndContext();
            BeginContext(1150, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1214, 40, false);
#line 42 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.TgLLahir));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 62, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class = \"col-sm-2\">\r\n            ");
            EndContext();
            BeginContext(1317, 46, false);
#line 45 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.TglPensiun));

#line default
#line hidden
            EndContext();
            BeginContext(1363, 63, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class = \"col-sm-10\">\r\n            ");
            EndContext();
            BeginContext(1427, 42, false);
#line 48 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
       Write(Html.DisplayFor(model => model.TglPensiun));

#line default
#line hidden
            EndContext();
            BeginContext(1469, 47, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
            EndContext();
            BeginContext(1516, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0cf8742bc29ecaff9b5e9cd5ba92c035b923a6a10240", async() => {
                BeginContext(1563, 4, true);
                WriteLiteral("Edit");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Details.cshtml"
                           WriteLiteral(Model.NIP);

#line default
#line hidden
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
            EndContext();
            BeginContext(1571, 8, true);
            WriteLiteral(" |\r\n    ");
            EndContext();
            BeginContext(1579, 38, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0cf8742bc29ecaff9b5e9cd5ba92c035b923a6a12612", async() => {
                BeginContext(1601, 12, true);
                WriteLiteral("Back to List");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1617, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<New.Models.Pegawai> Html { get; private set; }
    }
}
#pragma warning restore 1591
