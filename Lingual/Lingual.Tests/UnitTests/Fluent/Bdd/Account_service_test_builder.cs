using System;
using Lingual.Tests.Domain;

namespace Lingual.Tests.Fluent.Bdd
{
    public abstract class Account_service_test_builder
    {
        protected void contains_an_account(account_service_test_context context)
        {
            context.AccountId = 1234;
            context.Account = new Account
                                  {
                                      Id = context.AccountId
                                  };
            context.Repository.Accounts.Add(context.AccountId, context.Account);
        }

        protected void has_a_positive_balance(account_service_test_context context)
        {
            context.Account.TotalBalance = 100;
        }

        protected void has_had_activity_in_the_last_year(account_service_test_context context)
        {
            context.Account.LastActivityDate = DateTime.Today.Subtract(TimeSpan.FromDays(5));
        }

        protected void is_on_a_watch_list(account_service_test_context context)
        {
            context.WatchListService.Answer = true;
        }

        protected Account getting_the_account(account_service_test_context context)
        {
            return context.AccountService.GetAccount(context.AccountId);
        }
    }
}