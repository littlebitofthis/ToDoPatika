using System;
using System.Collections.Generic;
using System.Text;

namespace Proje2
{
    public class Board
    {
        Dictionary<int, string> kisiler = new Dictionary<int, string>();


        List<Kart> TODO = new List<Kart>();
        List<Kart> INPROGRESS = new List<Kart>();
        List<Kart> DONE = new List<Kart>();

        public Board()
        {
            kisiler.Add(0, "Yaren Ecem Terzioğlu");
            kisiler.Add(1, "Şevval İzgördü");
            kisiler.Add(2, "Ceren Tarı");
            kisiler.Add(3, "Ecem Rana Dumlu");
            kisiler.Add(4, "Bilge Şengül");

            TODO.Add(new Kart("Temizlik", "Yerleri Supur", "Yaren Ecem Terzioğlu",Kart.Buyuluk.M));
            INPROGRESS.Add(new Kart("Temizlik", "Camlari Sil", "Şevval İzgördü",Kart.Buyuluk.S));
            DONE.Add(new Kart("Spor", "2 Km Kos", "Ceren Tarı",Kart.Buyuluk.L));
            DONE.Add(new Kart("Ev", "Alisveris Yap", "Ecem Rana Dumlu",Kart.Buyuluk.XL));
            INPROGRESS.Add(new Kart("Temizlik", "Toz Al", "Bilge Şengül",Kart.Buyuluk.XS));
        }

        public void KartEkle()
        {
            string baslik;
            string icerik;
            int buyukluk;
            int kisi;

            Console.WriteLine("Baslik giriniz                                   : ");
            baslik = Console.ReadLine();
            Console.WriteLine("Icerik giriniz                                   : ");
            icerik = Console.ReadLine();
            Console.WriteLine("Buyukluk seciniz -> XS(1),S(2),M(3),L(4),XL(5)   :");
            buyukluk = int.Parse(Console.ReadLine());
            Console.WriteLine("Kisi ID'sini giriniz                             : ");
            kisi =int.Parse(Console.ReadLine());

            if (kisiler.ContainsKey(kisi) && buyukluk > 0 && buyukluk <= 5)
                TODO.Add(new Kart(baslik, icerik, kisiler[kisi], (Kart.Buyuluk)buyukluk));
            else
                Console.WriteLine("Hatali giris yaptiniz!");


        }

        public void KartGuncelle()
        {
            Console.WriteLine("Kart Guncelle calisiyor.");
        }

        public void KartSil()
        {
            string baslik;
            string icerik;

            Console.WriteLine("Oncelikle silmek istediginiz karti secmeniz gerekiyor.");
            Console.WriteLine("Lutfen kartin basligini yaziniz :    ");
            baslik = Console.ReadLine();
            Console.WriteLine("Lutfen kartin icerigi yaziniz :    ");
            icerik = Console.ReadLine();

            bool bulundu = false;
            
            foreach (var kart in TODO.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    TODO.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            foreach (var kart in INPROGRESS.ToArray()) 
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    INPROGRESS.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            foreach (var kart in DONE.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    DONE.Remove(kart);
                    Console.WriteLine("Kart silindi.");
                    bulundu = true;
                }
            }

            if (!bulundu)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Silmeyi sonlandirmak icin (1)");
                Console.WriteLine("* Yeniden denemek icin (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartSil();
                else
                    Console.WriteLine("Kart silme islemi sonlandi.");
            }
        }



        private void KartEkle(Kart kart,ref List<Kart> addList,ref List<Kart> deleteList)
        {
            addList.Add(kart);
            deleteList.Remove(kart);
            Console.WriteLine("Tasima islemi basarili!");
        }

        private void KartAra(string baslik,string icerik,ref List<Kart> kartListesi, ref bool bulundu, string listName)
        {
            foreach (var kart in kartListesi.ToArray())
            {
                if (kart.Baslik == baslik && kart.Icerik == icerik)
                {
                    bulundu = true;

                    Console.WriteLine("Bulunan Kart Bilgileri:");
                    Console.WriteLine("*******************************************");
                    Console.WriteLine("Baslik       :   {0}", kart.Baslik);
                    Console.WriteLine("Icerik       :   {0}", kart.Icerik);
                    Console.WriteLine("Atanan Kisi  :   {0}", kart.AtananKisi);
                    Console.WriteLine("Buyukluk     :   {0}", kart.Boyut);
                    Console.WriteLine("Line         :   {0}", listName);
                    Console.WriteLine();
                    Console.WriteLine("Lutfen tasimak istediginiz Line'i secin:");
                    Console.WriteLine("(1) TODO");
                    Console.WriteLine("(2) IN PROGRESS");
                    Console.WriteLine("(3) DONE");
                    int secim = int.Parse(Console.ReadLine());
                    switch (secim)
                    {
                        case 1:
                            KartEkle(kart,ref TODO,ref kartListesi);
                            break;
                        case 2:
                            KartEkle(kart, ref INPROGRESS, ref kartListesi);
                            break;
                        case 3:
                            KartEkle(kart, ref DONE, ref kartListesi);
                            break;
                        default:
                            Console.WriteLine("Hatali bir secim yaptiniz!");
                            break;
                    }


                }
            }
        }

        public void KartTasi()
        {
            string baslik;
            string icerik;
            bool bulundu = false;

            Console.WriteLine("Oncelikle tasimak istediginiz karti secmeniz gerekiyor.");
            Console.WriteLine("Lutfen kartin basligini yaziniz :    ");
            baslik = Console.ReadLine();
            Console.WriteLine("Lutfen kartin icerigi yaziniz :    ");
            icerik = Console.ReadLine();


            KartAra(baslik, icerik,ref TODO,ref bulundu,"TODO");                
            KartAra(baslik, icerik,ref INPROGRESS,ref bulundu,"INPROGRESS");    
            KartAra(baslik, icerik,ref DONE, ref bulundu,"DONE");              


            if (!bulundu)
            {
                int secim;
                Console.WriteLine("Aradiginiz kriterlere uygun kart bulunamadi.");
                Console.WriteLine("* Tasimayi sonlandirmak icin (1)");
                Console.WriteLine("* Yeniden denemek icin (2)");
                secim = int.Parse(Console.ReadLine());
                if (secim == 2)
                    KartTasi();
                else
                    Console.WriteLine("Kart silme islemi sonlandi.");
            }
        }

        public void BoardListele()
        {
            Console.WriteLine();
            Console.WriteLine("TODO Line");
            Console.WriteLine("*****************************");

            foreach (var kart in TODO)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

            Console.WriteLine();
            Console.WriteLine("IN PROGRESS Line");
            Console.WriteLine("*****************************");

            foreach (var kart in INPROGRESS)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

            Console.WriteLine();
            Console.WriteLine("DONE Line");
            Console.WriteLine("*****************************");

            foreach (var kart in DONE)
            {
                Console.WriteLine("Baslik       : {0}", kart.Baslik);
                Console.WriteLine("Icerik       : {0}", kart.Icerik);
                Console.WriteLine("Atanan Kisi  : {0}", kart.AtananKisi);
                Console.WriteLine("Buyukluk     : {0}", kart.Boyut);
                Console.WriteLine("-");
            }

        }

    }
}