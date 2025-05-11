using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class clCategoria
    {
     public int G16_Id { get; set; }
     public string G16_Nombre { get; set; }

       public static List<clCategoria> G16_cat =new List<clCategoria>();
        private static int G16_contador = 1;
        public static void agregarCategoria(string G16_N){
            G16_cat.Add(new clCategoria {
                G16_Id= G16_contador,
                G16_Nombre = G16_N,
            });
            G16_contador++;
        }
    }
}
