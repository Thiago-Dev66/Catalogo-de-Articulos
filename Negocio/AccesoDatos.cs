using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return  reader; }
        } 
        private readonly string connectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";

        public AccesoDatos()
        {
            conn = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }
        
        public void SetearConsulta(string consulta)
        {
            cmd.Connection = conn;

            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = consulta;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public void EjecutarReader()
        {
            cmd.Connection = conn;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public void CerrarConexion()
        {
            if (reader != null)
            {
                reader.Close();
            }
            conn.Close();
        }
    }
}
