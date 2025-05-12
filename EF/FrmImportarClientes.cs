using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF
{
    public partial class FrmImportarClientes : Form
    {
        private frmCLientes formularioClientes;
        public FrmImportarClientes()
        {
            InitializeComponent();

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

        private void btnImportar_Click(object sender, EventArgs e)

        {

            string G16_ruta = Path.Combine(txtDireccionPC.Text, txtNombre.Text + ".txt");

            
            if (File.Exists(G16_ruta))
            {
                clCliente.G16_Cli.Clear(); // Limpia la lista antes de cargar nuevos datos

                string[] G16_lineas = File.ReadAllLines(G16_ruta);
                foreach (string G16_line in G16_lineas)
                {
                    string[] G16_datos = G16_line.Split(',');
                    if (G16_datos.Length == 4)
                    {
                        string G16_dni = G16_datos[0].Trim();
                       
                        string G16_nombres = G16_datos[1].Trim();
                        string G16_apellidos = G16_datos[2].Trim();
                        string G16_celular = G16_datos[3].Trim();

                        clCliente.agregarCliente(Convert.ToInt32(G16_dni), G16_nombres, G16_apellidos, Convert.ToInt32(G16_celular));
                    }
                }

                // Verifica si la lista está vacía después de intentar agregar los datos
                if (clCliente.G16_Cli.Count == 0)
                {
                    MessageBox.Show("Datos no leídos. Verifique el formato del archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Clientes cargados correctamente desde la ruta seleccionada.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmImportarClientes G16_frm = new FrmImportarClientes();
                    G16_frm.Close();
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo cliente.txt en la ruta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }   
    }
}
