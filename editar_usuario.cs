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
    public partial class editar_usuario : Form
    {
        string objconsulta = "";
        public editar_usuario()
        {
            InitializeComponent();
        }
        public void cargarusuarios(String base_datos, string tabla, string columna)
        {
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT " + columna +" FROM " + tabla;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    cb_seleccion_usuario.Items.Clear();
                    while (tabla_consulta.Read())
                    {
                        string objeto = tabla_consulta[columna].ToString();
                        cb_seleccion_usuario.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
            cb_seleccion_usuario.SelectedIndex = 0;
        }
        public void cargartipos(String base_datos,string tabla, string columna)
        {
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT " + columna + " FROM " + tabla;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    cb_tipo_editar.Items.Clear();
                    while (tabla_consulta.Read())
                    {
                        string objeto = tabla_consulta[columna].ToString();
                        cb_tipo_editar.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
            cb_tipo_editar.SelectedIndex = 0;
        }

        private void btt_buscar_editar_Click(object sender, EventArgs e)
        {
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            objconsulta = "select * from usuarios where nombre = '" + cb_seleccion_usuario.Text + "'";
            SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
            try
            {
                while (tabla_consulta.Read())
                {

                    tb_nombre_editar.Text = tabla_consulta[1].ToString();
                    tb_usuario_editar.Text = tabla_consulta[2].ToString();
                    tb_password_editar.Text = tabla_consulta[3].ToString();
                    if (tabla_consulta[4].ToString().Equals("1"))
                    {
                        cb_tipo_editar.SelectedIndex = 0;
                    }
                    else
                    {
                        cb_tipo_editar.SelectedIndex = 1;
                    }
                }
            }
            catch (SqlException e1)
            {
                MessageBox.Show("Error en la busqueda" + e1.Message);
            }
            tabla_consulta.Close();
            lb_seleccion_usuario.Enabled = false;
            cb_seleccion_usuario.Enabled = false;
            btt_buscar_editar.Enabled = false;
            btt_limpiar.Enabled = true;
            btt_volverabuscar_editar.Enabled = true;
            lb_nombre_editar.Enabled = true;
            tb_nombre_editar.Enabled = true;
            lb_usuario_editar.Enabled = true;
            tb_usuario_editar.Enabled = true;
            lb_password_editar.Enabled = true;
            tb_password_editar.Enabled = true;
            lb_tipo_editar.Enabled = true;
            cb_tipo_editar.Enabled = true;
            btt_editar_editar.Enabled = true;
        }

        private void btt_editar_editar_Click(object sender, EventArgs e)
        {
            string cod = "";
            bool validacion = false;
            int k = 0;
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            objconsulta = "select * from usuarios where nombre = '" + cb_seleccion_usuario.Text + "'";
            SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
            try
            {
                while (tabla_consulta.Read())
                {
                    cod = tabla_consulta[0].ToString();
                    if (tabla_consulta[2].ToString().Equals(tb_usuario_editar.Text))
                    {
                        validacion = true;
                    }
                    else
                    {
                        validacion = false;
                    }
                }
            }
            catch (SqlException e1)
            {
                MessageBox.Show("Error en la busqueda" + e1.Message);
            }
            tabla_consulta.Close();
            if (!validacion)
            {
                objconsulta = "select * from usuarios where usuario = '" + tb_usuario_editar.Text + "'";
                SqlDataReader tabla_consulta1 = conexion_b_d.consulta(objconsulta, objconexion);
                try
                {
                    if (tabla_consulta1.Read())
                    {
                        MessageBox.Show("Ya está");
                        lb_validacion_editar.Text = "El número de usuario ya está registrado";
                        tb_usuario_editar.Clear();
                    }
                    else
                    {

                        validacion = true;
                    }
                }
                catch (SqlException e1)
                {
                    MessageBox.Show("Error en la busqueda" + e1.Message);
                }
                tabla_consulta1.Close();

            }
            if (validacion)
            {
                try
                {
                    if (cb_tipo_editar.SelectedIndex == 0)
                    {
                        k = 1;
                    }
                    else
                    {
                        k = 2;
                    }
                    objconsulta = "update usuarios set nombre = '" + tb_nombre_editar.Text + "', usuario = '" + tb_usuario_editar.Text + "', pass = '" + tb_password_editar.Text + "', tipo = '" + k + "' where cod = '" + cod + "'";
                    int p = conexion_b_d.actualizar(objconsulta, objconexion);
                    if (p != 0)
                    {
                        lb_validacion_editar.Visible = true;
                        lb_validacion_editar.Text = "Usuario editado correctamente";
                        cargarusuarios("nimusmatica", "usuarios", "nombre");

                    }
                    else
                    {
                        lb_validacion_editar.Visible = true;
                        lb_validacion_editar.Text = "No se pudo editar el usuario";
                    }
                }
                catch (SqlException e1)
                {
                    MessageBox.Show("Error en la busqueda" + e1.Message);
                }

            }
        }

        private void btt_limpiar_Click(object sender, EventArgs e)
        {
            tb_nombre_editar.Clear();
            tb_usuario_editar.Clear();
            tb_password_editar.Clear();
        }

        private void btt_volverabuscar_editar_Click(object sender, EventArgs e)
        {
            lb_seleccion_usuario.Enabled = true;
            cb_seleccion_usuario.Enabled = true;
            btt_buscar_editar.Enabled = true;
            btt_limpiar.Enabled = false;
            btt_volverabuscar_editar.Enabled = false;
            lb_nombre_editar.Enabled = false;
            tb_nombre_editar.Enabled = false;
            tb_nombre_editar.Clear();
            lb_usuario_editar.Enabled = false;
            tb_usuario_editar.Enabled = false;
            tb_usuario_editar.Clear();
            lb_password_editar.Enabled = false;
            tb_password_editar.Enabled = false;
            tb_password_editar.Clear();
            lb_tipo_editar.Enabled = false;
            cb_tipo_editar.Enabled = false;
            btt_editar_editar.Enabled = false;
        }
    }
}
