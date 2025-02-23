namespace ReserveIO.Models
{
	/// <summary>
	/// Связь между заказом пользователя и предоставляемыми сервисами
	/// </summary>
	public class ServiceInfo
	{
		/// <summary>
		/// ID записи
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// ID сервиса
		/// </summary>
		public int ServiceId { get; set; }
						
		/// <summary>
		/// ID заказа
		/// </summary>
		public int ReserveId { get; set; }

	}
}
