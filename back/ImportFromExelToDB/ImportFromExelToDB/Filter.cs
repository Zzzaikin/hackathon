namespace WebApi
{
    public class Filter
    {
        public string[] Positions { get; set; }
        public string[] Сities { get; set; }
        public string[] Genders { get; set; }
        public string[] FamilyStatuses { get; set; }
        public bool[] Mentor { get; set; }

        /// <summary>
        /// Минимальный опыт в месяцах
        /// </summary>
        public int ExperienceMin { get; set; }
        /// <summary>
        /// Максимальный опыт в месяцах
        /// </summary>
        public int ExperienceMax { get; set; }

        /// <summary>
        /// Минимальный опыт в годах
        /// </summary>
        public int AgeMin{ get; set; }
        /// <summary>
        /// Максимальный опыт в годах
        /// </summary>
        public int AgeMax{ get; set; }

        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }

        public int ChildrensNumberMin { get; set; }
        public int ChildrensNumberMax { get; set; }
    }
}
