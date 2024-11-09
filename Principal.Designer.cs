namespace nimusmatica
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.gb_general = new System.Windows.Forms.GroupBox();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lb_registro_nimusmatica = new System.Windows.Forms.Label();
            this.gb_inicio_sesion = new System.Windows.Forms.GroupBox();
            this.lb_mensaje_alerta = new System.Windows.Forms.Label();
            this.btt_iniciar_sesion = new System.Windows.Forms.Button();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_usuario = new System.Windows.Forms.TextBox();
            this.lb_password = new System.Windows.Forms.Label();
            this.lb_usuario = new System.Windows.Forms.Label();
            this.lb_ingreso_usuario = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.salir_menu_strip = new System.Windows.Forms.ToolStripMenuItem();
            this.volver_menu_item = new System.Windows.Forms.ToolStripMenuItem();
            this.gb_general.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.gb_inicio_sesion.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_general
            // 
            this.gb_general.BackColor = System.Drawing.Color.DimGray;
            this.gb_general.Controls.Add(this.pb_logo);
            this.gb_general.Controls.Add(this.lb_registro_nimusmatica);
            this.gb_general.Controls.Add(this.gb_inicio_sesion);
            this.gb_general.Location = new System.Drawing.Point(2, 27);
            this.gb_general.Name = "gb_general";
            this.gb_general.Size = new System.Drawing.Size(998, 973);
            this.gb_general.TabIndex = 29;
            this.gb_general.TabStop = false;
            // 
            // pb_logo
            // 
            this.pb_logo.Image = global::nimusmatica.Properties.Resources.simbolo;
            this.pb_logo.Location = new System.Drawing.Point(399, 21);
            this.pb_logo.Name = "pb_logo";
            this.pb_logo.Size = new System.Drawing.Size(174, 200);
            this.pb_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_logo.TabIndex = 0;
            this.pb_logo.TabStop = false;
            // 
            // lb_registro_nimusmatica
            // 
            this.lb_registro_nimusmatica.AutoSize = true;
            this.lb_registro_nimusmatica.BackColor = System.Drawing.Color.Transparent;
            this.lb_registro_nimusmatica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_registro_nimusmatica.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_registro_nimusmatica.ForeColor = System.Drawing.Color.Black;
            this.lb_registro_nimusmatica.Location = new System.Drawing.Point(338, 221);
            this.lb_registro_nimusmatica.Name = "lb_registro_nimusmatica";
            this.lb_registro_nimusmatica.Size = new System.Drawing.Size(308, 38);
            this.lb_registro_nimusmatica.TabIndex = 2;
            this.lb_registro_nimusmatica.Text = "Registro Nimusmatico";
            // 
            // gb_inicio_sesion
            // 
            this.gb_inicio_sesion.Controls.Add(this.lb_mensaje_alerta);
            this.gb_inicio_sesion.Controls.Add(this.btt_iniciar_sesion);
            this.gb_inicio_sesion.Controls.Add(this.tb_password);
            this.gb_inicio_sesion.Controls.Add(this.tb_usuario);
            this.gb_inicio_sesion.Controls.Add(this.lb_password);
            this.gb_inicio_sesion.Controls.Add(this.lb_usuario);
            this.gb_inicio_sesion.Controls.Add(this.lb_ingreso_usuario);
            this.gb_inicio_sesion.Location = new System.Drawing.Point(76, 313);
            this.gb_inicio_sesion.Name = "gb_inicio_sesion";
            this.gb_inicio_sesion.Size = new System.Drawing.Size(831, 467);
            this.gb_inicio_sesion.TabIndex = 6;
            this.gb_inicio_sesion.TabStop = false;
            // 
            // lb_mensaje_alerta
            // 
            this.lb_mensaje_alerta.AutoSize = true;
            this.lb_mensaje_alerta.BackColor = System.Drawing.Color.Transparent;
            this.lb_mensaje_alerta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_mensaje_alerta.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mensaje_alerta.ForeColor = System.Drawing.Color.Black;
            this.lb_mensaje_alerta.Location = new System.Drawing.Point(40, 398);
            this.lb_mensaje_alerta.Name = "lb_mensaje_alerta";
            this.lb_mensaje_alerta.Size = new System.Drawing.Size(222, 29);
            this.lb_mensaje_alerta.TabIndex = 9;
            this.lb_mensaje_alerta.Text = "Campos incompletos";
            this.lb_mensaje_alerta.Visible = false;
            // 
            // btt_iniciar_sesion
            // 
            this.btt_iniciar_sesion.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btt_iniciar_sesion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_iniciar_sesion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btt_iniciar_sesion.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_iniciar_sesion.Location = new System.Drawing.Point(281, 343);
            this.btt_iniciar_sesion.Name = "btt_iniciar_sesion";
            this.btt_iniciar_sesion.Size = new System.Drawing.Size(254, 45);
            this.btt_iniciar_sesion.TabIndex = 8;
            this.btt_iniciar_sesion.Text = "Iniciar sesión";
            this.btt_iniciar_sesion.UseVisualStyleBackColor = false;
            this.btt_iniciar_sesion.Click += new System.EventHandler(this.btt_iniciar_sesion_Click);
            // 
            // tb_password
            // 
            this.tb_password.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password.Location = new System.Drawing.Point(244, 240);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '•';
            this.tb_password.Size = new System.Drawing.Size(410, 34);
            this.tb_password.TabIndex = 7;
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            // 
            // tb_usuario
            // 
            this.tb_usuario.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_usuario.Location = new System.Drawing.Point(178, 155);
            this.tb_usuario.Name = "tb_usuario";
            this.tb_usuario.Size = new System.Drawing.Size(476, 34);
            this.tb_usuario.TabIndex = 6;
            this.tb_usuario.TextChanged += new System.EventHandler(this.tb_usuario_TextChanged);
            // 
            // lb_password
            // 
            this.lb_password.AutoSize = true;
            this.lb_password.BackColor = System.Drawing.Color.Transparent;
            this.lb_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_password.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password.ForeColor = System.Drawing.Color.Black;
            this.lb_password.Location = new System.Drawing.Point(40, 240);
            this.lb_password.Name = "lb_password";
            this.lb_password.Size = new System.Drawing.Size(182, 38);
            this.lb_password.TabIndex = 5;
            this.lb_password.Text = "Constraseña";
            // 
            // lb_usuario
            // 
            this.lb_usuario.AutoSize = true;
            this.lb_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lb_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_usuario.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_usuario.ForeColor = System.Drawing.Color.Black;
            this.lb_usuario.Location = new System.Drawing.Point(40, 151);
            this.lb_usuario.Name = "lb_usuario";
            this.lb_usuario.Size = new System.Drawing.Size(117, 38);
            this.lb_usuario.TabIndex = 4;
            this.lb_usuario.Text = "Usuario";
            // 
            // lb_ingreso_usuario
            // 
            this.lb_ingreso_usuario.AutoSize = true;
            this.lb_ingreso_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lb_ingreso_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_ingreso_usuario.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ingreso_usuario.ForeColor = System.Drawing.Color.Black;
            this.lb_ingreso_usuario.Location = new System.Drawing.Point(285, 37);
            this.lb_ingreso_usuario.Name = "lb_ingreso_usuario";
            this.lb_ingreso_usuario.Size = new System.Drawing.Size(259, 38);
            this.lb_ingreso_usuario.TabIndex = 3;
            this.lb_ingreso_usuario.Text = "Ingreso de usuario";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salir_menu_strip,
            this.volver_menu_item});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 30);
            this.menuStrip1.TabIndex = 31;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // salir_menu_strip
            // 
            this.salir_menu_strip.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salir_menu_strip.Name = "salir_menu_strip";
            this.salir_menu_strip.Size = new System.Drawing.Size(52, 26);
            this.salir_menu_strip.Text = "Salir";
            this.salir_menu_strip.Click += new System.EventHandler(this.salir_menu_strip_Click);
            // 
            // volver_menu_item
            // 
            this.volver_menu_item.Enabled = false;
            this.volver_menu_item.Font = new System.Drawing.Font("Franklin Gothic Medium", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volver_menu_item.Name = "volver_menu_item";
            this.volver_menu_item.Size = new System.Drawing.Size(63, 24);
            this.volver_menu_item.Text = "Volver";
            this.volver_menu_item.Visible = false;
            this.volver_menu_item.Click += new System.EventHandler(this.volver_menu_item_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1000, 1000);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gb_general);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1000, 1000);
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.gb_general.ResumeLayout(false);
            this.gb_general.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.gb_inicio_sesion.ResumeLayout(false);
            this.gb_inicio_sesion.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_general;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label lb_registro_nimusmatica;
        private System.Windows.Forms.GroupBox gb_inicio_sesion;
        private System.Windows.Forms.Label lb_mensaje_alerta;
        private System.Windows.Forms.Button btt_iniciar_sesion;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.TextBox tb_usuario;
        private System.Windows.Forms.Label lb_password;
        private System.Windows.Forms.Label lb_usuario;
        private System.Windows.Forms.Label lb_ingreso_usuario;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem salir_menu_strip;
        private System.Windows.Forms.ToolStripMenuItem volver_menu_item;
    }
}