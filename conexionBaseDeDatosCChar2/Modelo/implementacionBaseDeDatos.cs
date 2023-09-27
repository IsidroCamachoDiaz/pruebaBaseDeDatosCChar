using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBaseDeDatosCChar2.Modelo
{
    internal class implementacionBaseDeDatos : interfazConexionBaseDeDatos
    {
        void interfazConexionBaseDeDatos.ConexionBaseDatos()
        {
            //Conectar a postgresql
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection("Server=localhost:5432;User Id=postgres; " +
                    "Password=Flash12311;Database=gestorBibliotecaPersonal;");

                conn.Open(); // apertura de conección

                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand command = new NpgsqlCommand("SELECT *  FROM gbp_almacen.gbp_alm_cat_libros", conn);


                NpgsqlDataReader dr = command.ExecuteReader();

                // Si devulve datos los recorre y te los muestra por la consola)

                while (dr.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\n", dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString());

                conn.Close(); // cierre de conexion a BD. 
            }catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
        }
    }
}
