#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a74e68fa1ee296e20e7202dfe20dbc4bc49f9f8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_PenilaianAL_Pilih), @"mvc.1.0.view", @"/Areas/User/Views/PenilaianAL/Pilih.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/User/Views/PenilaianAL/Pilih.cshtml", typeof(AspNetCore.Areas_User_Views_PenilaianAL_Pilih))]
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
#line 3 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
using New.ViewModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a74e68fa1ee296e20e7202dfe20dbc4bc49f9f8", @"/Areas/User/Views/PenilaianAL/Pilih.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_PenilaianAL_Pilih : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<New.Models.Diary>>
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
#line 4 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
  
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
#line 17 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
 using (@Html.BeginForm("Pilih", "PenilaianAL", FormMethod.Post))
{

#line default
#line hidden
            BeginContext(371, 1222, true);
            WriteLiteral(@"    <div class=""col-sm-12"">
        <br />
        <h4>Penilaian Atasan Langsung</h4>
        <div id=""HeaderAL"">

        </div>
        <div class=""col-sm-6"">
            <div class=""form-group row "">
                <label class=""control-label col-sm-3"">Disetujui Tgl :</label>
                <input name=""Ajukan2"" class=""form-control col-sm-4"" type=""date"" value=TempData[""Ajukan2""] /> &nbsp;
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
            WriteLiteral("            </th>\r\n                    <th>\r\n                        Durasi\r\n                        (Menit)\r\n                    </th>\r\n                    <th>\r\n                        Disetujui\r\n");
            EndContext();
            BeginContext(1666, 95, true);
            WriteLiteral("                    </th>\r\n\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 63 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                 for (int i = 0; i < Model.Count(); i++)
                {
                    

#line default
#line hidden
            BeginContext(1859, 36, false);
#line 65 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].Id));

#line default
#line hidden
            EndContext();
            BeginContext(1918, 43, false);
#line 66 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].IdPeriode));

#line default
#line hidden
            EndContext();
            BeginContext(1984, 37, false);
#line 67 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
               Write(Html.HiddenFor(model => model[i].Nip));

#line default
#line hidden
            EndContext();
            BeginContext(2512, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2597, 42, false);
#line 78 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(Html.DisplayFor(model => model[i].Tanggal));

#line default
#line hidden
            EndContext();
            BeginContext(2639, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2731, 45, false);
#line 81 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(Html.DisplayFor(model => model[i].WaktuMulai));

#line default
#line hidden
            EndContext();
            BeginContext(2776, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(2780, 46, false);
#line 81 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                                                                        Write(Html.DisplayFor(model => model[i].WaktuHingga));

#line default
#line hidden
            EndContext();
            BeginContext(2826, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2918, 44, false);
#line 84 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(Html.DisplayFor(model => model[i].Aktifitas));

#line default
#line hidden
            EndContext();
            BeginContext(2962, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3054, 41, false);
#line 87 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(Html.DisplayFor(model => model[i].Tempat));

#line default
#line hidden
            EndContext();
            BeginContext(3095, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(3187, 40, false);
#line 90 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(Html.DisplayFor(model => model[i].Hasil));

#line default
#line hidden
            EndContext();
            BeginContext(3227, 65, true);
            WriteLiteral("\r\n                        </td>\r\n\r\n                        <td>\r\n");
            EndContext();
#line 94 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                              
                                TimeSpan mulai = @Model[i].WaktuMulai;
                                TimeSpan hingga = @Model[i].WaktuHingga;
                                int estDurasi = (int)hingga.Subtract(mulai).TotalMinutes;

                            

#line default
#line hidden
            BeginContext(3594, 28, true);
            WriteLiteral("                            ");
            EndContext();
            BeginContext(3623, 9, false);
#line 100 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                       Write(estDurasi);

#line default
#line hidden
            EndContext();
            BeginContext(3632, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 103 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                              
                                if (@Model[i].WaktuSetuju1 == null)
                                {

#line default
#line hidden
            BeginContext(3831, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(3867, 82, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5a74e68fa1ee296e20e7202dfe20dbc4bc49f9f812151", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 106 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model[i].WaktuSetuju1);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 106 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                                                                                            WriteLiteral(estDurasi);

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
            BeginContext(3949, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 107 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(4059, 36, true);
            WriteLiteral("                                    ");
            EndContext();
            BeginContext(4095, 63, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "5a74e68fa1ee296e20e7202dfe20dbc4bc49f9f814957", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
#line 110 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => Model[i].WaktuSetuju1);

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
            BeginContext(4158, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 111 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                                }
                            

#line default
#line hidden
            BeginContext(4226, 62, true);
            WriteLiteral("                        </td>\r\n\r\n\r\n                    </tr>\r\n");
            EndContext();
#line 117 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                }

#line default
#line hidden
            BeginContext(4307, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
            BeginContext(4361, 39, true);
            WriteLiteral("    <div>\r\n        &nbsp;\r\n    </div>\r\n");
            EndContext();
#line 125 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
}

#line default
#line hidden
            BeginContext(4403, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("scripts", async() => {
                BeginContext(4424, 441, true);
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
                BeginContext(4866, 3, false);
#line 148 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\PenilaianAL\Pilih.cshtml"
                         Write(idd);

#line default
#line hidden
                EndContext();
                BeginContext(4869, 365, true);
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
