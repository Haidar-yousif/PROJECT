using PROJECT.Repositorys;
using PROJECT.Repositorys.Models;
using System.Diagnostics;

namespace PROJECT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

  
        private void Home_Load(object sender, EventArgs e)
        {
            this.Text = "Home";
            Menu.Height = this.Height;
        }
   

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new FormInvest()).ShowDialog();
            this.Show();
        }

        private void Home_ResizeEnd(object sender, EventArgs e)
        {
            Menu.Height = this.Height;
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            Menu.Height = this.Height;
        }




    }
}