#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a393837727c339ffe681055f1c2875faafe44346"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_PenilaianAAL_Pilih), @"mvc.1.0.view", @"/Areas/User/Views/PenilaianAAL/Pilih.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/User/Views/PenilaianAAL/Pilih.cshtml", typeof(AspNetCore.Areas_User_Views_PenilaianAAL_Pilih))]
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
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\_ViewImports.cshtml"
using New;

#line default
#line hidden
#line 2 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\_ViewImports.cshtml"
using New.Models;

#line default
#line hidden
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
using New.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a393837727c339ffe681055f1c2875faafe44346", @"/Areas/User/Views/PenilaianAAL/Pilih.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_PenilaianAAL_Pilih : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<New.Models.Diary>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(31, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var idd = 0;
    var row = Model.FirstOrDefault();
    if (row != null)
    {
        idd = row.Id;
    }
    DateTime? tgl = ViewBag.Ajukan2;


#line default
#line hidden
            BeginContext(299, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 17 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
 using (@Html.BeginForm("Pilih", "PenilaianAAL", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(372, 1400, true);
            WriteLiteral(@"    <div class=""col-sm-12"">
        <br />
        <h4>Penilaian Atasan Langsung</h4>
        <div id=""HeaderAL"">

        </div>
        <div class=""col-sm-6"">
            <div class=""form-group row "">
                <label class=""control-label col-sm-3"">Disetujui Tgl :</label>
                <input name=""Selesai"" class=""form-control col-sm-4"" type=""date"" value=TempData[""Ajukan2""] /> &nbsp;
                <input type=""submit"" value=""Simpan"" class=""btn btn-danger"" />
            </div>
        </div>
        <table class=""table"">
            <thead class=""thead-light"">
                <tr>
                    <th>
                        Tanggal
                    </th>
                    <th>
                        Waktu
                    </th>
                    <th>
                        Aktifitas
                    </th>
                    <th>
                        Tempat
                    </th>
                    <th>
                        Hasil
        ");
            WriteLiteral(@"            </th>
                    <th>
                        Durasi
                        (Menit)
                    </th>
                    <th>
                        AL

                    </th>
                    <th>
                        Disetujui

                    </th>
                </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 65 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                 for (int i = 0; i < Model.Count(); i++)
                {
                    

#line default
#line hidden
            BeginContext(1870, 36, false);
#line 67 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].Id));

#line default
#line hidden
            EndContext();
            BeginContext(1929, 43, false);
#line 68 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].IdPeriode));

#line default
#line hidden
            EndContext();
            BeginContext(1995, 37, false);
#line 69 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].Nip));

#line default
#line hidden
            EndContext();
            BeginContext(2523, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2596, 42, false);
#line 80 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].Tanggal));

#line default
#line hidden
            EndContext();
            BeginContext(2638, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2718, 45, false);
#line 83 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].WaktuMulai));

#line default
#line hidden
            EndContext();
            BeginContext(2763, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(2767, 46, false);
#line 83 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                                                                    Write(Html.DisplayFor(model => model[i].WaktuHingga));

#line default
#line hidden
            EndContext();
            BeginContext(2813, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2893, 44, false);
#line 86 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].Aktifitas));

#line default
#line hidden
            EndContext();
            BeginContext(2937, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3017, 41, false);
#line 89 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].Tempat));

#line default
#line hidden
            EndContext();
            BeginContext(3058, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3138, 40, false);
#line 92 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].Hasil));

#line default
#line hidden
            EndContext();
            BeginContext(3178, 57, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                    <td>\r\n");
            EndContext();
#line 96 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                          
                            TimeSpan mulai = @Model[i].WaktuMulai;
                            TimeSpan hingga = @Model[i].WaktuHingga;
                            int estDurasi = (int)hingga.Subtract(mulai).TotalMinutes;

                        

#line default
#line hidden
            BeginContext(3517, 24, true);
            WriteLiteral("                        ");
            EndContext();
            BeginContext(3542, 9, false);
#line 102 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(estDurasi);

#line default
#line hidden
            EndContext();
            BeginContext(3551, 81, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        ");
            EndContext();
            BeginContext(3633, 47, false);
#line 106 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                   Write(Html.DisplayFor(model => model[i].WaktuSetuju1));

#line default
#line hidden
            EndContext();
            BeginContext(3680, 59, true);
            WriteLiteral("\r\n\r\n\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 111 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                         if (Model[i].WaktuSetuju2 == null)
                        {


#line default
#line hidden
            BeginContext(3829, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(3857, 94, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a393837727c339ffe681055f1c2875faafe4434612466", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 114 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model[i].WaktuSetuju2);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 114 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                                                                                    WriteLiteral(Model[i].WaktuSetuju1);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3951, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 115 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(4037, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(4065, 64, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a393837727c339ffe681055f1c2875faafe4434615247", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 118 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model[i].WaktuSetuju2);

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
            BeginContext(4129, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 119 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                        }

#line default
#line hidden
            BeginContext(4158, 54, true);
            WriteLiteral("\r\n                    </td>\r\n\r\n                </tr>\r\n");
            EndContext();
#line 124 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                }

#line default
#line hidden
            BeginContext(4231, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
            BeginContext(4285, 39, true);
            WriteLiteral("    <div>\r\n        &nbsp;\r\n    </div>\r\n");
            EndContext();
#line 132 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
}

#line default
#line hidden
            BeginContext(4327, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4348, 441, true);
                WriteLiteral(@"

    <script type=""text/javascript"">



        $(document).ready(function () {
            debugger;
            CallFunction();
        });


        function CallFunction() {


            var PostBackURL = '/User/PenilaianAL/GetHeaderAL'
            $.ajax({
                type: ""GET"",
                url: PostBackURL,
                contentType: ""application/json; charset=utf-8"",
                data: { ""Id"": ");
                EndContext();
                BeginContext(4790, 3, false);
#line 155 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAAL\Pilih.cshtml"
                         Write(idd);

#line default
#line hidden
                EndContext();
                BeginContext(4793, 365, true);
                WriteLiteral(@" },
                cache: false,
                datatyype: ""json"",
                success: function (data) {
                    $('#HeaderAL').html(data);

                }
                ,
                error: function () {
                    alert(""Dynamic content load failed"");
                }
            });
        }

    </script>
");
                EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<New.Models.Diary>> Html { get; private set; }
    }
}
#pragma warning restore 1591
