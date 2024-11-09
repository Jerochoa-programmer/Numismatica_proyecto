using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nimusmatica
{
    internal class operaciones_imagenes
    {
        public static Image redimensionarimagen(Image image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(image, 0, 0, width, height);
            }
            return resizedImage;
        }
        public static byte[] convertirimagenabyte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }
        public static byte[] ObtenerImagenDesdeBD(int idImagen, SqlConnection conexion_sql)
        {
            byte[] imagenBytes = null;

            try
            {
                using (SqlConnection conexion = conexion_sql)
                {
                    string obj_comando = "SELECT imagen FROM imagenes WHERE cod = @cod"; // Ajusta el nombre de la columna y la tabla según tu esquema
                    using (SqlCommand comando = new SqlCommand(obj_comando, conexion))
                    {
                        comando.Parameters.Add(new SqlParameter("@cod", SqlDbType.Int)).Value = idImagen;
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.Read() && reader["imagen"] != DBNull.Value)
                        {
                            imagenBytes = (byte[])reader["imagen"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener la imagen desde la base de datos: " + ex.Message);
            }

            return imagenBytes;
        }
        public static Image ConvertirByteArrayAImagen(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
            {
                MessageBox.Show("Los datos de la imagen están vacíos.");
                return null;
            }

            try
            {
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    return Image.FromStream(ms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al convertir byte array a imagen: " + ex.Message);
                return null;
            }
        }
    }
}
