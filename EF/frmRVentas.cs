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
        List<clProductoVendido> G16_ProVen = new List<clProductoVendido>();
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
        public void limpiar()
        {
            cbxProducto.SelectedIndex = -1;
            txtCantidad.Clear();
            btnAgregar.Enabled = false;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxCliente.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Cliente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbxProducto.SelectedIndex == -1)
                {
                    MessageBox.Show("Seleccione un Producto y agreguelo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                btnAgregar.Enabled = true;
                int G16_id = G16_ProVen.Count + 1; // autogenera el ID
                string G16_nombre = cbxProducto.Text;
                int G16_cantidad = int.Parse(txtCantidad.Text);

                // Buscar el producto en la lista estática
                var G16_productoBase = clProductos.G16_Pro.FirstOrDefault(G16_p => G16_p.G16_Nombre == G16_nombre);
                if (G16_productoBase == null)
                {
                    MessageBox.Show("Producto no encontrado en la lista base.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                return;
                }

                double G16_precio = G16_productoBase.G16_Precio;

                // Crear y agregar producto vendido
                var G16_productoVendido = new clProductoVendido(G16_id, G16_nombre, G16_cantidad, G16_precio);
                G16_ProVen.Add(G16_productoVendido);

                // Actualizar el DataGridView
                dgvRVentas.DataSource = null;
                dgvRVentas.DataSource = G16_ProVen;
                dgvRVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Actualizar total
                double total = G16_ProVen.Sum(G16_p => G16_p.G16_Cantidad * G16_p.G16_Precio);
                txtTotal.Text = "S/ " + total.ToString("0.00");

                // Limpiar campos
                limpiar();
            }
            catch (Exception G16_ex) { MessageBox.Show("Error:"+G16_ex, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop); }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRVentas.CurrentRow != null)
            {
                // Obtener el ID del producto seleccionado (columna G16_IdPro)
                int G16_IDselec = (int)dgvRVentas.CurrentRow.Cells["G16_IdPro"].Value;

                // Buscar el producto en la lista
                var G16_ElPro = G16_ProVen.FirstOrDefault(p => p.G16_IdPro == G16_IDselec);

                if (G16_ElPro != null)
                {
                    G16_ProVen.Remove(G16_ElPro);

                    // Refrescar el datagridview
                    dgvRVentas.DataSource = null;
                    dgvRVentas.DataSource = G16_ProVen;

                    // Actualizar total
                    double G16_total = G16_ProVen.Sum(G16_p => G16_p.G16_Cantidad * G16_p.G16_Precio);
                    txtTotal.Text = "Total: S/ " + G16_total.ToString("0.00");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbxCliente.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un cliente.");
                return;
            }

            if (G16_ProVen.Count == 0)
            {
                MessageBox.Show("No hay productos en la venta.");
                return;
            }

            // Obtener el cliente seleccionado
            string nombreSeleccionado = cbxCliente.Text;

            // Buscar cliente por nombre completo (nombre + espacio + apellido)
            var cliente = clCliente.G16_Cli.FirstOrDefault(c =>
                (c.G16_Nombres + " " + c.G16_Apellidos).Trim() == nombreSeleccionado.Trim());

            if (cliente == null)
            {
                MessageBox.Show("Cliente no encontrado.");
                return;
            }

            // Generar ID automático
            int nuevoIdVenta = clVenta.G16_Ventas.Count + 1;

            // Crear venta
            var nuevaVenta = new clVenta(nuevoIdVenta, cliente.G16_DNI, new List<clProductoVendido>(G16_ProVen));

            // Agregar a la lista de ventas
            clVenta.G16_Ventas.Add(nuevaVenta);

            // Mostrar confirmación
            MessageBox.Show("Venta registrada correctamente.\nTotal: S/ " + nuevaVenta.G16_PrecioTotal.ToString("0.00"));
            G16_ProVen.Clear();


        }
    }
}
