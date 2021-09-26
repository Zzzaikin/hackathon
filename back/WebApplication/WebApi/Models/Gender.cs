using System;

namespace WebApi.Models
{
    /// <summary>
    /// Пол.
    /// </summary>
    public class Gender
    {
        /// <summary>
        /// Id пола.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }
    }
}
