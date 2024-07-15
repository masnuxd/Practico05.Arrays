using System.ComponentModel;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using ConsoleTables;


namespace ConsoleApp02.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            //2.Ingrese en un vector de 10 posiciones la velocidad expresada en km/ que tienen que
            //estar entre 100 y 300 kms.Al finalizar el ingreso de los mismos hacer lo siguiente:
            //• Mostrar un listado de los valores alcanzados con su equivalente en millas/ h.
            //• Informar además la mayor y menor velocidades, así como también la
            //velocidad media.
            //• Al listar marque con un asterisco aquellas velocidades superiores al
            //promedio de velocidad.
            //• Mostrar la lista ordenada.
            //• Informe la cantidad de velocidades inferiores al promedio.
            //• Utilizar un menú para acceder a todas las opciones
            int[] velocidades = new int[10];
           
            do
            {
                Console.Clear();
                Console.WriteLine("0 - Cerrar el programa...");
                Console.WriteLine("1 - Ingreso de velocidades...");
                Console.WriteLine("2 - Mostrar en kilometros y millas...");
                Console.WriteLine("3 - Datos estadisticos...");
                Console.WriteLine("4 - Velocidades mayores al promedio...");
                Console.WriteLine("5 - Ordenar y mostrar velocidades...");
                Console.WriteLine("6 - Velocidades menores a promedio...");
                switch (OpcionIngresada())
                {
                    case 0:
                        return;
                    case 1:
                        GenerarNumeros(velocidades);
                        break;
                    case 2:
                        EstaVacio(velocidades);
                        MostrarVelocidadesEnKilometrosEnMillas(velocidades);
                        break;
                    case 3:
                        EstaVacio(velocidades);
                        MostrarEstadisticas(velocidades);
                        break;
                    case 4:
                        EstaVacio(velocidades);
                        MayoresAlPromedio(velocidades);
                        break;
                    case 5:
                        EstaVacio(velocidades);
                        OrdenarMostrarVelocidades(velocidades);
                        break;
                    case 6:
                        EstaVacio(velocidades);
                        MenoresAlPromedio(velocidades);
                        break;
                    default:
                        
                        break;
                }
            } while (true);
            
            
        }

        private static void MenoresAlPromedio(int[] velocidades)
        {
            Console.Clear();
            var velPromedio = velocidades.Average();
            var tabla = new ConsoleTable("Pocicion", "Kilometros", "Menor Promedio");

            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = CalcularMillas(velocidades[i]);
                if (velocidades[i] < velPromedio)
                {
                    tabla.AddRow(i, velocidades[i], "Menor al Promedio");
                }
                else
                {
                    tabla.AddRow(i, velocidades[i], "");
                }



            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void OrdenarMostrarVelocidades(int[] velocidades)
        {
            Array.Sort(velocidades);
            MostrarVelocidadesEnKilometrosEnMillas(velocidades);
        }

        private static void MayoresAlPromedio(int[] velocidades)
        {
            Console.Clear();
            var velPromedio = velocidades.Average();
            var tabla = new ConsoleTable("Pocicion", "Kilometros","Mayor Promedio");

            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = CalcularMillas(velocidades[i]);
                if (velocidades[i] > velPromedio)
                {
                    tabla.AddRow(i, velocidades[i], "Mayor al Promedio");
                }
                else
                {
                    tabla.AddRow(i, velocidades[i], "");
                }

                

            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void MostrarEstadisticas(int[] velocidades)
        {
            Console.Clear();
            int numMax = velocidades.Max();
            int numMin = velocidades.Min();
            double promedio = velocidades.Average();
            Console.WriteLine("Datos estadisticos completados...");
            EsperarTecla("Presione una tecla para mostrar los datos");
            var sb = new StringBuilder();
            sb.AppendLine($"La mayor velocidad es: {numMax}");
            sb.AppendLine($"La menor velocidad es: {numMin}");
            sb.AppendLine($"El promedio de las velocidades es: {promedio}");
            Console.WriteLine(sb.ToString());
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static void MostrarVelocidadesEnKilometrosEnMillas(int[] velocidades)
        {
            Console.Clear();
            var tabla = new ConsoleTable("Pocicion","Kilometros","Millas");
            
            for (int i = 0; i < velocidades.Length; i++)
            {
                var millas = CalcularMillas(velocidades[i]);
                tabla.AddRow(i, velocidades[i],millas);

            }
            Console.WriteLine(tabla.ToString());
            EsperarTecla("Precione una tecla para Continuar...");

        }

        private static double CalcularMillas(int v)
        {

            return v * 0.6314;
        }

        private static bool EstaVacio(int[] velocidades)
        {
            if (velocidades.All(x => x == 0))
            {
                Console.Clear();
                Console.WriteLine("El vector esta vacio...");
                EsperarTecla("Si desea rellenarlo. Precione cualquiee tecla...");
                GenerarNumeros(velocidades);
            }
            return false;
        }

        private static int OpcionIngresada()

        {
            do
            {
                Console.Write("Ingese su opcion a realizar:");
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

        private static void GenerarNumeros(int[] velocidades)
        {
            Console.Clear();
            var numerosAzar = new Random();
            for (int i = 0; i < velocidades.Length; i++)
            {
                velocidades[i] = numerosAzar.Next(100, 301);

            }
            Console.WriteLine("Numeros generados correctamente...");
            EsperarTecla("Precione una tecla para Continuar...");
        }

        private static char EsperarTecla(string v)
        {
            
            Console.WriteLine(v);
            var tecla = Console.ReadKey();
            return tecla.KeyChar;
        }
    }
    
}
