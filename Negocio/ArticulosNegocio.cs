using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Dominio;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> Listar()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> listaArt = new List<Articulo>();

            try
            {
                datos.SetearConsulta("select Codigo from ARTICULOS");
                datos.EjecutarReader();

                while (datos.Reader.Read()) 
                { 
                  Articulo aux = new Articulo();

                  aux.Codigo = (string)datos.Reader["Codigo"];

                  listaArt.Add(aux);
                }

                return listaArt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
