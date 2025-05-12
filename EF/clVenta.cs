using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class clVenta
    {
        public int G16_IdVenta { get; set; }// ID de la venta
        public int G16_DNI { get; set; }// DNI del cliente
        public List<clProductoVendido> G16_Prod { get; set; }// Lista de productos vendidos

        public double G16_PrecioTotal { get; set; }// Precio total de la venta

        public static List<clVenta> G16_Ventas = new List<clVenta>();
        public clVenta(int G16_idVen, int G16_dni, List<clProductoVendido> G16_prod)
        {
            G16_IdVenta = G16_idVen;
            G16_DNI = G16_dni;
            G16_Prod = G16_prod;
            G16_PrecioTotal = CalcularTotal();
        }

        // Método para calcular el total
        private double CalcularTotal()
        {
            double G16_total = 0;
            foreach (var G16_p in G16_Prod)
            {
                G16_total += G16_p.G16_Cantidad * G16_p.G16_Precio;
            }
            return G16_total;
        }
    }
}
