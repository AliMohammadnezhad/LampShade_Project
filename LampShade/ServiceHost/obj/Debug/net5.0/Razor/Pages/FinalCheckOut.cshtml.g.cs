#pragma checksum "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "40458e6e7eb1fb50469760196619570fa66d9e42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Pages.Pages_FinalCheckOut), @"mvc.1.0.razor-page", @"/Pages/FinalCheckOut.cshtml")]
namespace ServiceHost.Pages
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
#line 1 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\_ViewImports.cshtml"
using ServiceHost;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"40458e6e7eb1fb50469760196619570fa66d9e42", @"/Pages/FinalCheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d027006424b9e12b1709732f146fce9f1d78e6a1", @"/Pages/_ViewImports.cshtml")]
    public class Pages_FinalCheckOut : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "./Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 3 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
  
    ViewData["Title"] = "نتیجه پرداخت";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""breadcrumb-area section-space--half"">
    <div class=""container wide"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""breadcrumb-wrapper breadcrumb-bg"">
                    <div class=""breadcrumb-content"">
                        <h1 class=""breadcrumb-content__title"">نتیجه پرداخت</h1>
                        <ul class=""breadcrumb-content__page-map h4"">
                            <li>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "40458e6e7eb1fb50469760196619570fa66d9e423886", async() => {
                WriteLiteral("صفحه اصلی");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                            </li>
                            <li>
                                <a class=""active"">نتیجه پرداخت</a>
                            </li>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<div class=""page-content-area"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""page-wrapper"">
                    <div class=""page-content-wrapper"">
");
#nullable restore
#line 36 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                         if (Model.Payment != null)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                             if (Model.Payment.IsSuccessful)
                            {
                                if (Model.Payment.IsSuccessful && Model.Payment.IssueTrackingNo != "")
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-success text-center"" role=""alert"">
                                        <h1 class=""alert-heading"">پرداخت با موفیت انجام شد</h1>
                                        <h3>سفارش شما ثبت و در حال پیگیری میباشد ! با تشکر از اعتماد شما </h3>
                                        <hr>
                                        <h4 class=""mb-0"">کد پیگیری شما : ");
#nullable restore
#line 46 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                                                                    Write(Model.Payment.IssueTrackingNo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" مي باشد</h4>\r\n                                    </div>\r\n");
#nullable restore
#line 48 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <div class=""alert alert-success text-center"" role=""alert"">
                                        <h1 class=""alert-heading"">ثبت سفارش به صورت نقدی با موفقیت انجام پذیرفت</h1>
                                        <h3>با این روش پس از تایید سفارش از طرف شما کارشناسان ما با شما تماس گرفته و پس ازپیگیری های انجام شده سفارش شما ثبت و ارسال خواهد شد  </h3>
                                        <hr>
                                    </div>
");
#nullable restore
#line 56 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                                }
                            }
                            else if (!Model.Payment.IsSuccessful)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <div class=""alert alert-warning text-center"" role=""alert"">
                                    <h2 class=""alert-heading"">پرداخت وجه با شكست مواجه شده است</h2>
                                    <h4>در صورت كسر مبلغ از حساب شما حداكثر تا 24 ساعت آينده عودت خواهد داده شد .</h4>
                                    <hr>
                                </div>
");
#nullable restore
#line 65 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 65 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""alert alert-primary text-center"" role=""alert"">
                                <h2 class=""alert-heading"">کاربرگرامی !</h2>
                                <h4>پرداختی برای شما ثبت نشده است</h4>
                                <hr>
                            </div>
");
#nullable restore
#line 74 "F:\New Shop Project\Code\LampShade\ServiceHost\Pages\FinalCheckOut.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Pages.FinalCheckOutModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.FinalCheckOutModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Pages.FinalCheckOutModel>)PageContext?.ViewData;
        public ServiceHost.Pages.FinalCheckOutModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591