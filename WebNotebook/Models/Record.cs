using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebNotebook.Models.Base;

namespace WebNotebook.Models
{
    public class Record : BaseEntity
    {
        /// <summary>
        /// Модель данных Записи
        /// </summary>

        [Required(ErrorMessage = "Заполните имя контакта"),
        Display(Name = "Имя контакта"),
        Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Display(Name = "Телефон"),
        MaxLength(20),
        Column(TypeName = "nvarchar(20)"),
        RegularExpression(@"(\+7|8|\b)[\(\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[)\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)[\s-]*(\d)", ErrorMessage = "Некорректный номер телефона")]
        public string Phone { get; set; }

        [Display(Name = "Почта"),
        MaxLength(100),
        Column(TypeName = "nvarchar(100)"),
        RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z0-9-]{2,4}", ErrorMessage = "Некорректный адрес электронной почты")]
        public string Email { get; set; }

        [Display(Name = "Дата рождения"),
        DataType(DataType.Date),
        Column(TypeName = "datetime2(7)")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Организация"),
        MaxLength(200),
        Column(TypeName = "nvarchar(200)")]
        public string Company { get; set; }

        [Display(Name = "Комментарий"),
        MaxLength(200),
        Column(TypeName = "nvarchar(200)")]
        public string Comment { get; set; }
    }
}
