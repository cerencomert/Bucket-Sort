using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bucket_Sort
{
    class BucketSort
    {
        public static List<int> Sirala(params int[] x)
        {
            List<int> siraliListe = new List<int>();

            int kapsayisi = 10;

            //Kovaları oluşturuyoruz
            List<int>[] kovalar = new List<int>[kapsayisi];
            for (int i = 0; i < kapsayisi; i++)
            {
                kovalar[i] = new List<int>();
            }

            for (int i = 0; i < x.Length; i++)
            {
                int kova = (x[i] / kapsayisi);
                kovalar[kova].Add(x[i]);
            }

            //Her kovayı sıralayıp listeye ekleniyor
            for (int i = 0; i < kapsayisi; i++)
            {
                List<int> temp = InsertionSort(kovalar[i]);
                siraliListe.AddRange(temp);
            }
            return siraliListe;
        }

        //Burası insertion sort
        public static List<int> InsertionSort(List<int> girdi)
        {
            for (int i = 1; i < girdi.Count; i++)
            {
                int deger = girdi[i];
                int pointer = i - 1;
              
                while (pointer >= 0)
                {
                    if (deger < girdi[pointer])
                    {
                        girdi[pointer + 1] = girdi[pointer];
                        girdi[pointer] = deger;
                    }
                    else break;
                }
            }

            return girdi;
        }
        static void Main(string[] args)
        {
            int[] dizi = new int[] { 43, 17, 87, 92, 31, 6, 96, 13, 66, 62, 4 };

            Console.WriteLine("Orjinal Dizi\n");

            for (int i = 0; i < dizi.Length; i++)
            {
                Console.Write(dizi[i] +" - ");

            }

            Console.WriteLine("\n\nBucket ile Sıralanmış Dizi");

            List<int> sirali = Sirala(dizi);

            for (int i = 0; i < sirali.Count; i++)
            {
                Console.Write(sirali[i]+" - ");
            }
          
            Console.ReadLine();
        }
    }
}
