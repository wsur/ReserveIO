namespace ReserveIO.Models
{
	public class Service
	{
		/// <summary>
		/// ID сервиса
		/// </summary>
		public int ServiceId { get; set; }

		/// <summary>
		/// ID пользователя
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Имя сервиса
		/// </summary>
		public string ServiceName { get; set; }

		/// <summary>
		/// Стоймость сервиса
		/// </summary>
		public float ServiceCost { get; set; }
	}
}
