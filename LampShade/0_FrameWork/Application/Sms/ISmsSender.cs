namespace _0_FrameWork.Application.Sms
{
    public interface ISmsSender
    {
        void SendSms(string message, string mobile);
        void PostData(string method, string inputJson, string userName, string password);
    }
}
