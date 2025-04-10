using System.Numerics;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CASA_CAMBIO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("CASA DE CAMBIO - RIVERA"); //Imprime Titulo
            Console.WriteLine("************************");

            //Menu
            Console.WriteLine("\n 1- De Dolares a Soles ");
            Console.WriteLine("\n 2- De Euros a Soles ");
            Console.WriteLine("\n 3-Reporte del Dia ");
            Console.WriteLine(" ");

            //Elegir menu
            Console.WriteLine("Ingrese tipo de cambio : "); //
            
            string valor = Console.ReadLine(); //Leemos datos
            int opcion = int.Parse(valor);
            double dolar, euros, totaldolar, totaleuros;
            double tcd = 0;
            double tce = 4.20;

            //Creamos la estructura
            switch (opcion) //Evaluo valor de la variable
            {
                // Tomamos decisiones en cada caso
                case 1:
                    Console.Write("Tipo de Camio Hoy ");
                    tcd = double.Parse(Console.ReadLine());

                    Console.Write("Dolares a cambiar: ");
                    dolar = double.Parse(Console.ReadLine());                  

                    totaldolar= tcd * dolar;

                    Console.WriteLine("Total de S/. "+ totaldolar);

                    break; //Si no ponemos esta sentencia se queda en un bucle


                case 2:
                    Console.WriteLine("Tipo de Cambio de hoy S/.: " + tce);

                    Console.Write("Euros a cambiar: ");
                    euros = double.Parse(Console.ReadLine());

                    totaleuros = tce * euros;

                    Console.WriteLine("Total de S/. " + totaleuros);
                    break;               
                case 3:
                    Console.WriteLine("Reporte del Dia");
                    break;

                // Si presiona numero que no esta en el Rango 
                default:
                    Console.WriteLine("Opcion no encontrada ...!!!!!!!!!!! ");
                    break;
            }
        }
    }
}
