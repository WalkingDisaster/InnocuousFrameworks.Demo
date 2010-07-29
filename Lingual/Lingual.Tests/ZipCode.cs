using System;

namespace Something.Domain.Demographic
{
    public struct ZipCode
    {
        private readonly int _zip;
        private readonly int? _plusFour;

        public ZipCode(int zip)
        {
            _zip = zip;
            _plusFour = null;
        }

        public ZipCode(int zip, int plusFour)
        {
            _zip = zip;
            _plusFour = plusFour;
        }

        public int Zip { get { return _zip; } }

        public int? PlusFour { get { return _plusFour; } }

        public static ZipCode Parse(string zip)
        {
            return new ZipCode(int.Parse(zip));
        }

        public override string ToString()
        {
            return Zip.ToString();
        }

        public static implicit operator ZipCode(string zip)
        {
            return ZipCode.Parse(zip);
        }
    }
}