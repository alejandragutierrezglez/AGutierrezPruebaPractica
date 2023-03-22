using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Banco
    {
        public static void Add()
        {
            ML.Banco banco = new ML.Banco();
            Console.WriteLine("Escribe el nombre del banco: ");
            banco.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el numero de empleados");
            banco.NoEmpleados = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el numero de sucursales");
            banco.NoSucursales = int.Parse(Console.ReadLine());

            banco.Pais = new ML.Pais();
            Console.WriteLine("Escribe el Id de Pais");
            banco.Pais.IdPais = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el capital del banco");
            banco.Capital = decimal.Parse(Console.ReadLine());

            banco.RazonSocial = new ML.RazonSocial();
            Console.WriteLine("Escribe el Id de Razon Social");
            banco.RazonSocial.IdRazonSocial = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el numero de clientes");
            banco.NoClientes = int.Parse(Console.ReadLine());

            ML.Result result = BL.Banco.Add(banco);

            if (result.Correct == true)
            {
                Console.WriteLine("Se ha agregado el registro");
            }
            else
            {
                Console.WriteLine("No se ha podido agregar por: " + result.ErrorMessage);
            }

            Console.ReadKey();
        }
        public static void Update()
        {
            ML.Banco banco = new ML.Banco();

            Console.WriteLine("Escribe el Id de Banco a modificar");
            banco.IdBanco = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del banco: ");
            banco.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el numero de empleados");
            banco.NoEmpleados = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el numero de sucursales");
            banco.NoSucursales = int.Parse(Console.ReadLine());

            banco.Pais = new ML.Pais();
            Console.WriteLine("Escribe el Id de Pais");
            banco.Pais.IdPais = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el capital del banco");
            banco.Capital = decimal.Parse(Console.ReadLine());

            banco.RazonSocial = new ML.RazonSocial();
            Console.WriteLine("Escribe el Id de Razon Social");
            banco.RazonSocial.IdRazonSocial = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el numero de clientes");
            banco.NoClientes = int.Parse(Console.ReadLine());

            ML.Result result = BL.Banco.Update(banco);

            if (result.Correct == true)
            {
                Console.WriteLine("Se ha modificado el registro");
            }
            else
            {
                Console.WriteLine("No se ha podido modificar el registro por: " + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Banco banco = new ML.Banco();
            Console.WriteLine("Escribe el Id a eliminar");
            banco.IdBanco = int.Parse(Console.ReadLine());


            ML.Result result = BL.Banco.Delete(banco);

            if (result.Correct == true)
            {
                Console.WriteLine("Se ha eliminado el registro");
            }
            else
            {
                Console.WriteLine("No se ha eliminado el registro debido a: " + result.ErrorMessage);
            }
        }

        public static void GetAll()
        {
            ML.Banco banco = new ML.Banco();
            ML.Result result = BL.Banco.GetAll();

            foreach (ML.Banco banc in result.Objects)
            {
                Console.WriteLine("IdBanco: " + banc.IdBanco);
                Console.WriteLine("Nombre de Banco: " + banc.Nombre);
                Console.WriteLine("Numero de empleados: " + banc.NoEmpleados);
                Console.WriteLine("Numero de sucursales:" + banc.NoSucursales);
                banco.Pais = new ML.Pais();
                Console.WriteLine("IdPais: " + banc.Pais.IdPais);
                Console.WriteLine("Capital: " + banc.Capital);
                banco.RazonSocial = new ML.RazonSocial();
                Console.WriteLine("IdRazonSocial: " + banc.RazonSocial.IdRazonSocial);
                Console.WriteLine("Numero de clientes: " + banc.NoClientes);
                Console.WriteLine("---------------------------------------------------");
            }
            if (result.Correct == true)
            {
                Console.WriteLine("Se ha mostrado la lista de bancos");
            }
            else
            {
                Console.WriteLine("No se ha podido mostrar la lista debido a: "+result.ErrorMessage);
            }
            Console.ReadKey();

        }

    }
}
