using System;
using System.Net;

namespace TestNinja.Mocking
{
    public interface IInstallerHerlperRepo
    {
        bool DownloadInstaller(string customerName, string installerName);
    }

    public class InstallerHerlperRepo : IInstallerHerlperRepo
    {
        private string _setupDestinationFile;
        public bool DownloadInstaller(string customerName, string installerName)
        {
            var client = new WebClient();
            try
            {
                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    _setupDestinationFile);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
