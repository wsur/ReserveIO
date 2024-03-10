using Microsoft.AspNetCore.Mvc;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UsersController : ControllerBase
	{
		public UsersController(UsersContext context) 
		{
			db = context;
			if (!DBNull.Users.Any())
			{

			}

		}
	}
}
