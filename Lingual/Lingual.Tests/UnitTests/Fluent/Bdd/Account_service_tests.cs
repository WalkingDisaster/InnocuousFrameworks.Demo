using System;
using Lingual.Fluent.Bdd;
using Lingual.Tests.Domain;
using Lingual.Tests.Fluent.Bdd;
using NUnit.Framework;

namespace Lingual.Tests.UnitTests.Fluent.Bdd
{
    public class Account_service_tests : Account_service_test_builder
    {
        public ISpecificationSource MyTest
        {
            get
            {
                return Given.an<account_service_test_context>()
                    .that(contains_an_account)
                    .which(has_a_positive_balance,
                           has_had_activity_in_the_last_year)
                    .but(is_on_a_watch_list)
                    .when(getting_the_account)
                    .then(the_account_status_should_be_frozen,
                          the_account_should_have_a_zero_balance,
                          the_account_should_have_an_activity_date_of_today)
                    /*.should(give_me_all_the_money)*/;
            }
        }

        protected void the_account_status_should_be_frozen(account_service_test_context context, Account account)
        {
            Assert.AreEqual(AccountStatuses.Frozen, account.Status);
        }

        protected void the_account_should_have_a_zero_balance(account_service_test_context context, Account account)
        {
            Assert.AreEqual(0m, account.TotalBalance);
        }

        protected void the_account_should_have_an_activity_date_of_today(account_service_test_context context, Account account)
        {
            Assert.AreEqual(DateTime.Today, account.LastActivityDate);
        }

        protected void give_me_all_the_money(account_service_test_context context, Account account)
        {
            Assert.Fail("Failed on purpose");
        }
    }
}