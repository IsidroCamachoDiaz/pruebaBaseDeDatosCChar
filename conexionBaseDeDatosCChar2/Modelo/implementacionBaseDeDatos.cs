using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
                //Uso el metodo pàsaParametros que recibe la ruta del archivo
                //y devuelve un array con los datos de acceso
                string[] parametros = pasaParametros("C:\\Users\\Puesto3\\Desktop\\Ficheros\\claves.txt");

                string datos = String.Format("Server={0};User Id={1}; Password={2};Database={3};", parametros[0], parametros[1], parametros[2], parametros[3]);
                NpgsqlConnection conn = new NpgsqlConnection(datos);

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

        private string[] pasaParametros(string ruta)
        {
            //en vez de hacerlo con el objeto properties he usado un archivo de texto 
            string[] parametros=new string[4];
            string[] vector2;
            int i = 0;
            try
            {
                StreamReader sr = new StreamReader(ruta);

                while (!sr.EndOfStream)
                {
                    vector2 = sr.ReadLine().Split('=');
                    parametros[i] = vector2[1];
                    i++;
                }
                sr.Close();
                //Excepciones
            }catch(ArgumentException au)
            {
                Console.WriteLine("No es valido los argumentos que ofrece Error: "+au.Message);
            }catch(FileNotFoundException fn)
            {
                Console.WriteLine("El archivo que intenta leer no existe Error: " + fn.Message);
            }
            catch (DirectoryNotFoundException dn)
            {
                Console.WriteLine("No encuentra el directorio Error: " + dn.Message);
            }catch(Exception ex) 
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            return parametros;
        }
    }
}
