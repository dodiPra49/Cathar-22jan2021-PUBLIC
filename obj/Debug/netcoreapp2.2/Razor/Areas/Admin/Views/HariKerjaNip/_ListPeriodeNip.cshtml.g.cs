#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "250635972b8b76c9a536912b50a006da4bef012b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_HariKerjaNip__ListPeriodeNip), @"mvc.1.0.view", @"/Areas/Admin/Views/HariKerjaNip/_ListPeriodeNip.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/HariKerjaNip/_ListPeriodeNip.cshtml", typeof(AspNetCore.Areas_Admin_Views_HariKerjaNip__ListPeriodeNip))]
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
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\_ViewImports.cshtml"
using New;

#line default
#line hidden
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\_ViewImports.cshtml"
using New.Models;

#line default
#line hidden
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
using New.Utility;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"250635972b8b76c9a536912b50a006da4bef012b", @"/Areas/Admin/Views/HariKerjaNip/_ListPeriodeNip.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_HariKerjaNip__ListPeriodeNip : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<New.ViewModel.PegawaiPeriodeUnitList>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(80, 32, true);
            WriteLiteral("\r\n<h7><b>DAFTAR PNS</b></h7>\r\n\r\n");
            EndContext();
#line 7 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
 if (@Model.Count() != 0)
{

#line default
#line hidden
            BeginContext(142, 382, true);
            WriteLiteral(@"    <table class=""table  table-sm small border border-danger"" id=""pegawai"" width=""120%"" margin-top=0>
        <thead>
            <tr>

                <th>
                    Nip
                </th>
                <th width=""100px"">
                    Nama
                </th>

                <th>Aksi</th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 24 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(581, 74, true);
            WriteLiteral("                <tr>\r\n\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(656, 38, false);
#line 29 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nip));

#line default
#line hidden
            EndContext();
            BeginContext(694, 93, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td width=\"100px\">\r\n                        ");
            EndContext();
            BeginContext(788, 39, false);
#line 32 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(827, 148, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n                        <div class=\"nav justify-content-end\">\r\n                            ");
            EndContext();
            BeginContext(975, 270, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "250635972b8b76c9a536912b50a006da4bef012b6733", async() => {
                BeginContext(1151, 90, true);
                WriteLiteral("\r\n                                <i class=\"fa fa-plus\"></i>\r\n                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-idnip", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 37 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
                                                       WriteLiteral(item.Nip);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idnip"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-idnip", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idnip"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 38 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
                                     WriteLiteral(item.IdPola);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idpola"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-idpola", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["idpola"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1245, 88, true);
            WriteLiteral("\r\n\r\n                        </div>\r\n\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 47 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
            }

#line default
#line hidden
            BeginContext(1348, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 50 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
}
else
{

#line default
#line hidden
            BeginContext(1392, 33, true);
            WriteLiteral("    <h5>Tidak ada records </h5>\r\n");
            EndContext();
#line 54 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\Admin\Views\HariKerjaNip\_ListPeriodeNip.cshtml"
}

#line default
#line hidden
            BeginContext(1428, 10, true);
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<New.ViewModel.PegawaiPeriodeUnitList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
