#pragma checksum "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\ModalPopUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3ff475a127b8a5c246c9c1f1d2099b61459b48e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_User_Views_ModalPopUp), @"mvc.1.0.view", @"/Areas/User/Views/ModalPopUp.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/User/Views/ModalPopUp.cshtml", typeof(AspNetCore.Areas_User_Views_ModalPopUp))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3ff475a127b8a5c246c9c1f1d2099b61459b48e", @"/Areas/User/Views/ModalPopUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba3e2599a2d6344fe25b68d3144d692246d03a3c", @"/Areas/User/Views/_ViewImports.cshtml")]
    public class Areas_User_Views_ModalPopUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\ModalPopUp.cshtml"
  
    ViewBag.Title = "Satyaprakash Bootstrap PopUp";

#line default
#line hidden
            BeginContext(60, 9, true);
            WriteLiteral("\r\n<title>");
            EndContext();
            BeginContext(70, 13, false);
#line 5 "D:\DODI AGUSRI,S.KOM\Kominfo 2020\DEVELOPERS\ASPNETCORE\Kominfo\12Agustus2020\New\Areas\User\Views\ModalPopUp.cshtml"
  Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(83, 1981, true);
            WriteLiteral(@"</title>

<link href=""bootstrap/css/bootstrap.min.css"" rel=""stylesheet"">

<style>
    .button {
        background-color: #4CAF50; /* Green */
        border: none;
        color: white;
        padding: 15px 32px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 12px;
        margin: 4px 2px;
        cursor: pointer;
    }

    .button1 {
        border-radius: 2px;
    }

    .button2 {
        border-radius: 4px;
    }

    .button3 {
        border-radius: 8px;
    }

    .button4 {
        border-radius: 12px;
    }

    .button5 {
        border-radius: 50%;
    }
</style>
<div>
    <h2 style=""background-color: Yellow;color: Blue; text-align: center; font-style: oblique"">Satyaprakash Bootstrap PopUp</h2>
    <fieldset>
        <legend style=""color:orangered"">Click On Satyaprakash Bootstrap PopUp</legend>
        <div class=""container"">
            <div class=""row"">
                <div class=""col-xs-1");
            WriteLiteral(@"2"">

                    <button id=""btnShowModal"" type=""button""
                            class=""btn btn-sm btn-default pull-left col-lg-11 button button4"">
                        Satya Modals
                    </button>

                    <div class=""modal fade"" tabindex=""-1"" id=""loginModal""
                         data-keyboard=""false"" data-backdrop=""static"">
                        <div class=""modal-dialog modal-lg"">
                            <div class=""modal-content"">
                                <div class=""modal-header"">
                                    <button type=""button"" class=""close"" data-dismiss=""modal"">
                                        ×
                                    </button>
                                    <h4 class=""modal-title"">Satya Login</h4>
                                </div>
                                <div class=""modal-body"">
                                    ");
            EndContext();
            BeginContext(2064, 659, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3ff475a127b8a5c246c9c1f1d2099b61459b48e6136", async() => {
                BeginContext(2070, 646, true);
                WriteLiteral(@"
                                        <div class=""form-group"">
                                            <input class=""form-control"" type=""text""
                                                   placeholder=""Login Username"" id=""inputUserName"" />
                                        </div>
                                        <div class=""form-group"">
                                            <input class=""form-control"" placeholder=""Login Password""
                                                   type=""password"" id=""inputPassword"" />
                                        </div>
                                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2723, 1361, true);
            WriteLiteral(@"
                                </div>
                                <div class=""modal-footer"">
                                    <button type=""submit"" class=""btn btn-primary button button4"">Sign</button>
                                    <button type=""button"" id=""btnHideModal"" class=""btn btn-primary button button4"">
                                        Hide
                                    </button>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </fieldset>
</div>
<footer>
    <p style=""background-color: Yellow; font-weight: bold; color:blue; text-align: center; font-style: oblique"">
        ©
        <script>document.write(new Date().toDateString());</script>
    </p>
</footer>
<script src=""https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"">

</script>
<script src=""bootstrap/js/bootstrap.min.js""></script>

");
            WriteLiteral(@"<script type=""text/javascript"">

        $(document).ready(function () {
            $(""#btnShowModal"").click(function () {
                $(""#loginModal"").modal('show');
            });

            $(""#btnHideModal"").click(function () {
                $(""#loginModal"").modal('hide');
            });
        });
</script> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591