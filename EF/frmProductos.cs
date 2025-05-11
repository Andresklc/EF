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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            mostrar();
            listaCat();
          
        }
        public void mostrar()
        {
            try { 
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = clProductos.G16_Pro;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ClearSelection();
            }
            catch(Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }// muestra la tabla
        public void limpiar()
        {
            try
            {
                txtCodigo.Clear();
                txtNombre.Clear();
                txtPrecio.Clear();
                txtCodigo.Clear();
                cbxCategoria.SelectedIndex = -1;
                txtCategoria.Clear();
                btnRegistrar.Text = "Registrar";
                dgvProductos.ClearSelection();
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }//limpia los cuadros de texto
        public void listaCat()
        {
            cbxCategoria.DataSource = null;
            cbxCategoria.DataSource = clCategoria.G16_cat;
            cbxCategoria.DisplayMember = "G16_Nombre";  // Lo que se muestra
            cbxCategoria.SelectedIndex = -1;
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var G16_proExisCo = clProductos.G16_Pro.FirstOrDefault(G16_p => G16_p.G16_Codigo == txtCodigo.Text.Trim());
                var G16_proExisNo = clProductos.G16_Pro.FirstOrDefault(G16_p => G16_p.G16_Nombre == txtNombre.Text.Trim() &&
                                                                        G16_p.G16_Categoria == cbxCategoria.Text.Trim());
                if (G16_proExisCo != null)
                {
                        G16_proExisCo.G16_Nombre = txtNombre.Text;
                        G16_proExisCo.G16_Categoria = cbxCategoria.Text;
                        G16_proExisCo.G16_Precio = Convert.ToDouble(txtPrecio.Text);
                        MessageBox.Show("Editado", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (G16_proExisNo == null)
                    {
                        clProductos.agregarProducto(
                        txtNombre.Text,
                        cbxCategoria.Text,
                        Convert.ToDouble(txtPrecio.Text));
                        MessageBox.Show("Agregado", "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("El producto ya existe","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Stop); }
                }
                limpiar();
                mostrar();
            }
            catch (Exception G16_ex)
            { 
                MessageBox.Show(G16_ex.Message,"Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificamos que se haya seleccionado una fila válida
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow G16_fila = dgvProductos.Rows[e.RowIndex];
                    txtCodigo.Text = G16_fila.Cells["G16_Codigo"].Value.ToString();
                    txtNombre.Text = G16_fila.Cells["G16_Nombre"].Value.ToString();
                    cbxCategoria.Text = G16_fila.Cells["G16_Categoria"].Value.ToString();
                    txtPrecio.Text = G16_fila.Cells["G16_Precio"].Value.ToString();
                    btnRegistrar.Text = "Editar";
                }
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
           
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
            mostrar();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {      
            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(cbxCategoria.Text))
                {
                    MessageBox.Show("Por favor, escriba un nombre o seleccione una categoria para filtrar.","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    limpiar();
                    mostrar();
                }
                var G16_Filtro = clProductos.G16_Pro.Where(G16_p =>
                    (string.IsNullOrEmpty(txtNombre.Text) || G16_p.G16_Nombre.IndexOf(txtNombre.Text,
                    StringComparison.OrdinalIgnoreCase) >= 0) &&
                    (string.IsNullOrEmpty(cbxCategoria.Text) || G16_p.G16_Categoria.Equals(cbxCategoria.Text,
                    StringComparison.OrdinalIgnoreCase))).ToList();
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = G16_Filtro;
                dgvProductos.ClearSelection();

            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try { 
            string G16_Code = txtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(G16_Code))
            {
                MessageBox.Show("Seleccione el producto que desea eliminar.");
                return;
            }
                var G16_Producto = clProductos.G16_Pro.FirstOrDefault(p => p.G16_Codigo.Equals(G16_Code, 
                StringComparison.OrdinalIgnoreCase));
            if (G16_Producto != null)
            {
                DialogResult G16_SiNo = MessageBox.Show($"¿Esta seguro que desea eliminar el producto?",
                    "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (G16_SiNo == DialogResult.Yes)
                {
                    clProductos.G16_Pro.Remove(G16_Producto);
                    MessageBox.Show("Producto eliminado correctamente.");
                    mostrar();
                    limpiar();
                }
            }
            }
            catch(Exception G16_ex) 
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnAgCategoria_Click(object sender, EventArgs e)
        {
            var G16_catExisNo = clCategoria.G16_cat.FirstOrDefault(G16_p => G16_p.G16_Nombre == txtCategoria.Text.Trim());
            if (G16_catExisNo == null)
            {
                clCategoria.agregarCategoria(txtCategoria.Text);
                txtCategoria.Clear();
                listaCat();
            }
            else
            {
                MessageBox.Show($"Categoria '{txtCategoria.Text}' ya existente", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCategoria.Clear();
            }
        }
    } 
}
