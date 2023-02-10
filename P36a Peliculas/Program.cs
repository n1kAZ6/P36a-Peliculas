using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P36a_Peliculas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sR = new StreamReader(".\\Datos\\pelis.TXT", Encoding.Default);
            string[] vectorCampos;
            string[] vectorCampos2;
            string nombreFichero;


            Console.WriteLine("\tNº\tPelícula\t\t\t\tValor   Form.   Tamaño");
            Console.WriteLine("\t___\t_____________________________________\t_____   _____   ______");

            int orden=1;
            while (!sR.EndOfStream)
            {
                vectorCampos=sR.ReadLine().Split('(');
                vectorCampos2 = vectorCampos[1].Split(')'); 
                Console.WriteLine("\t{0}\t{1}    {2}\t {3}\t {4}", orden,
                        CuadraTexto(vectorCampos[0].Substring(36), 37, '.'),
                        vectorCampos2[0],
                        vectorCampos2[1].Substring(1,3).ToUpper(),
                        Math.Round(Convert.ToDouble((vectorCampos[0].Substring(22,13).Trim()))/1000000000,2));
                orden++;
            }
            sR.Close();

            do
            {
                Console.WriteLine("¿Nombre del fichero (sin extensión) donde guardar los datos? (Intro = salir sin guardar)");
                nombreFichero = Console.ReadLine().ToLower();

                if(nombreFichero=="pelis")
                    Console.WriteLine("El nombre del fichero elegido no puede ser igual que el original");
            } while (nombreFichero == "pelis");

            if (nombreFichero != String.Empty) 
            {
                StreamWriter sW = File.CreateText(String.Format(".\\Datos\\{0}.txt",nombreFichero));
                sR = new StreamReader(".\\Datos\\pelis.TXT", Encoding.Default);
                while (!sR.EndOfStream)
                {
                    vectorCampos = sR.ReadLine().Split('(');
                    vectorCampos2 = vectorCampos[1].Split(')');
                    sW.WriteLine("{0};{1};{2};{3}",
                            vectorCampos[0].Substring(36).Trim(),
                            vectorCampos2[0],
                            vectorCampos2[1].Substring(1, 3).ToUpper(),
                            Math.Round(Convert.ToDouble((vectorCampos[0].Substring(22, 13).Trim())) / 1000000000, 2));
                }
                sW.Close();
            }
            sR.Close();
            


            Console.WriteLine("Pulse una tecla para salir...");
            Console.ReadKey(true);
        }
        static string CuadraTexto(string texto, int numCaracteres, char caracter) 
        {
            if (texto.Length > numCaracteres)
                return texto.Substring(0, numCaracteres);
            while (texto.Length < numCaracteres)             
                texto += caracter;

            return texto.Substring(0, numCaracteres); 
        }
    }
}
