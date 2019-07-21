using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factura
{
    class Factura
    {
        static void Main(string[] args)
        {
            List<Cliente> listacliente = new List<Cliente>
            {
                new Cliente { Id=1, Nombre="Jose Cedeño" },
                new Cliente { Id= 2, Nombre="Maria Lopez" },
                new Cliente { Id=3, Nombre="Viviana Mero" },
                new Cliente { Id=4, Nombre="Jamileth Cedeño" },
                new Cliente { Id=5, Nombre="Ival Garcia" },
                new Cliente{ Id=6, Nombre="Tomy Ancundia" },
                new Cliente{ Id=7, Nombre="Roberth Barre" },
                new Cliente{ Id=8, Nombre="Maykel Zmabrano" },
                new Cliente{ Id=9, Nombre="Carlitos Sanchez" },
                new Cliente{ Id=10, Nombre="Diana Cevallos" },

            };
            List<Facturaa> listafactura = new List<Facturaa>
            {
                new Facturaa { Idcliente=1, Fecha= new DateTime(2019,07,20), Observacion="Cuaderno", Total= 12 },
                new Facturaa { Idcliente=2, Fecha= new DateTime(2019,07,19), Observacion="prob002", Total= 5 },
                new Facturaa { Idcliente=3, Fecha= new DateTime(2019,07,20), Observacion="borrador", Total= 2 },
                new Facturaa { Idcliente=1, Fecha= new DateTime(2019,07,17), Observacion="procesador", Total= 4 },
                new Facturaa { Idcliente=9, Fecha= new DateTime(2019,07,19), Observacion="prob003", Total= 2 },
                new Facturaa { Idcliente=6, Fecha= new DateTime(2019,07,19), Observacion="vaso", Total= 10 },
                new Facturaa { Idcliente=1, Fecha= new DateTime(2019,07,21), Observacion="prob001", Total= 11 },
                new Facturaa { Idcliente=8, Fecha= new DateTime(2019,07,19), Observacion="silla", Total= 20 },
                new Facturaa { Idcliente=9, Fecha= new DateTime(2019,07,22), Observacion="mesa", Total= 16 },
                new Facturaa { Idcliente=10, Fecha= new DateTime(2019,07,21), Observacion="cama", Total= 120 },
            };

            //////////////////////////////////////////////////////Clientes ordenados por Nombre//////////////////////////////////////////////////////////////////////
            IEnumerable<Cliente> listcliente =
                        from c in listacliente
                        orderby c.Nombre ascending
                        select c;

            Console.WriteLine();
            Console.WriteLine("****clientes ordenados por Nombre:****");
                foreach (Cliente c in listcliente)
                {
                    Console.WriteLine(c.Nombre);
                }
                
            ///////////////////////////////////////////////////////Ventas ordenadas por Fecha/////////////////////////////////////////////////////////////////
            IEnumerable<Facturaa> listfactura =
                        from f in listafactura
                        orderby f.Fecha ascending
                        select f;
            Console.WriteLine();
            Console.WriteLine("****ventas ordenadas por Fecha:****");
                foreach (Facturaa item in listfactura)
                {
                        Console.WriteLine("{0} {1} {2}", item.Fecha, item.Observacion, item.Total);

                }
            ///////////////////////////////////////////////////////////////Cliente con Mayor venta/////////////////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("****cliente con mayor venta:****");
            var mayor = (from may in listafactura select may.Total).Max();

            var mayorv = from w in listfactura
                         join g in listacliente on w.Idcliente equals g.Id
                         where mayor == w.Total
                         select new
                              {
                                  nombre = g.Nombre,
                                  observacion = w.Observacion,
                                  fecha= w.Fecha,
                                  total = w.Total
                              };
            foreach (var item in mayorv)
            {
                Console.WriteLine("Cliente: " + item.nombre + "  Observación: " + item.observacion+ "  Fecha: " + item.fecha + "  Total: " + item.total);
            }
            //////////////////////////////////////////////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("****Ventas realizas en menos de 1 año:****");
            DateTime formatofecha  = new DateTime(2019, 01, 01);
            

            var ultVentas = from v in listafactura
                            where  v.Fecha >= formatofecha
                            select v;
            
            var ultvent = from uv in listfactura
                          join g in listacliente on uv.Idcliente equals g.Id
                          where  ultVentas.Equals(uv.Fecha)
                          select new
                          {
                              observacion = uv.Observacion,
                              fecha = uv.Fecha,
                              total = uv.Total
                          };
            foreach (var item in ultvent)
            {
                Console.WriteLine("  Observación: " + item.observacion + "  Fecha: " + item.fecha + "  Total: " + item.total);
            }

            ////////////////////////////////////////////////////Venta más antigua realizada/////////////////////////////////////////
            var antigua = (from ant in listafactura
                           select ant.Fecha).Min() ;

            var asd = from w in listfactura
                      where antigua == w.Fecha
                      select new
                              {
                                  observacion = w.Observacion,
                                  fechav = w.Fecha,
                                  totalv = w.Total
                              };
            foreach (var item in asd)
            {
                Console.WriteLine();
                Console.WriteLine("*****Venta más antigua realizada:***** ");
                Console.WriteLine("Observación: " + item.observacion + "  Fecha: " + item.fechav + "  Total: " + item.totalv);
            }

            //////////////////////////////////////////////////////última venta realizada/////////////////////////////////////////////////
            var ultima = (from ant in listafactura 
                         select ant.Fecha).Max();

            var asdu = from w in listfactura
                       where ultima == w.Fecha
                       select new
                                {
                                    observacion = w.Observacion,
                                    fechav= w.Fecha,
                                    totalv= w.Total
                                };
            foreach (var item in asdu)
            {
                Console.WriteLine();
                Console.WriteLine("*****La última venta realizada:***** ");
                Console.WriteLine("Observación: "+item.observacion + "  Fecha: " + item.fechav + "  Total: " + item.totalv);
            }


            ///////////////////////////////////////////////Filtro por observción///////////////////////////////////////
            Console.WriteLine();
            Console.WriteLine("****filtro por Observación:****");

            var x = from i in listafactura
                    join g in listacliente on i.Idcliente equals g.Id
                    where i.Observacion.StartsWith("prob")
                    orderby i.Idcliente
                    select new
                    {
                        nombreCliente = g.Nombre,
                        fechaventa= i.Fecha,
                        obserVenta= i.Observacion,
                        totalVenta= i.Total
                    };

            foreach (var item in x)
            {

                Console.WriteLine("{0} {1} {2} {3}", item.nombreCliente, item.fechaventa, item.obserVenta, item.totalVenta);

            }
            //////////////////////////////////////////////////////////////////////////////////////////
            var vmayores =
                        from f in listafactura
                        orderby f.Total ascending
                        select f;

            
            Console.ReadKey();

            

        }
        class Cliente
        {
            public int Id { get; set; }
            public string Nombre { get; set; }
        }
        class Facturaa
        {
            public string Observacion { get; set; }
            public int Idcliente { get; set; }
            public DateTime Fecha { get; set; }
            public int Total { get; set; }
        }
    }
}
