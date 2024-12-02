using ConectorJamenSotf.Views;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ConectorJamenSotf
{
    public partial class InicioView : Form
    {
        public InicioView()
        {
            InitializeComponent();
        }

        private void enlacesDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnlacesViews enlaces = new EnlacesViews();

            enlaces.Show(this);


        }

        private void configuracionDelClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracionView configuracion = new ConfiguracionView();

            configuracion.Show(this);
        }

        private void conexionesALasBasesDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConexionesView con  = new ConexionesView(); 
            con.Show(this);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void InicioView_Load(object sender, EventArgs e)
        {
    
           

        }

     
 

   

        
    }
}
