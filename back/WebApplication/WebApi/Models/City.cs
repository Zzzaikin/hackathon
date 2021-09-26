using System;

namespace WebApi.Models
{
    /// <summary>
    /// Город.
    /// </summary>
    public class City
    {
        /// <summary>
        /// Id города.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название города.
        /// </summary>
        public string Name { get; set; }
    }
}
