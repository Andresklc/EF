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
        [DisplayName("ID")] public int G16_Id { get; set; }
        [DisplayName("Nombre")] public int G16_Nombre { get; set; }
        [DisplayName("Descripcion")] public int G16_Descripcion { get; set; }

        List<clCategoria> G16_cat =new List<clCategoria>();

    }
}
