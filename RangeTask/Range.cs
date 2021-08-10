namespace AcademIT.Vyatkin
{
    class Range
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
                Range intersection = new Range(rangeB.From, this.To);

                return intersection;
            }

            return null;
        }

        public bool IsContinuousInterval(Range rangeB)
        {
            if (this.To >= rangeB.From && this.From <= rangeB.To)
            {
                return true;
            }

            return false;
        }

        public Range GetCombination(Range rangeB)
        {
            if (this.From <= rangeB.From)
            {
                return new Range(this.From, rangeB.To);
            }

            return new Range(rangeB.From, this.To);
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
            if (this.From < rangeB.To && this.To > rangeB.From)
            {
                double minValueFrom = this.From < rangeB.From ? this.From : rangeB.From;
                if(minValueFrom == this.From)
                {
                    return new Range(rangeB.From, this.To);
                }
                
                return new Range(rangeB.To, this.To);
            }

            return null;
        }

        public Range[] GetDifferenceArray(Range rangeB)
        {
            Range[] differenceArray = new Range[2];

            differenceArray[0] = new Range(this.From, rangeB.From);
            differenceArray[1] = new Range(rangeB.To, this.To);

            return differenceArray;
        }
    }
}