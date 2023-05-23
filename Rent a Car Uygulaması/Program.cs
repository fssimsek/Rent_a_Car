using System;

namespace den
{
    internal class Program
    {
        static int surekayit = 0;
        static char[] sayilar = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] harfler = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'Q' };
        static int sayac = 0;
        static Galeri G049Galerisi = new Galeri();
        static Araba araba = new Araba();
        //KULLANICI ETKİLELŞİMİ
        static void Main(string[] args)
        {
            Uygulama();

        }
        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            SecimAl();
        }

        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1- Araba Kirala (K)                 ");
            Console.WriteLine("2- Araba Teslim Al (T)              ");
            Console.WriteLine("3- Kiradaki Arabaları Listele (R)   ");
            Console.WriteLine("4- Galerideki Arabaları Listele (M) ");
            Console.WriteLine("5- Tüm Arabaları Listele (A)        ");
            Console.WriteLine("6- Kiralama İptali (I)              ");
            Console.WriteLine("7- Araba Ekle (Y)                   ");
            Console.WriteLine("8- Araba Sil (S)                    ");
            Console.WriteLine("9- Bilgileri Göster (G)             ");
        }
        static void SahteVeriGir()
        {

            G049Galerisi.ArabaEkleme("34ARB3434", "FIAT", 70, ARACTIPI.Sedan);
            G049Galerisi.ArabaEkleme("35ARB3535", "KIA", 60, ARACTIPI.SUV);
            G049Galerisi.ArabaEkleme("34US2342", "OPEL", 50, ARACTIPI.Hatchback);

        }

        static void SecimAl()
        {
            string secim; 
            while (true)
            {
                
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                secim = Console.ReadLine().ToUpper();
                Console.WriteLine();
                switch (secim)
                {
                    case "1":
                    case "K":
                        ArabaKirala(); 
                        break;
                    case "2":
                    case "T":
                        ArabaTeslimAl(); 
                        break;
                    case "3":
                    case "R":
                        KiradakiArabalariListele(); 
                        break;
                    case "4":
                    case "M":
                        GaleridekiArabalariListele(); 
                        break;
                    case "5":
                    case "A":
                        TumArabalariListele(); 
                        break;
                    case "6":
                    case "I":
                        KiralamaIptali();
                        break;
                    case "7":
                    case "Y":
                        ArabaEkle(); 
                        break;
                    case "8":
                    case "S":
                        ArabaSil(); 
                        break;
                    case "9":
                    case "G":
                        BilgileriGoster();
                        break;
                    case "X":
                        break;
                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        sayac++;
                        if (sayac == 10)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                            Environment.Exit(0);
                        }
                        
                        break;
                }
            }
        }

        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle-");
            Console.WriteLine();
            int kontrol = 0;
            string plaka;

            while (true)
            {
                plaka = sorgu.PlakaAl("Plaka: ");
                xMi(plaka);
                foreach (Araba item in G049Galerisi.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        Console.WriteLine("Aynı plakada araba mevcut. Girdiğiniz plakayı kontrol edin.");
                        kontrol = 0;
                        break;
                    }
                    else kontrol++;
                }
                if (kontrol == G049Galerisi.Arabalar.Count)
                {
                    kontrol = 0;
                    break;
                }
            }

            string marka = "";

            while (true)
            {
                Console.Write("Marka: ");
                marka = Console.ReadLine().ToUpper();
                xMi(marka);
                int sayi;
                bool Sonuc = int.TryParse(marka, out sayi);
                if (Sonuc)
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
                else
                {
                    break;
                }
            }
            int kiralamaBedeli;
            string bedel = "";
            while (true)
            {
                Console.Write("Kiralama bedeli: ");
                bedel = Console.ReadLine();
                xMi(bedel);

                int sayi;
                bool Sonuc = int.TryParse(bedel, out sayi);
                if (Sonuc)
                {
                    kiralamaBedeli = sayi;
                    break;
                }
                else
                {
                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                }
            }


            ARACTIPI aTipi = ARACTIPI.Empty;

            Console.WriteLine("Araç tipi:      ");
            Console.WriteLine("SUV için 1       ");
            Console.WriteLine("Hatchback için 2 ");
            Console.WriteLine("Sedan için 3     ");
            while (true)
            {
                Console.Write("Araba Tipi: ");
                string secim = Console.ReadLine().ToUpper();

                switch (secim)
                {
                    case "1":
                        aTipi = ARACTIPI.SUV;
                        break;
                    case "2":
                        aTipi = ARACTIPI.Hatchback;
                        break;
                    case "3":
                        aTipi = ARACTIPI.Sedan;
                        break;
                    case "X":
                        SecimAl();
                        break;
                    default:
                        Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                        break;
                }
                if (aTipi != ARACTIPI.Empty) break;
            }

            G049Galerisi.ArabaEkleme(plaka, marka, kiralamaBedeli, aTipi);
            Console.WriteLine("");
            Console.WriteLine("Araba başarılı bir şekilde eklendi.");

        } //ekrandan bilgi alacak, galeri class'a gönderecek.
        static void ArabaKirala()
        {
            string plaka = "";
            int sure = 5;
            string kiralanmaSuresi = "";
            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine("");
            if (G049Galerisi.ToplamArabaSayisi == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
            }
            else if (G049Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Tüm araçlar kirada.");
            }
            else
            {
                while (true)
                {
                    plaka = sorgu.PlakaAl("Kiralanacak arabanın plakası: ");
                    foreach (Araba item in G049Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka && item.Durum == DURUM.Kirada)
                        {
                            Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                            sayac = 0;
                        }
                        else if (item.Plaka == plaka && item.Durum == DURUM.Galeride)
                        {
                            while (true)
                            {
                                Console.Write("Kiralanma süresi: ");
                                kiralanmaSuresi = Console.ReadLine();
                                xMi(kiralanmaSuresi);
                                bool Sonuc = int.TryParse(kiralanmaSuresi, out sure);
                                if (Sonuc)
                                {
                                    Console.WriteLine("");
                                    Console.WriteLine(plaka + " plakalı araba " + sure + " saatliğine kiralandı.");
                                    G049Galerisi.ArabaKiralama(plaka, sure);
                                    return;
                                }
                                else
                                {
                                    Console.WriteLine("Giriş tanımlanamadı. Tekrar deneyin.");
                                    sayac = 0;
                                }
                            }

                        }
                        else sayac++;
                    }
                    if (sayac == G049Galerisi.Arabalar.Count)
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                        sayac = 0;
                    }
                }
            }
            
        } 

        static void ArabaTeslimAl()
        {
            string plaka = "";
            Console.WriteLine("-Araba Teslim Al-");
            Console.WriteLine("");
            if (G049Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada hiç araba yok.");
            }
            else
            {
                sayac = 0;
                while (true)
                {
                    plaka = sorgu.PlakaAl("Teslim edilecek arabanın plakası: ");
                    foreach (Araba item in G049Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            if (item.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Araba galeride beklemeye alındı.");
                                sayac = 0;
                                item.Durum = DURUM.Galeride;
                                return;
                            }

                            else if (item.Durum == DURUM.Galeride)
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");

                            }
                            sayac = 0;
                        }
                        else sayac++;
                    }
                    if (G049Galerisi.ToplamArabaSayisi == sayac)
                    {
                        sayac = 0;
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                }
            }
        }
        static void KiradakiArabalariListele()
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine("");
            if (G049Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G049Galerisi.Arabalar)
                {
                    if (item.Durum == DURUM.Kirada)
                    {

                        Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));

                    }
                }
            }
        }

        static void GaleridekiArabalariListele()
        {
            Console.WriteLine("-Galerideki Arabalar-");
            Console.WriteLine("");
            if (G049Galerisi.BekleyenArabaSayisi == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G049Galerisi.Arabalar)
                {
                    if (item.Durum == DURUM.Galeride)
                    {

                        Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));

                    }
                }
            }
        }
        static void TumArabalariListele()
        {
            Console.WriteLine("-Tüm Arabalar-");
            Console.WriteLine("");
            if (G049Galerisi.Arabalar.Count == 0)
            {
                Console.WriteLine("Listelenecek araç yok.");
            }
            else
            {
                Console.WriteLine("Plaka         Marka       K. Bedeli   Araba Tipi  K. Sayısı   Durum");
                Console.WriteLine("----------------------------------------------------------------------");
                foreach (Araba item in G049Galerisi.Arabalar)
                {
                    Console.WriteLine(item.Plaka.PadRight(14) + item.Marka.PadRight(12) + item.KiralamaUcreti.ToString().PadRight(12) + item.ArabaTipi.ToString().PadRight(12) + item.KiralanmaSayisi.ToString().PadRight(12) + item.Durum.ToString().PadRight(8));
                }

            }
        }

        static void KiralamaIptali()
        {
            string plaka = "";
            int kontrol = 0;
            Console.WriteLine("-Kiralama İptali-");
            Console.WriteLine("");
            if (G049Galerisi.KiradakiArabaSayisi == 0)
            {
                Console.WriteLine("Kirada araba yok.");
            }
            else
            {
                while (true)
                {
                    plaka = sorgu.PlakaAl("Kiralaması iptal edilecek arabanın plakası: ");
                    foreach (Araba item in G049Galerisi.Arabalar)
                    {
                        if (item.Plaka == plaka)
                        {
                            if (item.Durum == DURUM.Kirada)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("İptal gerçekleştirildi.");
                                item.KiralanmaSureleri.RemoveAt(item.KiralanmaSureleri.Count - 1);
                                item.Durum = DURUM.Galeride;
                                return;
                            }
                            else
                            {
                                Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                            }
                            kontrol = 0;
                        }
                        else kontrol++;
                    }
                    if (kontrol == G049Galerisi.Arabalar.Count)
                    {
                        kontrol = 0;
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                }
            }
        }
        static void ArabaSil()
        {
            string plaka = "";
            Console.WriteLine("-Araba Sil-");
            Console.WriteLine("");
            int kontrol = 0;
            while (true)
            {
                plaka = sorgu.PlakaAl("Silmek istediğiniz arabanın plakasını giriniz: ");
                foreach (Araba item in G049Galerisi.Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        if (item.Durum == DURUM.Galeride)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Araba silindi.");
                            G049Galerisi.Arabalar.Remove(item);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Araba kirada olduğu için silme işlemi gerçekleştirilemedi.");
                        }
                        kontrol = 0;
                    }
                    else kontrol++;
                }
                if (kontrol == G049Galerisi.Arabalar.Count)
                {
                    kontrol = 0;
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
            }
        }

        static void BilgileriGoster()
        {
            Console.WriteLine("-Galeri Bilgileri-");
            Console.WriteLine($"Toplam araba sayısı: {G049Galerisi.ToplamArabaSayisi}");
            Console.WriteLine($"Kiradaki araba sayısı: {G049Galerisi.KiradakiArabaSayisi}");
            Console.WriteLine($"Bekleyen araba sayısı: {G049Galerisi.BekleyenArabaSayisi}");
            Console.WriteLine($"Toplam araba kiralama süresi: {G049Galerisi.ToplamArabaKiralanmaSuresi}");
            Console.WriteLine($"Toplam araba kiralama adedi: {G049Galerisi.ToplamArabaKiralanmaAdedi}");
            Console.WriteLine($"Ciro: {G049Galerisi.Ciro}");
        }

        static public void xMi(string ifade)
        {
            if (ifade == "X" || ifade == "x")
            {
                SecimAl();
            }
            else
            {
                return;
            }
                
        }
    }
}
