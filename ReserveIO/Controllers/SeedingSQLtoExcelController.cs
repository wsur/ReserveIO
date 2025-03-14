﻿using ClosedXML.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
		[Authorize(Roles = "Owner")]
		[HttpGet("[action]")]
		public async Task<IActionResult> Get(CancellationToken cancellationToken)
		{
			var workbook = new XLWorkbook();
			IXLWorksheet worksheet = null;//сделано специально, т.к. таблица инициализируется во вложенном цикле.
			var collection = usersContext.GetCollection();
			var tableNames = usersContext.GetTableNamesCollection();
			var tablePropertyNamesCollection = usersContext.GetTablePropertyNamesCollection();
			int element = 0;
			foreach (var items in collection)
			{
				if (!items.Any())
				{
					worksheet = workbook.Worksheets.Add(tableNames[element]);//название листа, у которого нет сущностей
					var tableCellIndex = 1;
					//перечисляем все свойства в данной таблице
					foreach (var property in tablePropertyNamesCollection[element])
					{
						worksheet.Cell(1, tableCellIndex).Value = property.Name;
						worksheet.Cell(1, tableCellIndex).Style.Fill.SetBackgroundColor(XLColor.Bisque);
						tableCellIndex++;
					}
					element++;//переход на обработку сл элемента
					continue;//защита от null-значений, когда коллекция пуста
				}
				worksheet = workbook.Worksheets.Add(tableNames[element]);//название листа
				var tableRowIndex = 1;
				//отдельная запись/строка в бд
				foreach (var it in items)
				{
					var properties = it.GetType().GetProperties();
					//сначала напишем названия свойств и их значения
					var tableCellIndex = 1;
					foreach (var prop in properties)
					{
						if (tableRowIndex == 1)
						{
							worksheet.Cell(tableRowIndex, tableCellIndex).Value = prop.Name;//название свойства
							worksheet.Cell(tableRowIndex, tableCellIndex).Style.Fill.SetBackgroundColor(XLColor.Bisque);
							worksheet.Cell(tableRowIndex + 1, tableCellIndex).Value = prop.GetValue(it)?.ToString();//Первое значения объекта
						}
						else
						{
							worksheet.Cell(tableRowIndex + 1, tableCellIndex).Value = prop.GetValue(it)?.ToString();
						}
						//покраска нечётных строк
						if (tableRowIndex % 2 == 1 && tableRowIndex != 1)
						{
							worksheet.Cell(tableRowIndex, tableCellIndex).Style.Fill.SetBackgroundColor(XLColor.AirForceBlue);
						}
						tableCellIndex++;//переход в сл. колонку
					}
					tableRowIndex++;
				}
				element++;
			}

			using (var stream = new MemoryStream())
			{
				workbook.SaveAs(stream);
				var content = stream.ToArray();

				return File(
					content,
					"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
					"dataDB.xlsx");
			}
		}
	}


}
