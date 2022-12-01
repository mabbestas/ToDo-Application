using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoUygulaması.Entities
{
    public class Database
    {
        public void Start(List<User> users, List<Card> cards)
        {
            User user1 = new User();
            user1.Id = 1;
            user1.Name = "Burak";
            users.Add(user1);

            User user2 = new User();
            user2.Id = 2;
            user2.Name = "Mustafa";
            users.Add(user2);

            User user3 = new User();
            user3.Id = 3;
            user3.Name = "Ayhan";
            users.Add(user3);

            Card card1 = new Card();
            card1.Baslik = "Frontend";
            card1.Icerik = "HTML";
            card1.Kisi = user1.Name;
            card1.Buyukluk = Enum.Size.S;
            card1.Status = Enum.Status.ToDo;
            cards.Add(card1);

            Card card2 = new Card();
            card2.Baslik = "Backend";
            card2.Icerik = "C#";
            card2.Kisi = user2.Name;
            card2.Buyukluk = Enum.Size.L;
            card2.Status = Enum.Status.InProgress;
            cards.Add(card2);

            Card card3 = new Card();
            card3.Baslik = "Fullstack";
            card3.Icerik = "Javascript";
            card3.Kisi = user3.Name;
            card3.Buyukluk = Enum.Size.XL;
            card3.Status = Enum.Status.Done;
            cards.Add(card3);
        }


    }
}
