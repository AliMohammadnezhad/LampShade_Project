#pragma checksum "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b08bd16710eff4823863b443317522a08dc604dd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(ServiceHost.Areas.Administration.Pages.Areas_Administration_Pages_Index), @"mvc.1.0.razor-page", @"/Areas/Administration/Pages/Index.cshtml")]
namespace ServiceHost.Areas.Administration.Pages
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
#line 2 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
using _0_Framework.Application;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b08bd16710eff4823863b443317522a08dc604dd", @"/Areas/Administration/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5e25ad8efa72e2da71cf3335257970b7e2689da", @"/Areas/Administration/Pages/_ViewImports.cshtml")]
    public class Areas_Administration_Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
  
    ViewData["Title"] = "صفحه اصلی";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""row"">

    <div class=""col-lg-3 col-md-6"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>
            </div>

            <h4 class=""header-title m-t-0 m-b-30"">درآمد کل</h4>

            <div class=""widget-chart-1 text-center"">


                <div class=""widget-detail-1"">
                    <h2 class=""p-t-10 m-b-0""> ");
#nullable restore
#line 24 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                         Write(Model.Counts.TotalIncome.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral(@" تومان </h2>
                    <p class=""text-muted"">درآمد کل</p>
                </div>
                <div class=""progress progress-bar-success-alt progress-sm m-b-0"">
                    <div class=""progress-bar progress-bar-success"" role=""progressbar""
                         aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100""
                         style=""width: 100%;"">
                        <span class=""sr-only""></span>
                    </div>
                </div>

            </div>
        </div>
    </div>

    <div class=""col-lg-3 col-md-6"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>

            </div>

            <h4 class=""header-title m-t-0 m-b-30"">تعداد کل نظرات
            </h4>

            <div class=""widget-box-2"">
              ");
            WriteLiteral("  <div class=\"widget-detail-2\">\r\n                    <h2 class=\"m-b-0\"> ");
#nullable restore
#line 53 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                  Write(Model.Counts.TotalComment);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
                    <p class=""text-muted m-b-25"">تعداد کل دیدگاه ها</p>
                </div>
                <div class=""progress progress-bar-success-alt progress-sm m-b-0"">
                    <div class=""progress-bar progress-bar-primary-alt"" role=""progressbar""
                         aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100""
                         style=""width: 100%;"">
                        <span class=""sr-only"">77% مجموع</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-lg-3 col-md-6"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>

            </div>

            <h4 class=""header-title m-t-0 m-b-30"">تعداد کل سفارش ها
            </h4>

            <div class=""widget-");
            WriteLiteral("box-2\">\r\n                <div class=\"widget-detail-2\">\r\n                    <h2 class=\"m-b-0\"> ");
#nullable restore
#line 80 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                  Write(Model.Counts.TotalOrders);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
                    <p class=""text-muted m-b-25"">تعداد کل سفارش ها</p>
                </div>
                <div class=""progress progress-bar-warning progress-sm m-b-0"">
                    <div class=""progress-bar progress-bar-primary-alt"" role=""progressbar""
                         aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100""
                         style=""width: 100%;"">
                        <span class=""sr-only"">77% مجموع</span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class=""col-lg-3 col-md-6"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>

            </div>

            <h4 class=""header-title m-t-0 m-b-30"">تعداد کل محصولات
            </h4>

            <div class=""widget-box-2""");
            WriteLiteral(">\r\n                <div class=\"widget-detail-2\">\r\n                    <h2 class=\"m-b-0\"> ");
#nullable restore
#line 107 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                  Write(Model.Counts.TotalProducts);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h2>
                    <p class=""text-muted m-b-25"">تعداد کل محصولات</p>
                </div>
                <div class=""progress progress-bar-warning progress-sm m-b-0"">
                    <div class=""progress-bar progress-bar-purple"" role=""progressbar""
                         aria-valuenow=""100"" aria-valuemin=""0"" aria-valuemax=""100""
                         style=""width: 100%;"">
                        <span class=""sr-only"">77% مجموع</span>
                    </div>
                </div>
            </div>
        </div>
    </div>


</div>

<div class=""row"">
    <div class=""col-lg-4"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>
            </div>

            <h4 class=""header-title m-t-0"">فروش روزانه</h4>

            <div class=""widget-chart text-cente");
            WriteLiteral(@"r"">

                <canvas width=""300"" id=""doughnut""></canvas>

            </div>
        </div>
    </div>

    <div class=""col-lg-8"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>
            </div>
            <h4 class=""header-title m-t-0"">آمارها</h4>

                <canvas  id=""bar""></canvas>

        </div>
    </div>


</div>


<div class=""row"">
    <div class=""col-lg-4"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>

            </div>

            <h4 class=""header-title m-t-0 m-b-30"">جعبه پیام های دریافتی</h4>

            <div class");
            WriteLiteral("=\"inbox-widget nicescroll\" style=\"height: 315px;\">\r\n");
#nullable restore
#line 174 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                 foreach (var item in Model.LatestComment)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"inbox-item\">\r\n\r\n                        <p class=\"inbox-item-author\">\r\n                            ");
#nullable restore
#line 179 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 181 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                             if (item.IsConfirmed)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-success\">تایید شده</span>\r\n");
#nullable restore
#line 184 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <span class=\"badge badge-danger\">در انتظار تایید</span>\r\n");
#nullable restore
#line 188 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"

                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </p>\r\n                        <p class=\"inbox-item-text\">ثبت شده برای : ");
#nullable restore
#line 191 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                                             Write(item.OwnerRecordName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        <p class=\"inbox-item-date\">");
#nullable restore
#line 192 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                              Write(item.CreateDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    </div>\r\n");
#nullable restore
#line 194 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

            </div>
        </div>
    </div>

    <div class=""col-lg-8"">
        <div class=""card-box"">
            <div class=""dropdown pull-right"">
                <a href=""#"" class=""dropdown-toggle card-drop"" data-toggle=""dropdown"" aria-expanded=""false"">
                    <i class=""zmdi zmdi-more-vert""></i>
                </a>

            </div>

            <h4 class=""header-title m-t-0 m-b-30"">آخرین سفارشات ثبت شده</h4>

            <div class=""table-responsive"">
                <table class=""table"">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>خریدار</th>
                            <th>مبلغ پرداخت</th>
                            <th>تاریخ ثبت سفارش</th>
                            <th>وضعیت</th>
                            <th>نحوه پرداخت</th>
                        </tr>
                    </thead>
                    <tbody>
");
#nullable restore
#line 225 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                         foreach (var item in Model.LatestOrders)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
#nullable restore
#line 228 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                               Write(item.OrderId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 229 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                               Write(item.AccountName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 230 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                               Write(item.PayAmount.ToMoney());

#line default
#line hidden
#nullable disable
            WriteLiteral("تومان</td>\r\n                                <td>");
#nullable restore
#line 231 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                               Write(item.DateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>\r\n");
#nullable restore
#line 233 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                     if (item.IsPaid)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"label label-success\">پرداخت شده</span>\r\n");
#nullable restore
#line 236 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                    }
                                    else if (item.IsCanceled)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"label label-danger\">کنسل شده</span>\r\n");
#nullable restore
#line 240 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                    }
                                    else if (!item.IsCanceled && !item.IsPaid)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"label label-warning\">در انتظار پرداخت</span>\r\n");
#nullable restore
#line 244 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </td>\r\n                                <td>");
#nullable restore
#line 246 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                               Write(item.PaymentMethod);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            </tr>\r\n");
#nullable restore
#line 248 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </tbody>\r\n                </table>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/3.6.0/chart.min.js"" integrity=""sha512-GMGzUEevhWh8Tc/njS0bDpwgxdCJLQBWG3Z2Ct+JGOpVnEmjvNx6ts4v6A2XJf1HOrtOsfhv3hBKpK9kE5z8AQ=="" crossorigin=""anonymous"" referrerpolicy=""no-referrer""></script>
    <script>
        const doughnutChartDiv = document.getElementById(""doughnut"");
        const doughnutData = ");
#nullable restore
#line 261 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                        Write(Html.Raw(JsonConvert.SerializeObject(Model.DoughnutDataSet)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        const doughnutChart = new Chart(doughnutChartDiv,
            {
                type: ""doughnut"",
                data: {
                    labels: [""فروش با تخفیف"", ""فروش بدون تخفیف""],
                    datasets: [doughnutData]
                },
                options: {
                    elements: {
                        bar: {
                            borderWidth: 1
                        }
                    }
                }
            });

        const data = ");
#nullable restore
#line 278 "F:\New Shop Project\Code\LampShade\ServiceHost\Areas\Administration\Pages\Index.cshtml"
                Write(Html.Raw(JsonConvert.SerializeObject(Model.BarLineDataSet)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        const barChartDiv = document.getElementById(""bar"");
        const barChart = new Chart(barChartDiv,
            {
                type: ""bar"",
                data: {
                    labels: [""فروردین"", ""اردیبهشت"", ""خرداد"", "" تیر"", ""مرداد"", ""شهریور"", ""مهر"", ""آبان"", ""آذر"", ""دی"", ""بهمن"", ""اسفند""],
                    datasets: data
                },
                options: {
                    elements: {
                        bar: {
                            borderWidth: 1
                        }
                    }
                }
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ServiceHost.Areas.Administration.Pages.IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Areas.Administration.Pages.IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ServiceHost.Areas.Administration.Pages.IndexModel>)PageContext?.ViewData;
        public ServiceHost.Areas.Administration.Pages.IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
