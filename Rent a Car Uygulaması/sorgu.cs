using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace den
{
    internal class sorgu
    {

        static public bool PlakaMi(string veri)
        {
            if (veri.Length > 6 && veri.Length < 10 && SayiMi(veri.Substring(0, 2)) && HarfMi(veri.Substring(2, 1)))
            {
                if (veri.Length == 7 && SayiMi(veri.Substring(3)))
                {
                    return true;
                }

                else if (veri.Length < 9 && HarfMi(veri.Substring(3, 1)) && SayiMi(veri.Substring(4)))
                {
                    return true;
                }
                else if (HarfMi(veri.Substring(3, 2)) && SayiMi(veri.Substring(5)))
                {
                    return true;
                }
            }
            return false;
        }
        static public bool HarfMi(string veri)
        {
            veri = veri.ToUpper();

            for (int i = 0; i < veri.Length; i++)
            {
                int kod = (int)veri[i];
                if ((kod >= 65 && kod <= 90) != true)
                {
                    return false;
                }
            }

            return true;
        }
        static public string PlakaAl(string mesaj)
        {

            string plaka;
            do
            {
                try
                {
                    Console.Write(mesaj);
                    plaka = Console.ReadLine().ToUpper();
                    Program.xMi(plaka);
                    if (!PlakaMi(plaka))
                    {
                        throw new Exception("Bu şekilde plaka girişi yapamazsınız. Tekrar deneyin.");

                    }

                    return plaka;


                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }


            } while (true);
        }

        static public bool SayiMi(string giris)
        {
            foreach (char item in giris)
            {
                if (!Char.IsNumber(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
