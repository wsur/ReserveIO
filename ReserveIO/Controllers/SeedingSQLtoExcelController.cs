using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReserveIO.Models;

namespace ReserveIO.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SeedingSQLtoExcelController : ControllerBase
	{
		readonly UsersContext usersContext;
		public SeedingSQLtoExcelController(UsersContext context)
		{
			usersContext = context;
		}

		/// <summary>
		/// Получаем данные и сохраняем их в excel файл
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns></returns>
		[HttpPost("[action]")]
		public async Task<ActionResult> Get(CancellationToken cancellationToken)
		{
			var workbook = new XLWorkbook();
			int index = 1;
			var worksheet = workbook.Worksheets.Add("CostHour");//имя сущности в виде имени листа excel
			var costHoursList = usersContext.CostHours.ToList();
			foreach (var costHour in costHoursList)
			{
				if(index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"CostId";
					worksheet.Cell("B" + index).Value = $"CostRoomId";
					worksheet.Cell("C" + index).Value = $"TimeStampTZ";
					worksheet.Cell("D" + index).Value = $"Cost";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = costHour.CostId;
					worksheet.Cell("B" + index).Value = costHour.CostRoomId;
					worksheet.Cell("C" + index).Value = costHour.TimeStampTZ;
					worksheet.Cell("D" + index).Value = costHour.Cost;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("Role");//имя сущности в виде имени листа excel
			var roleList = usersContext.Roles.ToList();
			foreach (var role in roleList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"RoleId";
					worksheet.Cell("B" + index).Value = $"RoleName";
					worksheet.Cell("C" + index).Value = $"Delete";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = role.RoleId;
					worksheet.Cell("B" + index).Value = role.RoleName;
					worksheet.Cell("C" + index).Value = role.Delete;
					if(index%2 == 1)
					{
						/*тест*/
						/*worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Almond;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Amaranth;*/
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;

			worksheet = workbook.Worksheets.Add("Room");//имя сущности в виде имени листа excel
			var roomList = usersContext.Rooms.ToList();
			foreach (var room in roomList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"RoomId";
					worksheet.Cell("B" + index).Value = $"RoomName";
					worksheet.Cell("C" + index).Value = $"ServiceOn";
					worksheet.Cell("D" + index).Value = $"OnOff";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = room.RoomId;
					worksheet.Cell("B" + index).Value = room.RoomName;
					worksheet.Cell("C" + index).Value = room.ServiceOn;
					worksheet.Cell("D" + index).Value = room.OnOff;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("Service");//имя сущности в виде имени листа excel
			var serviceList = usersContext.Services.ToList();
			foreach (var service in serviceList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"ServiceId";
					worksheet.Cell("B" + index).Value = $"UserId";
					worksheet.Cell("C" + index).Value = $"ServiceName";
					worksheet.Cell("D" + index).Value = $"ServiceCost";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = service.ServiceId;
					worksheet.Cell("B" + index).Value = service.UserId;
					worksheet.Cell("C" + index).Value = service.ServiceName;
					worksheet.Cell("D" + index).Value = service.ServiceCost;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("ServiceInfo");//имя сущности в виде имени листа excel
			var serviceInfoList = usersContext.ServiceInfos.ToList();
			foreach (var serviceInfo in serviceInfoList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"Id";
					worksheet.Cell("B" + index).Value = $"ServiceId";
					worksheet.Cell("C" + index).Value = $"ReserveId";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = serviceInfo.Id;
					worksheet.Cell("B" + index).Value = serviceInfo.ServiceId;
					worksheet.Cell("C" + index).Value = serviceInfo.ReserveId;
					if(index%2 == 1)
					{
						//нечётные ячейки красим
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Almond;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Almond;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Almond;
					}
				
				}
				index++;
			}
			index = 1;

			worksheet = workbook.Worksheets.Add("SummaryTables");//имя сущности в виде имени листа excel
			var summaryTableList = usersContext.SummaryTables.ToList();
			foreach (var summaryTable in summaryTableList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"SummaryId";
					worksheet.Cell("B" + index).Value = $"LesseeId";
					worksheet.Cell("C" + index).Value = $"RoomId";
					worksheet.Cell("D" + index).Value = $"Datetime";
					worksheet.Cell("F" + index).Value = $"EndTime";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Almond;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Amaranth;
					worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.Almond;
					worksheet.Cell("F" + index).Style.Fill.BackgroundColor = XLColor.Almond;
				}
				else
				{
					worksheet.Cell("A" + index).Value = summaryTable.SummaryId;
					worksheet.Cell("B" + index).Value = summaryTable.LesseeId;
					worksheet.Cell("C" + index).Value = summaryTable.RoomId;
					worksheet.Cell("D" + index).Value = summaryTable.Datetime;
					worksheet.Cell("F" + index).Value = summaryTable.EndTime;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("F" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("User");//имя сущности в виде имени листа excel
			var userList = usersContext.Users.ToList();
			foreach (var user in userList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"UserId";
					worksheet.Cell("B" + index).Value = $"Name";
					worksheet.Cell("C" + index).Value = $"Age";
					worksheet.Cell("D" + index).Value = $"Delete";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = user.UserId;
					worksheet.Cell("B" + index).Value = user.Name;
					worksheet.Cell("C" + index).Value = user.Age;
					worksheet.Cell("D" + index).Value = user.Delete;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("D" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}

				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("UserLogPass");//имя сущности в виде имени листа excel
			var userLogPassList = usersContext.UserLogPasses.ToList();
			foreach (var userLogPass in userLogPassList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"UserId";
					worksheet.Cell("B" + index).Value = $"Login";
					worksheet.Cell("C" + index).Value = $"Password";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = userLogPass.UserId;
					worksheet.Cell("B" + index).Value = userLogPass.Login;
					worksheet.Cell("C" + index).Value = userLogPass.Password;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("UserRole");//имя сущности в виде имени листа excel
			var userRoleList = usersContext.UserRoles.ToList();
			foreach (var userRole in userRoleList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"UserRoleId";
					worksheet.Cell("B" + index).Value = $"UserId";
					worksheet.Cell("C" + index).Value = $"RoleId";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = userRole.UserRoleId;
					worksheet.Cell("B" + index).Value = userRole.UserId;
					worksheet.Cell("C" + index).Value = userRole.RoleId;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;


			worksheet = workbook.Worksheets.Add("UserRoom");//имя сущности в виде имени листа excel
			var userRoomList = usersContext.UserRooms.ToList();
			foreach (var userRoom in userRoomList)
			{
				if (index == 1)
				{
					//имена столбцов
					worksheet.Cell("A" + index).Value = $"UserRoomId";
					worksheet.Cell("B" + index).Value = $"UserId";
					worksheet.Cell("C" + index).Value = $"RoomId";
					worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
					worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.Bisque;
				}
				else
				{
					worksheet.Cell("A" + index).Value = userRoom.UserRoomId;
					worksheet.Cell("B" + index).Value = userRoom.UserId;
					worksheet.Cell("C" + index).Value = userRoom.RoomId;
					if (index % 2 == 1)
					{
						worksheet.Cell("A" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("B" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
						worksheet.Cell("C" + index).Style.Fill.BackgroundColor = XLColor.AirForceBlue;
					}
				}
				index++;
			}
			index = 1;
			workbook.SaveAs("Test.xlsx");
			return Ok();
		}

/*		public string Get_Field_By_Id(string table_Name, string field_Name, string PK_val)
		{
		
			return Convert.ToString(usersContext.GetColumnById(table_Name, field_Name, PK_val));
		}*/
	}


}
