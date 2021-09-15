using System;

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

                if (Math.Min(From, range.From) == From)
                {
                    return new Range(range.From, To);
                }

                return new Range(From, range.To);
            }

            return null;
        }

        public Range[] GetUnion(Range range)
        {
            if (From <= range.To && To >= range.From)
            {
                return new Range[] { new Range(Math.Min(From, range.From), Math.Max(To, range.To)) };
            }

            return new Range[] { new Range(From, To), new Range(range.From, range.To) };
        }

        public Range[] GetDifference(Range range)
        {
            if (range.From < From || range.To > To)
            {
                if (GetIntersection(range) != null)
                {
                    if (Math.Min(From, range.From) == From)
                    {
                        return new Range[] { new Range(From, range.From) };
                    }

                    return new Range[] { new Range(range.From, From) };
                }

                return null;
            }

            return new Range[] { new Range(From, range.From), new Range(range.To, To) };
        }

        public override string ToString()
        {
            return $"({From};{To})";
        }

        public static double FindDistanceBetweenRanges(Range range1, Range range2)
        {
            if (range1.GetIntersection(range2) == null)
            {
                if (Math.Min(range1.From, range2.From) == range1.From)
                {
                    return Math.Min(range2.From - range1.To, range2.To - range1.From);
                }

                return Math.Min(range1.From - range2.To, range1.To - range2.From);
            }

            return 0;
        }
    }
}