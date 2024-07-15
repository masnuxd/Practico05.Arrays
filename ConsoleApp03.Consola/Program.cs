using ConsoleTables;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
namespace ConsoleApp03.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Diseñe un programa que me permita ingresar nombres de personas en un vector de 8
            //posiciones.El nombre de la persona no puede ser nulo y no puede tener más de 12
            //caracteres.Al finalizar el ingreso desarrollar lo siguiente:
            //• Mostrar aquellos nombres que comienzan con la letra “C”. (Modificar luego
            //para que comience con cualquier letra informada por el usuario).
            //• Informe además cuantos nombres comienzan con una vocal. (Investigar
            //métodos del tipo string)
            //• Mostrar los nombres ingresados junto con la cantidad de caracteres de cada
            //uno y la cantidad de vocales.
            //• Utilizar un menú para acceder a todas las opciones

            string[] personas = {"Maria","emanuel","Carla","Cesar","Asan","aseres","Norma","abian"};
            do
            {
                Console.Clear();
                Console.WriteLine("0 - Cerrar el programa...");
                Console.WriteLine("1 - Ingresar nombres de personas...");
                Console.WriteLine("2 - Mostrar lista por letra ingresada...");
                Console.WriteLine("3 - Mostrar lista por que inician con una vocal...");
                Console.WriteLine("4 - Mostrar lista con Cantidad de caracteres y vocales...");
                

                switch (Opcion())
                {
                    case 0:
                        return;
                    case 1: 
                        IngresarPersonas(personas);
                        break;
                    case 2:
                        MostrarListaPorLetra(personas);
                        break;
                    case 3:
                        MostrarListaPorVocal(personas);
                        break;
                    case 4:
                        MostrarListaPorCaracteres(personas);    
                        break;
                    default:
                        break;
                }
            } while (true);            
            



        }

        private static void MostrarListaPorCaracteres(string[] personas)
        {
            Console.Clear();
            Array.Sort(personas);
            string[] vocales = { "A", "E", "I", "O", "U", "a", "e", "i", "o", "u" };
            var tabla = new ConsoleTable("Nombres","Cant.Letras","Cant.Vocales");
            foreach (var item in personas)
            {
                
                var contadorVocales = 0;
                for (int i = 0; i < vocales.Length; i++)
                {

                    if (item.Contains(vocales[i]))
                    {
                        contadorVocales++;
                    }
                    
                }
                tabla.AddRow(item, item.Length, contadorVocales);
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Precione una tecla para Continuar...");
        }
        private static void MostrarListaPorVocal(string[] personas)
        {
            Console.Clear();
            Array.Sort(personas);
            string[] vocales = {"A","E","I","O","U", "a", "e", "i", "o", "u" };
            var tabla = new ConsoleTable("Vocales","Nombres");
            foreach (var item in personas)
            {
                for (int i = 0; i < vocales.Length; i++)
                {
                    if (item.StartsWith(vocales[i]))
                    {
                        tabla.AddRow(vocales[i].ToUpper(),item);
                    }
                }
               
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Precione una tecla para Continuar...");
        }

        private static void MostrarListaPorLetra(string[] personas)
        {
            Console.Write("Ingrese una letra:");
            string letraIngresada = Console.ReadLine();
            var tabla = new ConsoleTable($"Letra:{letraIngresada}", "Nombres");
            foreach (var item in personas)
            {
                if (item.StartsWith(letraIngresada.ToUpper()))
                {
                    tabla.AddRow("",item);       
                }
            }
            Console.WriteLine(tabla.ToString());
            EsperaTecla("Presione una tecla para continuar...");
        }

        private static void IngresarPersonas(string[] personas)
        {
            Console.Clear();
            for (int i = 0; i < personas.Length; i++)
            {
                Console.Write($"Ingrese el nombre de la {i+1}° peersona:");
                personas[i] = Console.ReadLine();
                
            }
            EsperaTecla("Precione una tecla para Continuar...");
        }

        private static void EsperaTecla(string v)
        {
            Console.WriteLine(v);
            Console.ReadKey();  
        }

        private static int Opcion()
        {
            
            do
            {
                Console.Write("Ingrese la opcion a seleccionar:");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("La opcion esta mal ingresada. Vuelva a ingresarla:");
                }
                return value;
            } while (true);
            
            
        }
    }
}