namespace Number
{
    public sealed class RationalNumber : IComparable
    {
        int _numerator;
        int _denominator;

        public RationalNumber(int numerator, int denominator)
        {
            if (denominator <= 0)
            {
                throw new ArgumentException("Denominator cannot less or equal to zero.");
            }

            int gcd = GCD(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;

        }

        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public int Numerator { get => _numerator; private set => _numerator = value; }
        public int Denominator { get => _denominator; private set => _denominator = value; }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object? obj)
        {
            if (obj is RationalNumber)
            {
                RationalNumber other = obj as RationalNumber;
                return Numerator == other.Numerator && Denominator == other.Denominator;
            }

            return false;
        }

        public int CompareTo(object? obj)
        {
            if (obj is RationalNumber)
            {
                double current = (double)this.Numerator / this.Denominator);
                double other = (double)(obj as RationalNumber).Numerator / (obj as RationalNumber).Denominator;
                
                return current.CompareTo(other);
            }

            return -1;
        }


        public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        }

        public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
        {
            return new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        }

        public static explicit operator double(RationalNumber r)
        {
            return (double)r.Numerator / r.Denominator;
        }

        public static implicit operator RationalNumber(int i)
        {
            return new RationalNumber(i, 1);
        }
    }
}
