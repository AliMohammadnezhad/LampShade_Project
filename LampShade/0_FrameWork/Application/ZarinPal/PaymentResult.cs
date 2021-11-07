namespace _0_FrameWork.Application.ZarinPal
{
    public class PaymentResult
    {
        public bool IsSuccessful { get; set; } = false;
        public string Message { get; set; }
        public string IssueTrackingNo { get; set; }

        public PaymentResult Succeeded( string issueTrackingNo)
        {
            IsSuccessful = true;
            IssueTrackingNo = issueTrackingNo;
            return this;
        }

        public PaymentResult Failed()
        {
            IsSuccessful = false;
            return this;
        }
    }
}