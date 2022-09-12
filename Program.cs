using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace CreacionTxt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String primerNumero;
            DateTime today = DateTime.Now;
            String nombre;
            bool entero = true;
            //Puedes consultar tu nombre de maquina por codigo y concatenar en la cadena
            //asi evitando dejar estatico tu nombre de red
            //Investiga sttings o variable sinternas de visual studio
            string folderPath = @"C:\Users\Saday Nava\Downloads\Ejercicio";
            string doc = $"{folderPath}\\EscribeLineas.txt";
            /* 
             string folderPath = @"C:\Users\Saday Nava\Downloads\Ejercicio";
             if (!Directory.Exists(folderPath))
             {
                 Directory.CreateDirectory(folderPath);
                 Console.WriteLine(folderPath);                

             }

                 string[] lines = { "Primera Línea", "Segunda Línea", "Tercera Línea" };
                 System.IO.File.WriteAllLines($"{folderPath}\\EscribeLineas.txt", lines);
             */

            Console.WriteLine("************ MENU ************");
            Console.Write("Introduce usuario: ");
            nombre = Console.ReadLine();
            Console.Write("Introduce el edad: ");
            primerNumero = Console.ReadLine();//primerNumero = Convert.ToInt32(Console.ReadLine());
            entero = Entero(entero, primerNumero);

            while(entero != true)
            {
                Console.Write("Favor de ingresar un numero entero \n");
                Console.Write("Introduce la edad: ");
                primerNumero = Console.ReadLine();
                entero = Entero(entero, primerNumero);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Console.WriteLine(folderPath);

                }
                if (!File.Exists(doc))
                {
                    string[] lines = { $"{nombre} ingreso un dato erroneo", $"------> fecha {today}" };
                    System.IO.File.WriteAllLines(doc, lines);

                }
                else
                {
                    StreamReader sr = new StreamReader(doc);
                    String line = sr.ReadLine();
                    //Continue to read until you reach end of file
                    while (line == null)
                    {
                        StreamWriter sw = new StreamWriter(doc);
                        //Write a line of text
                        sw.WriteLine($"{nombre} ingreso un dato erroneo");
                        //Write a second line of text
                        sw.WriteLine($"------> el dia {today}");
                        //Close the file
                        sw.Close();
                    }
                    sr.Close();
                }
                
            } 

            Console.Write("Muchas Gracias!\n");
            Console.WriteLine("Nombre {0}, Edad {1} ",
                nombre,primerNumero);
            Console.ReadKey();
        }

        static bool Entero(bool entero, String primerNumero)
        {
            char[] test = primerNumero.ToCharArray();
            for (int i = 0; i < test.Length; i++)
            {
                if (test[i] == '.')
                {entero = false;}
                else
                { entero = true;}

                if (entero == false)
                {
                    entero = false;
                    break;
                }
            }
            return (entero);
        }
    }
}
