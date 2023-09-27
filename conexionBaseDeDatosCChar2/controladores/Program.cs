using conexionBaseDeDatosCChar2.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBaseDeDatosCChar2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            interfazConexionBaseDeDatos inter = new implementacionBaseDeDatos();
            NpgsqlConnection conn=inter.AbrirConexionBaseDatos();
            inter.ConsultaDatos("SELECT *  FROM gbp_almacen.gbp_alm_cat_libros", conn);
            inter.CerrarBaseDeDatos(conn);
            Console.ReadLine();
        }
    }
}
