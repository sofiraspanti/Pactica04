using Microsoft.Data.SqlClient;
using Practica04.Dominio;
using Practica04.Repositorio.Interfaz;
using Practica04.Utils;
using System.Data;

namespace Practica04.Datos.Repositorio
{
    public class DetalleRepositorio : IDetalleTurno
    {
        //public bool Add(Detalle_turno detalle_Turno)
        //{
        //    if (detalle_Turno == null)
        //    {
        //        throw new ArgumentNullException(nameof(detalle_Turno), "Turno no puede ser nulo");
        //    }

        //    bool result = true;
        //    SqlTransaction? t = null;
        //    SqlConnection? cnn = null;

        //    try
        //    {
        //        // Obtengo la conexion y la abro 
        //        cnn = DataHelper.GetInstance().GetConnection();
        //        cnn.Open();

        //        // Inicio una nueva transacción
        //        t = cnn.BeginTransaction();

        //        // Configuro el comando para ejecutar el procedimiento almacenado
        //        var cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
        //        cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;

        //        // Agrego los parametros al comando
        //        cmdDetalle.Parameters.AddWithValue("id_turno", detalle_Turno.Id_turno);
        //        cmdDetalle.Parameters.AddWithValue("id_servicio", detalle_Turno.Servicio);
        //        cmdDetalle.Parameters.AddWithValue("observaciones", detalle_Turno.Observacion);

        //        // Ejecuto el comando
        //        cmdDetalle.ExecuteNonQuery();

        //        // Confirmo la transacción
        //        t.Commit();

        //    } catch (SqlException)
        //    {
        //        if (t != null)
        //        {
        //            t.Rollback();
        //        }
        //        result = false;
        //    }
        //    finally
        //    {
        //        // Me aseguro de cerrar la conexión
        //        if (cnn != null && cnn.State == ConnectionState.Closed)
        //        {
        //            cnn.Close();                    
        //        }
        //    }
        //    return result;
        //}
    }
}
