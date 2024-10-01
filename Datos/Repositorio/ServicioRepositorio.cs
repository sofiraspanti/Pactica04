using Microsoft.Data.SqlClient;
using Practica04.Dominio;
using Practica04.Repositorio.Interfaz;
using Practica04.Utils;
using System.Data;
using Practica04.Dominio;

namespace Practica04.Datos.Repositorio
{
    public class ServicioRepositorio : IServicio
    {
        
        public List<Servicio> GetAll()
        {
            DataTable dt = DataHelper.GetInstance().ExecuteSPQuery("SP_CONSULTAR_SERVICIOS", null);

            var servicios = new List<Servicio>();

            if (dt != null && dt.Rows.Count > 0)
            {

                foreach (DataRow row in dt.Rows)
                {

                    var servicio = new Servicio()
                    {
                        Nombre = row["nombre"].ToString(),
                        Costo = (int)row["costo"],
                        EnPromocion = row["enPromocion"].ToString(),
                    };
                    servicios.Add(servicio);
                }
            }
            return servicios;
        }

        
    }
}
