using System.Drawing.Imaging;
using System.Runtime.Intrinsics.X86;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int length;
        int h, w;
        public Form1()
        {
            InitializeComponent();
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Browse Button 
        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFile.FileName);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        //For Greyscale
        public bool ProcessImage(Bitmap bmp)
        {
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color bmpColor = bmp.GetPixel(i, j);
                    int red = bmpColor.R;
                    int green = bmpColor.G;
                    int blue = bmpColor.B;
                    int gray = (byte)(.299 * red + .587 * green + .114 * blue);
                    red = gray;
                    green = gray;
                    blue = gray;

                    bmp.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return true;
        }

  
        //For Color Inversion
        public bool ProcessImage1(Bitmap bmp1)
        {
            for (int i = 0; i < bmp1.Width; i++)
            {
                for (int j = 0; j < bmp1.Height; j++)
                {
                    Color pixel = bmp1.GetPixel(i, j);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    bmp1.SetPixel(i, j, Color.FromArgb(255 - red, 255 - green, 255 - blue));
                }
            }

            pictureBox2.Image = bmp1;

            return true;
        }


        //SaveButton
        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog svf = new SaveFileDialog();


            if (svf.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image.Save(svf.FileName + "." + ImageFormat.Jpeg);
            }

        }

     
        //For Sepia
        public bool ProcessImage2(Bitmap bmp2)
        {
            for (int i = 0; i < bmp2.Width; i++)
            {
                for (int j = 0; j < bmp2.Height; j++)
                {
                    Color pixel = bmp2.GetPixel(i, j);

                    int red = pixel.R;
                    int green = pixel.G;
                    int blue = pixel.B;

                    int SepiaRed = Convert.ToInt32(0.393 * red + 0.769 * green + 0.189 * blue);
                    int SepiaGreen = Convert.ToInt32(0.349 * red + 0.686 * green + 0.168 * blue);
                    int SepiaBlue = Convert.ToInt32(0.272 * red + 0.543 * green + 0.131 * blue);

                    if (SepiaRed > 255)
                    {
                        SepiaRed = 255;
                    }
                    if (SepiaGreen > 255)
                    {
                        SepiaGreen = 255;
                    }
                    if (SepiaBlue > 255)
                    {
                        SepiaBlue = 255;
                    }

                    pixel = Color.FromArgb(pixel.A, SepiaRed, SepiaGreen, SepiaBlue);
                    bmp2.SetPixel(i, j, pixel);
                }
            }

            pictureBox2.Image = bmp2;

            return true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = pictureBox1.Image;
            Clipboard.SetImage(pictureBox2.Image);
        }

        private void grayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            ProcessImage(copyBitmap);
            pictureBox2.Image = copyBitmap;
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            ProcessImage1(copyBitmap);
            pictureBox2.Image = copyBitmap;
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap copyBitmap = new Bitmap((Bitmap)pictureBox1.Image);
            ProcessImage2(copyBitmap);
            pictureBox2.Image = copyBitmap;
        }
    }
}