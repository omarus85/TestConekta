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
            foreach (string linea in textBoxInput.Lines)
            {
                switch (linea[0])
                {
                    case 'I':
                        Iline(linea.Trim());
                        break;
                    case 'C':
                        Cline(linea.Trim());
                        break;
                    case 'L':
                        Lline(linea.Trim());
                        break;
                    case 'V':
                        Vline(linea.Trim());
                        break;
                    case 'H':
                        Hline(linea.Trim());
                        break;
                    case 'F':
                        break;
                    case 'S':
                        Sline(linea.Trim());
                        break;
                    case 'X':
                        Xline(linea.Trim());
                        break;
                    default:
                        MessageBox.Show("Linea no válida: " + linea);
                        break;
                }

            }
        }

        #region Lineas
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
                MessageBox.Show("Linea no válida: " + line);
            }
        }

        private void Cline(string line)
        {
            if (line.Length == 1)
            {
                clearImage();
            }
            else
            {
                MessageBox.Show("Linea no válida: " + line);
            }
        }

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
                MessageBox.Show("Linea no válida: " + line);
            }
        }

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
                MessageBox.Show("Linea no válida: " + line);
            }
        }
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
                MessageBox.Show("Linea no válida: " + line);
            }
        }
        private void Xline(string line)
        {
            if (line.Length == 1)
            {
                buttonAccept.Enabled = false;
            }
            else
            {
                MessageBox.Show("Linea no válida: " + line);
            }
        }
        #endregion Lineas

        #region Aux
        private void createImage(int M, int N)
        {
            image = new char[M, N];
            clearImage();
        }
        private void clearImage()
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    image[i, j] = 'O';
                }
            }
        }
        private void paintPixel(int x, int y, char color)
        {
            x -= 1;
            y -= 1;
            image[x, y] = color;
        }

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
        #endregion
    }
}
