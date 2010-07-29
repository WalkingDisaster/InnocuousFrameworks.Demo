using Lingual.Tests.Domain;

namespace Lingual.Tests.Fluent.Bdd
{
    public class account_service_test_context
    {
        public account_service_test_context()
        {
            Repository = new FakeAccountRepository();
            WatchListService = new FakeWatchListService();
            AccountService = new AccountService(Repository, WatchListService);
        }

        public long AccountId { get; set; }
        public Account Account { get; set; }
        public FakeAccountRepository Repository { get; private set; }
        public FakeWatchListService WatchListService { get; private set; }
        public AccountService AccountService { get; set; }
    }
}