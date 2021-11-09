using System.Collections.Generic;
using System.Linq;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages
{
    public class IndexModel : PageModel
    {
        public Chart DoughnutDataSet { get; set; }
        public List<Chart> BarLineDataSet { get; set; }
        public TotalCounts Counts = new();

        public List<OrderViewModel> LatestOrders;
        public List<CommentViewModel> LatestComment;
        private readonly IOrderApplication _orderApplication;
        private readonly ICommentApplication _commentApplication;
        private readonly IProductApplication _productApplication;
        public IndexModel(IOrderApplication orderApplication, ICommentApplication commentApplication, IProductApplication productApplication)
        {
            _orderApplication = orderApplication;
            _commentApplication = commentApplication;
            _productApplication = productApplication;
        }


        public void OnGet()
        {
            LatestOrders = _orderApplication.GateLatestOrders();
            LatestComment = _commentApplication.GetLatestComment();
            var order = _orderApplication.CalculateOrdersSales();
            var price = _orderApplication.GetSalesInMoth()
                .Select(price => price.PayAmount).ToList();

            Counts.TotalOrders = _orderApplication.GetAllOrdersCount();
            Counts.TotalComment = _commentApplication.TotalComment();
            Counts.TotalIncome = price.Sum();
            Counts.TotalProducts = _productApplication.GetAllProductsCount();


            DoughnutDataSet = new Chart
            {
                Label = "Apple",
                Data = new  List<double>(){order.Sales,order.DiscountSales},
                BorderColor = "#ffcdb2",
                BackgroundColor = new[] { "#b5838d", "#ffd166", "#7f4f24", "#ef233c", "#003049" }
            };

            BarLineDataSet = new List<Chart>
            {
                new Chart
                {
                    Label = "مبلغ کل فروش",
                    Data = price,
                    BackgroundColor = new[] {"#0008ff"},
                    BorderColor = "#b5838d"
                },
      
            };

       
        }

 


        public class Chart
        {
            [JsonProperty(PropertyName = "label")]
            public string Label { get; set; }

            [JsonProperty(PropertyName = "data")]
            public List<double> Data { get; set; }

            [JsonProperty(PropertyName = "backgroundColor")]
            public string[] BackgroundColor { get; set; }

            [JsonProperty(PropertyName = "borderColor")]
            public string BorderColor { get; set; }
        }


        public class TotalCounts
        {
            public double TotalIncome { get; set; }
            public double TotalComment { get; set; }
            public double TotalProducts { get; set; }
            public double TotalOrders { get; set; }
        }





    }
}
