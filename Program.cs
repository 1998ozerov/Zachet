using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquareAreaBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {

                // добавляем их в бд
                TypeArea user1 = new TypeArea {  Id=1, Name = "Плоская тарелка", Square=12, Type = "Квадрат" };
                TypeArea user2 = new TypeArea { Id = 2, Name = "Глубокая тарелка", Square=5, Type = "Круг" };
                TypeArea user3 = new TypeArea { Id = 3, Name = "Блюдо", Square = 10, Type = "Круг" };
                db.TypeArea.Add(user1);
                db.TypeArea.Add(user2);
                db.TypeArea.Add(user3);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
                var area = db.TypeArea;
                Console.WriteLine("Список объектов:");
                foreach (TypeArea u in area)
                {
                    Console.WriteLine("{0}.{1} - {2} - {3}", u.Id, u.Name, u.Square, u.Type);
                }

                Console.WriteLine("\nSum():");
                // суммарная цена всех моделей
                int sum1 = db.TypeArea.Sum(p => p.Square);
                int sum2 = db.TypeArea.Where(p => p.Type.Contains("Круг")).Sum(p => p.Square);
                Console.Write("Общая суммаг= ");
                Console.WriteLine(sum2);
                Console.Write("Общая сумма площади тарелок с типом Круг= ");
                Console.WriteLine(sum2);

                Console.WriteLine("\nIntersect():");
                var area2 = db.TypeArea.Where(p => p.Type.Contains("Круг"))
       .Intersect(db.TypeArea.Where(p => p.Name.Contains("Блюдо")));
                foreach (var item in area2)
                {
                    Console.WriteLine(item.Id+". "+item.Name+" - "+item.Square+" - "+item.Type);
                   
                }

                Console.Read();
            }
        }
    }
}