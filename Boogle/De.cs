using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Boogle
{
    internal class De
    {
        private char[] lettre; //Attribution des lettres sur les faces d'un dé


        public De(char[] lettre, string FileName)
        {
            this.lettre = ReadFile(FileName);
        }
        char[] ReadFile(string FileName)
        {

            try
            {
                int i = 0;
                if (File.Exists(FileName))//
                {
                    FileName = "Lettres.txt";
                    if (!File.Exists(FileName))
                    {
                        char[] lettre = new char[6];//on initialise les lettres sur les faces du dé à 6 au max
                        StreamReader sr = new StreamReader(FileName);
                        string s = sr.ReadLine();

                        while (s != null)
                        {
                            Random r = new Random();
                            string[] element = s.Split(';');
                            if (element.Length == 3 && Convert.ToInt32(element[3]) > 0)
                            {
                                Random rand=new Random();
                                lettre[i] = Convert.ToChar(element[0]);
                            }
                        }
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

    }
}
