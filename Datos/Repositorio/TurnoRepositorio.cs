using Microsoft.Data.SqlClient;
using Practica04.Dominio;
using Practica04.Repositorio.Interfaz;
using Practica04.Utils;
using System.Data;
using System.Linq.Expressions;

namespace Practica04.Datos.Repositorio
{
    public class TurnoRepositorio : ITurno
    {
        public bool Add(Turno turno)
        {
            if (turno == null)
            {
                throw new ArgumentNullException("Turno no puede ser nulo");
            }

            bool result = true;
            SqlTransaction? t = null;
            SqlConnection? cnn = null;
            try
            {
                // Obtengo la conexión y la abro
                cnn = DataHelper.GetInstance().GetConnection();
                cnn.Open();

                // Inicio una nueva transaccion
                t = cnn.BeginTransaction();

                // Configuro el comando para ejecutar el procedimiento almacenado
                var cmd = new SqlCommand("SP_CREAR_TURNO", cnn, t);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Agrego los parametros al comando
                cmd.Parameters.AddWithValue("fecha", turno.Fecha);
                cmd.Parameters.AddWithValue("hora", turno.Hora);
                cmd.Parameters.AddWithValue("cliente", turno.Cliente);

                // Ejecuto el comando
                cmd.ExecuteNonQuery();

                // Obtengo el id del turno para agregar los detalles - Con esta parte, no hace falta el metodo Add en el repositorio de detalle
                int idTurno = (int)cmd.Parameters["@id"].Value;

                foreach(var detalle in turno.Detalle)
                {
                    // Configuro el comando para ejecutar el procedimiento almacenado
                    var cmdDetalle = new SqlCommand("SP_INSERTAR_DETALLES", cnn, t);
                    cmdDetalle.CommandType = System.Data.CommandType.StoredProcedure;

                    // Agrego los parametros al comando
                    cmdDetalle.Parameters.AddWithValue("id_turno", idTurno);
                    cmdDetalle.Parameters.AddWithValue("id_servicio", detalle.Servicio);
                    cmdDetalle.Parameters.AddWithValue("observaciones", detalle.Observacion);

                    // Ejecuto el comando
                    cmdDetalle.ExecuteNonQuery();
                    
                }

                // Confirmo la transacción
                t.Commit();
            }
            catch (Exception ex)
            {
                if (t != null) { t.Rollback(); }
                result = false;
            }
            finally
            {
                // Me aseguro de cerrar la conexion si está abierta
                if (cnn != null && cnn.State == ConnectionState.Closed) { cnn.Close(); }
            }
            return result;


        } 
    }
}
