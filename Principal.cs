using nimusmatica.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nimusmatica
{
    public partial class Principal : Form
    {
        public static int tipo_usuario = 0;
        string objconsulta = "";
        public static int form_principal = 0;
        menu_admin obj_m_admin = new menu_admin();
        public static agregar_elemento obj_fn = null;
        public static editar_elemento obj_el = null;
        public static buscar_elemento obj_be = null;
        public static eliminar_elemento obj_ee = null;
        public static int validacion_volver = 0;
        
        public Principal()
        {
            InitializeComponent();
        }
        
        private void btt_salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void cambio_form(int i,Form f1, Form f2)
        {

            switch (i)
            {
                case 0:
                    gb_general.Visible = true;
                    volver_menu_item.Visible = false;
                    volver_menu_item.Enabled = false;
                    f1.Visible = false;
                    break;
                case 1:
                    f1.MdiParent = this;
                    f1.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                    f1.Show();
                    volver_menu_item.Visible = true;
                    volver_menu_item.Enabled = true;
                    gb_general.Visible = false;
                    break;
                case 2:
                    obj_m_admin.metodo_volver();
                    break;
                case 3:
                    obj_m_admin.metodo_volver_1();
                    break;
                case 4:
                    obj_fn.volver();
                    break;
                case 5:
                    obj_el.volver();
                    break;
                case 6:
                    obj_be.volver();
                    break;
                case 7:
                    obj_ee.volver();
                    break;
                case 8:
                    obj_m_admin.metodo_volver_1();
                    obj_m_admin.metodo_admin();
                    break;
                case 9:
                    obj_m_admin.metodo_volver_1();
                    obj_m_admin.metodo_comun();
                    break;
                case 10:
                    obj_fn.volver_elemeneto_especial();
                    break;
                case 11:
                    obj_el.volver_elemento_especial();
                    break;
                case 12:
                    obj_be.volver_elemento_especial();
                    break;
                case 13:
                    obj_ee.volver_elemento_especial();
                    break;

            }
        }

        private void btt_iniciar_sesion_Click(object sender, EventArgs e)
        {
            lb_mensaje_alerta.Visible = false;
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            if (String.IsNullOrEmpty(tb_usuario.Text) || String.IsNullOrEmpty(tb_password.Text))
            {
                lb_mensaje_alerta.Visible = true;
                tb_password.Clear();
                tb_usuario.Clear();
            }
            else
            {
                objconsulta = "select * from usuarios where usuario = '" + tb_usuario.Text + "'";
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
                try
                {
                    if (tabla_consulta.Read())
                    {
                        if (!tabla_consulta[3].ToString().Equals(tb_password.Text))
                        {
                            lb_mensaje_alerta.Visible = true;
                            lb_mensaje_alerta.Text = "Usuario o contraseña incorrecta";
                            tb_password.Clear();
                            tb_usuario.Clear();
                        }
                        else
                        {
                            tipo_usuario = Int32.Parse(tabla_consulta[4].ToString());
                            if (tipo_usuario == 1)
                            {
                                obj_m_admin.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                                obj_m_admin.MdiParent = this;
                                obj_m_admin.Show();
                                obj_m_admin.metodo_comun();
                                gb_general.Visible = false;
                                volver_menu_item.Visible = true;
                                volver_menu_item.Enabled = true;
                                tb_usuario.Clear();
                                tb_password.Clear();
                                cambio_form(1, obj_m_admin, obj_m_admin);
                                validacion_volver = 1;
                            }
                            else if (tipo_usuario == 2)
                            {
                                obj_m_admin.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                                obj_m_admin.MdiParent = this;
                                obj_m_admin.Show();
                                obj_m_admin.metodo_admin();
                                gb_general.Visible = false;
                                volver_menu_item.Visible = true;
                                volver_menu_item.Enabled = true;
                                tb_usuario.Clear();
                                tb_password.Clear();
                                cambio_form(1, obj_m_admin, obj_m_admin);
                                validacion_volver = 2;
                            }
                        }
                    }
                    else
                    {
                        lb_mensaje_alerta.Visible = true;
                        lb_mensaje_alerta.Text = "Usuario o contraseña incorrecta";
                        tb_password.Clear();
                        tb_usuario.Clear();
                    }
                }
                catch (SqlException e1)
                {
                    MessageBox.Show("Fallo en la busqueda" + e1.Message);
                }
                tabla_consulta.Close();

            }
        }

        private void volver_menu_item_Click(object sender, EventArgs e)
        {
            switch (form_principal) {
                case 0:
                    cambio_form(form_principal, obj_m_admin, obj_m_admin);
                    break;
                case 2:
                    cambio_form(2, obj_m_admin, obj_m_admin);
                    break;
                case 3:
                    cambio_form(3, obj_m_admin, obj_m_admin);
                    form_principal = 2;
                    break;
                case 4:
                    cambio_form(4, obj_m_admin, obj_m_admin);
                    form_principal = 3;
                    break;
                case 5:
                    cambio_form(5, obj_m_admin, obj_m_admin);
                    form_principal = 3;
                    break;
                case 6:
                    cambio_form(6, obj_m_admin, obj_m_admin);
                    switch (validacion_volver)
                    {
                        case 1:
                            form_principal = 9;
                            break;
                        case 2:
                            form_principal = 8;
                            break;
                        case 3:
                            form_principal = 3;
                            break;
                    }
                    break;
                case 7:
                    cambio_form(7, obj_m_admin, obj_m_admin);
                    form_principal = 3;
                    break;
                case 8:
                    cambio_form(8, obj_m_admin, obj_m_admin);
                    form_principal = 0;
                    break;
                case 9:
                    cambio_form(9, obj_m_admin, obj_m_admin);
                    form_principal = 0;
                    break;
                case 10:
                    cambio_form(10, obj_fn, obj_m_admin);
                    form_principal = 4;
                    break;
                case 11:
                    cambio_form(11, obj_fn, obj_m_admin);
                    form_principal = 5;
                    break;
                case 12:
                    cambio_form(12, obj_fn, obj_m_admin);
                    form_principal = 6;
                    break;
                case 13:
                    cambio_form(13, obj_fn, obj_m_admin);
                    form_principal = 7;
                    break;
            }
        }

        private void salir_menu_strip_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tb_password_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
