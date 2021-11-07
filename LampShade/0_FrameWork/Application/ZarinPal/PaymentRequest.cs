namespace _0_FrameWork.Application.ZarinPal
{
    public class PaymentRequest
    {
        public string[] metadata { get;set; }
        public string CallbackURL { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public string MerchantID { get; set; }
    }
}
