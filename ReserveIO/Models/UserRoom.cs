namespace ReserveIO.Models
{
	/// <summary>
	/// Связь арендодателя с его помещениями
	/// </summary>
	public class UserRoom
	{
		/// <summary>
		/// ID связи пользователь-комната
		/// </summary>
		public int UserRoomId { get; set; }
		/// <summary>
		/// ID пользователя
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// ID комнаты
		/// </summary>
		public int RoomId { get; set; }
	}
}
