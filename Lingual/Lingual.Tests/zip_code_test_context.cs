using Something.Domain.Demographic;

namespace Lingual.Tests
{
    public class zip_code_test_context : TestContext
    {
        private string _stringToParse;

        public void has_this_string(string zip)
        {
            _stringToParse = zip;
        }

        public ZipCode parse_zip_code()
        {
            return ZipCode.Parse(_stringToParse);
        }

        public ZipCode implicitly_cast_string_to_zip_code()
        {
            return _stringToParse;
        }
    }
}