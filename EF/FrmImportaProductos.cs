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

namespace EF
{
    public partial class FrmImportaProductos : Form
    {
        public FrmImportaProductos()
        {
            InitializeComponent();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            string G16_rutaProductos = Path.Combine(txtDireccionPC.Text, txtNombre.Text + ".txt");

            if (File.Exists(G16_rutaProductos))
            {
                clProductos.G16_Pro.Clear(); // Limpia la lista de productos antes de cargar nuevos datos

                string[] G16_lineas = File.ReadAllLines(G16_rutaProductos);
                foreach (string G16_line in G16_lineas)
                {
                    string[] G16_datos = G16_line.Split(',');
                    if (G16_datos.Length == 4)  // Ahora tenemos 4 campos: Código, Nombre, Categoria, Precio
                    {
                        string codigo = G16_datos[0].Trim();  // Código
                        string nombre = G16_datos[1].Trim();  // Nombre
                        string categoria = G16_datos[2].Trim();  // Categoría
                        double precio = 0;

                        // Intentamos convertir el precio a un número
                        if (double.TryParse(G16_datos[3].Trim(), out precio))
                        {
                            // Agregar el producto utilizando el código, nombre, categoría y precio
                            clProductos.agregarProducto(nombre, categoria, precio);
                        }
                    }
                }

                // Verifica si la lista de productos está vacía después de intentar agregar los datos
                if (clProductos.G16_Pro.Count == 0)
                {
                    MessageBox.Show("Datos no leídos. Verifique el formato del archivo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }
                else
                {
                    MessageBox.Show("Productos cargados correctamente desde la ruta seleccionada.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmImportaProductos G16_frm = new FrmImportaProductos();
                    G16_frm.Close();
                }
            }
            else
            {
                MessageBox.Show("No se encontró el archivo de productos.txt en la ruta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
