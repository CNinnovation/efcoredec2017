using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ModelsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDatabase();
            //CreateMenus();
            // TrackingDemo();
            UpdateDemo();
        }

        private static void UpdateDemo()
        {
            using (var context = new MenusContext())
            {
                Menu m1 = context.Menus.FirstOrDefault();
                m1.Subtitle = "changed";
                context.SaveChanges();

            }
        }

        private static void TrackingDemo()
        {
            int a = 3;
            string s1 = string.Format("abc {0}", a);
            string s2 = $"abc {a}";
            FormattableString s3 = $"abc {a}";


            using (var context = new MenusContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
                var m1 = context.Menus.Where(m => m.Title.StartsWith("Gemüse")).FirstOrDefault();
                var m2 = context.Menus.Where(m => m.Subtitle.StartsWith("mit")).FirstOrDefault();
                if (m1 == m2)
                {
                    Console.WriteLine("the same object");
                }
                else
                {
                    Console.WriteLine("not the same object");
                }
            }
        }

        //private static void CreateMenus()
        //{
        //    using (var context = new MenusContext())
        //    {
        //        var card1 = new MenuCard
        //        {
        //            Title = "Veggie"
        //        };
        //        //context.MenuCards.Add(card1);

        //        var menu1 = new Menu
        //        {
        //            MenuCard = card1,
        //            Title = "Ravioli mit Spinat-Mascaponefülle",
        //            Subtitle = "in Kräutersauce, dazu Salat"
        //        };
        //        context.Menus.Add(menu1);
        //        context.SaveChanges();
        //    }
        //}

        private static void CreateMenus()
        {
            using (var context = new MenusContext())
            {
                var card1 = new MenuCard
                {
                    Title = "Veggie"
                };
                //context.MenuCards.Add(card1);

                var menu1 = new Menu("Gemüsegulasch", "mit Kartoffelknödel", card1);

                context.Menus.Add(menu1);
                context.SaveChanges();
            }
        }

        private static void CreateDatabase()
        {
            using (var context = new MenusContext())
            {
                var created = context.Database.EnsureCreated();
            }
        }
    }
}
