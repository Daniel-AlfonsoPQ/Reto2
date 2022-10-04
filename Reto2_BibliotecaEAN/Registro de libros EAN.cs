using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Capa_Entidad;
using Capa_Negocio;

namespace Reto2_BibliotecaEAN
{
    public partial class Form1 : Form
    {
        ClassEntidad objent = new ClassEntidad();
        ClassNegocio objneg = new ClassNegocio();
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void text_buscar_TextChanged(object sender, EventArgs e)
        {
            if (text_buscar.Text != "")
            {
                objent.titulo = text_buscar.Text;
                DataTable dt = new DataTable();
                dt = objneg.N_buscar_libros(objent);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.DataSource = objneg.N_listar_libros();
            }
        }

        void mantenimiento(String accion)
        {
            
            
                objent.codigo = Convert.ToInt32(text_codigo.Text);
                objent.titulo = text_titulo.Text;
                objent.autor = text_autor.Text;
                objent.editorial = text_editorial.Text;
                objent.precio = Convert.ToDouble(text_precio.Text);
                objent.cantidad = Convert.ToInt32(text_cantidad.Text);
                objent.accion = accion;
                String men = objneg.N_mantenimiento_libro(objent);
                MessageBox.Show(men, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }


        void limpiar()
        {
            text_codigo.Text = "0";
            text_titulo.Text = "";
            text_autor.Text = "";
            text_editorial.Text = "";
            text_precio.Text = "";
            text_cantidad.Text = "";
            text_buscar.Text = "";
            dataGridView1.DataSource = objneg.N_listar_libros();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            text_codigo.Text = "0";
            dataGridView1.DataSource = objneg.N_listar_libros();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_titulo.Text != "") {
                if (MessageBox.Show("¿Deseas registrar el libro " + text_titulo.Text + "?", "Mensaje",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("1");
                    limpiar();
                }
            }
           
            
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_codigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas modificar el libro " + text_titulo.Text + "?", "Mensaje",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("2");
                    limpiar();
                }
            }
                
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (text_codigo.Text != "")
            {
                if (MessageBox.Show("¿Deseas eliminar el libro " + text_titulo.Text + "?", "Mensaje",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    mantenimiento("3");
                    limpiar();
                }
            }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dataGridView1.CurrentCell.RowIndex;

            text_codigo.Text = dataGridView1[0, fila].Value.ToString();
            text_titulo.Text = dataGridView1[1, fila].Value.ToString();
            text_autor.Text = dataGridView1[2, fila].Value.ToString();
            text_editorial.Text = dataGridView1[3, fila].Value.ToString();
            text_precio.Text = dataGridView1[4, fila].Value.ToString();
            text_cantidad.Text = dataGridView1[5, fila].Value.ToString();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void text_cantidad_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
