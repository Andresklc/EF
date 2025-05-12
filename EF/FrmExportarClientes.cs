using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EF
{
    public partial class FrmExportarClientes : Form
    {
        public FrmExportarClientes()
        {
            InitializeComponent();
            MostrarClientesEnTextBox();
        }
        private void MostrarClientesEnTextBox()
        {
            txtVista.Clear(); // Limpia el contenido anterior
            txtVista.Text = "Lista de Clientes\r\n";
            foreach (var G16_clie in clCliente.G16_Cli)
            {
                string G16_linea = $"{G16_clie.G16_DNI},{G16_clie.G16_Nombres},{G16_clie.G16_Apellidos},{G16_clie.G16_Celular}";
                txtVista.AppendText(G16_linea + Environment.NewLine); // Agrega cada línea con salto
            }
        }
        private void btnSelecion_Click(object sender, EventArgs e)
        {
            using (var G16_nav = new FolderBrowserDialog())
            {
                try
                {
                    if (G16_nav.ShowDialog() == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(G16_nav.SelectedPath))
                    {
                        txtDireccionPC.Text = G16_nav.SelectedPath;
                    }
                }
                catch (Exception G16_ex)
                {
                    MessageBox.Show("Error:" + G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtDireccionPC.Text)) { MessageBox.Show($"El textbox navegador esta vacio,porfavor colocar su direccion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop); return; }
                String[] G16_Imprimir = { txtVista.Text };
                using (StreamWriter G16_Salida = new StreamWriter(txtDireccionPC.Text + "\\" + txtNombre.Text + ".txt", true))
                {
                    foreach (String G16_Linea in G16_Imprimir)
                    {
                        G16_Salida.WriteLine(G16_Linea);
                    }
                    G16_Salida.Close();
                }
                txtDireccionPC.Clear();
                MessageBox.Show($"El listado {txtNombre.Text.ToString()}.txt fue guardado exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmExportarClientes G16_frm = new FrmExportarClientes();
                G16_frm.Close();
            }
            catch (Exception G16_ex)
            {
                MessageBox.Show("Error:" + G16_ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        
    }
}
