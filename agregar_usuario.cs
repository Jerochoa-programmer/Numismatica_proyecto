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
    public partial class agregar_usuario : Form
    {
        string objconsulta = "";
        public agregar_usuario()
        {
            InitializeComponent();
        }
        public void cargarcombobox()
        {
            SqlConnection connection = conexion_b_d.conectar("nimusmatica");
            if (connection != null)
            {
                string objcomando1 = "SELECT tipo FROM tipos_usuarios";
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    cb_tipo_registro.Items.Clear();
                    while (tabla_consulta.Read())
                    {
                        string objeto = tabla_consulta["tipo"].ToString();
                        cb_tipo_registro.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
            cb_tipo_registro.SelectedIndex = 0;
        }

        private void btt_limpiar_agregar_Click(object sender, EventArgs e)
        {
            tb_nombre_registro.Clear();
            tb_password_ingreso.Clear();
            tb_usuario_registro.Clear();
            lb_alerta.Visible = false;
        }

        private void btt_registrar_Click(object sender, EventArgs e)
        {
            bool validacion = false;
            lb_alerta.Visible = false;
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            if (String.IsNullOrEmpty(tb_nombre_registro.Text) || String.IsNullOrEmpty(tb_usuario_registro.Text) || String.IsNullOrEmpty(tb_password_ingreso.Text))
            {
                lb_alerta.Visible = true;
                lb_alerta.Text = "Campos incompletos.";
                tb_nombre_registro.Clear();
                tb_password_ingreso.Clear();
                tb_usuario_registro.Clear();
            }
            else
            {
                objconsulta = "select * from usuarios where usuario = '" + tb_usuario_registro.Text + "'";
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
                try
                {
                    if (tabla_consulta.Read())
                    {
                        lb_alerta.Visible = true;
                        lb_alerta.Text = "Usuario ya registrado";
                        tb_nombre_registro.Clear();
                        tb_password_ingreso.Clear();
                        tb_usuario_registro.Clear();
                        validacion = false;
                    }
                    else
                    {
                        validacion = true;

                    }
                }
                catch (SqlException e1)
                {
                    MessageBox.Show("Error" + e1.Message);
                }

                tabla_consulta.Close();
                if (validacion = true)
                {
                    try
                    {
                        int k = 0;
                        if (cb_tipo_registro.SelectedIndex == 0)
                        {
                            k = 1;
                        }
                        else
                        {
                            k = 2;
                        }
                        objconsulta = "insert into usuarios values('" + tb_nombre_registro.Text + "','" + tb_usuario_registro.Text + "','" + tb_password_ingreso.Text + "','" + k + "')";
                        int n = conexion_b_d.actualizar(objconsulta, objconexion);
                        if (n == 0)
                        {
                            lb_alerta.Visible = true;
                            lb_alerta.Text = "Error en el ingreso";
                        }
                        else
                        {
                            lb_alerta.Visible = true;
                            lb_alerta.Text = "Usuario registrado";
                            tb_nombre_registro.Clear();
                            tb_password_ingreso.Clear();
                            tb_usuario_registro.Clear();
                            cb_tipo_registro.SelectedIndex = 0;
                        }

                    }
                    catch (SqlException e1)
                    {
                        MessageBox.Show("Error" + e1.Message);
                    }
                }

            }
        }
    }
}
