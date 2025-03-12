namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(UserConfiguration))]
	public class User
	{
		/// <summary>
		/// ID пользователя
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Имя пользователя
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Возраст
		/// </summary>
		public int Age { get; set; }
		
		/// <summary>
		/// Удалена ли учётная запись
		/// </summary>
		public bool Delete { get; set; }//состояние удалён ли пользователь или нет
	}
}
