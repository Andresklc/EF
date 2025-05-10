using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void productosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProductos G16_FormProduc = new frmProductos();
            G16_FormProduc.Show();
        }

    }
}
