using ConsoleApp9.Properties.Rep;

using listadeProducto;
using listadeProductoVendido;
using listadeUsuario;
using listadeVentas;
using System.Windows.Forms;

namespace tablas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Producto> productos = ADO_Metodos.ObtenerProductos();
            dataGridView1.DataSource = productos;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<ProductoVendido> productosVendidos = ADO_Metodos.ObtenerProductosVendidos();
            dataGridView1.DataSource = productosVendidos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Usuario> usuarios = ADO_Metodos.ObtenerUsuarios();
            dataGridView1.DataSource = usuarios;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Ventas> ventas = ADO_Metodos.ObtenerVentas();
            dataGridView1.DataSource = ventas;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string nombreUsuario = textBox1.Text;
            string contraseña = textBox2.Text;

            Usuario usuario = ADO_Metodos.IniciarSesion(nombreUsuario, contraseña);

            if (usuario != null)
            {
                MessageBox.Show("Usuario Correcto");
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
