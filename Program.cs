using System;

namespace TimeSpanClashFinder
{
	class Program
	{
		static void Main(string[] args)
		{
			ClashFinder clashFinder = new ClashFinder();

            for (int i = 0; i < 3; i++)
			{
				clashFinder.bookingStart = new TimeSpan(9, 15, 00);
                clashFinder.bookingEnd = new TimeSpan(13, 15, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(14, 00, 00);
                clashFinder.bookingEnd = new TimeSpan(16, 00, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(13, 15, 00);
                clashFinder.bookingEnd = new TimeSpan(15, 15, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(12, 30, 00);
                clashFinder.bookingEnd = new TimeSpan(14, 30, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(14, 30, 00);
                clashFinder.bookingEnd = new TimeSpan(16, 30, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(15, 00, 00);
                clashFinder.bookingEnd = new TimeSpan(17, 00, 00);
                clashFinder.FindClashes();

                clashFinder.bookingStart = new TimeSpan(15, 30, 00);
                clashFinder.bookingEnd = new TimeSpan(17, 30, 00);
                clashFinder.FindClashes();

				clashFinder.bookingStart = new TimeSpan(10, 30, 00);
                clashFinder.bookingEnd = new TimeSpan(12, 00, 00);
                clashFinder.FindClashes();

				clashFinder.bookingStart = new TimeSpan(13, 30, 00);
                clashFinder.bookingEnd = new TimeSpan(15, 30, 00);
                clashFinder.FindClashes();

				clashFinder.slotStart = clashFinder.slotStart + TimeSpan.FromHours(2.5);
			}

		}
	}

	public class ClashFinder
	{
		public TimeSpan bookingStart = new TimeSpan(11, 30, 00);
		public TimeSpan bookingEnd = new TimeSpan(12, 00, 00);
		public TimeSpan slotStart = new TimeSpan(9, 00, 00);

		public ClashFinder(){
		}

        public void FindClashes()
		{
			var twoResult = ClashCalculator(2);
			var fourResult = ClashCalculator(4);
			var sixResult = ClashCalculator(6);

			Console.WriteLine(string.Format("{0} durations available: {1} {2} {3}", slotStart,
			                                twoResult ? " " : "2",
			                                fourResult ? " " : "4",
			                                sixResult ? " " : "6"
			                               ));
			Console.WriteLine("---");         
		}

        private bool ClashCalculator(int duration)
		{
			TimeSpan slotEnd = slotStart + TimeSpan.FromHours((double)duration);

			bool overlap = slotStart < bookingEnd && bookingStart < slotEnd;

            /*if(overlap)
			{
				overlap = FindLargestDuration(duration);
			}*/

			return overlap;
		}

        private bool FindLargestDuration(int duration)
		{
			TimeSpan slotEnd = slotStart + TimeSpan.FromHours(2.5);

			TimeSpan durationBeginning = bookingStart.Subtract(slotStart);
			TimeSpan durationEnding = slotEnd.Subtract(bookingEnd);

			/*if(durationBeginning >= new TimeSpan(2, 0, 0))
			{
				return true;
			}*/

			if(durationEnding >= new TimeSpan(duration, 0, 0))
			{
				return false;
			}

			return true;
		}
	}
}
