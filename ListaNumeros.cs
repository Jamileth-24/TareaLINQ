using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaNumeros
{
    class ListaNumeros
    {
          static  bool Primo (int numero) {
               int a=0;
                 for (int i = 1; i < (numero + 1); i++)
                 {
                     if (numero % i == 0)
                     {
                         a++;
                     }

                 }
                 if (a == 2)
                 {
                    return true;
                 }
                return false;
        }
      

        static void Main(string[] args)
        {
            List<Int32> listanumero = new List<Int32> { };

            Random random = new Random();

            for (int i = 0; i <50; i++)//lista de 50 numeros
            {
                listanumero.Add(random.Next(1, 101));
            }
            /////////////////////////////////Mostrar en consola todos los números primos.///////////////////////////////////////////////
            Console.WriteLine("*****Los números primos son:***** ");
            var nprimo = from l in listanumero where Primo(l) select l;
            foreach (var item in nprimo)
            {
                Console.WriteLine(item);
            }

            /////////////////////////////////////Mostrar en consola la suma de todos los elementos.////////////////////////////////////////////

            var suma = listanumero.Sum();
            Console.WriteLine();
            Console.WriteLine("La suma de los elementos es: " + suma);


            //////////////////////////////////////•	Generar una nueva lista con el cuadrado de los números.//////////////////////////////////////
            // Cuadrado de los números

            List<Double> listanumCuadrado = new List<Double> { };

            foreach (double item in listanumero)
            {
                listanumCuadrado.Add(Math.Pow(item, 2));
             
            }

            /////////////////////////////////////•	Generar una nueva lista con los números primos.////////////////////////////////////////////////

            List<Int32> listaPrimos = new List<Int32> { };

            foreach (var item in nprimo)
            {
                listaPrimos.Add(item);
            }
            /////////////////////////////////	Optener el promedio de todos los números mayores a 50./////////////////////////////////////
            int smayor = 0;
            int cont = 0;
            foreach (var item in listanumero)
            {
                if (item > 50)
                {
                    smayor+=item;
                    cont++;
                }
            }
            double promedio = smayor / cont;
            Console.WriteLine();
            Console.WriteLine("Promedio de números mayores a 50 es:   "+promedio);

            /////////////////////////////////////////Mostrar en consola los número unicos.//////////////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("*****Valores únicos*****");
            var vunico = (from unico in listanumero select unico).Distinct();
            foreach (var item in vunico)
            {
                Console.WriteLine(item);
            }
            //////////////////////////////////////////////Contar la cantidad de elementos Pares e Impares//////////////////////////////////////// 
            int par = 0;
            int impar = 0;
            foreach (var item in listanumero)
            {
                
                if (item % 2 == 0)
                {
                    par++;
                }
                else
                {
                    impar++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Total de elementos pares = " + par);
            Console.WriteLine("Total de elementos impares = " + impar);

            //////////////////////////////////////////////////Suma de los números únicos///////////////////////////////////////////////////////////////////
            var s_unico = vunico.Sum();
            Console.WriteLine();
            Console.WriteLine("La suma de los elementos únicos es: " + s_unico);

            /////////////////////////////////////////////////Mostrar en consola los elementos de forma descendente.///////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("*****Elementos en orden descendentes*****");
            (from r in listanumero
                 orderby r descending
                 select r).ToList().ForEach(p => { Console.WriteLine(p); });
            Console.ReadKey();
        }
    }
}
