using System;

namespace Task2
{
	public static class InterfacesDemo
	{
		public static void DemoMain()
		{
			ISeries progression = new ArithmeticalProgression(2, 2);
			Console.WriteLine("Progression:");
			PrintSeries(progression);

			ISeries list = new List(new double[] { 5, 8, 6, 3, 1 });
			Console.WriteLine("List:");
			PrintSeries(list);
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
	}

	public interface ISeries
	{
		double GetCurrent();
		bool MoveNext();
		void Reset();
	}

	public class ArithmeticalProgression : IIndexableSeries
	{
		double start, step;
		int currentIndex;

		public ArithmeticalProgression(double start, double step)
		{
			this.start = start;
			this.step = step;
			this.currentIndex = 1;
		}

		public double GetCurrent()
		{
			return start + step * currentIndex;
		}

		public bool MoveNext()
		{
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentIndex = 1;
		}

		public double this[int index]
		{
			get
			{
				return start + step * index;
			}
		}
	}

	public class GeometricProgression : ISeries
	{
		double start;
		double denominator;
		int currentIndex;
		double currentValue;

		public GeometricProgression(double start, double denominator)
		{
			if (start != 0 && denominator != 0)
			{
				this.start = start;
				this.denominator = denominator;
				this.currentValue = start;
				this.currentIndex = 1;
			}
			else
			{
				throw new Exception("Invalid value");
			}
		}

		public double GetCurrent()
		{
			return currentValue * denominator;
		}

		public bool MoveNext()
		{
			currentValue *= denominator;
			currentIndex++;
			return true;
		}

		public void Reset()
		{
			currentValue = start;
			currentIndex = 1;
		}
	}

	public class List : IIndexableSeries
	{
		private double[] series;
		private int currentIndex;

		public List(double[] series)
		{
			this.series = series;
			currentIndex = 0;
		}

		public double GetCurrent()
		{
			return series[currentIndex];
		}

		public bool MoveNext()
		{
			currentIndex = currentIndex < series.Length - 1 ? currentIndex + 1 : 0;
			return true;
		}

		public void Reset()
		{
			currentIndex = 0;
		}

        public double this[int index]
		{
			get { return series[index]; }
		}
	}

	public interface IIndexable
	{
		double this[int index] { get; }
	}

	interface IIndexableSeries : ISeries, IIndexable
	{
	}
}
