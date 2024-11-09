using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace nimusmatica
{
    internal class conexion_b_d
    {

        public static SqlConnection conectar(string nomBD)
        {
            SqlConnection conectar = new SqlConnection("Data Source=LAPTOP-R3DFH8EP\\SQLEXPRESS;Initial" + " Catalog = " + nomBD + "; Integrated Security = SSPI; ");
            try
            {
                conectar.Open();
                //MessageBox.Show("Se realizo la conexion...");
                return conectar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la conexión " + ex.ToString());
                return null;
            }
        }

        public static SqlDataReader consulta(string conSQL, SqlConnection conector)
        {
            try
            {
                SqlCommand comando = new SqlCommand(conSQL, conector);
                SqlDataReader tabla = comando.ExecuteReader();
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fallo la consulta " + ex.ToString());
                return null;
            }
        }

        public static int actualizar(string conSQL, SqlConnection conector)
        {
            int num = 0;
            try
            {
                SqlCommand comando = new SqlCommand(conSQL, conector);
                num = comando.ExecuteNonQuery();
                return num;
            }
            catch (SqlException e)
            {
                MessageBox.Show("Fallo la consulta" + e.ToString());
                return num;
            }
        }

        public static void cerrar(SqlConnection conector)
        {
            try
            {
                conector.Close();
            }
            catch (SqlException e) {
            
            }
        }
        public void ActualizarImagen(string tabla, string atributo, byte[] imagen, string cod, SqlConnection conexion)
        {
            
            string query = "update "+tabla+" set "+atributo+" = @Imagen where cod = "+cod+"";

            
            using (conexion)
            {
                conexion.Open();
                using (SqlCommand command = new SqlCommand(query, conexion))
                {
                    command.Parameters.Add("@Imagen", System.Data.SqlDbType.Image).Value = imagen;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

