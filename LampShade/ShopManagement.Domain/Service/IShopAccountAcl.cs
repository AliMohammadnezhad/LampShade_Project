namespace ShopManagement.Domain.Service
{
    public interface IShopAccountAcl
    {
        (string FullName, string Mobile) GetAccountForSendSmsBy(long id);
    }
}
