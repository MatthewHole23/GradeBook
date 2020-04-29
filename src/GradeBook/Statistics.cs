using System;

namespace GradeBook
{
	public class Statistics
	{
		// Defining the fields and properties of Statistics
		// read only property
		public double Average
		{
			get
			{
				return Sum / Count;
			}
		}

		public double High;
		public double Low;
		public char Letter
		{
			get
			{
				switch (Average)
            	{
                case var d when d >= 90.0:
                    return 'A';
                    

                case var d when d >= 80.0:
                    return 'B';

                case var d when d >= 70.0:
                    return 'C';

                case var d when d >= 60.0:
                    return 'D';

                default:
                    return 'F';

            	}
			}
		}
		public double Sum;
		public int Count;
		

		// creating the method 'Add' which takes in a number and used the properties/fields and assigns values to them
		public void Add(double number)
		{
			Sum += number;
			Count++;
			Low = Math.Min(number, Low);
            High = Math.Max(number, High);
		}

		// creating a constructor for a Statistics object which when instantiating has these default values
		public Statistics()
		{
			Count = 0;
			Sum = 0.0;
            High = 0.0;
            Low = 100.0;
		}
	}

}
