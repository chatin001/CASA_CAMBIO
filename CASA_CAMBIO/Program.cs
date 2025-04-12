
// ***********************************
// TRABAJO FINAL - APLICACION DE CONSOLA
// AUTOR: RIVERA YATACO JUAN MANUEL
// TEMA: CASA DE CAMBIO
// ***********************************



namespace CASA_CAMBIO
{
    internal class Program
    {
        // Defino estructura para almacenar las transacciones
        struct Transaccion
        {
            public int tipo;           // 1.Dolar, 2.Euro
            public double tipoCambio;   
            public double cantidad;    
            public double total;      
            public DateTime fecha;   
        }

        static void Main(string[] args)
        {
            // Matriz para almacenar las transacciones (máximo 10)
            Transaccion[] transacciones = new Transaccion[10];
            int contadorTransacciones = 0;
            bool continuar = true;

            double tcd = 0;  
            double tce = 4.20;  

            while (continuar && contadorTransacciones < 10)
            {
                Console.Clear();
                Console.WriteLine("CASA DE CAMBIO - RIVERA");  
                Console.WriteLine("************************");
                //Menu
                Console.WriteLine("\n 1- De Dolares a Soles ");
                Console.WriteLine("\n 2- De Euros a Soles ");
                Console.WriteLine("\n 3- Reporte del Dia ");
                Console.WriteLine("\n 4- Salir");
                Console.WriteLine(" ");

                //Elegir menu con validación
                int opcion = 0;
                bool entradaValida = false;

                do
                {
                    Console.Write("Ingrese opción (1-4): ");
                    string valor = Console.ReadLine();  

                    // Validamos que sea un número
                    entradaValida = int.TryParse(valor, out opcion);

                    if (!entradaValida)
                    {
                        Console.WriteLine("Error: Solo se permiten números. Intente nuevamente.");
                    }

                } while (!entradaValida);

                switch (opcion)  
                {
                    case 1: 
                        double tipoCambioDolar = 0;
                        bool tipoCambioValido = false;

                        do
                        {
                            Console.Write("Tipo de Cambio Hoy: ");
                            string valorTC = Console.ReadLine();
                            tipoCambioValido = double.TryParse(valorTC, out tipoCambioDolar);

                            if (!tipoCambioValido)
                            {
                                Console.WriteLine("Error: Solo se permiten números. Intente nuevamente.");
                            }
                        } while (!tipoCambioValido);

                        tcd = tipoCambioDolar;

                        bool dolaresValido = false;
                        double dolar = 0;

                        do
                        {
                            Console.Write("Dolares a cambiar: ");
                            string valorDolares = Console.ReadLine();
                            dolaresValido = double.TryParse(valorDolares, out dolar);

                            if (!dolaresValido)
                            {
                                Console.WriteLine("Error: Solo se permiten números. Intente nuevamente.");
                            }
                        } while (!dolaresValido);

                        double totaldolar = tcd * dolar;
                        Console.WriteLine("Total de S/. " + totaldolar);

                        // Guardar la transacción en la matriz
                        transacciones[contadorTransacciones].tipo = 1;
                        transacciones[contadorTransacciones].tipoCambio = tcd;
                        transacciones[contadorTransacciones].cantidad = dolar;
                        transacciones[contadorTransacciones].total = totaldolar;
                        transacciones[contadorTransacciones].fecha = DateTime.Now;

                        contadorTransacciones++;

                        Console.WriteLine("\nTransacción registrada correctamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 2:  
                        Console.WriteLine("Tipo de Cambio de hoy S/.: " + tce);

                        bool eurosValido = false;
                        double euros = 0;

                        do
                        {
                            Console.Write("Euros a cambiar: ");
                            string valorEuros = Console.ReadLine();
                            eurosValido = double.TryParse(valorEuros, out euros);

                            if (!eurosValido)
                            {
                                Console.WriteLine("Error: Solo se permiten números. Intente nuevamente.");
                            }
                        } while (!eurosValido);

                        double totaleuros = tce * euros;
                        Console.WriteLine("Total de S/. " + totaleuros);

                        // Guardo la transacción matriz
                        transacciones[contadorTransacciones].tipo = 2;
                        transacciones[contadorTransacciones].tipoCambio = tce;
                        transacciones[contadorTransacciones].cantidad = euros;
                        transacciones[contadorTransacciones].total = totaleuros;
                        transacciones[contadorTransacciones].fecha = DateTime.Now;

                        contadorTransacciones++;

                        Console.WriteLine("\nTransacción registrada correctamente.");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 3: 
                        MostrarReporte(transacciones, contadorTransacciones);
                        Console.WriteLine("\nPresione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;

                    case 4: 
                        continuar = false;
                        Console.WriteLine("Gracias por usar la Casa de Cambio RIVERA");
                        break;

                    default:  
                        Console.WriteLine("Opción no encontrada ...!!!!!!!!!!! ");
                        Console.WriteLine("Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }

            // Límite de transacciones
            if (contadorTransacciones >= 10)
            {
                Console.WriteLine("\nSe ha alcanzado el límite máximo de transacciones.");
                Console.WriteLine("Presione cualquier tecla para ver el reporte final...");
                Console.ReadKey();
                MostrarReporte(transacciones, contadorTransacciones);
            }
        }

        // Método para mostrar el reporte de transacciones
        static void MostrarReporte(Transaccion[] transacciones, int contador)
        {
            Console.Clear();
            Console.WriteLine("REPORTE DEL DÍA - CASA DE CAMBIO RIVERA");
            Console.WriteLine("=======================================");

            if (contador == 0)
            {
                Console.WriteLine("\nNo hay transacciones registradas.");
                return;
            }

            double totalDolares = 0;
            double totalEuros = 0;
            double totalSolesDolares = 0;
            double totalSolesEuros = 0;

            Console.WriteLine("\nLista de transacciones:");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("| N° | Tipo    | Tipo Cambio | Cantidad | Total (S/.) | Fecha y Hora        |");
            Console.WriteLine("------------------------------------------------------------------------------");

            for (int i = 0; i < contador; i++)
            {
                string tipo = transacciones[i].tipo == 1 ? "Dólar" : "Euro";

                Console.WriteLine("| {0,-2} | {1,-7} | {2,-11:F2} | {3,-8:F2} | {4,-10:F2} | {5,-19} |",
                    i + 1,
                    tipo,
                    transacciones[i].tipoCambio,
                    transacciones[i].cantidad,
                    transacciones[i].total,
                    transacciones[i].fecha.ToString("dd/MM/yyyy HH:mm"));

                // Acumulacion de  total según tipo de moneda
                if (transacciones[i].tipo == 1)
                {
                    totalDolares += transacciones[i].cantidad;
                    totalSolesDolares += transacciones[i].total;
                }
                else
                {
                    totalEuros += transacciones[i].cantidad;
                    totalSolesEuros += transacciones[i].total;
                }
            }


                  

            Console.WriteLine("------------------------------------------------------------------------------");

            // Mostramos resumen
            Console.WriteLine("\nRESUMEN:");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Total de transacciones Diario: " + contador);


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Total de dólares cambiados: " + totalDolares.ToString("F2") + " $ USD");
            Console.ResetColor(); // Restaura el color predeterminado


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Total de euros cambiados: " + totalEuros.ToString("F2") + " EUR");
            Console.ResetColor();

            Console.WriteLine("Total en soles por dólares: S/. " + totalSolesDolares.ToString("F2"));


            Console.WriteLine("Total en soles por euros: S/. " + totalSolesEuros.ToString("F2"));

            Console.ForegroundColor = ConsoleColor.Yellow;
           // Console.WriteLine("TOTAL GENERAL EN SOLES: S/. " + (totalSolesDolares + totalSolesEuros).ToString("F2"));

            Console.ResetColor();

            Console.WriteLine("---------------------------------------");
        }
    }
}