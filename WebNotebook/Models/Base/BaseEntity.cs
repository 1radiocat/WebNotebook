using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebNotebook.Models.Base
{
    public class BaseEntity
    {
        /// <summary>
        /// Базовая сущность с автогенерацией Id
        /// </summary>

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
