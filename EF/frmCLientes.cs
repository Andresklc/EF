using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;



namespace EF
{
    public partial class frmCLientes : Form
    {
        public frmCLientes()
        {
            InitializeComponent();
            mostrar();
            limpiar();
        }
        public void mostrar()
        {
            try
            {
                dgvClientes.DataSource = null;

                // Crear una lista temporal solo con los campos deseados (sin nombre completo)
                var listaFiltrada = clCliente.G16_Cli.Select(c => new
                {
                    DNI = c.G16_DNI,
                    Nombres = c.G16_Nombres,
                    Apellidos = c.G16_Apellidos,
                    Celular = c.G16_Celular
                    // NO se incluye la propiedad NombreCompleto
                }).ToList();

                dgvClientes.DataSource = listaFiltrada;
                dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvClientes.ClearSelection();
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }// muestra la tabla
        public void limpiar()
        {
            try
            {
                txtDNI.Enabled = true;
                txtDNI.Clear();
                txtNombre.Clear();
                txtApellidos.Clear();
                txtCelular.Clear();
                btnRegistrar.Text = "Registrar";
                dgvClientes.ClearSelection();
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }//limpia los cuadros de texto
        public bool Validaciones()
        {
            if (!ValidarDNIRecursivo(txtDNI.Text))
            {
                MessageBox.Show("El DNI debe contener exactamente 8 dígitos numéricos.");
                return true;
            }
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Rellenar el campo de Nombres.");
                return true;
            }
            if (string.IsNullOrEmpty(txtApellidos.Text))
            {
                MessageBox.Show("Rellenar el campo de Apellidos.");
                return true;
            }
            if (!ValidarCelularRecursivo(txtCelular.Text))
            {
                MessageBox.Show("El Celular debe contener exactamente 9 dígitos numéricos.");
                return true;
            }
            return false;

        }//Comprueva si los campos cumplen con los requisitos
        //Cuenta la cantidad numeros que contiene el textbox y evita los caracteres↓
        public bool ValidarDNIRecursivo(string G16_Texto, int G16_Indice = 0, int G16_Contador = 0)
        {
            if (G16_Indice >= G16_Texto.Length)
                return G16_Contador == 8;

            if (char.IsDigit(G16_Texto[G16_Indice]))
                return ValidarDNIRecursivo(G16_Texto, G16_Indice + 1, G16_Contador + 1);
            else
                return ValidarDNIRecursivo(G16_Texto, G16_Indice + 1, G16_Contador);
        }
        public bool ValidarCelularRecursivo(string G16_Texto, int G16_Indice = 0, int G16_Contador = 0)
        {
            if (G16_Indice >= G16_Texto.Length)
                return G16_Contador == 9;

            if (char.IsDigit(G16_Texto[G16_Indice]))
                return ValidarCelularRecursivo(G16_Texto, G16_Indice + 1, G16_Contador + 1);
            else
                return ValidarCelularRecursivo(G16_Texto, G16_Indice + 1, G16_Contador);
        }
        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Verificamos que se haya seleccionado una fila válida
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow G16_fila = dgvClientes.Rows[e.RowIndex];
                    txtDNI.Text = G16_fila.Cells["G16_DNI"].Value.ToString();
                    txtNombre.Text = G16_fila.Cells["G16_Nombres"].Value.ToString();
                    txtApellidos.Text = G16_fila.Cells["G16_Apellidos"].Value.ToString();
                    txtCelular.Text = G16_fila.Cells["G16_Celular"].Value.ToString();
                    btnRegistrar.Text = "Editar";
                    txtDNI.Enabled = false;
                }
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (Validaciones()) { return; }
                var G16_proExisDn = clCliente.G16_Cli.FirstOrDefault(G16_p => G16_p.G16_DNI ==Convert.ToDouble(txtDNI.Text));
                var G16_proExisNo = clCliente.G16_Cli.FirstOrDefault(G16_p => G16_p.G16_DNI == Convert.ToDouble(txtDNI.Text) &&
                                                                        G16_p.G16_Nombres == txtNombre.Text.Trim());
                if (G16_proExisDn != null)
                {
                    G16_proExisDn.G16_Nombres = txtNombre.Text;
                    G16_proExisDn.G16_Apellidos = txtApellidos.Text;
                    G16_proExisDn.G16_Celular = Convert.ToInt32(txtCelular.Text);
                    MessageBox.Show("Editado", "Estado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (G16_proExisNo == null)
                    {
                        clCliente.agregarCliente(
                        Convert.ToInt32(txtDNI.Text),
                        txtNombre.Text,
                        txtApellidos.Text,
                        Convert.ToInt32(txtCelular.Text));
                        txtDNI.Enabled = false;
                        MessageBox.Show("Agregado", "Respuesta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else { MessageBox.Show("El Cliente ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop); }
                }
                limpiar();
                mostrar();
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
                if (string.IsNullOrEmpty(txtNombre.Text) && string.IsNullOrEmpty(txtApellidos.Text))
                {
                    MessageBox.Show("Por favor, escriba un nombre o un apellido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    limpiar();
                    mostrar();
                }
                var G16_Filtro = clCliente.G16_Cli.Where(G16_c =>
                    (string.IsNullOrEmpty(txtNombre.Text) || G16_c.G16_Nombres.IndexOf(txtNombre.Text,
                    StringComparison.OrdinalIgnoreCase) >= 0) &&
                    (string.IsNullOrEmpty(txtApellidos.Text) || G16_c.G16_Apellidos.IndexOf(txtApellidos.Text,
                    StringComparison.OrdinalIgnoreCase) >= 0)).ToList();
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = G16_Filtro;
                dgvClientes.ClearSelection();

            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                string G16_D = txtDNI.Text.Trim();
                if (string.IsNullOrEmpty(G16_D))
                {
                    MessageBox.Show("Seleccione el cliente que desee eliminar.");
                    return;
                }
                var G16_Clien = clCliente.G16_Cli.FirstOrDefault(G16_C => G16_C.G16_DNI.ToString().Equals(G16_D,
                StringComparison.OrdinalIgnoreCase));
                if (G16_Clien != null)
                {
                    DialogResult G16_SiNo = MessageBox.Show($"¿Esta seguro que desea eliminar al Cliente?",
                        "Confirmar eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (G16_SiNo == DialogResult.Yes)
                    {
                        clCliente.G16_Cli.Remove(G16_Clien);
                        MessageBox.Show("Cliente eliminado correctamente.");
                        mostrar();
                        limpiar();
                    }
                }
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show(G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }    
}
