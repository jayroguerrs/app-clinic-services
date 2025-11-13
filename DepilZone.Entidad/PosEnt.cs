using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Entidad
{
    public class PosSale
    {
        public String Tipo_Operacion { get; set; }
        public String Tipo_Comprobante { get; set; }
        public String Comprobante { get; set; }
        public String Fecha_Emision { get; set; }
        public String Documento { get; set; }
        public String Estado { get; set; }
        public String Razon_Social { get; set; }
        public String Cod_Afectación { get; set; }
        public String Codigo { get; set; }
        public String Descripción { get; set; }
        public decimal Cantidad { get; set; }
        public String U_M { get; set; }
        public decimal Precio_Unitario { get; set; }
        public decimal Valor_Unitario { get; set; }
        public decimal Valor_Venta { get; set; }
        public decimal Descuento_Venta { get; set; }
        public decimal Igv { get; set; }
        public decimal Importe { get; set; }
        public decimal Adicional { get; set; }
        public String Moneda { get; set; }
        public String Cond_Pago { get; set; }
        public String Forma_Pago { get; set; }
        public String Orden_Compra { get; set; }
        public decimal Op_Gravadas { get; set; }
        public decimal Op_Exoneradas { get; set; }
        public decimal Op_Inafectas { get; set; }
        public decimal Op_Gratuitas { get; set; }
        public decimal Descuento_Op { get; set; }
        public decimal Igv_Op { get; set; }
        public decimal Total { get; set; }
        public decimal Peso_Bruto { get; set; }
        public String Um_Pesobruto { get; set; }
        public decimal Importe_Baja { get; set; }
        public String Punto_Venta { get; set; }
        public String Numero_Documento { get; set; }
        public String Razon_Social_Cl { get; set; }
        public String Direccion_Cliente { get; set; }
        public String Adicionales { get; set; }        
        public int IdSede { get; set; }
        public int IdUser { get; set; }
    }
    public class PosIzip
    {
        public String CODIGO { get; set; }
        public String TIPO_MOVIMIENTO { get; set; }
        public String TIPO_CAPTURA { get; set; }
        public String TRANSACCION { get; set; }
        public String FECHA_TRANSACCION { get; set; }
        public String HORA_TRANSACCION { get; set; }
        public String FECHA_CIERRE_LOTE { get; set; }
        public String FECHA_PROCESO { get; set; }
        public String FECHA_ABONO { get; set; }
        public String ESTADO { get; set; }
        public Decimal IMPORTE { get; set; }
        public Decimal COMISION { get; set; }
        public Decimal IGV { get; set; }
        public Decimal IMPORTE_NETO { get; set; }
        public Decimal ABONO_LOTE { get; set; }
        public String NUM_LOTE { get; set; }
        public String TERMINAL { get; set; }
        public String NUM_REF { get; set; }
        public String MARCA_TARJETA { get; set; }
        public String NUM_TARJETA { get; set; }
        public String CODIGO_AUTORIZACION { get; set; }
        public String CUOTAS { get; set; }
        public String OBSERVACIONES { get; set; }
        public String MONEDA { get; set; }
        public String SERIE_TERMINAL { get; set; }
        public Int32 IdSede { get; set; }                
        public Int32 IdUser { get; set; }
    }
}
