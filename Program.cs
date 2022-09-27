using System;

namespace Proje2
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            int input = MenuYaz();

            while (true)
            {
                switch (input)
                {
                    case 1: // Kart Ekle
                        board.KartEkle();
                        input = MenuYaz();
                        break;
                    case 2: // Kart Guncelle
                        board.KartGuncelle();
                        input = MenuYaz();
                        break;
                    case 3: // Kart Sil
                        board.KartSil();
                        input = MenuYaz();
                        break;
                    case 4: // Kart Tasi
                        board.KartTasi();
                        input = MenuYaz();
                        break;
                    case 5: // Board Listele
                        board.BoardListele();
                        input = MenuYaz();
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Boyle bir secim yok. Cikis yapiliyor.");
                        Environment.Exit(0);
                        break;
                }
            }

            
        }

        public static int MenuYaz()
        {
            Console.WriteLine();
            Console.WriteLine("Lutfen yapmak istediginiz islemi secin");
            Console.WriteLine("************************************");
            Console.WriteLine("(1) Kart Eklemek");
            Console.WriteLine("(2) Kart Guncelle");
            Console.WriteLine("(3) Kart Sil");
            Console.WriteLine("(4) Kart Tasi");
            Console.WriteLine("(5) Board Listelemek");
            Console.WriteLine("(6) Cikis");
            return int.Parse(Console.ReadLine());
        }
    }
}