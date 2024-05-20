namespace ReserveIO.Models
{
	public class Room
	{
		/// <summary>
		/// ID помещения
		/// </summary>
		public int RoomId { get; set; }

		/// <summary>
		/// Имя помещения
		/// </summary>
		public string RoomName { get; set; }

		/// <summary>
		/// Доступность для съёма
		/// </summary>
		public bool OnOff { get; set; }

		/// <summary>
		/// Можно ли добавлять сервисы
		/// </summary>
		public bool ServiceOn { get; set; }
	}
}
