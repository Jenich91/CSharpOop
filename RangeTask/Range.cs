namespace AcademIT.Vyatkin
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

        public Range GetIntersection(Range rangeB)
        {
            if (this.From < rangeB.To && this.To > rangeB.From)
            {
                if (this.To > rangeB.To)
                {
                    return new Range(rangeB.From, rangeB.To);
                }

                if (rangeB.To > this.To)
                {
                    return new Range(this.From, this.To);
                }

                double minValueFrom = this.From < rangeB.From ? this.From : rangeB.From;

                if (minValueFrom == this.From)
                {
                    return new Range(rangeB.From, this.To);
                }

                return new Range(this.From, rangeB.To);
            }

            return null;
        }

        public bool IsContinuousInterval(Range rangeB)
        {
            if (this.From <= rangeB.To && this.To >= rangeB.From)
            {
                return true;
            }

            return false;
        }

        public Range GetCombination(Range rangeB)
        {
            double minValueFrom = this.From < rangeB.From ? this.From : rangeB.From;
            double maxValueTo = this.To > rangeB.To ? this.To : rangeB.To;

            return new Range(minValueFrom, maxValueTo);
        }

        public Range[] GetCombinationArray(Range rangeB)
        {
            Range[] сombinationArray = new Range[2];

            сombinationArray[0] = new Range(this.From, this.To);
            сombinationArray[1] = new Range(rangeB.From, rangeB.To);

            return сombinationArray;
        }
        public bool IsContinuousIntervalAfterDifference(Range rangeB)
        {
            if (rangeB.From < this.From || rangeB.To > this.To)
            {
                return true;
            }

            return false;
        }

        public Range GetDifference(Range rangeB)
        {
            if (this.GetLength() - rangeB.GetLength() > 0)
            {
                double minValueFrom = this.From < rangeB.From ? this.From : rangeB.From;
                if (minValueFrom == this.From)
                {
                    return new Range(this.From, rangeB.From);
                }

                return new Range(rangeB.From, this.From);
            }

            return null;
        }

        public Range[] GetDifferenceArray(Range rangeB)
        {
            Range[] differenceArray = new Range[2];

            differenceArray[0] = new Range(this.From, rangeB.From - 1);
            differenceArray[1] = new Range(rangeB.To + 1, this.To);

            return differenceArray;
        }
    }
}