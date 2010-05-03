using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace uSwitch.Energy.Silverlight.Model
{
	public struct TimePeriod
	{
		public const string OneMonth = "1 Month";
		public const string ThreeMonth = "3 Months";
		public const string SixMonth = "6 Months";
		public const string OneYear = "1 Year";

		public static IEnumerable<string> GetAll()
		{
			return new[] {OneMonth, ThreeMonth, SixMonth, OneYear};
		}

		public static double CalculateCostOverMonth(string period, double amount)
		{
			switch (period)
			{
				case OneMonth:
					return amount;
				case ThreeMonth:
					return amount/3;
				case SixMonth:
					return amount/6;
				case OneYear:
					return amount/12;
			}

			throw new ArgumentOutOfRangeException("period", "Period not reconised");
		}

		public static double CalculateKwhOverMonth(string period, double amount)
		{
			switch (period)
			{
				case OneMonth:
					return amount;
				case ThreeMonth:
					return amount / 3;
				case SixMonth:
					return amount / 6;
				case OneYear:
					return amount / 12;
			}

			throw new ArgumentOutOfRangeException("period", "Period not reconised");
		}
	}
}
