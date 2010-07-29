using Lingual.Adapters;
using NUnit.Framework;

namespace Lingual.Tests
{
    [TestFixture]
    public class OldFashionedUnitTests
    {
        [SetUp]
        public void Arrange()
        {
            // I would mock stuff here if I had anything to mock
        }

/*
        [Test]
        public void OneShouldNotBePrime()
        {
            VerifyThatIsPrime(1);
        }
*/

        [Test]
        public void TwoShouldBePrime()
        {
            VerifyThatIsPrime(2);
        }

        [Test]
        public void ThreeShouldBePrime()
        {
            VerifyThatIsPrime(3);
        }

        [Test]
        public void FiveShouldBePrime()
        {
            VerifyThatIsPrime(5);
        }

        [Test]
        public void SevenShouldBePrime()
        {
            VerifyThatIsPrime(7);
        }

        [Test]
        public void ElevenShouldBePrime()
        {
            VerifyThatIsPrime(11);
        }

/*
        [Test]
        public void TwentyShouldBePrime()
        {
            VerifyThatIsPrime(20);
        }
*/
        
        private static void VerifyThatIsPrime(int primeNumber)
        {
            if (primeNumber < 2)
                Assert.Fail("The prime number must be greater than one.");
            // we don't assert that the prime number is divisible by 1 or itself, because we get no metadata by doing this.  All numbers are divisble by 1 and themselves.
            var asDecimal = (decimal) primeNumber;
            for (var i = 2; i < primeNumber; i++)
            {
                var primeNumberDividedByI = asDecimal/i;
                Assert.AreNotEqual((int) primeNumberDividedByI, primeNumberDividedByI, string.Format("{0} is divisible by {1} and is therefore not prime.", primeNumber, i));
            }
        }
    }
}