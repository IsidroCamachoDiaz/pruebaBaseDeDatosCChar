using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conexionBaseDeDatosCChar2.Modelo
{
    public interface interfazConexionBaseDeDatos
    {
        NpgsqlConnection AbrirConexionBaseDatos();
        void ConsultaDatos(string query, NpgsqlConnection conn);
        void CerrarBaseDeDatos(NpgsqlConnection conn);

    }
}
