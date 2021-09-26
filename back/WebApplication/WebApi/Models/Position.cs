using System;

namespace WebApi.Models
{
    /// <summary>
    /// Должность.
    /// </summary>
    public class Position
    {
        /// <summary>
        /// Id должности.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Название должности.
        /// </summary>
        public string Name { get; set; }
    }
}
