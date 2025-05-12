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
    public partial class frmRVentas : Form
    {
        List<clProductoVendido> productosVendidos = new List<clProductoVendido>();
        public frmRVentas()
        {
            InitializeComponent();
            listaCli();
            listaPro();
        }

        public void listaCli()
        {
            cbxCliente.DataSource = null;
            cbxCliente.DataSource = clCliente.G16_Cli;
            cbxCliente.DisplayMember = "NombreCompleto";  // Lo que se muestra
            cbxCliente.SelectedIndex = -1;
        }
        public void listaPro()
        {
            cbxProducto.DataSource = null;
            cbxProducto.DataSource = clProductos.G16_Pro;
            cbxProducto.DisplayMember = "G16_Nombre";  // Lo que se muestra
            cbxProducto.SelectedIndex = -1;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int G16_id = productosVendidos.Count + 1; // autogenera el ID
            string G16_nombre = cbxProducto.Text;
            int G16_cantidad = int.Parse(txtCantidad.Text);

            // Buscar el producto en la lista estática
            var G16_productoBase = clProductos.G16_Pro.FirstOrDefault(G16_p => G16_p.G16_Nombre == G16_nombre);
            if (G16_productoBase == null)
            {
                MessageBox.Show("Producto no encontrado en la lista base.");
                return;
            }

            double G16_precio = G16_productoBase.G16_Precio;

            // Crear y agregar producto vendido
            var G16_productoVendido = new clProductoVendido(G16_id, G16_nombre, G16_cantidad, G16_precio);
            productosVendidos.Add(G16_productoVendido);

            // Actualizar el DataGridView
            dgvRVentas.DataSource = null;
            dgvRVentas.DataSource = productosVendidos;
            dgvRVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Actualizar total
            double total = productosVendidos.Sum(G16_p => G16_p.G16_Cantidad * G16_p.G16_Precio);
            txtTotal.Text = "S/ " + total.ToString("0.00");

            // Limpiar campos
            cbxProducto.SelectedIndex = -1;
            txtCantidad.Clear();
 
        }
    }
}
