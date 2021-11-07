using System.IO;
using System.Net;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using Newtonsoft.Json;
using RestSharp;

namespace _0_FrameWork.Application.ZarinPal
{
    public class ZarinPalFactory : IZarinPalFactory
    {
        private readonly IConfiguration _configuration;

        public string Prefix { get; set; }
        private string MerchantId { get; }

        public ZarinPalFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            Prefix = _configuration.GetSection("payment")["method"];
            MerchantId = _configuration.GetSection("payment")["merchant"];
        }

        public PaymentResponse CreatePaymentRequest(string amount, string mobile, string email, string description, long orderId)
        {
            var url = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentRequest.json");
            var request = new RestRequest(Method.POST);


            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");
         
            var siteUrl = _configuration.GetSection("payment")["siteUrl"];

            string[] metadata = new string[2];
            metadata[0] = $"[mobile: {mobile}]";
            metadata[1] = $"[email: {email}]";

            var body = new PaymentRequest
            {
                CallbackURL = $"{siteUrl}/CheckOut?handler=CallBack&oId={orderId}",
                Description = description,
                Amount = int.Parse(amount),
                MerchantID = MerchantId,
                metadata = metadata
            };
            var jsResult = new JavaScriptSerializer().Serialize(body);

            request.AddJsonBody(body);
            var response = url.Execute(request);


            var peyResponse = new JavaScriptSerializer().Deserialize<PaymentResponse>(response.Content);
            peyResponse.Perfix = Prefix;
            return peyResponse;
        }

 

        public VerificationResponse CreateVerificationRequest(string authority, double amount)
        {
            var url = new RestClient($"https://{Prefix}.zarinpal.com/pg/rest/WebGate/PaymentVerification.json");
            var request = new RestRequest(Method.POST);

            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/json");

            var body = new VerificationRequest
            {
                Amount = amount,
                Authority = authority,
                MerchantID = MerchantId
            };
            var jsResult = new JavaScriptSerializer().Serialize(body);

            request.AddJsonBody(body);
            var response = url.Execute(request);


            var peyResponse = new JavaScriptSerializer().Deserialize<VerificationResponse>(response.Content);

            return peyResponse;
        }

    }



}
