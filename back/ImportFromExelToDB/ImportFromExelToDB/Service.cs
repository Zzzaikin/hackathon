using System;
using System.Linq;
using WebApi;
using WebApi.Models;

namespace RosAtomDataBase
{
    public class Service
    {
        public bool ApplyFilter(Employee employee, Filter filter)
        {
            if (filter.Positions != null &&
                !filter.Positions.Contains(employee.Position.Name))
            {
                return false;
            }

            if (filter.Сities != null &&
                !filter.Сities.Contains(employee.City.Name))
            {
                return false;
            }

            if (filter.Genders != null &&
                !filter.Genders.Contains(employee.Gender.Name))
            {
                return false;
            }

            if (filter.FamilyStatuses != null &&
                !filter.FamilyStatuses.Contains(employee.FamilyStatus.Name))
            {
                return false;
            }

            if (filter.Mentor != null &&
                !filter.Mentor.Contains(employee.Mentor))
            {
                return false;
            }

            if (filter.ExperienceMin <= 0 &&
                filter.ExperienceMin > DateTime.Now.Month - employee.EmploymentDate.Month)
            {
                return false;
            }

            if (filter.ExperienceMax <= 0 &&
                filter.ExperienceMax < DateTime.Now.Month - employee.EmploymentDate.Month)
            {
                return false;
            }

            if (filter.AgeMin <= 0 &&
                filter.AgeMin > DateTime.Now.Month - employee.Birthdate.Month)
            {
                return false;
            }

            if (filter.AgeMax <= 0 &&
                filter.AgeMax < DateTime.Now.Month - employee.Birthdate.Month)
            {
                return false;
            }

            if (filter.SalaryMin <= 0 &&
                filter.SalaryMin > employee.Salary)
            {
                return false;
            }

            if (filter.SalaryMax <= 0 &&
                filter.SalaryMax < employee.Salary)
            {
                return false;
            }

            if (filter.ChildrensNumberMin <= 0 &&
                filter.ChildrensNumberMin > employee.ChildrensNumber)
            {
                return false;
            }

            if (filter.ChildrensNumberMax <= 0 &&
                filter.ChildrensNumberMax < employee.Salary)
            {
                return false;
            }

            return true;
        }
    }
}
