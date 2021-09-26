using System;

namespace WebApi.Models
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Id записи о сотруднике.
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Id сотрудника.
        /// </summary>
        public int EmployeeId {  get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public Position Position { get; set; }
        /// <summary>
        /// Id должности.
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Семейный статус.
        /// </summary>
        public FamilyStatus FamilyStatus { get; set; }
        /// <summary>
        /// Id семейного статуса.
        /// </summary>
        public Guid FamilyId { get; set; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Id пола.
        /// </summary>
        public Guid GenderId { get; set; }

        /// <summary>
        /// Город проживания.
        /// </summary>
        public City City { get; set; }
        /// <summary>
        /// Id города.
        /// </summary>
        public Guid CityId { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// Дата трудоустройства.
        /// </summary>
        public DateTime EmploymentDate { get; set; }
        /// <summary>
        /// Дата увольнения.
        /// </summary>
        public DateTime DismissalDate { get; set; }

        /// <summary>
        /// Месяц о которых информируют данные.
        /// </summary>
        public DateTime Period {  get; set; }

        /// <summary>
        /// Зарплата.
        /// </summary>
        public int Salary { get; set; }
        /// <summary>
        /// Количестов детей.
        /// </summary>
        public int ChildrensNumber { get; set; }

        /// <summary>
        /// Наставник.
        /// </summary>
        public bool Mentor { get; set; }
    }
}
