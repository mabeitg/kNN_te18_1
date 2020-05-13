using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kNN_te18_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Gabriels
        public double[] GetImageData(string filename)
        {
            //Öppna bilden
            Bitmap image = new Bitmap(filename);

            //array för datan
            double[] data = new double[image.Width * image.Height];

            int pixelNr = 0;

            //Gå igenom varje pixel
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    //skaffar varenda rgb värde från pixeln
                    double r = image.GetPixel(x, y).R;
                    double g = image.GetPixel(x, y).G;
                    double b = image.GetPixel(x, y).B;

                    //matte saker:
                    //r + g + b / 3 = medelvärde
                    //medelvärde / 255 <= 1
                    //255 * 3 = 765

                    //får värdet
                    double pixelValue = (r + g + b) / 765;
                    //sparar värdet
                    data[pixelNr] = pixelValue;
                    pixelNr++;
                }
            }
            return data;
        }

        //Välj filer att processa
        private void button1_Click(object sender, EventArgs e)
        {
         
            if(openDialog.ShowDialog() == DialogResult.OK)
            {
                List<double[]> allImageData = new List<double[]>();

                //För alla valda filer
                foreach(string fileName in openDialog.FileNames)
                {
                    //Läs av filen
                    double[] data = GetImageData(fileName);

                    //Spara datan i listan
                    allImageData.Add(data);
                }
            }
        }
    }
}

