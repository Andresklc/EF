using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class clProductoVendido
    {
        [DisplayName("ID")] public int G16_IdPro { get; set; } // ID del producto
        [DisplayName("Nombre")] public string G16_Nombre{ get; set; } //Nombre delproducto
        [DisplayName("Cantidad")] public int G16_Cantidad { get; set; }
        [DisplayName("Precio Unitario")] public double G16_Precio { get; set; } // Precio del producto

        public clProductoVendido(int G16_idPro, string G16_nombre, int G16_Can, double G16_prec)
        {
            G16_IdPro = G16_idPro;
            G16_Nombre = G16_nombre; 
            G16_Cantidad=G16_Can;
            G16_Precio = G16_prec;
        }
    }
}
