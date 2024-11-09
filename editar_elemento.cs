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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace nimusmatica
{
    public partial class editar_elemento : Form
    {
        private static string tipo_de_elemento = "";
        Image imagen_elementos = null;
        private static bool image_validation = false;
        private static int tipo_de_procedencia = 0;
        private static List<int> lista_elementos = new List<int>();
        public editar_elemento()
        {
            InitializeComponent();
        }
        private void cargarcombobox(String base_datos, System.Windows.Forms.ComboBox combob, string tabla, string columna)
        {
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT " + columna + " FROM " + tabla;
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
        private bool cargarcomboboxWHERE(String base_datos, System.Windows.Forms.ComboBox combob, string tabla, int columna)
        {
            bool validacion = false;
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT * FROM " + tabla + " where tipo = " + columna;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);
                combob.Items.Clear();
                lista_elementos.Clear();
                if (tabla_consulta.Read())
                {
                    elementos e = new elementos(Int32.Parse(tabla_consulta[0].ToString()), tabla_consulta[1].ToString(), tabla_consulta[5].ToString(), tabla_consulta[7].ToString());
                    lista_elementos.Add(e.Cod);
                    string objeto = e.tostring();
                    combob.Items.Add(objeto);

                    while (tabla_consulta.Read())
                    {
                         e = new elementos(Int32.Parse(tabla_consulta[0].ToString()), tabla_consulta[1].ToString(), tabla_consulta[5].ToString(), tabla_consulta[7].ToString());
                        lista_elementos.Add(e.Cod);
                         objeto = e.tostring();
                        combob.Items.Add(objeto);
                    }
                    tabla_consulta.Close();
                    validacion = true;
                }
                else
                {
                    validacion = false;
                }
                conexion_b_d.cerrar(connection);
            }
            else
            {
                validacion = false;
            }
            return validacion;
            combob.SelectedIndex = 0;
        }
        private bool cargarcomboboxESPECIAL(String base_datos, System.Windows.Forms.ComboBox combob, string tabla)
        {
            bool validacion = false;
            SqlConnection connection = conexion_b_d.conectar(base_datos);
            if (connection != null)
            {
                string objcomando1 = "SELECT * FROM " + tabla ;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);
                combob.Items.Clear();
                lista_elementos.Clear();
                if (tabla_consulta.Read())
                {
                    lista_elementos.Add(Int32.Parse(tabla_consulta[0].ToString()));
                    combob.Items.Add(tabla_consulta[1].ToString());

                    while (tabla_consulta.Read())
                    {
                        lista_elementos.Add(Int32.Parse(tabla_consulta[0].ToString()));
                        combob.Items.Add(tabla_consulta[1].ToString());
                    }
                    tabla_consulta.Close();
                    validacion = true;
                }
                else
                {
                    validacion = false;
                }
                conexion_b_d.cerrar(connection);
            }
            else
            {
                validacion = false;
            }
            return validacion;
            combob.SelectedIndex = 0;
        }
        private void cargar_elementos(string tabla, int atributo)
        {
            SqlConnection connection = conexion_b_d.conectar("nimusmatica");
            if (connection != null)
            {
                string objcomando1 = "SELECT * FROM " + tabla + " where cod = " + atributo;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    while (tabla_consulta.Read())
                    {
                        string valor_convertido = tabla_consulta[1].ToString().Replace(",", "");
                        long valor = (long.Parse(valor_convertido))/10000;
                        tb_valor_agregar_elemento.Text = valor.ToString();
                        tb_cantidad_elemento_agregar.Text = tabla_consulta[2].ToString();
                        cb_tipo_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[3].ToString())-1;
                        byte[] imagenBytes = (byte[])tabla_consulta[4];
                        pb_imagen_elemento_agregar.Image = operaciones_imagenes.redimensionarimagen(operaciones_imagenes.ConvertirByteArrayAImagen(imagenBytes), pb_imagen_elemento_agregar.Width, pb_imagen_elemento_agregar.Height);
                        tb_fecha_elemento_agregar.Text = tabla_consulta[5].ToString();
                        cb_tipo_moneda_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[6].ToString())-1;
                        cb_pais_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[7].ToString())-1;

                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
        }

        private void cargar_elementos_especial(string tabla, int atributo)
        {
            SqlConnection connection = conexion_b_d.conectar("nimusmatica");
            if (connection != null)
            {
                string objcomando1 = "SELECT * FROM " + tabla + " where cod = " + atributo;
                SqlDataReader tabla_consulta = conexion_b_d.consulta(objcomando1, connection);

                if (tabla_consulta != null)
                {
                    while (tabla_consulta.Read())
                    {
                        tb_nombre_elemento_especial.Text = tabla_consulta[1].ToString();
                        string valor_convertido = tabla_consulta[2].ToString().Replace(",", "");
                        long valor = (long.Parse(valor_convertido)) / 10000;
                        tb_valor_agregar_elemento.Text = valor.ToString();
                        tb_cantidad_elemento_agregar.Text = tabla_consulta[3].ToString();
                        cb_tipo_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[4].ToString()) - 1;
                        byte[] imagenBytes = (byte[])tabla_consulta[5];
                        pb_imagen_elemento_agregar.Image = operaciones_imagenes.redimensionarimagen(operaciones_imagenes.ConvertirByteArrayAImagen(imagenBytes), pb_imagen_elemento_agregar.Width, pb_imagen_elemento_agregar.Height);
                        tb_fecha_elemento_agregar.Text = tabla_consulta[6].ToString();
                        cb_tipo_moneda_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[7].ToString()) - 1;
                        cb_pais_elemento_agregar.SelectedIndex = Int32.Parse(tabla_consulta[8].ToString()) - 1;

                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
        }
        private void activacion_btt_agregar()
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 && tb_fecha_elemento_agregar.Text.Length > 0 && tb_cantidad_elemento_agregar.Text.Length > 0 && (cb_tipo_elemento_agregar.SelectedIndex == 0 || cb_tipo_elemento_agregar.SelectedIndex == 1))
            {
                if (cb_tipo_elemento_agregar.SelectedIndex == 0)
                {
                    if (image_validation == true)
                    {
                        btt_editar_elemento.Enabled = true;
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
                                btt_editar_elemento.Enabled = true;
                            }
                        }
                    }
                    else if (cb_pais_elemento_agregar.SelectedIndex >= 0)
                    {
                        if (image_validation == true)
                        {
                            btt_editar_elemento.Enabled = true;
                        }
                    }
                }
            }
            else
            {
                btt_editar_elemento.Enabled = false;
            }
        }

        public void volver()
        {
            gb_seleccion_tipo.Visible = true;
            gb_seleccionar_elemento.Visible = false;

            cb_tipo_elemento.SelectedIndex = 0;
            cb_tipo_de_elemento_inicio.SelectedIndex = 0;
            cb_elementos_cargados.Items.Clear();

            btt_continuar_elemento.Enabled = false;

        }

        public void volver_elemento_especial()
        {
            gb_seleccionar_elemento.Visible = true;
            gb_editar_usuario.Visible = false;

            lb_elemento_editar.Enabled = true;
            cb_elementos_cargados.Enabled = true;
            btt_buscar_editar.Enabled = true;

            lb_valor_agregar.Enabled = false;
            lb_tipo_moneda_elemento_agregar.Enabled = false;
            lb_cantidad_agregar.Enabled = false;
            lb_fechas_elemento_agregar.Enabled = false;
            lb_tipo_elemento_agregar.Enabled = false;
            lb_alerta_elemento_agregar.Enabled = false;

            tb_valor_agregar_elemento.Enabled = false;
            tb_valor_agregar_elemento.Clear();
            tb_cantidad_elemento_agregar.Enabled = false;
            tb_cantidad_elemento_agregar.Clear();
            tb_fecha_elemento_agregar.Enabled = false;
            tb_fecha_elemento_agregar.Clear();

            cb_elementos_cargados.SelectedIndex = 0;
            cb_tipo_moneda_elemento_agregar.Enabled = false;
            cb_tipo_moneda_elemento_agregar.SelectedIndex = 0;
            cb_tipo_elemento_agregar.Enabled = false;
            cb_tipo_elemento_agregar.SelectedIndex = 0;
            cb_tipo_de_elemento_inicio.Enabled = true;

            btt_imagen_elemento_agregar.Enabled = false;
            btt_editar_elemento.Enabled = false;
            btt_limpiar_elemento_agregar.Enabled = false;
            btt_regresar_editar.Enabled = false;

            chb_otra_moneda_elemento_agregar.Enabled = false;
            chb_otra_moneda_elemento_agregar.Checked = false;

            pb_imagen_elemento_agregar.Enabled = false;
            pb_imagen_elemento_agregar.Image = Resources.simbolo;

            cb_elementos_cargados.Text = "";
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
        private void btt_continuar_elemento_Click(object sender, EventArgs e)
        {
            bool validacion = false;

            image_validation = false;
            switch (cb_tipo_elemento.SelectedIndex)
            {
                case 0:
                    tipo_de_elemento = "monedas";
                    switch (cb_tipo_de_elemento_inicio.SelectedIndex)
                    {
                        case 0:
                            tipo_de_procedencia = 1;
                            validacion = cargarcomboboxWHERE("nimusmatica", cb_elementos_cargados, tipo_de_elemento, tipo_de_procedencia);
                            tb_nombre_elemento_especial.Visible = false;
                            lb_nombre_elemento_especial.Visible = false;
                            break;
                        case 1:
                            tipo_de_procedencia = 2;
                            validacion = cargarcomboboxWHERE("nimusmatica", cb_elementos_cargados, tipo_de_elemento, tipo_de_procedencia);
                            tb_nombre_elemento_especial.Visible = false;
                            lb_nombre_elemento_especial.Visible = false;
                            break;
                        case 2:
                            tipo_de_procedencia = 3;
                            tipo_de_elemento = "monedas_especiales";
                            validacion = cargarcomboboxESPECIAL("nimusmatica", cb_elementos_cargados, tipo_de_elemento);
                            tb_nombre_elemento_especial.Visible = true;
                            lb_nombre_elemento_especial.Visible = true;
                            break;
                    }
                    break;
                case 1:
                    tipo_de_elemento = "billetes";
                    switch (cb_tipo_de_elemento_inicio.SelectedIndex)
                    {
                        case 0:
                            tipo_de_procedencia = 1;
                            validacion = cargarcomboboxWHERE("nimusmatica", cb_elementos_cargados, tipo_de_elemento, tipo_de_procedencia);
                            tb_nombre_elemento_especial.Visible = false;
                            lb_nombre_elemento_especial.Visible = false;
                            break;
                        case 1:
                            tipo_de_procedencia = 2;
                            validacion = cargarcomboboxWHERE("nimusmatica", cb_elementos_cargados, tipo_de_elemento, tipo_de_procedencia);
                            tb_nombre_elemento_especial.Visible = false;
                            lb_nombre_elemento_especial.Visible = false;
                            break;
                        case 2:
                            tipo_de_procedencia = 3;
                            tipo_de_elemento = "billetes_especiales";
                            validacion = cargarcomboboxESPECIAL("nimusmatica", cb_elementos_cargados, tipo_de_elemento);
                            tb_nombre_elemento_especial.Visible = true;
                            lb_nombre_elemento_especial.Visible = true;
                            tb_nombre_elemento_especial.Enabled = true;
                            lb_nombre_elemento_especial.Enabled = true;
                            break;
                    }
                    break;
            }
            
            if (validacion)
            {
                gb_seleccion_tipo.Visible = false;
                gb_seleccionar_elemento.Visible = true;
                cb_tipo_de_elemento_inicio.Enabled = false;
                Principal.form_principal = 5;
                cargarcombobox("nimusmatica", cb_tipo_moneda_elemento_agregar, "tipos_monedas", "nombre");
                cargarcombobox("nimusmatica", cb_tipo_elemento_agregar, "tipos", "tipo");
                cargarcombobox("nimusmatica", cb_pais_elemento_agregar, "paises", "nombre");
                lb_alerta_elemento_agregar.Visible = false;
                lb_validacion_principal.Visible = false;
            }
            else
            {
                lb_validacion_principal.Visible = true;
                lb_validacion_principal.Text = "No se encontraron elementos con esas caracteristicas";
            }

        }

        private void gb_seleccion_tipo_Enter(object sender, EventArgs e)
        {

        }

        private void cb_tipo_elemento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo_elemento.SelectedIndex == 0 || cb_tipo_elemento.SelectedIndex == 1)
            {
                cb_tipo_de_elemento_inicio.Enabled = true;
            }
            else
            {
                cb_tipo_de_elemento_inicio.Enabled = false;
            }
        }

        private void cb_tipo_de_elemento_inicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_tipo_de_elemento_inicio.SelectedIndex == 0 || cb_tipo_de_elemento_inicio.SelectedIndex == 1 || cb_tipo_de_elemento_inicio.SelectedIndex == 2)
            {
                btt_continuar_elemento.Enabled = true;
            }
            else
            {
                btt_continuar_elemento.Enabled = false;
            }
        }

        private void btt_buscar_editar_Click(object sender, EventArgs e)
        {
            gb_seleccionar_elemento.Visible = false;
            gb_editar_usuario.Visible = true;

            lb_elemento_editar.Enabled = false;
            cb_elementos_cargados.Enabled = false;
            btt_buscar_editar.Enabled = false;

            lb_valor_agregar.Enabled = true;
            lb_tipo_moneda_elemento_agregar.Enabled = true;
            lb_cantidad_agregar.Enabled =true;
            lb_fechas_elemento_agregar.Enabled =true;
            lb_tipo_elemento_agregar.Enabled=true;
            lb_alerta_elemento_agregar.Visible = false;
            lb_nombre_elemento_especial.Enabled = true;

            tb_nombre_elemento_especial.Enabled = true;
            tb_valor_agregar_elemento.Enabled = true;
            tb_cantidad_elemento_agregar.Enabled = true;
            tb_fecha_elemento_agregar.Enabled = true;

            cb_tipo_moneda_elemento_agregar.Enabled = true;
            cb_tipo_elemento_agregar.Enabled = true;

            btt_imagen_elemento_agregar.Enabled = true;
            btt_limpiar_elemento_agregar.Enabled = true;
            btt_regresar_editar.Enabled = true;
            btt_editar_elemento.Enabled = true;

            chb_otra_moneda_elemento_agregar.Enabled = true;

            pb_imagen_elemento_agregar.Enabled = true;

            if (tipo_de_procedencia==1 || tipo_de_procedencia == 2)
            {
                cargar_elementos(tipo_de_elemento, lista_elementos[cb_elementos_cargados.SelectedIndex]);
            }
            else if(tipo_de_procedencia==3)
            {
                cargar_elementos_especial(tipo_de_elemento, lista_elementos[cb_elementos_cargados.SelectedIndex]);
            }
            Principal.form_principal = 11;

        }

        private void btt_regresar_editar_Click(object sender, EventArgs e)
        {
            volver_elemento_especial();
        }

        private void tb_valor_agregar_elemento_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_valor_agregar_elemento.Text, out _))
            {
                tb_valor_agregar_elemento.Text = "";
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

        private void tb_cantidad_elemento_agregar_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(tb_cantidad_elemento_agregar.Text, out _))
            {
                tb_cantidad_elemento_agregar.Text = "";
            }
        }

        private void tb_fecha_elemento_agregar_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in tb_fecha_elemento_agregar.Text)
            {
                if (!char.IsDigit(c) && !" /-".Contains(c))
                {
                    tb_fecha_elemento_agregar.Text = "";
                    break;
                }
            }
        }

        private void cb_tipo_elemento_agregar_SelectedIndexChanged(object sender, EventArgs e)
        {
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
        }

        private void chb_otro_pais_CheckedChanged(object sender, EventArgs e)
        {
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

        private void tb_elemento_otro_pais_agregar_TextChanged(object sender, EventArgs e)
        {
            if (tb_valor_agregar_elemento.Text.Length > 0 || tb_fecha_elemento_agregar.Text.Length > 0 || tb_cantidad_elemento_agregar.Text.Length > 0 || tb_elemento_otro_pais_agregar.Text.Length > 0)
            {
                btt_limpiar_elemento_agregar.Enabled = true;
            }
            else
            {
                btt_limpiar_elemento_agregar.Enabled = false;
            }
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
            }
            catch (Exception e1)
            {
                MessageBox.Show("Error al seleccionar la imagen: " + e1.Message);
            }
        }

        private void cb_tipo_moneda_elemento_agregar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tb_otra_moneda_elemento_agregar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btt_limpiar_elemento_agregar_Click(object sender, EventArgs e)
        {
            tb_nombre_elemento_especial.Text = null; 
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
            cb_tipo_moneda_elemento_agregar.SelectedIndex = 0;
        }

        private void btt_editar_elemento_Click(object sender, EventArgs e)
        {
            byte[] imagenConvertida = operaciones_imagenes.convertirimagenabyte(pb_imagen_elemento_agregar.Image);

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
                            if (tipo_de_procedencia == 1 || tipo_de_procedencia ==2)
                            {
                            objconsulta = $"update {tipo_de_elemento} set valor = @valor, cantidad = @cantidad, tipo = @tipo, imagen = @imagen, fecha = @fecha, tipo_moneda = @tipo_moneda, pais = @pais where cod = @cod;";
                            //objconsulta = "update " + tipo_de_elemento + " set valor = " + tb_valor_agregar_elemento.Text + ", cantidad = " + tb_cantidad_elemento_agregar.Text + ", tipo = " + tipo + ", imagen = @imagen , fecha = " + tb_fecha_elemento_agregar.Text + ", tipo_moneda = " + moneda + ", pais = " + pais + " where cod = " + lista_elementos[cb_elementos_cargados.SelectedIndex] + ";";
                        }
                            else if (tipo_de_procedencia==3)
                            {
                            objconsulta = $"update {tipo_de_elemento} set nombre = @nombre, valor = @valor, cantidad = @cantidad, tipo = @tipo, imagen = @imagen, fecha = @fecha, tipo_moneda = @tipo_moneda, pais = @pais where cod = @cod;";
                            //objconsulta = "update " + tipo_de_elemento + " set nombre = " + tb_nombre_elemento_especial.Text + ", valor = " + tb_valor_agregar_elemento.Text + ", cantidad = " + tb_cantidad_elemento_agregar.Text + ", tipo = " + tipo + ", imagen = @imagen , fecha = " + tb_fecha_elemento_agregar.Text + ", tipo_moneda = " + moneda + ", pais = " + pais + " where cod = " + lista_elementos[cb_elementos_cargados.SelectedIndex] + ";";
                        }
                            using (SqlCommand comando = new SqlCommand(objconsulta, conexion))
                            {
                                comando.Parameters.Add(new SqlParameter("@imagen", SqlDbType.VarBinary)).Value = imagenConvertida;
                                comando.Parameters.AddWithValue("@nombre", tb_nombre_elemento_especial.Text);
                                comando.Parameters.AddWithValue("@valor", tb_valor_agregar_elemento.Text);
                                comando.Parameters.AddWithValue("@cantidad", tb_cantidad_elemento_agregar.Text);
                                comando.Parameters.AddWithValue("@tipo", tipo);
                                comando.Parameters.AddWithValue("@fecha", tb_fecha_elemento_agregar.Text);
                                comando.Parameters.AddWithValue("@tipo_moneda", moneda);
                                comando.Parameters.AddWithValue("@pais", pais);
                                comando.Parameters.AddWithValue("@cod", lista_elementos[cb_elementos_cargados.SelectedIndex]);
                                int n = comando.ExecuteNonQuery();
                                if (n > 0)
                                {
                                    lb_alerta_elemento_agregar.Text = "Elemento agregado";
                                    lb_alerta_elemento_agregar.Visible = true;

                                    lb_elemento_editar.Enabled = true;
                                    cb_elementos_cargados.Enabled = true;
                                    btt_buscar_editar.Enabled = true;

                                    lb_valor_agregar.Enabled = false;
                                    lb_tipo_moneda_elemento_agregar.Enabled = false;
                                    lb_cantidad_agregar.Enabled = false;
                                    lb_fechas_elemento_agregar.Enabled = false;
                                    lb_tipo_elemento_agregar.Enabled = false;
                                    lb_nombre_elemento_especial.Enabled = false;

                                    tb_nombre_elemento_especial.Text = "";
                                    tb_nombre_elemento_especial.Enabled = false;
                                    tb_valor_agregar_elemento.Enabled = false;
                                    tb_valor_agregar_elemento.Clear();
                                    tb_cantidad_elemento_agregar.Enabled = false;
                                    tb_cantidad_elemento_agregar.Clear();
                                    tb_fecha_elemento_agregar.Enabled = false;
                                    tb_fecha_elemento_agregar.Clear();

                                    cb_tipo_moneda_elemento_agregar.Enabled = false;
                                    cb_tipo_moneda_elemento_agregar.SelectedIndex = 0;
                                    cb_tipo_elemento_agregar.Enabled = false;
                                    cb_tipo_elemento_agregar.SelectedIndex = 0;

                                    btt_imagen_elemento_agregar.Enabled = false;
                                    btt_editar_elemento.Enabled = false;
                                    btt_limpiar_elemento_agregar.Enabled = false;
                                    btt_regresar_editar.Enabled = false;

                                    chb_otra_moneda_elemento_agregar.Enabled = false;
                                    chb_otra_moneda_elemento_agregar.Checked = false;

                                    pb_imagen_elemento_agregar.Enabled = false;
                                    pb_imagen_elemento_agregar.Image = Resources.simbolo;

                                if (tipo_de_procedencia ==1 || tipo_de_procedencia == 2)
                                {
                                    cargarcomboboxWHERE("nimusmatica", cb_elementos_cargados, tipo_de_elemento, tipo_de_procedencia);
                                }
                                else if(tipo_de_procedencia ==3)
                                {
                                    cargarcomboboxESPECIAL("nimusmatica", cb_elementos_cargados, tipo_de_elemento);
                                }
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
            catch (SqlException e1)
            {
                MessageBox.Show("Error al editar elemento " + e1.ToString());
            }
        }

        private void cb_elementos_cargados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_elementos_cargados.SelectedIndex >=0)
            {
                btt_buscar_editar.Enabled = true;
            }
            else
            {
                btt_buscar_editar.Enabled = false;
            }
        }
    }
}
