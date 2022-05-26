using System;
using System.Globalization;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
			ISeries series1 = new GeometricProgression(1,2);
			IIndexableSeries series2 = new ArithmeticalProgression(2, 2);

			PrintSeries(series1);
            Console.WriteLine("\n");
			OutputElement(series2, 5);
        }
		
		static void PrintSeries(ISeries series)
		{
			series.Reset();

			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine(series.GetCurrent());
				series.MoveNext();
			}
		}

		static void OutputElement(IIndexableSeries series, int index)
        {
			PrintSeries(series);
			Console.WriteLine("\n");
			Console.WriteLine(series[index]);
        }
	}
}
