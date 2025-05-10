using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class clProductos
    {
        [DisplayName("Código")] public string G16_Codigo { get; set; }
        [DisplayName("Nombre")] public string G16_Nombre { get; set; }
        [DisplayName("Categoria")] public string G16_Categoria { get; set; }
        [DisplayName("Precio")] public double G16_Precio { get; set; }

        public static List<clProductos> Pro = new List<clProductos>();
        private static int contador = 1;
        public static void agregarProducto(string G16_No, string G16_Ca, double G16_Pr)
        {
            //Genera mi codigo Prunera letra de mi categoria + Numero de orden
            string G_16Co = G16_Ca.Substring(0, 1).ToUpper() + contador.ToString();
            Pro.Add(new clProductos { 
            G16_Codigo = G_16Co,
            G16_Nombre = G16_No,
            G16_Categoria = G16_Ca,
            G16_Precio= G16_Pr,
            });
            contador++;
        }
    }
}
    