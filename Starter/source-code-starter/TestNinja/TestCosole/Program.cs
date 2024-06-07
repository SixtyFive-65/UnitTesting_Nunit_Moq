using TestNinja.Mocking;

namespace TestNinja
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var repo = new InstallerHelper(new InstallerHerlperRepo());

            var data = repo.DownloadInstaller("customerName", "installer");
        }
    }
}
