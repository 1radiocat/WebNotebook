using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace WebNotebook.Models
{
    public class RecordCompanyViewModel
    {
        /// <summary>
        /// Поиск контакта по компании
        /// </summary>

        public List<Record> Records { get; set; }
        public SelectList Companies { get; set; }
        public string RecordCompany { get; set; }
        public string SearchString { get; set; }
    }
}
