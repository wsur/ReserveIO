namespace ReserveIO.Models
{
	public class SummaryTable
	{
		/// <summary>
		/// ID записи
		/// </summary>
		public int SummaryId { get; set; }

		/// <summary>
		/// ID пользователя
		/// </summary>
		public int LesseeId { get; set; }

		/// <summary>
		/// ID комнаты
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		/// Время начала бронирования
		/// </summary>
		public DateTime Datetime { get; set; }

		/// <summary>
		/// Время конца бронирования
		/// </summary>
		public DateTime EndTime { get; set; }
	}
}
