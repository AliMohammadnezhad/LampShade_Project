using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Configuration;
using Nancy.Json;
using RestSharp;

namespace _0_FrameWork.Application.Sms
{
    public class SmsSender : ISmsSender
    {

        private readonly IConfiguration _configuration;
        private readonly (string number,string username,string passwd) _sendSmsData;

        public SmsSender(IConfiguration configuration)
        {
            _configuration = configuration;
            _sendSmsData.username = _configuration.GetSection("Sms").GetSection("WebServiceUserName").Value;
            _sendSmsData.passwd = _configuration.GetSection("Sms").GetSection("WebServicePassword").Value;
            _sendSmsData.number = _configuration.GetSection("Sms").GetSection("SenderNumber").Value;
        }


  
        public void SendSms(string message, string mobile)
        {

            var numbersList = new List<string> {mobile};
            object input = new
            {
                PhoneNumber = _sendSmsData.number, 
                Message = message, 
                UserGroupID = Guid.NewGuid(), 
                Mobiles = numbersList, 
                SendDateInTimeStamp = new SendSms().GetTimeStamp(DateTime.Now, DateTimeKind.Local)
            };

            var inputJson = (new JavaScriptSerializer()).Serialize(input);
            PostData("SendMessage", inputJson, _sendSmsData.username, _sendSmsData.passwd);

        }

        public void PostData(string method, string inputJson, string userName, string password)
        {
            var client = new RestClient("http://smspanel.trez.ir/api/smsAPI/SendMessage/");
            var request = new RestRequest(Method.POST);
            var token = new SendSms().Base64Encode(userName + ":" + password);

            request.AddHeader("Authorization", $"Basic {token}");
            //var body = new StringContent(inputJson, Encoding.UTF8, "application/json");
            //var jsonBody = new JavaScriptSerializer().Serialize(body);
            request.AddJsonBody(inputJson);


            var restResponse = client.Execute(request);
        }
    }
}
