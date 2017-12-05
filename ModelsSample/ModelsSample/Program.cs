using System;

namespace ModelsSample
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDatabase();
            CreateMenus();
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
