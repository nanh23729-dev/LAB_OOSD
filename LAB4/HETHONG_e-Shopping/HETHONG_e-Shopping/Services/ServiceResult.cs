namespace EShopping.Services
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }

        public static ServiceResult Ok(string message, int id = 0)
        {
            ServiceResult r = new ServiceResult();
            r.Success = true;
            r.Message = message;
            r.Id = id;
            return r;
        }

        public static ServiceResult Fail(string message)
        {
            ServiceResult r = new ServiceResult();
            r.Success = false;
            r.Message = message;
            return r;
        }
    }
}