namespace ReserveIO.Models
{
	//[EntityTypeConfiguration(typeof(RoleConfiguration))]
	public class Role
	{
		/// <summary>
		/// ID Роли
		/// </summary>
		public int RoleId { get; set; }

		/// <summary>
		/// Роль
		/// </summary>
		public string RoleName { get; set; }

		/// <summary>
		/// Удалена ли из сервиса
		/// </summary>
		public bool Delete { get; set; }
	}
}
