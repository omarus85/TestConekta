using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppTestConekta
{
    public partial class Form1 : Form
    {
        private int M = 0, N = 0;
        private char[,] image;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            textBoxOutput.Text = string.Empty;
            if (textBoxInput.Lines.Length > 0)
            {
                evaluaLineas(textBoxInput.Lines);
            }
        }
        /// <summary>
        /// Evalua linea por linea la información ingresada.
        /// </summary>
        /// <param name="lineas">Arreglo con la informacíon a evaluar</param>
        private void evaluaLineas(string[] lineas)
        {
            foreach (string line in lineas)
            {
                string linea = line.Trim();
                if (linea.Length > 0)
                {
                    try
                    {
                        switch (linea[0])
                        {
                            case 'I':
                                Iline(linea);
                                break;
                            case 'C':
                                Cline(linea);
                                break;
                            case 'L':
                                Lline(linea);
                                break;
                            case 'V':
                                Vline(linea);
                                break;
                            case 'H':
                                Hline(linea);
                                break;
                            case 'F':
                                Fline(linea);
                                break;
                            case 'S':
                                Sline(linea);
                                break;
                            case 'X':
                                Xline(linea);
                                break;
                            default:
                                throw new Exception();
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Linea no válida: " + linea);
                        break;
                    }
                }
            }
        }

        #region Lineas
        /// <summary>
        /// Valida las lineas que empiezan con la letra I
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Iline(string line)
        {
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 3)
                {
                    if (list[0].Length != 1)
                        throw new Exception();
                    if (!int.TryParse(list[1], out M))
                        throw new Exception();
                    if (!int.TryParse(list[2], out N))
                        throw new Exception();
                    createImage(M, N);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra C
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Cline(string line)
        {
            if (line.Length == 1)
            {
                clearImage();
            }
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra L
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Lline(string line)
        {
            int x = 0, y = 0;
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 4)
                {
                    if (list[0].Length != 1)
                        throw new Exception();
                    if (!int.TryParse(list[1], out x))
                        throw new Exception();
                    if (!int.TryParse(list[2], out y))
                        throw new Exception();
                    if (list[3].Length != 1)
                        throw new Exception();
                    if (x > M || y > N)
                        throw new Exception();
                    paintPixel(x, y, char.Parse(list[3]));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra S
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Sline(string line)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                builder = new StringBuilder();
                for (int j = 0; j < M; j++)
                {
                    builder.Append(image[j, i]);
                }
                textBoxOutput.AppendText(builder.ToString() + "\r\n");
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra V
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Vline(string line)
        {
            int x = 0, y1 = 0, y2 = 0;
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 5)
                {
                    if (list[0].Length != 1)
                        throw new Exception();
                    if (!int.TryParse(list[1], out x))
                        throw new Exception();
                    if (!int.TryParse(list[2], out y1))
                        throw new Exception();
                    if (!int.TryParse(list[3], out y2))
                        throw new Exception();
                    if (list[4].Length != 1)
                        throw new Exception();
                    if (x > M || y1 > N || y2 > N)
                        throw new Exception();
                    paintVLine(x, y1, y2, char.Parse(list[4]));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra H
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Hline(string line)
        {
            int y = 0, x1 = 0, x2 = 0;
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 5)
                {
                    if (list[0].Length != 1)
                        throw new Exception();
                    if (!int.TryParse(list[1], out x1))
                        throw new Exception();
                    if (!int.TryParse(list[2], out x2))
                        throw new Exception();
                    if (!int.TryParse(list[3], out y))
                        throw new Exception();
                    if (list[4].Length != 1)
                        throw new Exception();
                    if (x1 > M || x2 > M || y > N)
                        throw new Exception();
                    paintHLine(x1, x2, y, char.Parse(list[4]));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// Valida las lineas que empiezan con la letra X
        /// Como es la instrucción que termina la sesión, deshabilita el boton aceptar para no modificar el resultado.
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Xline(string line)
        {
            if (line.Length == 1)
            {
                buttonAccept.Enabled = false;
            }
            else
            {
                throw new Exception();
            }
        }
        /// <summary>
        /// valida las lineas que empiezan con la letra F
        /// </summary>
        /// <param name="line">linea a evaluar</param>
        private void Fline(string line)
        {
            int x = 0, y = 0;
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 4)
                {
                    if (list[0].Length != 1)
                        throw new Exception();
                    if (!int.TryParse(list[1], out x))
                        throw new Exception();
                    if (!int.TryParse(list[2], out y))
                        throw new Exception();
                    if (list[3].Length != 1)
                        throw new Exception();
                    if (x > M || y > N)
                        throw new Exception();
                    fillRegion(x, y, char.Parse(list[3]));
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        #endregion Lineas

        #region Aux
        /// <summary>
        /// Crea la imagen y la inicializa
        /// </summary>
        /// <param name="M">Ancho de la imagen</param>
        /// <param name="N">Altura de la imagen</param>
        private void createImage(int M, int N)
        {
            image = new char[M, N];
            clearImage();
        }
        /// <summary>
        /// Elimina todo el contenido de la imagen.
        /// </summary>
        private void clearImage()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    image[i, j] = 'O';
                }
            }
            textBoxOutput.Text = string.Empty;
        }
        /// <summary>
        /// Cambia el color del pixel indicado
        /// </summary>
        /// <param name="x">Coordenada x del pixel a cambiar</param>
        /// <param name="y">Coordenada y del pixel a cambiar</param>
        /// <param name="color"></param>
        private void paintPixel(int x, int y, char color)
        {
            x -= 1;
            y -= 1;
            image[x, y] = color;
        }
        /// <summary>
        /// Pinta una linea vertical
        /// </summary>
        /// <param name="x">Indice de la columna a pintar</param>
        /// <param name="y1">Renglon inicial de la posición a pintar</param>
        /// <param name="y2">Renglon final de la posición a pintar</param>
        /// <param name="color"></param>
        private void paintVLine(int x, int y1, int y2, char color)
        {
            int min = y1 < y2 ? y1 : y2;
            int max = y1 > y2 ? y1 : y2;
            x--;
            min--;
            max--;
            for (int y = min; y <= max; y++)
            {
                image[x, y] = color;
            }
        }
        /// <summary>
        /// Pinta una linea horizontal
        /// </summary>
        /// <param name="x1">Columna inicial de la posición a pintar</param>
        /// <param name="x2">Columna final de la posición a pintar</param>
        /// <param name="y">Indice del renglon a pintar</param>
        /// <param name="color"></param>
        private void paintHLine(int x1, int x2, int y, char color)
        {
            int min = x1 < x2 ? x1 : x2;
            int max = x1 > x2 ? x1 : x2;
            y--;
            min--;
            max--;
            for (int x = min; x <= max; x++)
            {
                image[x, y] = color;
            }
        }
        /// <summary>
        /// Pinta el pixel seleccionado del color indicado y evalua si también se deben de pintar los pixeles contiguos
        /// </summary>
        /// <param name="x">Coordenada x del pixel a cambiar</param>
        /// <param name="y">Coordenada y del pixel a cambiar</param>
        /// <param name="color">El color a cambiar</param>
        private void fillRegion(int x, int y, char color)
        {
            char originalColor = image[x - 1, y - 1];
            image[x - 1, y - 1] = color;
            if (x - 1 > 0)
            {
                if (getColor(x - 1, y) == originalColor)
                {
                    fillRegion(x - 1, y, color);
                }
            }
            if (x + 1 <= M)
            {
                if (getColor(x + 1, y) == originalColor)
                {
                    fillRegion(x + 1, y, color);
                }
            }
            if (y - 1 > 0)
            {
                if (getColor(x, y - 1) == originalColor)
                {
                    fillRegion(x, y - 1, color);
                }
            }
            if (y + 1 <= N)
            {
                if (getColor(x, y + 1) == originalColor)
                {
                    fillRegion(x, y + 1, color);
                }
            }
        }
        /// <summary>
        /// Obtiene el color de la posición seleccionada
        /// </summary>
        /// <param name="x">Coordenada x del pixel a cambiar</param>
        /// <param name="y">Coordenada y del pixel a cambiar</param>
        /// <returns>El color de la posición seleccionada</returns>
        private char getColor(int x, int y)
        {
            return image[x - 1, y - 1];
        }
        #endregion
    }
}
