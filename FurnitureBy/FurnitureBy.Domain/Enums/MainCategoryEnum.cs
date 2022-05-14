using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FurnitureBy.Domain.Enums
{
    public enum MainCategoryEnum
    {
        /// <summary>
        /// Кровати
        /// </summary>
        [Display(Name = "Кровати")]
        Bads = 1,

        /// <summary>
        /// Кровати
        /// </summary>
        [Display(Name = "Диваны")]
        Sofas = 2,

        /// <summary>
        /// Кровати
        /// </summary>
        [Display(Name = "Шкафы")]
        Closets = 3,

        /// <summary>
        /// Кровати
        /// </summary>
        [Display(Name = "Столы")]
        Tables = 4,

        /// <summary>
        /// Кровати
        /// </summary>
        [Display(Name = "Стулья")]
        Chairs = 5
    }
}
