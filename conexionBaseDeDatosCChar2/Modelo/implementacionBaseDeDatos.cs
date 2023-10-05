using Microsoft.Win32.SafeHandles;
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
        NpgsqlConnection interfazConexionBaseDeDatos.AbrirConexionBaseDatos()
        {
            //Conectar a postgresql
            NpgsqlConnection conn=null;
            try
            {
                //Uso el metodo pàsaParametros que recibe la ruta del archivo
                //y devuelve un array con los datos de acceso
                string[] parametros = pasaParametros("C:\\Users\\Puesto3\\Desktop\\Ficheros\\claves.txt");

                string datos = String.Format("Server={0};User Id={1}; Password={2};Database={3};", parametros[0], parametros[1], parametros[2], parametros[3]);
                 conn = new NpgsqlConnection(datos);

                conn.Open(); // apertura de conección
                
   
            }catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
                conn=null;
            }
            return conn;
        }


        void interfazConexionBaseDeDatos.ConsultaDatos(string query, NpgsqlConnection conn)
        {
            try
            {
                // creas tu query y le envías la conexión con la que va a trabajar y filtras la condición que necesitas 
                NpgsqlCommand command = new NpgsqlCommand(query, conn);
                NpgsqlDataReader dr = command.ExecuteReader();
            
                // Si devulve datos los recorre y te los muestra por la consola)
                while (dr.Read())
                    Console.Write("{0}\t{1}\t{2}\t{3}\t{4}\n", dr[0], dr[1], dr[2], dr[3], dr[4]);
            }catch(Exception ex) 
            {
                Console.WriteLine("Error: "+ex.Message);
            }
         }

        void interfazConexionBaseDeDatos.CerrarBaseDeDatos(NpgsqlConnection conn)
        {
            // Cierra la conexion
            try
            {
                conn.Close();
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
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
