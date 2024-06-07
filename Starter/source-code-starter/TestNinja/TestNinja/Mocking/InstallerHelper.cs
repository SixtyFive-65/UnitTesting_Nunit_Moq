using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private readonly IInstallerHerlperRepo _repo;

        public InstallerHelper()
        {
            
        }
        public InstallerHelper(IInstallerHerlperRepo repo)
        {
            _repo = repo;
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            try
            {
                return _repo.DownloadInstaller(customerName, installerName);
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }
}