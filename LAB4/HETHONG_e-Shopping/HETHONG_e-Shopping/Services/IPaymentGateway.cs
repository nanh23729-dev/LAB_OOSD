using EShopping.Models;

namespace EShopping.Services
{
    public interface IPaymentGateway
    {
        ServiceResult Authorize(TheTinDung the, decimal soTien);
    }

    // Giả lập dịch vụ thanh toán. Khi triển khai thật chỉ cần viết lớp mới implement IPaymentGateway
    public class MockPaymentGateway : IPaymentGateway
    {
        public ServiceResult Authorize(TheTinDung the, decimal soTien)
        {
            string so = the.SoThe.Replace(" ", "");

            if (so.EndsWith("0000"))
                return ServiceResult.Fail("Thẻ bị từ chối bởi dịch vụ thanh toán.");

            if (soTien > 100000000m)
                return ServiceResult.Fail("Thẻ không đủ khả năng thanh toán.");

            return ServiceResult.Ok("Thanh toán được chấp nhận.");
        }
    }
}