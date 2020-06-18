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
                        break;
                    case 'H':
                        break;
                    case 'F':
                        break;
                    case 'S':
                        break;
                    case 'X':
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
                    paintPixel(x,y,char.Parse(list[3]));
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
        #endregion
    }
}
