#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ea7148f93ddb033c2f85bea10fabe008ec3c8285"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_PnsNoEntriCathar_index), @"mvc.1.0.view", @"/Areas/Admin/Views/PnsNoEntriCathar/index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Admin/Views/PnsNoEntriCathar/index.cshtml", typeof(AspNetCore.Areas_Admin_Views_PnsNoEntriCathar_index))]
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
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\_ViewImports.cshtml"
using New;

#line default
#line hidden
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\_ViewImports.cshtml"
using New.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ea7148f93ddb033c2f85bea10fabe008ec3c8285", @"/Areas/Admin/Views/PnsNoEntriCathar/index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_PnsNoEntriCathar_index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<New.Models.noEntriCathar>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(46, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(136, 84, true);
            WriteLiteral("\r\n<h2><center>PNS BELUM ENTRI AKTIVITAS HARIAN DI APLIKASI SICATHAR </center></h2>\r\n");
            EndContext();
            BeginContext(291, 18, true);
            WriteLiteral("<h4><center>Bulan ");
            EndContext();
            BeginContext(310, 17, false);
#line 10 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
             Write(ViewData["bulan"]);

#line default
#line hidden
            EndContext();
            BeginContext(327, 7, true);
            WriteLiteral(" Tahun ");
            EndContext();
            BeginContext(335, 17, false);
#line 10 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
                                      Write(ViewData["tahun"]);

#line default
#line hidden
            EndContext();
            BeginContext(352, 132, true);
            WriteLiteral("   </center></h4>\r\n\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th align=\"left\" width=\"10%\">\r\n                ");
            EndContext();
            BeginContext(485, 39, false);
#line 17 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayNameFor(model => model.NIP));

#line default
#line hidden
            EndContext();
            BeginContext(524, 68, true);
            WriteLiteral("\r\n            </th>\r\n            <th align=\"left\">\r\n                ");
            EndContext();
            BeginContext(593, 40, false);
#line 20 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(633, 68, true);
            WriteLiteral("\r\n            </th>\r\n            <th align=\"left\">\r\n                ");
            EndContext();
            BeginContext(702, 43, false);
#line 23 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayNameFor(model => model.Jabatan));

#line default
#line hidden
            EndContext();
            BeginContext(745, 65, true);
            WriteLiteral("\r\n            </th>\r\n\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 29 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(842, 73, true);
            WriteLiteral("        <tr>\r\n            <td align=\"left\" width=\"10%\">\r\n                ");
            EndContext();
            BeginContext(916, 38, false);
#line 32 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NIP));

#line default
#line hidden
            EndContext();
            BeginContext(954, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td align=\"left\">\r\n                ");
            EndContext();
            BeginContext(1023, 39, false);
#line 35 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(1062, 68, true);
            WriteLiteral("\r\n            </td>\r\n            <td align=\"left\">\r\n                ");
            EndContext();
            BeginContext(1131, 42, false);
#line 38 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Jabatan));

#line default
#line hidden
            EndContext();
            BeginContext(1173, 38, true);
            WriteLiteral("\r\n            </td>\r\n\r\n        </tr>\r\n");
            EndContext();
#line 42 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\Admin\Views\PnsNoEntriCathar\index.cshtml"
}

#line default
#line hidden
            BeginContext(1214, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<New.Models.noEntriCathar>> Html { get; private set; }
    }
}
#pragma warning restore 1591
