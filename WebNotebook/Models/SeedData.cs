using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using WebNotebook.Domain;

namespace WebNotebook.Models
{
    public class SeedData
    {

        /// <summary>
        /// Наполнение БД данными
        /// </summary>

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                    serviceProvider.GetRequiredService<
                        DbContextOptions<AppDbContext>>()))
            {
                if (context.Records.Any())
                {
                    return;
                }

                context.Records.AddRange(

                    new Record
                    {
                        Name = "Алексей Иванов",
                        Phone = "+7-900-000-4652",
                        Email = "ivanov@fintech.ru",
                        BirthDate = DateTime.Parse("1980-1-10"),
                        Company = "FinTech INC",
                        Comment = "Спит до 10 утра"
                    },

                    new Record
                    {
                        Name = "Виктор Сидоров",
                        Phone = "+7-900-000-2249",
                        Email = "sidorov@yabank.ru",
                        BirthDate = DateTime.Parse("1985-2-27"),
                        Company = "YaBank LTD",
                        Comment = "Играет в минифутбол"
                    },

                    new Record
                    {
                        Name = "Сергей Степанов",
                        Phone = "+7-900-000-6768",
                        Email = "stepanov@greenfruit.ru",
                        BirthDate = DateTime.Parse("1986-10-12"),
                        Company = "GreenFruit LLC",
                        Comment = "Болеет за Сибирь"
                    },

                    new Record
                    {
                        Name = "Андрей Супрунов",
                        Phone = "+7-900-000-0177",
                        Email = "suprunov@fintech.ru",
                        BirthDate = DateTime.Parse("1982-12-3"),
                        Company = "FinTech INC",
                        Comment = "Торгует на Мосбирже"
                    },

                    new Record
                    {
                        Name = "Дмитрий Петров",
                        Phone = "+7-900-000-6773",
                        Email = "petrov@yabank.ru",
                        BirthDate = DateTime.Parse("1983-4-26"),
                        Company = "YaBank LTD",
                        Comment = "Разводит мопсов"
                    },

                    new Record
                    {
                        Name = "Денис Ефимов",
                        Phone = "+7-900-000-9945",
                        Email = "efimov@greenfruit.ru",
                        BirthDate = DateTime.Parse("1986-7-19"),
                        Company = "GreenFruit LLC",
                        Comment = "Коллекционирует настольные игры"
                    },

                    new Record
                    {
                        Name = "Константин Виноградов",
                        Phone = "+7-900-000-4555",
                        Email = "vinogradov@yabank.ru",
                        BirthDate = DateTime.Parse("1987-9-3"),
                        Company = "YaBank LTD",
                        Comment = "Увлекается хард эндуро спортом"
                    },

                    new Record
                    {
                        Name = "Сергей Петров",
                        Phone = "+7-900-000-9561",
                        Email = "petrov@greenfruit.ru",
                        BirthDate = DateTime.Parse("1984-11-29"),
                        Company = "GreenFruit LLC",
                        Comment = "Ходит в \"Кабанчик\" каждую пятницу"
                    },

                    new Record
                    {
                        Name = "Владимир Яковлев",
                        Phone = "+7-900-000-2143",
                        Email = "yakovlev@fintech.ru",
                        BirthDate = DateTime.Parse("1989-11-18"),
                        Company = "FinTech INC",
                        Comment = "Смотрит ужасы по утрам"
                    },

                    new Record
                    {
                        Name = "Михаил Николаев",
                        Phone = "+7-900-000-5735",
                        Email = "nikolaev@yabank.ru",
                        BirthDate = DateTime.Parse("1982-4-6"),
                        Company = "YaBank LTD",
                        Comment = "Член движения Навального"
                    });

                context.SaveChanges();

            }
        }
    }
}
