using Microsoft.WindowsAzure.MobileServices;
using XF.Atividade6.Infrastructure;

namespace XF.Atividade6.Repositories
{
    public class RepositoryBase
    {
        protected MobileServiceClient client;

        public MobileServiceClient CurrentClient
        {
            get { return client; }
        }

        public RepositoryBase()
        {
            client = new MobileServiceClient(Constants.ApplicationURL);
        }
    }
}
