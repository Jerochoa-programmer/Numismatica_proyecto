using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nimusmatica
{
    public partial class buscar_usuario : Form
    {
        string objconsulta = "";
        public buscar_usuario()
        {
            InitializeComponent();
        }
        public void cargarusuarios(String base_datos, string tabla, string columna)
        {
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT " + columna + " FROM " + tabla;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    cb_seleccionar_buscar.Items.Clear();
                    while (tabla_consulta.Read())
                    {
                        string objeto = tabla_consulta[columna].ToString();
                        cb_seleccionar_buscar.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
            cb_seleccionar_buscar.SelectedIndex = 0;
        }
        private void btt_buscar_buscar_Click(object sender, EventArgs e)
        {
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            objconsulta = "select * from usuarios where nombre = '" + cb_seleccionar_buscar.Text + "'";
            SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
            try
            {
                while (tabla_consulta.Read())
                {

                    tb_nombre_buscar.Text = tabla_consulta[1].ToString();
                    tb_usuario_buscar.Text = tabla_consulta[2].ToString();
                    tb_password_buscar.Text = tabla_consulta[3].ToString();
                    if (tabla_consulta[4].ToString().Equals("1"))
                    {
                        tb_tipo_buscar.Text = "común";
                    }
                    else
                    {
                        tb_tipo_buscar.Text = "administrador";
                    }
                }
            }
            catch (SqlException e1)
            {
                MessageBox.Show("Error en la busqueda" + e1.Message);
            }
            tabla_consulta.Close();
            lb_nombre_buscar.Enabled = true;
            tb_nombre_buscar.Enabled = true;
            lb_usuario_buscar.Enabled = true;
            tb_usuario_buscar.Enabled = true;
            lb_password_buscar.Enabled = true;
            tb_password_buscar.Enabled = true;
            lb_tipo_buscar.Enabled = true;
            tb_tipo_buscar.Enabled = true;
            btt_regresar_buscar.Enabled = true;
            btt_buscar_buscar.Enabled = false;
            lb_seleccion_buscar.Enabled = false;
            cb_seleccionar_buscar.Enabled = false;
        }

        private void btt_regresar_buscar_Click(object sender, EventArgs e)
        {
            lb_nombre_buscar.Enabled = false;
            tb_nombre_buscar.Enabled = false;
            tb_nombre_buscar.Clear();
            lb_usuario_buscar.Enabled = false;
            tb_usuario_buscar.Enabled = false;
            tb_usuario_buscar.Clear();
            lb_password_buscar.Enabled = false;
            tb_password_buscar.Enabled = false;
            tb_password_buscar.Clear();
            lb_tipo_buscar.Enabled = false;
            tb_tipo_buscar.Enabled = false;
            tb_tipo_buscar.Clear();
            btt_regresar_buscar.Enabled = false;
            btt_buscar_buscar.Enabled = true;
            lb_seleccion_buscar.Enabled = true;
            cb_seleccionar_buscar.Enabled = true;
        }
    }
}
