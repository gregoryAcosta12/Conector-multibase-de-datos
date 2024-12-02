namespace ConectorJamenSotf
{
    partial class ConectorView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.enlaceDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuracionDelClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionALaBaseDeDatosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conexionALaBaseDeDatosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enlaceDeDatosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1030, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // enlaceDeDatosToolStripMenuItem
            // 
            this.enlaceDeDatosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuracionDelClienteToolStripMenuItem,
            this.conexionALaBaseDeDatosToolStripMenuItem,
            this.conexionALaBaseDeDatosToolStripMenuItem1});
            this.enlaceDeDatosToolStripMenuItem.Name = "enlaceDeDatosToolStripMenuItem";
            this.enlaceDeDatosToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.enlaceDeDatosToolStripMenuItem.Text = "Menu de conexion";
            // 
            // configuracionDelClienteToolStripMenuItem
            // 
            this.configuracionDelClienteToolStripMenuItem.Name = "configuracionDelClienteToolStripMenuItem";
            this.configuracionDelClienteToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.configuracionDelClienteToolStripMenuItem.Text = "Enlace de datos";
            this.configuracionDelClienteToolStripMenuItem.Click += new System.EventHandler(this.configuracionDelClienteToolStripMenuItem_Click);
            // 
            // conexionALaBaseDeDatosToolStripMenuItem
            // 
            this.conexionALaBaseDeDatosToolStripMenuItem.Name = "conexionALaBaseDeDatosToolStripMenuItem";
            this.conexionALaBaseDeDatosToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.conexionALaBaseDeDatosToolStripMenuItem.Text = "Configuracion";
            // 
            // conexionALaBaseDeDatosToolStripMenuItem1
            // 
            this.conexionALaBaseDeDatosToolStripMenuItem1.Name = "conexionALaBaseDeDatosToolStripMenuItem1";
            this.conexionALaBaseDeDatosToolStripMenuItem1.Size = new System.Drawing.Size(221, 22);
            this.conexionALaBaseDeDatosToolStripMenuItem1.Text = "Conexion a la base de datos";
            // 
            // ConectorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1030, 526);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ConectorView";
            this.Text = "ConectorJamenSotf";
            this.Load += new System.EventHandler(this.ConectorView_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem enlaceDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuracionDelClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionALaBaseDeDatosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conexionALaBaseDeDatosToolStripMenuItem1;
    }
}