#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37ce36baed42cc4ab597c80881ac0ac2b481075b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_PenilaianAL_Index), @"mvc.1.0.view", @"/Areas/User/Views/PenilaianAL/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/User/Views/PenilaianAL/Index.cshtml", typeof(AspNetCore.Areas_User_Views_PenilaianAL_Index))]
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
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\_ViewImports.cshtml"
using New;

#line default
#line hidden
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\_ViewImports.cshtml"
using New.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37ce36baed42cc4ab597c80881ac0ac2b481075b", @"/Areas/User/Views/PenilaianAL/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_PenilaianAL_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<New.Models.PeriodeNIP>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(133, 874, true);
            WriteLiteral(@"

<div class=""col-sm-10"">
    <br />
    <h4>Penilaian Atasan Langsung</h4></br>

    <table class=""table"">
        <thead class=""thead-light"">
            <tr>
                <th>
                    <div style=""color:#E95420"">NIP</div>
                </th>
                <th>
                    <div style=""color:#E95420"">Nama</div>
                </th>
                <th>
                    <div style=""color:#E95420"">Diajukan Tanggal</div>
                </th>
                <th>
                    <div style=""color:#E95420"">Dinilai AL</div>
                </th>
                <th>
                    <div style=""color:#E95420"">Dinilai AAL</div>
                </th>
                <th>
                    <div style=""color:#E95420"">Proses</div>
                </th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 37 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1064, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1137, 38, false);
#line 41 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Nip));

#line default
#line hidden
            EndContext();
            BeginContext(1175, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1255, 53, false);
#line 44 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NipNavigation.Nama));

#line default
#line hidden
            EndContext();
            BeginContext(1308, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1388, 42, false);
#line 47 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Ajukan1));

#line default
#line hidden
            EndContext();
            BeginContext(1430, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1510, 42, false);
#line 50 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Ajukan2));

#line default
#line hidden
            EndContext();
            BeginContext(1552, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1632, 42, false);
#line 53 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Selesai));

#line default
#line hidden
            EndContext();
            BeginContext(1674, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1754, 83, false);
#line 56 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
                   Write(Html.ActionLink("Pilih", "Pilih", new { idperiode = item.IdPeriode, nip=item.Nip }));

#line default
#line hidden
            EndContext();
            BeginContext(1837, 54, true);
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 60 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\27Oktober2020\New\Areas\User\Views\PenilaianAL\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1906, 38, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<New.Models.PeriodeNIP>> Html { get; private set; }
    }
}
#pragma warning restore 1591