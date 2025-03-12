namespace ReserveIO.Models
{
	public class UserLogPass
	{
		/// <summary>
		/// Id пользователя
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// логин
		/// </summary>
		public string Login { get; set; }

		/// <summary>
		/// пароль
		/// </summary>
		public string Password { get; set; }
	}
}
