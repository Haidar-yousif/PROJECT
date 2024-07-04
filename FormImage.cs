using PROJECT.Repositorys;
using PROJECT.Repositorys.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PROJECT
{
    public partial class FormImage : Form
    {
        int SerialNo;
        int serperFromPerson;
        byte[] front_image;
        byte[] left_image;
        byte[] right_image;
        int isvalid;
        public FormImage()
        {
            isvalid = 0;
            InitializeComponent();
        }
        public FormImage(int serp, int ser)
        {
            isvalid = 0;
            SerialNo = ser;
            serperFromPerson = serp;
            InitializeComponent();
        }
        private void FormImage_Load(object sender, EventArgs e)
        {
            Refresh();
            isvalid = 0;
            serial_field.Text = SerialNo.ToString();
            serper_field.Text = serperFromPerson.ToString();
            left_image = new byte[] { };
            right_image = new byte[] { };
            front_image = new byte[] { };
            FillPictureBox();
        }
        private void FormImage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
        private void HandlePictureBox(PictureBox Box, ref byte[] bytelist)
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Title = "image";
                    openFileDialog.Filter = "Image files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        if (filePath != "")
                        {
                            isvalid += 1;
                            Bitmap image = new Bitmap(filePath);
                            Box.Image = image;
                            bytelist = File.ReadAllBytes(filePath);
                        }

                    }
                    else
                    {

                        MessageBox.Show("Please select an image.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("error in loading the image");
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isExist())
            {
                HandlePictureBox(pictureBox1, ref left_image);
            }
            else
            {
                MessageBox.Show("there is record already");
                pictureBox1_DoubleClick(sender, e);
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (!isExist())
            {
                HandlePictureBox(pictureBox2, ref front_image);
            }
            else
            {
                MessageBox.Show("there is record already");
            }
            pictureBox2_DoubleClick(sender, e);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!isExist())
            {
                HandlePictureBox(pictureBox3, ref right_image);
            }
            else
            {
                MessageBox.Show("there is record already");
                pictureBox3_DoubleClick(sender, e);
            }
        }
        private bool verify()
        {
            if (isvalid == 3) return true;

            return false;
        }
        private bool isExist()
        {
            using (var context = new InvEntitie())
            {
                var imagefaces = context.ImageFaces;

                bool isexist = context.ImageFaces.Any(v => (v.Serial == SerialNo) && (serperFromPerson == v.Serpers));

                if (isexist)
                {
                    FillPictureBox();
                }
                return isexist;
            }
            return false;

        }
        private void FillPictureBox()
        {
            using (var context = new InvEntitie())
            {

                var target = context.ImageFaces.FirstOrDefault(v => (v.Serial == SerialNo) && (v.Serpers == serperFromPerson));
                if (target == null) return;
                pictureBox1.Image = ByteArrayToImage(target.Faceleft);
                pictureBox2.Image = ByteArrayToImage(target.Facefront);
                pictureBox3.Image = ByteArrayToImage(target.Faceright);
            };


        }
        public static Image ByteArrayToImage(byte[] byteArray)
        {
            using (var ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }
        private async void insertbtn_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {

                try
                {
                    if (!isExist())
                    {

                        if (MessageBox.Show("Are you need to insert this images ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (verify())
                            {
                                var image = new ImageFace
                                {
                                    Serial = SerialNo,
                                    Serpers = serperFromPerson,
                                    Facefront = front_image,
                                    Faceleft = left_image,
                                    Faceright = right_image
                                };

                                using (var context = new InvEntitie())
                                {
                                    var images = context.ImageFaces;
                                    images.Add(image);
                                    context.SaveChanges();

                                }
                                MessageBox.Show("opartion done successfuly");
                            }
                            else
                            {
                                MessageBox.Show("all images should be specified");
                            }
                        }
                        else
                        {
                            MessageBox.Show("operation was canceled");
                        }
                    }
                    else
                    {
                        MessageBox.Show("already there is record \n double click to change");
                    }

                }
                catch { MessageBox.Show("already there is record \n double click to change"); }

            });
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new InvEntitie())
            {
                var imagefaces = context.ImageFaces;
                bool isexist = context.ImageFaces.Any(v => (v.Serial == SerialNo) && (serperFromPerson == v.Serpers));
                if (isexist)
                {
                    HandlePictureBox(pictureBox1, ref left_image);
                }
                return;
            };
        }

        private void pictureBox2_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new InvEntitie())
            {
                var imagefaces = context.ImageFaces;
                bool isexist = context.ImageFaces.Any(v => (v.Serial == SerialNo) && (serperFromPerson == v.Serpers));
                if (isexist)
                {
                    HandlePictureBox(pictureBox2, ref front_image);

                }
                return;
            };
        }

        private void pictureBox3_DoubleClick(object sender, EventArgs e)
        {
            using (var context = new InvEntitie())
            {
                var imagefaces = context.ImageFaces;
                bool isexist = context.ImageFaces.Any(v => (v.Serial == SerialNo) && (serperFromPerson == v.Serpers));
                if (isexist)
                {
                    HandlePictureBox(pictureBox3, ref right_image);

                }
                return;
            };
        }

        private async void updatebtn_Click(object sender, EventArgs e)
        {

            await Task.Run(() =>
            {

                try
                {



                    using (var context = new InvEntitie())
                    {
                        var imagefaces = context.ImageFaces;

                        bool isexist = context.ImageFaces.Any(v => (v.Serial == SerialNo) && (serperFromPerson == v.Serpers));

                        if (isexist)
                        {

                            if (MessageBox.Show("Are you need to update this images ? ", "open paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                var target = context.ImageFaces.FirstOrDefault(v => (v.Serial == SerialNo && v.Serpers == serperFromPerson));
                                context.Update(target);
                                if (left_image.Length != 0) target.Faceleft = left_image;
                                if (right_image.Length != 0) target.Faceright = right_image;
                                if (front_image.Length != 0) target.Facefront = front_image;

                                context.SaveChanges();

                                MessageBox.Show("opartion done successfuly");
                                FormImage_Load(sender, e);
                            }
                            else
                            {
                                MessageBox.Show("operation was canceled");
                            }
                        }
                    }

                }
                catch { MessageBox.Show("already there is record \n double click to change"); }

            });
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            FormImage_Load(sender, e);
        }
    }
}
