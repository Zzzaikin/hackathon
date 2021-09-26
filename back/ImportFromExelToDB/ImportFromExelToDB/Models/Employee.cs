using System;

namespace WebApi.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public int EmployeeId {  get; set; }

        public Position Position { get; set; }
        public Guid PositionId { get; set; }

        public FamilyStatus FamilyStatus { get; set; }
        public Guid FamilyId { get; set; }

        public Gender Gender { get; set; }
        public Guid GenderId { get; set; }

        public City City { get; set; }
        public Guid CityId { get; set; }

        public DateTime Birthdate { get; set; }

        public DateTime EmploymentDate { get; set; }
        public DateTime DismissalDate { get; set; }

        public DateTime Period {  get; set; }

        public int Salary { get; set; }
        public int ChildrensNumber { get; set; }

        public bool Mentor { get; set; }
    }
}
