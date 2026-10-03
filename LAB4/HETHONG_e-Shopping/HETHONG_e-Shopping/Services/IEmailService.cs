using System.Diagnostics;

namespace EShopping.Services
{
    public interface IEmailService
    {
        void Gui(string den, string tieuDe, string noiDung);
    }

    // Giả lập: in ra cửa sổ Output của Visual Studio
    public class MockEmailService : IEmailService
    {
        public void Gui(string den, string tieuDe, string noiDung)
        {
            Debug.WriteLine("Gui email toi: " + den);
            Debug.WriteLine(tieuDe);
            Debug.WriteLine(noiDung);
        }
    }
}