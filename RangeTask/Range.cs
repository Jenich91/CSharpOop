namespace RangeTask
{
    public class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range)
        {
            if (From < range.To && To > range.From)
            {
                if (From < range.From && To > range.To)
                {
                    return new Range(range.From, range.To);
                }

                if (range.To > To && range.From < From)
                {
                    return new Range(From, To);
                }

                double minValueFrom = From < range.From ? From : range.From;

                if (minValueFrom == From)
                {
                    return new Range(range.From, To);
                }

                return new Range(From, range.To);
            }

            return null;
        }

        public bool IsContinuousInterval(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                return true;
            }

            return false;
        }

        public Range[] GetUnion(Range range)
        {
            Range[] unionArray;

            if (From <= range.To && To >= range.From)
            {
                unionArray = new Range[0];

                double minFrom = From < range.From ? From : range.From;
                double maxTo = To > range.To ? To : range.To;
                unionArray[0] = new Range(minFrom, maxTo);

                return unionArray;
            }

            unionArray = new Range[2];

            unionArray[0] = new Range(From, To);
            unionArray[1] = new Range(range.From, range.To);

            return unionArray;
        }

        public bool IsContinuousIntervalAfterDifference(Range range)
        {
            if (range.From < From || range.To > To)
            {
                return true;
            }

            return false;
        }

        public Range[] GetDifferenceArray(Range range)
        {
            Range[] differenceArray = new Range[0];

            if (range.From < From || range.To > To)
            {
                if (GetIntersection(range) != null)
                {
                    double minValueFrom = From < range.From ? From : range.From;
                    if (minValueFrom == From)
                    {
                        differenceArray[0] = new Range(From, range.From);
                        return differenceArray;
                    }

                    differenceArray[0] = new Range(range.From, From);
                    return differenceArray;
                }

                return null;
            }

            differenceArray = new Range[2];

            differenceArray[0] = new Range(From, range.From - 1);
            differenceArray[1] = new Range(range.To + 1, To);

            return differenceArray;
        }
    }
}
