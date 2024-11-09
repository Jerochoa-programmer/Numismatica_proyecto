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

namespace nimusmatica
{
    public partial class buscar_elemento : Form
    {
        private static int tipo_de_pais = 0;
        private static string tipo_de_elemento = "";
        private static bool image_validation = false;
        private static int tipo_de_procedencia = 0;
        private static List<int> lista_elementos = new List<int>();
        private static int tipo_moneda = 0;
        public buscar_elemento()
        {
            InitializeComponent();
        }
        public void volver()
        {
            gb_seleccion_tipo.Visible = true;
            gb_seleccionar_elemento.Visible = false;

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

            tb_cantidad_buscar_elemento.Enabled = false;
            tb_fecha_buscar_elemento.Enabled = false;
            tb_moneda_buscar_elemento.Enabled = false;
            tb_pais_buscar_elemento.Enabled = false;
            tb_tipo_billete_buscar_elemento.Enabled = false;
            tb_valor_buscar_elemento.Enabled = false;
            tb_nombre_elemento_especial.Text = "";

            cb_tipo_de_elemento_inicio.Enabled = true;

            btt_buscar_de_nuevo.Enabled = false;

            pb_imagen_elemento_agregar.Enabled = false;
            pb_imagen_elemento_agregar.Image = Resources.simbolo;

            cb_elementos_cargados.Text = "";
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
                string objcomando1 = "SELECT * FROM " + tabla;
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
                        long valor = (long.Parse(valor_convertido)) / 10000;
                        tb_valor_buscar_elemento.Text = valor.ToString();
                        tb_cantidad_buscar_elemento.Text = tabla_consulta[2].ToString();
                        if (Int32.Parse(tabla_consulta[3].ToString())==1)
                        {
                            tb_tipo_billete_buscar_elemento.Text = "Nacional";
                        }
                        else
                        {
                            tb_tipo_billete_buscar_elemento.Text = "Internacional";
                        }
                        byte[] imagenBytes = (byte[])tabla_consulta[4];
                        pb_imagen_elemento_agregar.Image = operaciones_imagenes.redimensionarimagen(operaciones_imagenes.ConvertirByteArrayAImagen(imagenBytes), pb_imagen_elemento_agregar.Width, pb_imagen_elemento_agregar.Height);
                        tb_fecha_buscar_elemento.Text = tabla_consulta[5].ToString();
                        tipo_de_pais = Int32.Parse(tabla_consulta[7].ToString());
                        tipo_moneda = Int32.Parse(tabla_consulta[6].ToString());
                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
            }
        }
        private void cargar_elementos_1(string tabla, int atributo, TextBox CAJADETEXTO)
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
                        CAJADETEXTO.Text = tabla_consulta[1].ToString();
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
                        tb_valor_buscar_elemento.Text = valor.ToString();
                        tb_cantidad_buscar_elemento.Text = tabla_consulta[3].ToString();
                        if (Int32.Parse(tabla_consulta[4].ToString()) == 1)
                        {
                            tb_tipo_billete_buscar_elemento.Text = "Nacional";
                        }
                        else
                        {
                            tb_tipo_billete_buscar_elemento.Text = "Internacional";
                        }
                        byte[] imagenBytes = (byte[])tabla_consulta[5];
                        pb_imagen_elemento_agregar.Image = operaciones_imagenes.redimensionarimagen(operaciones_imagenes.ConvertirByteArrayAImagen(imagenBytes), pb_imagen_elemento_agregar.Width, pb_imagen_elemento_agregar.Height);
                        tb_fecha_buscar_elemento.Text = tabla_consulta[6].ToString();
                        tipo_de_pais = Int32.Parse(tabla_consulta[8].ToString());
                        tipo_moneda = Int32.Parse(tabla_consulta[7].ToString());

                    }
                    tabla_consulta.Close();
                }
                conexion_b_d.cerrar(connection);
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
                Principal.form_principal = 6;
                lb_alerta_elemento_agregar.Visible = false;
                lb_validacion_principal.Visible = false;
            }
            else
            {
                lb_validacion_principal.Visible = true;
                lb_validacion_principal.Text = "No se encontraron elementos con esas caracteristicas";
            }
            
        }

        private void btt_buscar_editar_Click(object sender, EventArgs e)
        {
            gb_editar_usuario.Visible = true;
            gb_seleccionar_elemento.Visible = false;

            lb_elemento_editar.Enabled = false;
            cb_elementos_cargados.Enabled = false;
            btt_buscar_editar.Enabled = false;

            tb_cantidad_buscar_elemento.Enabled = true;
            tb_fecha_buscar_elemento.Enabled = true;
            tb_moneda_buscar_elemento.Enabled=true;
            tb_pais_buscar_elemento.Enabled = true;
            tb_tipo_billete_buscar_elemento.Enabled = true;
            tb_valor_buscar_elemento.Enabled = true;

            lb_valor_agregar.Enabled = true;
            lb_tipo_moneda_elemento_agregar.Enabled = true;
            lb_cantidad_agregar.Enabled = true;
            lb_fechas_elemento_agregar.Enabled = true;
            lb_tipo_elemento_agregar.Enabled = true;
            lb_alerta_elemento_agregar.Visible = false;
            lb_pais_elemento_agregar.Enabled = true;

            btt_buscar_de_nuevo.Enabled = true;

            pb_imagen_elemento_agregar.Enabled = true;

            if (tipo_de_procedencia == 1 || tipo_de_procedencia == 2)
            {
                lb_nombre_elemento_especial.Visible = false;
                tb_nombre_elemento_especial.Visible = false;
                cargar_elementos(tipo_de_elemento, lista_elementos[cb_elementos_cargados.SelectedIndex]);
                cargar_elementos_1("paises", tipo_de_pais, tb_pais_buscar_elemento);
                cargar_elementos_1("tipos_monedas", tipo_moneda, tb_moneda_buscar_elemento);
            }
            else if (tipo_de_procedencia==3)
            {
                lb_nombre_elemento_especial.Enabled = true;
                tb_nombre_elemento_especial.Enabled = true;
                cargar_elementos_especial(tipo_de_elemento, lista_elementos[cb_elementos_cargados.SelectedIndex]);
                cargar_elementos_1("paises", tipo_de_pais, tb_pais_buscar_elemento);
                cargar_elementos_1("tipos_monedas", tipo_moneda, tb_moneda_buscar_elemento);
            }
            Principal.form_principal = 12;
        }

        private void btt_buscar_de_nuevo_Click(object sender, EventArgs e)
        {
            volver_elemento_especial();
        }

        private void cb_elementos_cargados_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
