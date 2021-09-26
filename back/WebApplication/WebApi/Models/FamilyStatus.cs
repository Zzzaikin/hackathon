using System;

namespace WebApi.Models
{
    /// <summary>
    /// Семейное положение.
    /// </summary>
    public class FamilyStatus
    {
        /// <summary>
        /// Id семейного положения.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Семейное положение.
        /// </summary>
        public string Name { get; set; }
    }
}
