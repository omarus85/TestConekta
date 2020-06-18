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
        private int[,] image;

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
                        Iline(linea);
                        break;
                    default:
                        break;
                }

            }
        }

        private void Iline(string line)
        {
            string[] list = line.Split(' ');
            try
            {
                if (list.Length == 3)
                {
                    if (list[0] != "I")
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

        private void createImage(int M, int N)
        {
            MessageBox.Show("creaimagen: " + M + " " + N);
            image = new int[M, N];
        }

    }
}
