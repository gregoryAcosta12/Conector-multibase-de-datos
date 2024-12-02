using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConectorJamenSotf
{
    public partial class ConectorView : Form
    {
        public ConectorView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario ConectorViews
            InicioView conectorForm = new InicioView();

            // Mostrar el formulario ConectorViews
            conectorForm.Show(); // Abre el formulario sin bloquear el actual
                                 // conectorForm.ShowDialog(); // Usa esto si prefieres que sea modal
        }

        private void ConectorView_Load(object sender, EventArgs e)
        {
           

            

        }


        private void configuracionDelClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnlaceView EnlaceForm = new EnlaceView();

            // Mostrar el formulario ConectorViews
            EnlaceForm.Show();
        }
    }
}
