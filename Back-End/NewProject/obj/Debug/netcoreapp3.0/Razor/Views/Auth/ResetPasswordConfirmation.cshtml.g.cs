#pragma checksum "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/Auth/ResetPasswordConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d247acd2fea91263ff90ddd579796f3ae0a90ccf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_ResetPasswordConfirmation), @"mvc.1.0.view", @"/Views/Auth/ResetPasswordConfirmation.cshtml")]
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
#line 1 "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/_ViewImports.cshtml"
using Shop.API;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/_ViewImports.cshtml"
using Shop.API.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/_ViewImports.cshtml"
using Shop.API.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d247acd2fea91263ff90ddd579796f3ae0a90ccf", @"/Views/Auth/ResetPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ae968ca23229b467b2e7b1adbdc6edec90196b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_ResetPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/Auth/ResetPasswordConfirmation.cshtml"
  
    ViewData["Title"] = "Подтверждение сброса пароля";

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div style=\"width: 100%;\nheight: 100%;\nposition: fixed;\ntop: 0;\nleft: 0;\ndisplay: flex;\nalign-items: center;\nalign-content: center;\njustify-content: center;\noverflow: auto;\">\n        <div>\n            <h1>");
#nullable restore
#line 15 "/home/alexandr/Work/course-work-shop/Back-End/NewProject/Views/Auth/ResetPasswordConfirmation.cshtml"
           Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n            <h2>\n                Ваш пароль успешно сброшен.\n            </h2>\n        </div>\n    </div>");
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
