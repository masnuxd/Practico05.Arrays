using System.Collections.Concurrent;
using System.Diagnostics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Channels;
using ConsoleTables;

namespace ConsoleApp1.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            //1.Diseñe un programa que me permita almacenar en un array de 10 posiciones, números
            //  al azar.Al finalizar el proceso:
            //• Mostrar la lista de los números generados en una tabla.
            //• Mostrar el mayor y el menor número generado.
            //• Mostrar la lista ordenada.
            //• Mostrar los números pares.
            //• Mostrar los números primos.
            //• Utilizar un menú para ir a todas las opciones.

            Console.WriteLine("Iniciando el programa...");
            EsperarTecla("Presione una tacla para Continuar...");
            Console.Clear();

            int[] numeros = new int[10]; 

            do
            {
                Console.Clear();   
                Console.WriteLine("0 - Salir del programa...");
                Console.WriteLine("1 - Ingreso de los numeros...");
                Console.WriteLine("2 - Mostrar numeros ingresados...");
                Console.WriteLine("3 - Datos estadisticos...");
                Console.WriteLine("4 - Mostrar numeros primos...");
                Console.WriteLine("5 - Mostrar numeros pares...");
                Console.WriteLine("6 - Ordenar lista de numeros...");

                switch (Opcion())
                {
                    case 0:
                        Console.WriteLine("Cerrando el programa...");
                        EsperarTecla("Programa cerrado correctamente, Precione una tecla para Continuar...");
                        return;
                    case 1:
                        GenerarNumeros(numeros);
                        break;
                    case 2:
                        EstaVacio(numeros);
                        MostrarDatos(numeros);
                        break;
                    case 3:
                        EstaVacio(numeros);
                        MostrarEstadisticas(numeros);
                        break;
                    case 4:
                        EstaVacio(numeros);
                        MostrarPrimos(numeros);
                        break;
                    case 5:
                        EstaVacio(numeros);
                        MostrarPares(numeros);
                        break;
                        case 6:
                        EstaVacio(numeros);
                        OrdenarVector(numeros);

                        break;

                    default:
                        break;
                }
                
            } while (true);


        }

        private static void OrdenarVector(int[] numeros)
        {
            Console.Clear();
            Array.Sort(numeros);
            Console.WriteLine("Vector ordenado...");
            EsperarTecla("Presione una tecla para Continuar...");
            var tabla = new ConsoleTable("Posicion", "Numeros Ordenados");
            for (int i = 0; i < numeros.Length; i++)
            {
              tabla.AddRow(i, numeros[i]);
            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void MostrarPrimos(int[] numeros)
        {
            Console.Clear();
            Console.WriteLine("Datos cargados correctamente...");
            EsperarTecla("Precione una tecla para mostrar los datos en la tabla...");
            var tabla = new ConsoleTable("Posicion", "Numero ingresado", "Nros Primos");
            for (int i = 0; i < numeros.Length; i++)
            {
                if (EsPrimo(numeros[i]))
                {
                    tabla.AddRow(i, numeros[i], "V");
                }
                else
                {
                    tabla.AddRow(i, numeros[i], "F");
                }
            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static bool EsPrimo(int v)
        {

            for (int i = 2; v / 2 <= 0;)
            {
                if (v % i == 0)
                {
                    return false;
                }
            }
            return true;

        }

        private static void MostrarPares(int[] numeros)
        {
            Console.Clear();
            Console.WriteLine("Datos cargados correctamente...");
            EsperarTecla("Precione una tecla para mostrar los datos en la tabla...");
            var tabla = new ConsoleTable("Posicion", "Numero ingresado","Nros Par");
            for (int i = 0; i < numeros.Length; i++)
            {
                if (EsPar(numeros[i]))
                {
                    tabla.AddRow(i, numeros[i], "V");
                }
                else 
                {
                    tabla.AddRow(i, numeros[i], "F");
                }

                

            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static bool EsPar(int v)
        {
            if (v % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void MostrarEstadisticas(int[] numeros)
        {
            Console.Clear();    
            int numMax = numeros.Max();
            int numMin = numeros.Min();
            double promedio = numeros.Average();

            Console.WriteLine("Datos estadisticos completados...");
            EsperarTecla("Presione una tecla para mostrar los datos");
            var sb = new StringBuilder();
            sb.AppendLine($"El numero mayor es: {numMax}");
            sb.AppendLine($"El numero menor es: {numMin}");
            sb.AppendLine($"El promedio de los numeros es: {promedio}");
            Console.WriteLine(sb.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void MostrarDatos(int[] numeros)
        {
            Console.Clear();
            Console.WriteLine("Datos cargados correctamente...");
            EsperarTecla("Precione una tecla para mostrar los datos en la tabla...");
            var tabla = new ConsoleTable("Posicion", "Numero ingresado");
            for (int i = 0; i < numeros.Length; i++) 
            {
               
                tabla.AddRow(i, numeros[i]);
                
            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void GenerarNumeros(int[] numeros)
        {
            Console.Clear();
            var numerosAzar = new Random();
            for (int i = 0; i < numeros.Length; i++)
            {
                numeros[i] = numerosAzar.Next(1,101);

            }
            Console.WriteLine("Numeros generados correctamente...");
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static int Opcion()
        {
            do
            {
                
                Console.Write("Ingrese su opcion a realizar:");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("La opcion esta mal ingresada. Vuelva a ingresarla:");
                }
                else
                {
                    return value;
                }
            } while (true);
        }

        private static char EsperarTecla(string v)
        {
            Console.WriteLine(v);
            var tecla = Console.ReadKey();
            return tecla.KeyChar;
        }
        private static bool EstaVacio(int[] numeros)
        {
          
            if (numeros.All(x => x == 0))
            {
                Console.Clear();
                Console.WriteLine("El vector esta vacio...");
                EsperarTecla("Si desea rellenarlo. Precione cualquiee tecla...");
                GenerarNumeros(numeros);
            }
            return false;
        }
    }
}
