using Lingual.Fluent.Bdd;
using NBehave.Spec.NUnit;
using Something.Domain.Demographic;

namespace Lingual.Tests
{
    public class Parse_zip_code_from_a_valid_short_string
    {
        protected const string valid_short_zip_code = "12345";
        protected const int valid_zip = 12345;
        protected const string valid_zip_code_string = valid_short_zip_code;

        protected ZipCode parsing_the_string_to_zip_code(zip_code_test_context context)
        {
            return context.parse_zip_code();
        }

        protected ZipCode making_a_zip_code_from_a_string(zip_code_test_context context)
        {
            return context.implicitly_cast_string_to_zip_code();
        }

        protected void is_a_valid_short_zip_code_string(zip_code_test_context context)
        {
            context.has_this_string(valid_short_zip_code);
        }

        public ISpecificationSource Parse_a_valid_short_zip_code_string
        {
            get
            {
                return Given.a<zip_code_test_context>()
                    .that(is_a_valid_short_zip_code_string)
                    .when(parsing_the_string_to_zip_code)
                    .then(the_first_part_of_the_zip_code_should_be_as_expected,
                          the_second_part_of_the_zip_code_should_be_null,
                          the_zip_code_prints_correctly);
            }
        }

        public ISpecificationSource Implicitly_cast_short_zip_code_string_to_zip_code
        {
            get
            {
                return Given.a<zip_code_test_context>()
                    .that(is_a_valid_short_zip_code_string)
                    .when(making_a_zip_code_from_a_string)
                    .then(the_first_part_of_the_zip_code_should_be_as_expected,
                          the_second_part_of_the_zip_code_should_be_null,
                          the_zip_code_prints_correctly);
            }
        }

        public void the_first_part_of_the_zip_code_should_be_as_expected(zip_code_test_context context, ZipCode zipCode)
        {
            zipCode.Zip.ShouldEqual(valid_zip);
        }

        public void the_second_part_of_the_zip_code_should_be_null(zip_code_test_context context, ZipCode zipCode)
        {
            zipCode.PlusFour.ShouldBeNull();
        }

        public void the_zip_code_prints_correctly(zip_code_test_context context, ZipCode zipCode)
        {
            zipCode.ToString().ShouldEqual(valid_zip_code_string);
        }
    }
}