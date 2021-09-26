using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace RosAtomDataBase.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        /// <summary>
        /// Возвращает данные для гиаграммы.
        /// </summary>
        [HttpPost]
        public IActionResult GetData([FromBody] Filter filter)
        {
            if(filter == null)
            {
                return BadRequest();
            }

            using var db = new EmployeeDbContext();
            var service = new Service();

            var employeses = db.Employees
                .Include(e => e.City)
                .Include(e => e.Gender)
                .Include(e => e.FamilyStatus)
                .Include(e => e.Position)
                .AsParallel()
                .Select(e => e)
                .Where(e => service.ApplyFilter(e, filter))
                .ToArray();

            var periods = db.Employees
                .AsParallel()
                .Select(e => e.Period)
                .Distinct()
                .ToList();

            periods.Sort();

            var dataByPeriod = new Dictionary<DateTime, Employee[]>();

            foreach (var period in periods)
            {
                dataByPeriod.Add(
                    period,
                    employeses.AsParallel().Where(e => e.Period == period).ToArray());
            }

            var monthlyAverage = new List<double>();

            switch (filter.SelectedParametr.ToLower())
            {
                case "возраст":
                    foreach (var data in dataByPeriod)
                    {
                        monthlyAverage.Add(
                            data.Value.Select(e => DateTime.Now - e.Birthdate).Average(e => e.Days));
                    }
                    break;

                case "зарплата":
                    foreach (var data in dataByPeriod)
                    {
                        monthlyAverage.Add(
                            data.Value.Average(e => e.Salary));
                    }
                    break;

                case "количество детей":
                    foreach (var data in dataByPeriod)
                    {
                        monthlyAverage.Add(
                            data.Value.Average(e => e.ChildrensNumber));
                    }
                    break;

                case "опыт работы":
                    foreach (var data in dataByPeriod)
                    {
                        monthlyAverage.Add(
                            data.Value.Select(e => DateTime.Now - e.EmploymentDate).Average(e => e.Days));
                    }
                    break;
            }

            return Ok(monthlyAverage);
        }
    }
}
