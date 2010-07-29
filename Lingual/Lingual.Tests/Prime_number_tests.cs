using System.Collections.Generic;
using NBehave.Spec.NUnit;

namespace Lingual.Tests
{
    public class Prime_number_tests
    {
        private ITestSource GetPrimeTests(int primeNumber)
        {
            return new SimpleTestSource(new TestContext
                                            {
                                                ArrangeDescription = "Given the number" + primeNumber,
                                                ActDescription = "",
                                                Tests = GenerateTests(primeNumber)
                                            });
        }

        private IEnumerable<TestInformation> GenerateTests(int primeNumber)
        {
            var asDecimal = (decimal) primeNumber;
            var tests = new List<TestInformation>(primeNumber)
                            {
                                new TestInformation
                                    {
                                        AssertDescription = "it should be greater than 1.",
                                        SortableName =
                                            string.Format("Prime number {0} should be greater than 1.", primeNumber),
                                        Test = () => primeNumber.ShouldBeGreaterThan(1)
                                    },
                                new TestInformation
                                    {
                                        AssertDescription = "it should be divisible by itself.",
                                        SortableName = string.Format("Divide prime number {0} by itself", primeNumber),
                                        Test = () => (asDecimal/primeNumber).ShouldEqual((int) (asDecimal/primeNumber))
                                    }
                            };
            if (primeNumber > 1)
            {
                tests.Add(new TestInformation
                              {
                                  AssertDescription = "it should be divisible by the number 1.",
                                  SortableName = string.Format("Divide prime number {0} by 1", primeNumber),
                                  Test = () => (asDecimal/1).ShouldEqual((int) (asDecimal/1))
                              });
            }
            if (primeNumber > 2)
            {
                for (var i = 2; i < primeNumber; i++)
                {
                    var primeNumberDividedByI = asDecimal / i;
                    tests.Add(new TestInformation
                                  {
                                      AssertDescription = "it should not be divisible by the number " + i + ".",
                                      SortableName = string.Format("Divide prime number {0} by {1}", primeNumber, i),
                                      Test = () => primeNumberDividedByI.ShouldNotEqual((int) primeNumberDividedByI)
                                  });
                }
            }
            return tests;
        }

/*
        public ITestSource The_number_1_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(1);
            }
        }
*/

        public ITestSource The_number_2_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(2);
            }
        }

        public ITestSource The_number_3_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(3);
            }
        }

        public ITestSource The_number_5_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(5);
            }
        }

        public ITestSource The_number_7_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(7);
            }
        }

        public ITestSource The_number_11_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(11);
            }
        }

/*
        public ITestSource The_number_20_is_a_prime_number
        {
            get
            {
                return GetPrimeTests(20);
            }
        }
*/
    }
}