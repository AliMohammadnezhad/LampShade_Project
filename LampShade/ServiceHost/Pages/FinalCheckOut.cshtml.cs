using _0_FrameWork.Application.ZarinPal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;

namespace ServiceHost.Pages
{
    public class FinalCheckOutModel : PageModel
    {
        public PaymentResult Payment = new PaymentResult();
        public void OnGet()
        {
            var cookie = Request.Cookies["PayResult"];
            var result = new JavaScriptSerializer().Deserialize<PaymentResult>(cookie);
            Payment = result;
        }
    }
}
