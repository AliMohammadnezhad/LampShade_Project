#pragma checksum "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f33953a33fcc3c10aa9a899558ac6241f36f0b63"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Panel.Pages.Areas_Panel_Pages_Orders), @"mvc.1.0.razor-page", @"/Areas/Panel/Pages/Orders.cshtml")]
namespace ServiceHost.Areas.Panel.Pages
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
#line 2 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f33953a33fcc3c10aa9a899558ac6241f36f0b63", @"/Areas/Panel/Pages/Orders.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"512ba2ae5da143bd376ba15f5c41a0e0f92c2691", @"/Areas/Panel/Pages/_ViewImports.cshtml")]
    public class Areas_Panel_Pages_Orders : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
  
    ViewData["Title"] = "سفارشات من";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""box-shadow mb-4 mt-lg-0 border-rad-10 w-100"">
    <div class=""card-title p-4 border-bottom"">
        <i class=""fa fa-user""></i>
        <span>سفارش های انجام شده</span>

    </div>
    <div class=""card-body p-4 pt-0"">
        <div class=""row"">
            <table class=""table table-striped"">
                <thead>
                    <tr>
                        <th scope=""col"">#</th>
                        <th scope=""col"">پرداخت کننده</th>
                        <th scope=""col"">کل مبلغ قابل پرداخت</th>
                        <th scope=""col"">مبلغ تخفیف</th>
                        <th scope=""col"">مبلغ پرداخت شده</th>
                        <th scope=""col"">روش پرداخت</th>
                        <th scope=""col"">شماره پیگیری</th>
                        <th scope=""col"">تاریخ ثبت شفارس</th>
                        <th scope=""col"">وضعیت</th>
                        <th scope=""col"">آیتم ها</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 32 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                     foreach (var order in Model.Orders)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <th scope=\"row\">");
#nullable restore
#line 35 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                                       Write(order.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>");
#nullable restore
#line 36 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 37 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.TotalAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 38 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.DiscountAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 39 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 40 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.PaymentMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 41 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.IssueTrackingNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td>");
#nullable restore
#line 42 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                           Write(order.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 43 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                             if (order.IsPaid)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-success\">\r\n                                    پرداخت شده\r\n                                </td>\r\n");
#nullable restore
#line 48 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                            }
                            else if (order.IsCanceled)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <td class=\"text-danger\">\r\n                                    کنسل شده\r\n                                </td>\r\n");
#nullable restore
#line 54 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <td>\r\n                                <button type=\"button\" class=\"btn btn-primary\" id=\"OrderItems\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2429, "\"", 2463, 3);
            WriteAttributeValue("", 2439, "ShowItem(", 2439, 9, true);
#nullable restore
#line 56 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
WriteAttributeValue("", 2448, order.OrderId, 2448, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2462, ")", 2462, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-action=\'");
#nullable restore
#line 56 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                                                                                                                                                             Write(Url.Page("./Orders", "Items"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\'>\r\n                                    مشاهده آیتم ها\r\n                                </button>\r\n                            </td>\r\n                        </tr>\r\n");
#nullable restore
#line 61 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Panel\Pages\Orders.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                </tbody>
            </table>


        </div>

    </div>
</div>


<div class=""modal fade"" id=""myModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""exampleModalLongTitle"">محصولات مربوط به این سفارش</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"" id=""DataContent"">
                ...
            </div>
            <div class=""modal-footer"">
                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">خروج</button>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Script", async() => {
                WriteLiteral(@"
    <script>

        function ShowItem(id) {
            const url = document.querySelector('#OrderItems').dataset.action;
            $.ajax({
                type: 'Get',
                url: url,
                data: { ""id"": id },
              
               

                success: function(data) {
                    console.log(data);
                    $('#DataContent').html(data);
                    $('#myModal').modal('show');
                },
                error: function(data) {
                    console.log(data);
                    
                }
            });
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Areas.Panel.Pages.OrdersModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Areas.Panel.Pages.OrdersModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Areas.Panel.Pages.OrdersModel>)PageContext?.ViewData;
        public ServiceHost.Areas.Panel.Pages.OrdersModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
