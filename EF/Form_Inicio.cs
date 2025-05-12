using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EF
{
    public partial class Form_Inicio : Form
    {

        public Form_Inicio()
        {
            InitializeComponent();
            clProductos.agregarProducto("Jugo de naranja", "Bebida", 2.8);
            clProductos.agregarProducto("Tomate", "Verdura", 3);
            clProductos.agregarProducto("Fresa", "Fruta", 4);
            clProductos.agregarProducto("Agua mineral", "Bebida", 1.5);
            clProductos.agregarProducto("Papa", "Verdura", 2.2);
            clProductos.agregarProducto("Gaseosa cola", "Bebida", 3.5);
            clProductos.agregarProducto("Naranja", "Fruta", 3.2);
            clProductos.agregarProducto("Lechuga", "Verdura", 2.4);
            clProductos.agregarProducto("Té helado", "Bebida", 3.2);
            clProductos.agregarProducto("Manzana", "Fruta", 3);
            clProductos.agregarProducto("Cebolla", "Verdura", 2.7);
            clProductos.agregarProducto("Plátano", "Fruta", 2.5);
            clProductos.agregarProducto("Café en lata", "Bebida", 4);
            clProductos.agregarProducto("Zanahoria", "Verdura", 1.8);
            clProductos.agregarProducto("Uva", "Fruta", 5.5);
            clCategoria.agregarCategoria("Fruta");
            clCategoria.agregarCategoria("Bebida");
            clCategoria.agregarCategoria("Verdura");
            clCliente.agregarCliente(78456833, "Mario", "Cortez", 965423679);
            clCliente.agregarCliente(74581236, "Lucía", "Ramírez", 912345678);
            clCliente.agregarCliente(73849561, "Carlos", "Quispe", 987654321);
            clCliente.agregarCliente(76382945, "Andrea", "Flores", 923456789);
            clCliente.agregarCliente(72836459, "Jorge", "Gómez", 934567891);
            clCliente.agregarCliente(75681234, "Valeria", "Rojas", 945678123);
            clCliente.agregarCliente(76983456, "Luis", "Fernández", 956789234);
            clCliente.agregarCliente(71234567, "Camila", "Mendoza", 967891345);
            clCliente.agregarCliente(70123456, "Pedro", "Sánchez", 978912456);
            clCliente.agregarCliente(72345678, "Ana", "Delgado", 989123567);
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos G16_FormProduc = new frmProductos();
            G16_FormProduc.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCLientes G16_FormCLien = new frmCLientes();
            G16_FormCLien.Show();
        }



        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmRVentas G16_FormVen = new frmRVentas();
            G16_FormVen.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExportarClientes G16_ForExCli = new FrmExportarClientes();
            G16_ForExCli.Show();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmExportarProductos G16_ForExPro = new FrmExportarProductos();
            G16_ForExPro.Show();
        }

        private void soporteTecnicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string G16_mensaje ="Contactar a:\n"+
             "Larrea Cortez, Luis Andres - N00446667@upn.pe (Lider)\n" +
             "Ortega Valverde, Yulissa Stephany - N00366132@upn.pe\n" +
             "Leon Ccahuana, Jeffrey Carlos - N00423806@upn.pe\n" +
             "Huancollo Fuentes, Luis Angelo - N00480703@upn.pe";

            MessageBox.Show(G16_mensaje, "Grupo 16_Lista de Alumnos", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void vercionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("VERSION G16 0.1 \nSi ve esto profe un saludo no eh dormido en 2 dias by Andres", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
