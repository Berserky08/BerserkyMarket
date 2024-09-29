using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Runtime.InteropServices;
using System.Globalization;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public Dashboard VerDashboard()
        {
            Dashboard objeto = new Dashboard();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteDashboard", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            objeto = new Dashboard()
                            {
                                TotalCliente = Convert.ToInt32(dr["TotalCliente"]),
                                TotalVenta = Convert.ToInt32(dr["TotalVenta"]),
                                TotalProducto = Convert.ToInt32(dr["TotalProducto"]),
                            };
                        }
                    }
                }
            }
            catch
            {
                objeto = new Dashboard();
            }
            return objeto;
        }

        public List<Reporte> Ventas(string fechainicio, string fechafin, string idtransaccion)
        {
            List<Reporte> lista = new List<Reporte>();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_ReporteVentas", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("FechaInicio", fechainicio);
                    cmd.Parameters.AddWithValue("FechaFin", fechafin);
                    cmd.Parameters.AddWithValue("IdTransaccion", idtransaccion);
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add
                                (
                                    new Reporte()
                                    {
                                        FechaVenta = dr["FechaVenta"].ToString(),
                                        Cliente = dr["Cliente"].ToString(),
                                        Producto = dr["Producto"].ToString(),
                                        Precio = Convert.ToDecimal(dr["Precio"], new CultureInfo("es-ES")),
                                        Cantidad =Convert.ToInt32(dr["Clave"].ToString()),
                                        Total = Convert.ToDecimal(dr["Total"], new CultureInfo("es-ES")),
                                        IdTransaccion = dr["Activo"].ToString()
                                    }
                                );
                        }
                    }
                }
            }
            catch
            {
                lista = new List<Reporte>();
            }
            return lista;
        }
    }
}
