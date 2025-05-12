using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class clCliente
    {
        [DisplayName("DNI")] public int G16_DNI { get; set; }
        [DisplayName("Nombres")] public string G16_Nombres { get; set; }
        [DisplayName("Apellidos")] public string G16_Apellidos { get; set; }
        [DisplayName("Celular")] public int G16_Celular { get; set; }



        public static List<clCliente> G16_Cli = new List<clCliente>();
        public static void agregarCliente(int G16_DN,string G16_No, string G16_Ap, int G16_Cel)
        {
            G16_Cli.Add(new clCliente{
                G16_DNI = G16_DN,
                G16_Nombres = G16_No,
                G16_Apellidos = G16_Ap,
                G16_Celular = G16_Cel             
            });
        }

        public string NombreCompleto
        {
            get { return G16_Nombres + " " + G16_Apellidos; }
        }//obtener el nombre completo en las listas
    }
}
