#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fddd494345c3e5a526c64125420778e223fa9bff"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_UserEdit_Delete), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/UserEdit/Delete.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/SuperAdmin/Views/UserEdit/Delete.cshtml", typeof(AspNetCore.Areas_SuperAdmin_Views_UserEdit_Delete))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fddd494345c3e5a526c64125420778e223fa9bff", @"/Areas/SuperAdmin/Views/UserEdit/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/SuperAdmin/Views/_ViewImports.cshtml")]
    public class Areas_SuperAdmin_Views_UserEdit_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<New.Models.ApplicationUser>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(35, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml"
  
    ViewData["Title"] = "Delete";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(126, 85, true);
            WriteLiteral("\r\n\r\n\r\n<br />\r\n<h4>Apakah anda yakin menghapus unit kerja ini?</h4>\r\n<hr />\r\n\r\n<div>\r\n");
            EndContext();
            BeginContext(392, 110, true);
            WriteLiteral("\r\n    <div class=\"row\">\r\n        <label class=\"col-2\">Nip</label>\r\n        <label class=\"col-4 border-bottom\">");
            EndContext();
            BeginContext(503, 9, false);
#line 24 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml"
                                      Write(Model.NIP);

#line default
#line hidden
            EndContext();
            BeginContext(512, 135, true);
            WriteLiteral("</label>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <label class=\"col-2\">Uraian</label>\r\n        <label class=\"col-4 border-bottom\">");
            EndContext();
            BeginContext(648, 10, false);
#line 29 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml"
                                      Write(Model.Nama);

#line default
#line hidden
            EndContext();
            BeginContext(658, 139, true);
            WriteLiteral("</label>\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n        <label class=\"col-2\">Valid Till</label>\r\n        <label class=\"col-4 border-bottom\">");
            EndContext();
            BeginContext(798, 15, false);
#line 34 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml"
                                      Write(Model.UnitKerja);

#line default
#line hidden
            EndContext();
            BeginContext(813, 30, true);
            WriteLiteral("</label>\r\n    </div>\r\n\r\n\r\n    ");
            EndContext();
            BeginContext(843, 419, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fddd494345c3e5a526c64125420778e223fa9bff7351", async() => {
                BeginContext(869, 136, true);
                WriteLiteral("\r\n        <div class=\"form-group row\">\r\n\r\n            <div class=\"col-sm-2\"></div>\r\n            <div class=\"col-sm-2\">\r\n                ");
                EndContext();
                BeginContext(1005, 37, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "fddd494345c3e5a526c64125420778e223fa9bff7883", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 43 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\UserEdit\Delete.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.NIP);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1042, 114, true);
                WriteLiteral("\r\n                \r\n                <input type=\"submit\" value=\"Hapus\" class=\"btn btn-danger\" />\r\n                ");
                EndContext();
                BeginContext(1156, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fddd494345c3e5a526c64125420778e223fa9bff9871", async() => {
                    BeginContext(1202, 7, true);
                    WriteLiteral("Kembali");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1213, 42, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1262, 14, true);
            WriteLiteral("\r\n\r\n\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<New.Models.ApplicationUser> Html { get; private set; }
    }
}
#pragma warning restore 1591
