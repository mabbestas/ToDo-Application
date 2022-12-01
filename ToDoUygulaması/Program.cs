using System;
using System.Collections.Generic;
using System.Linq;
using ToDoUygulaması.Entities;
using ToDoUygulaması.Enum;
using ToDoUygulaması.Method;

namespace ToDoUygulaması
{
    class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>();
            List<Card> cards = new List<Card>();
            Database database = new Database();
            database.Start(users, cards);
            bool esc = false;
            while (esc == false)
            {
                Console.WriteLine("Lütfen yapmak istediğiniz işlemi seçiniz :)");
                Console.WriteLine("*******************************************");
                Console.WriteLine("(1) Board Listelemek\n(2) Board'a Kart Eklemek\n(3) Board'dan Kart Silmek\n(4) Kart Taşımak");

                int number = 0;
                bool input = int.TryParse(Console.ReadLine(), out number);
                if (input && number > 0 && number < 5)
                {
                    switch (number)
                    {
                        case 1:
                            Methods methods = new Methods();
                            methods.Listele(cards);
                            break;
                        case 2:
                            Methods methods1 = new Methods();
                            methods1.KartEkle(cards, users);
                            break;
                        case 3:
                            Methods methods2 = new Methods();
                            methods2.KartSilme(cards);
                            break;
                        case 4:
                            Methods methods3 = new Methods();
                            methods3.KartTasima(cards);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Lütfen seçeneklerden birini seçiniz!");
                }
            }
        }
    }
}
