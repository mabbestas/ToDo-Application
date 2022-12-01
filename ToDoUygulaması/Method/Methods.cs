using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoUygulaması.Entities;
using ToDoUygulaması.Enum;

namespace ToDoUygulaması.Method
{
    public class Methods
    {
        public void Listele(List<Card> liste)
        {
            Console.WriteLine("TODO Line\n************************");
            foreach (var item in liste)
            {
                if (item.Status.ToString() == "ToDo")
                {
                    Console.WriteLine($"Başlık      : {item.Baslik}\nİçerik      : {item.Icerik}\nAtanan Kişi : {item.Kisi}\nBüyüklük    : {item.Buyukluk}");
                    Console.WriteLine("-");
                }
            }
            Console.WriteLine();

            Console.WriteLine("InProgress Line\n************************");
            foreach (var item in liste)
            {
                if (item.Status.ToString() == "InProgress")
                {
                    Console.WriteLine($"Başlık      : {item.Baslik}\nİçerik      : {item.Icerik}\nAtanan Kişi : {item.Kisi}\nBüyüklük    : {item.Buyukluk}");
                    Console.WriteLine("-");
                }
            }
            Console.WriteLine();

            Console.WriteLine("Done Line\n************************");
            foreach (var item in liste)
            {
                if (item.Status.ToString() == "Done")
                {
                    Console.WriteLine($"Başlık      : {item.Baslik}\nİçerik      : {item.Icerik}\nAtanan Kişi : {item.Kisi}\nBüyüklük    : {item.Buyukluk}");
                    Console.WriteLine("-");
                }
            }
        }

        public void KartEkle(List<Card> cards, List<User> users)
        {
            Card newCard = new Card();
            Console.Write("Başlık Giriniz                                  : ");
            string baslik = Console.ReadLine();
            Console.Write("İçerik Giriniz                                  : ");
            string icerik = Console.ReadLine();
            Console.Write("Büyüklük Seçiniz -> XS(1),S(2),M(3),L(4),XL(5)  : ");
            int num = Convert.ToInt32(Console.ReadLine());
            Size size = SizeSecme(num);
            Console.Write("Kişi Seçiniz                                    : ");
            int kisiId = Convert.ToInt32(Console.ReadLine());

            foreach (var item in users.ToList())
            {
                if (item.Id == kisiId)
                    newCard.Kisi = item.Name;
            }
            newCard.Baslik = baslik;
            newCard.Icerik = icerik;
            newCard.Buyukluk = size;
            newCard.Status = Status.ToDo;
            cards.Add(newCard);
        }

        public Size SizeSecme(int num)
        {
            Size sum = (Size)1;
            switch (num)
            {
                case 1:
                    sum = (Size)1;
                    break;
                case 2:
                    sum = (Size)2;
                    break;
                case 3:
                    sum = (Size)3;
                    break;
                case 4:
                    sum = (Size)4;
                    break;
                case 5:
                    sum = (Size)5;
                    break;
            }
            return sum;
        }

        public void KartSilme(List<Card> liste)
        {
            Console.Write("Öncelikle silmek istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız:  ");
            string input = Console.ReadLine();
            int count = 0;
            foreach (var item in liste.ToList())
            {
                if (item.Baslik == input)
                {
                    liste.Remove(item);
                    count++;
                    break;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                    return;
                else
                    KartSilme(liste);
            }
        }

        public void KartTasima(List<Card> liste)
        {
            Console.Write("Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor.\nLütfen kart başlığını yazınız: ");
            string input = Console.ReadLine();
            int count = 0;
            foreach (var item in liste.ToList())
            {
                if (item.Baslik == input)
                {
                    Console.WriteLine("Bulunan Kart Bilgileri:\n**************************************");
                    Console.WriteLine($"Başlık      : {item.Baslik}\nİçerik      : {item.Icerik}\nAtanan Kişi : {item.Kisi}\nBüyüklük    : {item.Buyukluk}\nLine        : {item.Status}");
                    Console.WriteLine();
                    Console.WriteLine("Lütfen taşımak istediğiniz Line'ı seçiniz:\n(1) TODO\n(2) IN PROGRESS\n(3) DONE");
                    int num = Convert.ToInt32(Console.ReadLine());
                    switch (num)
                    {
                        case 1:
                            item.Status = Status.ToDo;
                            break;
                        case 2:
                            item.Status = Status.InProgress;
                            break;
                        case 3:
                            item.Status = Status.Done;
                            break;
                    }
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine("Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız.\n* Silmeyi sonlandırmak için : (1)\n* Yeniden denemek için : (2)");
                int num = Convert.ToInt32(Console.ReadLine());
                if (num == 1)
                    return;
                else
                    KartTasima(liste);
            }
        }
    }
}
