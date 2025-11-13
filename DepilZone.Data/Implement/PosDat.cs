using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Implement
{
    public class PosDat : IPosDat
    {
        private readonly string _connectionString;
        public PosDat(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        public async Task<bool> insSale(PosSale model)
        {
            Boolean flag = false;

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_importar_dataCounter", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("vv_Tipo_Operacion", model.Tipo_Operacion);
                cmd.Parameters.AddWithValue("vv_Tipo_Comprobante", model.Tipo_Comprobante);
                cmd.Parameters.AddWithValue("vv_Comprobante", model.Comprobante);
                cmd.Parameters.AddWithValue("dt_Fecha_Emision", Convert.ToDateTime(model.Fecha_Emision).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("vv_Documento", model.Documento);
                cmd.Parameters.AddWithValue("vv_Estado", model.Estado);
                cmd.Parameters.AddWithValue("vv_Razon_Social", model.Razon_Social);
                cmd.Parameters.AddWithValue("vv_Cod_Afectacion", model.Cod_Afectación);
                cmd.Parameters.AddWithValue("vv_Codigo", model.Codigo);
                cmd.Parameters.AddWithValue("vv_Descripcion", model.Descripción);
                cmd.Parameters.AddWithValue("vn_Cantidad", model.Cantidad);
                cmd.Parameters.AddWithValue("vv_U_M", model.U_M);
                cmd.Parameters.AddWithValue("vn_Precio_Unitario", model.Precio_Unitario);
                cmd.Parameters.AddWithValue("vn_Valor_Unitario", model.Valor_Unitario);
                cmd.Parameters.AddWithValue("vn_Valor_Venta", model.Valor_Venta);
                cmd.Parameters.AddWithValue("vn_Descuento_Venta", model.Descuento_Venta);
                cmd.Parameters.AddWithValue("vn_Igv", model.Igv);
                cmd.Parameters.AddWithValue("vn_Importe", model.Importe);
                cmd.Parameters.AddWithValue("vn_Adicional", model.Adicional);
                cmd.Parameters.AddWithValue("vv_Moneda", model.Moneda);
                cmd.Parameters.AddWithValue("vv_Cond_Pago", model.Cond_Pago);
                cmd.Parameters.AddWithValue("vv_Forma_Pago", model.Forma_Pago);
                cmd.Parameters.AddWithValue("vv_Orden_Compra", model.Orden_Compra);
                cmd.Parameters.AddWithValue("vn_Op_Gravadas", model.Op_Gravadas);
                cmd.Parameters.AddWithValue("vn_Op_Exoneradas", model.Op_Exoneradas);
                cmd.Parameters.AddWithValue("vn_Op_Inafectas", model.Op_Inafectas);
                cmd.Parameters.AddWithValue("vn_Op_Gratuitas", model.Op_Gratuitas);
                cmd.Parameters.AddWithValue("vn_Descuento_Op", model.Descuento_Op);
                cmd.Parameters.AddWithValue("vn_Igv_Op", model.Igv_Op);
                cmd.Parameters.AddWithValue("vn_Total", model.Total);
                cmd.Parameters.AddWithValue("vn_Peso_Bruto", model.Peso_Bruto);
                cmd.Parameters.AddWithValue("vv_Um_Pesobruto", model.Um_Pesobruto);
                cmd.Parameters.AddWithValue("vn_Importe_Baja", model.Importe_Baja);
                cmd.Parameters.AddWithValue("vv_Punto_Venta", model.Punto_Venta);
                cmd.Parameters.AddWithValue("vv_Numero_Documento", model.Numero_Documento);
                cmd.Parameters.AddWithValue("vv_Razon_Social_cl", model.Razon_Social_Cl);
                cmd.Parameters.AddWithValue("vv_Direccion_Cliente", model.Direccion_Cliente);
                cmd.Parameters.AddWithValue("vv_Adicionales", model.Adicionales);
                cmd.Parameters.AddWithValue("vi_idsede", model.IdSede);
                cmd.Parameters.AddWithValue("vi_usuarioimporta", model.IdUser);                

                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }

                conn.Close();

                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> insIzip(PosIzip model)
        {
            Boolean flag = false;

            try
            {
                using SqlConnection conn = GetConnection();
                await conn.OpenAsync();

                using SqlCommand cmd = new SqlCommand("sp_importar_dataEasyFact", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("vv_codigo", model.CODIGO);
                cmd.Parameters.AddWithValue("vv_tipo_movimiento", model.TIPO_MOVIMIENTO);
                cmd.Parameters.AddWithValue("vv_tipo_captura", model.TIPO_CAPTURA);
                cmd.Parameters.AddWithValue("vv_transaccion", model.TRANSACCION);
                cmd.Parameters.AddWithValue("dt_fecha_transaccion", Convert.ToDateTime(model.FECHA_TRANSACCION).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("vt_hora_transaccion", model.HORA_TRANSACCION);
                cmd.Parameters.AddWithValue("dt_fecha_cierre_lote", Convert.ToDateTime(model.FECHA_CIERRE_LOTE).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("dt_fecha_proceso", Convert.ToDateTime(model.FECHA_PROCESO).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("dt_fecha_abono", Convert.ToDateTime(model.FECHA_ABONO).ToString("yyyy-MM-dd"));
                cmd.Parameters.AddWithValue("vv_estado", model.ESTADO);
                cmd.Parameters.AddWithValue("vn_importe", model.IMPORTE);
                cmd.Parameters.AddWithValue("vn_comision", model.COMISION);
                cmd.Parameters.AddWithValue("vn_igv", model.IGV);
                cmd.Parameters.AddWithValue("vn_importe_neto", model.IMPORTE_NETO);
                cmd.Parameters.AddWithValue("vn_abono_lote", model.ABONO_LOTE);
                cmd.Parameters.AddWithValue("vv_num_lote", model.NUM_LOTE);
                cmd.Parameters.AddWithValue("vv_terminal", model.TERMINAL);
                cmd.Parameters.AddWithValue("vv_num_ref", model.NUM_REF);
                cmd.Parameters.AddWithValue("vv_marca_tarjeta", model.MARCA_TARJETA);
                cmd.Parameters.AddWithValue("vv_num_tarjeta", model.NUM_TARJETA);
                cmd.Parameters.AddWithValue("vv_codigo_autorizacion", model.CODIGO_AUTORIZACION);
                cmd.Parameters.AddWithValue("vv_cuotas", model.CUOTAS);
                cmd.Parameters.AddWithValue("vv_observaciones", model.OBSERVACIONES);
                cmd.Parameters.AddWithValue("vv_moneda", model.MONEDA);
                cmd.Parameters.AddWithValue("vv_serie_terminal", model.SERIE_TERMINAL);
                cmd.Parameters.AddWithValue("vi_idsede", model.IdSede);
                cmd.Parameters.AddWithValue("vi_usuarioimporta", model.IdUser);
                cmd.Parameters.AddWithValue("dt_fechaimporta", DateTime.Now);

                if (cmd.ExecuteNonQuery() > 0)
                {
                    flag = true;
                }

                conn.Close();

                return flag;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
