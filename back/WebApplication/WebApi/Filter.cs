namespace WebApi
{
    /// <summary>
    /// Фильтр для сотрудников.
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// Должность.
        /// </summary>
        public string[] Positions { get; set; }
        /// <summary>
        /// Город проживания.
        /// </summary>
        public string[] Сities { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public string[] Genders { get; set; }
        /// <summary>
        /// Семейное положение.
        /// </summary>
        public string[] FamilyStatuses { get; set; }
        /// <summary>
        /// Наличие наставника.
        /// </summary>
        public bool[] Mentor { get; set; }

        /// <summary>
        /// Минимальный опыт в месяцах.
        /// </summary>
        public int ExperienceMin { get; set; }
        /// <summary>
        /// Максимальный опыт в месяцах.
        /// </summary>
        public int ExperienceMax { get; set; }

        /// <summary>
        /// Минимальный опыт в годах.
        /// </summary>
        public int AgeMin{ get; set; }
        /// <summary>
        /// Максимальный опыт в годах.
        /// </summary>
        public int AgeMax{ get; set; }
        
        /// <summary>
        /// Минимальная зарплата в рублях.
        /// </summary>
        public int SalaryMin { get; set; }
        /// <summary>
        /// Максимальная зарплата в рублях
        /// </summary>
        public int SalaryMax { get; set; }

        /// <summary>
        /// Минимальное количество детей.
        /// </summary>
        public int ChildrensNumberMin { get; set; }
        /// <summary>
        /// Максимальное количество детей.
        /// </summary>
        public int ChildrensNumberMax { get; set; }

        /// <summary>
        /// Выбранный пользователей параметр, по которому 
        /// будет осуществляться поиск.
        /// </summary>
        public string SelectedParametr {  get; set; }
    }
}
