namespace ReserveIO.Models
{
	public class CostHour
	{
		/// <summary>
		/// ID записи стоймости
		/// </summary>
		public int CostId { get; set; }

		/// <summary>
		/// ID комнаты
		/// </summary>
		public int CostRoomId { get; set; }

		/// <summary>
		/// Время начала бронирования
		/// </summary>
		public DateTime TimeStampTZ { get; set; }

		/// <summary>
		/// Цена
		/// </summary>
		public int Cost { get; set; }

	}
}
