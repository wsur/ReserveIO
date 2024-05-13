namespace ReserveIO.Models
{
	public class SummaryTable
	{
		public int SummaryId { get; set; }

		public int LesseeId { get; set; }

		public int RoomId { get; set; }

		public DateTime Datetime { get; set; }

		public DateTime EndTime { get; set; }
	}
}
