#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "31bc1476c8d18cd2e1c80b6cad19a61a63a32461"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_SuperAdmin_Views_Pegawai_Index2), @"mvc.1.0.view", @"/Areas/SuperAdmin/Views/Pegawai/Index2.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/SuperAdmin/Views/Pegawai/Index2.cshtml", typeof(AspNetCore.Areas_SuperAdmin_Views_Pegawai_Index2))]
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
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
using New.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"31bc1476c8d18cd2e1c80b6cad19a61a63a32461", @"/Areas/SuperAdmin/Views/Pegawai/Index2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/SuperAdmin/Views/_ViewImports.cshtml")]
    public class Areas_SuperAdmin_Views_Pegawai_Index2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PagedResult<New.Models.Pegawai>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index2", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn  btn-warning"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.SingleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Print", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(101, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
  
    var urlTemplate = Url.Action() + "?page={0}";
    var request = ViewContext.HttpContext.Request;
    foreach (var key in request.Query.Keys)
    {
        if (key == "page")
        {
            continue;
        }

        urlTemplate += "&" + key + "=" + request.Query[key];
    }

    var startIndex = Math.Max(Model.CurrentPage - 5, 1);
    var finishIndex = Math.Min(Model.CurrentPage + 5, Model.PageCount);

#line default
#line hidden
            BeginContext(542, 14, true);
            WriteLiteral("\r\n\r\n<br />\r\n\r\n");
            EndContext();
#line 27 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
 using (Html.BeginForm("Index2", "Pegawai", FormMethod.Get))
{

#line default
#line hidden
            BeginContext(621, 456, true);
            WriteLiteral(@"    <div class=""col-12"">
        <div class=""row"">
            <div class=""col-sm-8"">
                <h4>Daftar Pegawai </h4>
            </div>
            <div class=""col-sm-4"">
                <div class=""nav justify-content-end"">
                    <input id=""Cari"" type=""text"" class=""form-control""
                     name=""searchString"" placeholder=""Searching ..."">
                </div>
            </div>
        </div>
    </div>
");
            EndContext();
#line 42 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
}

#line default
#line hidden
            BeginContext(1080, 184, true);
            WriteLiteral("\r\n<div class=\"col-12\">\r\n    <br />\r\n    <table class=\"table table-striped  table-sm\">\r\n        <thead class=\"thead-light\">\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1264, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a324618625", async() => {
                BeginContext(1334, 3, true);
                WriteLiteral("NIP");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortOrder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 50 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                                                    WriteLiteral(ViewData["NipSortParm"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortOrder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1341, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1408, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a3246111124", async() => {
                BeginContext(1479, 4, true);
                WriteLiteral("NAMA");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-sortOrder", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 53 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                                                    WriteLiteral(ViewData["NamaSortParm"]);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-sortOrder", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["sortOrder"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1487, 358, true);
            WriteLiteral(@"
                </th>
                <th>
                    <div style=""color:#007bff"">TANGGAL LAHIR</div>
                </th>
                <th>
                    <div style=""color:#007bff"">TANGGAL PENSIUN</div>
                </th>
                <th>
                    <div class=""nav justify-content-end"">
                        ");
            EndContext();
            BeginContext(1845, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a3246113919", async() => {
                BeginContext(1892, 31, true);
                WriteLiteral("<i class=\"fa fa-user-plus\"></i>");
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
            BeginContext(1927, 58, true);
            WriteLiteral("\r\n                        &nbsp;\r\n                        ");
            EndContext();
            BeginContext(1985, 78, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a3246115462", async() => {
                BeginContext(2032, 27, true);
                WriteLiteral("<i class=\"fa fa-print\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2063, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(2316, 109, true);
            WriteLiteral("                    </div>\r\n                </th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n\r\n\r\n");
            EndContext();
#line 76 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
             foreach (var item in Model.Results)
            {

#line default
#line hidden
            BeginContext(2490, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2563, 38, false);
#line 80 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NIP));

#line default
#line hidden
            EndContext();
            BeginContext(2601, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2681, 39, false);
#line 83 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(2720, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2800, 43, false);
#line 86 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TgLLahir));

#line default
#line hidden
            EndContext();
            BeginContext(2843, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2923, 45, false);
#line 89 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                   Write(Html.DisplayFor(modelItem => item.TglPensiun));

#line default
#line hidden
            EndContext();
            BeginContext(2968, 118, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"nav justify-content-end\">\r\n");
            EndContext();
            BeginContext(3528, 30, true);
            WriteLiteral("\r\n                            ");
            EndContext();
            BeginContext(3558, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a3246119746", async() => {
                BeginContext(3635, 26, true);
                WriteLiteral("<i class=\"fa fa-edit\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 100 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                                                   WriteLiteral(item.NIP);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3665, 66, true);
            WriteLiteral("\r\n                            &nbsp;\r\n                            ");
            EndContext();
            BeginContext(3731, 109, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "31bc1476c8d18cd2e1c80b6cad19a61a63a3246122310", async() => {
                BeginContext(3809, 27, true);
                WriteLiteral("<i class=\"fa fa-times\"></i>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 102 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
                                                     WriteLiteral(item.NIP);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3840, 86, true);
            WriteLiteral("\r\n\r\n                        </div>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 107 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
            }

#line default
#line hidden
            BeginContext(3941, 42, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n");
            EndContext();
            BeginContext(3985, 54, false);
#line 112 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\SuperAdmin\Views\Pegawai\Index2.cshtml"
Write(await Component.InvokeAsync<PagerViewComponent>(Model));

#line default
#line hidden
            EndContext();
            BeginContext(4040, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PagedResult<New.Models.Pegawai>> Html { get; private set; }
    }
}
#pragma warning restore 1591
