
using System.Text;
using ConsoleTables;

namespace ConsoleApp04.Consola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //4.Diseñe un programa que me permita almacenar las máximas temperaturas alcanzadas
            //en una semana, las mismas deberán estar comprendidas en el rango de - 10 y 24
            //grados.El programa deberá permitir modificar las temperaturas ingresadas, listar las
            //mismas en el orden que fueron ingresadas junto con su equivalente en Fahrenheit,
            //informar la mayor y menor temperatura y el promedio de las mismas.Marcar las
            //temperaturas superiores al promedio de temperaturas.
            //• Considerar contar con un menú en la aplicación para poder llevar adelante
            //todo lo solicitado.
            //• Considerar que se puedan repetir las temperaturas.
            //• Considerar informar la máxima y mínima junto con la fecha que se produjo.
            //• Considerar ordenar las temperaturas.
            string[] diasSemana = { "Domingo", "Lunes","Martes","Miercoles","Jueves","Viernes","Sabado" };
            int[] temperaturasMaximas = new int[diasSemana.Length] ;

            do
            {
                Console.Clear();
                Console.WriteLine("0 - Salir del programa...");
                Console.WriteLine("1 - Ingreso de temperaturas de la semana...");
                Console.WriteLine("2 - Mostrar lista de temperaturas en Celcius y Fahreneit...");
                Console.WriteLine("3 - Modificar lista de temperaturas...");
                Console.WriteLine("4 - Mostrar datos estadisticos...");
                Console.WriteLine("5 - Temperaturas mayores al promedio...");
                Console.WriteLine("6 - Ordenar temperaturas...");
                EspereTecla("Precione una tecla para Continuar...");
                switch (Opcion())
                {
                    case 0:
                        return;
                    case 1:
                        TemperaturasIngresadas(temperaturasMaximas,diasSemana);
                        break;
                    case 2:
                        MostrarLista(temperaturasMaximas,diasSemana);
                        break;
                    case 3:
                        ModificarTemperatura(temperaturasMaximas, diasSemana);
                        break;
                    case 4:
                        MostrarDatosEstadisticos(temperaturasMaximas);
                        break;
                    case 5:
                        MayoresAlPromedio(temperaturasMaximas);
                        break;
                    case 6:
                        OrdenarTemperaturas(temperaturasMaximas);   
                        break;
                    default:
                        break;
                }
            } while (true);

        }

        private static void OrdenarTemperaturas(int[] temperaturasMaximas)
        {
            Console.Clear();
            Console.WriteLine("Temperaturas Ordenadas...");
            Array.Sort(temperaturasMaximas);
            EspereTecla("Precione una tecla para Continuar...");
        }

        private static void MayoresAlPromedio(int[] temperaturasMaximas)
        {
            Console.Clear();
            var promedio = temperaturasMaximas.Average();
            var tabla = new ConsoleTable($"Temp. Prom:{promedio}","Temperaturas", "Mayor. Prom");
            Console.WriteLine("Datos cargado correctamente...");
            foreach (var item in temperaturasMaximas)
            {
                if (item > promedio)
                {
                    tabla.AddRow("", item, "Mayor al promedio.");

                }
                else 
                {
                    tabla.AddRow("", item, "Menor al promedio.");
                }
            }
            Console.WriteLine(tabla.ToString());
            EspereTecla("Precione una tecla para Continuar...");
        }

        

        private static void MostrarDatosEstadisticos(int[] temperaturasMaximas)
        {
            Console.Clear();
            var tempMax = temperaturasMaximas.Max();
            var tempMin = temperaturasMaximas.Min();
            var promedio = temperaturasMaximas.Average();


            StringBuilder sb = new();
            sb.AppendLine($"La temperatura Maxima alcanzada es: {tempMax}");
            sb.AppendLine($"La temperatura minima alcanzada es: {tempMax}");
            sb.AppendLine($"El promedio de la temperaturas es: {promedio}");
            Console.WriteLine(sb.ToString());
            Console.WriteLine("Datos estadisticos cargados...");
            EspereTecla("Presione una tecla para Continuar...");
        }

        private static void ModificarTemperatura(int[] temperaturasMaximas, string[] diasSemana)
        {
            Console.Clear();
            var tabla = new ConsoleTable("Pos. a Mod.","Dia semana", "Celcuis");
            for (var i = 0; i < diasSemana.Length;)
            {

                for (i = 0; i < temperaturasMaximas.Length; i++)
                {
                    tabla.AddRow(i,diasSemana[i], temperaturasMaximas[i]);
                }
                
            }
            Console.WriteLine(tabla.ToString());

            do
            {
                Console.Write("Ingrese el numero de la pocicion a modificar:");
                var select = Opcion();
                if (select <= temperaturasMaximas.Length)
                {
                    var b = ValidarTemperatura();
                   
                    temperaturasMaximas[select] = b;  
                    break;
                }
                else
                {
                    Console.WriteLine("La pocicion ingresada no en valida. Vuelva a ingresarla...");
                }

            } while (true);
            
            Console.WriteLine("Listado completado...");
            EspereTecla("Presione una tecla para Continuar...");
            Console.WriteLine(tabla.ToString());
        }

        private static int ValidarTemperatura()
        {
            int value=0;

            do
            {
                Console.Write($"Ingrese la temperatura a modificar:");

                if (!int.TryParse(Console.ReadLine(), out value))
                {
                    Console.WriteLine("La temperatura esta mal ingresada. Vuelva a ingresarlo:");
                }
                else
                {
                    if (value >= 10 && value <= 24)
                    {
                        return value;

                    }
                }
            } while (true);

        }

        private static void MostrarLista(int[] temperaturasMaximas, string[] diasSemana)
        {
            Console.Clear();
            var tabla = new ConsoleTable("Dia semana","Celcuis","Fahreneit");
            for (var i= 0;i < diasSemana.Length;)
            {
                
                for (i=0;i <  temperaturasMaximas.Length;i++)
                {
                    tabla.AddRow(diasSemana[i], temperaturasMaximas[i], ConvertirFahreneit(temperaturasMaximas[i]));
                }
               
            }
            Console.WriteLine("Listado completado...");
           
            Console.WriteLine(tabla.ToString());
            EspereTecla("Presione una tecla para Continuar...");
        }

        private static double ConvertirFahreneit(double item)
        {
            return 1.8 * item + 32;
        }

        private static void TemperaturasIngresadas(int[] temperaturasMaxima, string[]diasSemana)
        {
           
            Console.Clear();
            
            for (int i = 0; i < diasSemana.Length;i++)
            {
                var f = true;
                int value = 0;
                do
                {
                    Console.Write($"Ingrese la temperatura del {diasSemana[i]}");

                    if (!int.TryParse(Console.ReadLine(), out value))
                    {
                        Console.WriteLine("La temperatura esta mal ingresada. Vuelva a ingresarlo:");
                    }
                    else
                    {
                        if (value >= 10 && value <= 24)
                        {
                            for (int r = 0; r < temperaturasMaxima.Length;r++)
                            {
                                temperaturasMaxima[r] = value;
                                
                            }
                            break;
                            
                        }
                        else
                        {
                            Console.WriteLine("La temperatura ingresada no puede ser mayor a 24° y menor que 10°");
                        }
                    }
                   


                } while (f);

                
            }
            Console.WriteLine("Temperaturas de la semana ingresadas correctamente...");
            EspereTecla("Precione una tecla para Continuar...");
        }

        

        private static void EspereTecla(string v)
        {
            Console.WriteLine(v);
            Console.ReadKey();
        }

        private static int Opcion()
        {
            do
            {
                Console.Write("Ingrese una opcion a realizar:");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("La opcion ingresada no es valida. Vuelva a ingresarla:");
                }
                else
                {
                    return value;

                }
            } while (true);
        }
    }
}
