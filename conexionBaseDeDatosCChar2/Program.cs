using conexionBaseDeDatosCChar2.Modelo;
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
            inter.ConexionBaseDatos();
            Console.ReadLine();
        }
    }
}
