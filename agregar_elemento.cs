using nimusmatica.Properties;
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
using System.Xml.Linq;

namespace nimusmatica
{
    public partial class agregar_elemento : Form
    {
        private static string tipo_de_elemento = "";
        private static string nombre_elemento_especial = "";
        private static int caracteristica_elemento = 0;
        Image imagen_elementos = null;
        private static bool image_validation = false;
        public agregar_elemento()
        {
            InitializeComponent();
        }
        private void cargarcombobox(String base_datos, System.Windows.Forms.ComboBox combob, string tabla, string columna)
        {
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT " + columna +" FROM " + tabla;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    combob.Items.Clear();
                    while (tabla_consulta.Read())
                    {
                        string objeto = tabla_consulta[columna].ToString();
                        combob.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
            combob.SelectedIndex = 0;
        }
        private void activacion_btt_agregar()
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 && tb_fecha_elemento_agregar.Text.Length > 0 && tb_cantidad_elemento_agregar.Text.Length > 0 && (cb_tipo_elemento_agregar.SelectedIndex == 0 || cb_tipo_elemento_agregar.SelectedIndex == 1))
            {
                if (cb_tipo_elemento_agregar.SelectedIndex == 0)
                {
                    if (image_validation == true)
                    {
                        btt_agregar_elemento.Enabled = true;
                    }
                }
                else if (cb_tipo_elemento_agregar.SelectedIndex == 1)
                {
                    if (chb_otro_pais.Checked)
                    {
                        if (tb_elemento_otro_pais_agregar.Text.Length > 0)
                        {
                            if (image_validation == true)
                            {
                                btt_agregar_elemento.Enabled = true;
                            }
                        }
                    }
                    else if (cb_pais_elemento_agregar.SelectedIndex >= 0)
                    {
                        if (image_validation == true)
                        {
                            btt_agregar_elemento.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btt_agregar_elemento.Enabled = false;
            }
        }
        private int agregar_valor(string tabla, string valor)
        {
            int i = 0;
            bool validacion = false;
            bool validacion1 = false;
            SqlConnection objconexion = conexion_b_d.conectar("nimusmatica");
            string objconsulta = "select * from " + tabla + " where nombre = '" + valor + "'";
            SqlDataReader tabla_consulta = conexion_b_d.consulta(objconsulta, objconexion);
            try
            {
                if (tabla_consulta.Read())
                {
                    validacion = false;
                }
                else
                {
                    validacion = true;

                }
            }
            catch (SqlException e1)
            {
                i = -1;
            }

            tabla_consulta.Close();

            if (validacion)
            {
                try
                {
                    objconsulta = "insert into " + tabla + " values('" + valor + "')";
                    int n = conexion_b_d.actualizar(objconsulta, objconexion);
                    if (n == 0)
                    {
                        i = -1;
                        validacion1 = false;
                    }
                    else
                    {
                        validacion1 = true;
                    }
                }
                catch (SqlException e1)
                {
                    i = -1;
                }
            }
            else
            {
                i = -1;
            }

            if (validacion1)
            {
                objconsulta = "select * from " + tabla + " where nombre = '" + valor + "'";
                SqlDataReader tabla_consulta1 = conexion_b_d.consulta(objconsulta, objconexion);
                try
                {
                    if (tabla_consulta1.Read())
                    {
                        i = Int32.Parse(tabla_consulta1[0].ToString());
                    }
                    else
                    {
                        i = -1;

                    }
                }
                catch (SqlException e1)
                {
                    i = -1;
                }

                tabla_consulta1.Close();
            }
            return i;
        }
        private void btt_imagen_elemento_agregar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Title = "Seleccionar imagen",
                    Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
                };
                DialogResult result = openFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    Image imagenoriginal = Image.FromFile(filePath);
                    imagen_elementos = imagenoriginal;
                    Image imagenredimensionada = operaciones_imagenes.redimensionarimagen(imagenoriginal, pb_imagen_elemento_agregar.Width, pb_imagen_elemento_agregar.Height);
                    pb_imagen_elemento_agregar.Image = imagenredimensionada;
                    image_validation = true;
                }
                else
                {
                    image_validation = false;
                }
                activacion_btt_agregar();
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error al seleccionar la imagen: " + e1.Message);
            }
        }

        private void btt_continuar_elemento_Click(object sender, EventArgs e)
        {
            if (cb_tipo_elemento.SelectedIndex == 0 && cb_caracteristicas_elemento.SelectedIndex == 0)
            {
                tipo_de_elemento = "monedas";

            }
            else if(cb_tipo_elemento.SelectedIndex == 1 && cb_caracteristicas_elemento.SelectedIndex == 0)
            {
                tipo_de_elemento = "billetes";
            }
            else if (cb_tipo_elemento.SelectedIndex == 0 && cb_caracteristicas_elemento.SelectedIndex == 1)
            {
                tipo_de_elemento = "monedas_especiales";
            }
            else if (cb_tipo_elemento.SelectedIndex == 1 && cb_caracteristicas_elemento.SelectedIndex == 1)
            {
                tipo_de_elemento = "billetes_especiales";
            }
            if (cb_caracteristicas_elemento.SelectedIndex == 0)
            {
                caracteristica_elemento = 1;
                image_validation = false;
                lb_alerta_seleccionar.Visible = false;
                gb_agregar_usuario.Visible = true;
                gb_seleccion_tipo.Visible = false;
            }
            else
            {
                caracteristica_elemento = 2;
                image_validation = false;
                lb_alerta_seleccionar.Visible = false;
                gb_nombre_elemento_especial.Visible = true;
                gb_seleccion_tipo.Visible = false;
            }
            
            Principal.form_principal = 4;
            cargarcombobox("nimusmatica", cb_tipo_moneda_elemento_agregar, "tipos_monedas", "nombre");
            cargarcombobox("nimusmatica", cb_tipo_elemento_agregar, "tipos", "tipo");
            cargarcombobox("nimusmatica", cb_pais_elemento_agregar, "paises", "nombre");

        }
        public void volver()
        {
            gb_agregar_usuario.Visible = false;
            tb_valor_agregar_elemento.Text = null;
            tb_fecha_elemento_agregar.Text = null;
            tb_cantidad_elemento_agregar.Text = null;
            tb_elemento_otro_pais_agregar.Text = null;
            chb_otro_pais.Checked = false;
            cb_pais_elemento_agregar.SelectedIndex = 0;
            cb_pais_elemento_agregar.Enabled = false;
            cb_tipo_elemento_agregar.SelectedIndex = 0;
            lb_pais_elemento_agregar.Enabled = false;
            pb_imagen_elemento_agregar.Image = Resources.simbolo;
            lb_alerta_elemento_agregar.Visible = false;
            gb_seleccion_tipo.Visible = true;
            gb_nombre_elemento_especial.Visible = false;
        }

        public void volver_elemeneto_especial()
        {
            gb_agregar_usuario.Visible = false;
            tb_valor_agregar_elemento.Text = null;
            tb_fecha_elemento_agregar.Text = null;
            tb_cantidad_elemento_agregar.Text = null;
            tb_elemento_otro_pais_agregar.Text = null;
            chb_otro_pais.Checked = false;
            cb_pais_elemento_agregar.SelectedIndex = 0;
            cb_pais_elemento_agregar.Enabled = false;
            cb_tipo_elemento_agregar.SelectedIndex = 0;
            lb_pais_elemento_agregar.Enabled = false;
            pb_imagen_elemento_agregar.Image = Resources.simbolo;
            lb_alerta_elemento_agregar.Visible = false;
            gb_nombre_elemento_especial.Visible = true;
            tb_nombre_elemento_especial.Text = "";
        }
        private void cb_tipo_elemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo_elemento.SelectedIndex==0 || cb_tipo_elemento.SelectedIndex == 1)
            {
                cb_caracteristicas_elemento.Enabled = true;
            }
        }

        private void tb_valor_agregar_elemento_TextChanged(object sender, EventArgs e)
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 || tb_fecha_elemento_agregar.Text.Length > 0 || tb_cantidad_elemento_agregar.Text.Length > 0 || tb_elemento_otro_pais_agregar.Text.Length > 0)
            {
                btt_limpiar_elemento_agregar.Enabled = true;
                activacion_btt_agregar();
            }
            else
            {
                btt_limpiar_elemento_agregar.Enabled = false;
            }

            if (!int.TryParse(tb_valor_agregar_elemento.Text, out _))
            {
                tb_valor_agregar_elemento.Text = "";
            }
        }

        private void tb_cantidad_elemento_agregar_TextChanged(object sender, EventArgs e)
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 || tb_fecha_elemento_agregar.Text.Length > 0 || tb_cantidad_elemento_agregar.Text.Length > 0 || tb_elemento_otro_pais_agregar.Text.Length > 0)
            {
                btt_limpiar_elemento_agregar.Enabled = true;
                activacion_btt_agregar();
            }
            else
            {
                btt_limpiar_elemento_agregar.Enabled = false;
            }
            if (!int.TryParse(tb_cantidad_elemento_agregar.Text, out _))
            {
                tb_cantidad_elemento_agregar.Text = "";
            }
        }

        private void tb_fecha_elemento_agregar_TextChanged(object sender, EventArgs e)
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 || tb_fecha_elemento_agregar.Text.Length > 0 || tb_cantidad_elemento_agregar.Text.Length > 0 || tb_elemento_otro_pais_agregar.Text.Length > 0)
            {
                btt_limpiar_elemento_agregar.Enabled = true;
                activacion_btt_agregar();
            }
            else
            {
                btt_limpiar_elemento_agregar.Enabled = false;
            }
            foreach (char c in tb_fecha_elemento_agregar.Text)
            {
                if (!char.IsDigit(c) && !"/".Contains(c))
                {
                    tb_fecha_elemento_agregar.Text = "";
                    break;
                }
            }
        }

        private void cb_tipo_elemento_agregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            activacion_btt_agregar();
            if (cb_tipo_elemento_agregar.SelectedIndex == 1)
            {
                lb_pais_elemento_agregar.Enabled = true;
                cb_pais_elemento_agregar.Enabled = true;
                chb_otro_pais.Enabled = true;
            }
            else
            {
                lb_pais_elemento_agregar.Enabled = false;
                cb_pais_elemento_agregar.Enabled = false;
                chb_otro_pais.Enabled = false;
            }
        }

        private void cb_pais_elemento_agregar_SelectedIndexChanged(object sender, EventArgs e)
        {
            activacion_btt_agregar();
        }

        private void tb_elemento_otro_pais_agregar_TextChanged(object sender, EventArgs e)
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 || tb_fecha_elemento_agregar.Text.Length > 0 || tb_cantidad_elemento_agregar.Text.Length > 0 || tb_elemento_otro_pais_agregar.Text.Length > 0)
            {
                btt_limpiar_elemento_agregar.Enabled = true;
                activacion_btt_agregar();
            }
            else
            {
                btt_limpiar_elemento_agregar.Enabled = false;
            }
        }

        private void chb_otro_pais_CheckedChanged(object sender, EventArgs e)
        {
            activacion_btt_agregar();
            if (chb_otro_pais.Checked)
            {
                lb_pais_elemento_agregar.Enabled = false;
                cb_pais_elemento_agregar.Enabled = false;
                lb_elemento_otro_pais.Enabled = true;
                tb_elemento_otro_pais_agregar.Enabled = true;
            }
            else
            {
                lb_pais_elemento_agregar.Enabled = true;
                cb_pais_elemento_agregar.Enabled = true;
                lb_elemento_otro_pais.Enabled = false;
                tb_elemento_otro_pais_agregar.Enabled = false;
            }
        }

        private void chb_otra_moneda_elemento_agregar_CheckedChanged(object sender, EventArgs e)
        {
            if (chb_otra_moneda_elemento_agregar.Checked)
            {
                lb_tipo_moneda_elemento_agregar.Enabled = false;
                cb_tipo_moneda_elemento_agregar.Enabled = false;
                lb_otra_moneda_elemento_agregar.Enabled = true;
                tb_otra_moneda_elemento_agregar.Enabled = true;
            }
            else
            {
                lb_tipo_moneda_elemento_agregar.Enabled = true;
                cb_tipo_moneda_elemento_agregar.Enabled = true;
                lb_otra_moneda_elemento_agregar.Enabled = false;
                tb_otra_moneda_elemento_agregar.Enabled = false;
            }
        }

        private void btt_limpiar_elemento_agregar_Click(object sender, EventArgs e)
        {
            tb_valor_agregar_elemento.Text = null;
            tb_fecha_elemento_agregar.Text = null;
            tb_cantidad_elemento_agregar.Text = null;
            tb_elemento_otro_pais_agregar.Text = null;
            chb_otro_pais.Checked = false;
            cb_pais_elemento_agregar.SelectedIndex = 0;
            cb_pais_elemento_agregar.Enabled = false;
            cb_tipo_elemento_agregar.SelectedIndex = 0;
            lb_pais_elemento_agregar.Enabled = false;
            pb_imagen_elemento_agregar.Image = Resources.simbolo;
            lb_alerta_elemento_agregar.Visible = false;
        }

        private void btt_agregar_elemento_Click(object sender, EventArgs e)
        {
            byte[] imagenConvertida = operaciones_imagenes.convertirimagenabyte(imagen_elementos);
            
            try
            {
                using (SqlConnection conexion = conexion_b_d.conectar("nimusmatica"))
                {
                    bool validacion1 = false;
                    bool validacion2 = false;
                    int pais = 0;
                    int moneda = 0;
                    int tipo = 0;
                    string objconsulta = "";
                    if (chb_otra_moneda_elemento_agregar.Checked)
                    {
                        if (String.IsNullOrEmpty(tb_otra_moneda_elemento_agregar.Text))
                        {
                            lb_alerta_elemento_agregar.Visible = true;
                            lb_alerta_elemento_agregar.Text = "Campos incompletos";
                            validacion1 = false;
                        }
                        else
                        {
                            moneda = agregar_valor("tipos_monedas", tb_otra_moneda_elemento_agregar.Text);
                            if (moneda == -1)
                            {
                                lb_alerta_elemento_agregar.Visible = true;
                                lb_alerta_elemento_agregar.Text = "No se pudo agregar la nueva moneda";
                                validacion1 = false;
                            }
                            else
                            {
                                validacion1 = true;
                            }
                        }
                    }
                    else
                    {
                        validacion1 = true;
                        moneda = cb_tipo_moneda_elemento_agregar.SelectedIndex + 1;
                    }
                    if (cb_tipo_elemento_agregar.SelectedIndex == 1)
                    {
                        tipo = 2;
                        if (chb_otro_pais.Checked)
                        {
                            if (String.IsNullOrEmpty(tb_elemento_otro_pais_agregar.Text))
                            {
                                lb_alerta_elemento_agregar.Visible = true;
                                lb_alerta_elemento_agregar.Text = "Campos incompletos";
                                validacion2 = false;
                            }
                            else
                            {
                                pais = agregar_valor("paises", tb_elemento_otro_pais_agregar.Text);
                                if (pais == -1)
                                {
                                    lb_alerta_elemento_agregar.Visible = true;
                                    lb_alerta_elemento_agregar.Text = "No se pudo agregar el nuevo pais";
                                    validacion2 = false;
                                }
                                else
                                {
                                    validacion2 = true;
                                }
                            }
                        }
                        else if (cb_pais_elemento_agregar.SelectedIndex == 0)
                        {
                            tipo = 1;
                            pais = 1;
                            validacion2 = true;
                        }
                        else
                        {
                            pais = cb_pais_elemento_agregar.SelectedIndex + 1;
                            validacion2 = true;
                        }
                    }
                    else
                    {
                        tipo = 1;
                        validacion2 = true;
                        pais = 1;
                    }
                    if (validacion1 && validacion2)
                    {
                        if (caracteristica_elemento ==1)
                        {
                            objconsulta = "INSERT INTO " + tipo_de_elemento + " VALUES ('" + tb_valor_agregar_elemento.Text + "', '" + tb_cantidad_elemento_agregar.Text + "', '" + tipo + "',  @imagen, '" + tb_fecha_elemento_agregar.Text + "', '" + moneda + "', '" + pais + "')";
                        }
                        else if (caracteristica_elemento == 2)
                        {
                            objconsulta = "INSERT INTO " + tipo_de_elemento + " VALUES ('" + nombre_elemento_especial + "', '" + tb_valor_agregar_elemento.Text + "', '" + tb_cantidad_elemento_agregar.Text + "', '" + tipo + "',  @imagen, '" + tb_fecha_elemento_agregar.Text + "', '" + moneda + "', '" + pais + "')";
                        }
                        using (SqlCommand comando = new SqlCommand(objconsulta, conexion))
                        {
                            comando.Parameters.Add(new SqlParameter("@imagen", SqlDbType.VarBinary)).Value = imagenConvertida;
                            int n = comando.ExecuteNonQuery();
                            if (n > 0)
                            {
                                lb_alerta_elemento_agregar.Text = "Elemento agregado";
                                tb_valor_agregar_elemento.Text = null;
                                tb_fecha_elemento_agregar.Text = null;
                                tb_cantidad_elemento_agregar.Text = null;
                                tb_elemento_otro_pais_agregar.Text = null;
                                chb_otro_pais.Checked = false;
                                cb_pais_elemento_agregar.SelectedIndex = 0;
                                cb_pais_elemento_agregar.Enabled = false;
                                cb_tipo_elemento_agregar.SelectedIndex = 0;
                                lb_pais_elemento_agregar.Enabled = false;
                                pb_imagen_elemento_agregar.Image = Resources.simbolo;
                                lb_alerta_elemento_agregar.Text = "Elemento agregado";
                                lb_alerta_elemento_agregar.Visible = true;
                                cargarcombobox("nimusmatica", cb_tipo_moneda_elemento_agregar, "tipos_monedas", "nombre");
                                cargarcombobox("nimusmatica", cb_tipo_elemento_agregar, "tipos", "tipo");
                                cargarcombobox("nimusmatica", cb_pais_elemento_agregar, "paises", "nombre");
                                tb_otra_moneda_elemento_agregar.Text = null;
                                tb_otra_moneda_elemento_agregar.Enabled = false;
                            }
                            else
                            {
                                lb_alerta_elemento_agregar.Text = "Elemento no agregado";
                                lb_alerta_elemento_agregar.Visible = true;
                            }
                            conexion.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message);
            }
        }

        private void cb_tipo_moneda_elemento_agregar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb_caracteristicas_elemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_caracteristicas_elemento.SelectedIndex == 0 || cb_caracteristicas_elemento.SelectedIndex == 1)
            {
                btt_continuar_elemento.Enabled = true;
            }
        }

        private void tb_nombre_elemento_especial_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tb_nombre_elemento_especial.Text))
            {
                btt_continuar_elemento_especial.Enabled = false;
            }
            else
            {
                btt_continuar_elemento_especial.Enabled = true;
            }
        }

        private void btt_continuar_elemento_especial_Click(object sender, EventArgs e)
        {
            nombre_elemento_especial = tb_nombre_elemento_especial.Text;
            Principal.form_principal = 10;
            gb_agregar_usuario.Visible = true;
            gb_nombre_elemento_especial.Visible = false;
        }
    }
}
