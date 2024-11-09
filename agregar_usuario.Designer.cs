namespace nimusmatica
{
    partial class agregar_usuario
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
            this.gb_general = new System.Windows.Forms.GroupBox();
            this.gb_agregar_usuario = new System.Windows.Forms.GroupBox();
            this.lb_show_password = new System.Windows.Forms.Label();
            this.lb_alerta = new System.Windows.Forms.Label();
            this.cb_tipo_registro = new System.Windows.Forms.ComboBox();
            this.tb_password_ingreso = new System.Windows.Forms.TextBox();
            this.tb_usuario_registro = new System.Windows.Forms.TextBox();
            this.tb_nombre_registro = new System.Windows.Forms.TextBox();
            this.lb_tipo_usuario = new System.Windows.Forms.Label();
            this.lb_password_ingreso = new System.Windows.Forms.Label();
            this.lb_usuario_ingreso = new System.Windows.Forms.Label();
            this.lb_nombre_usuario = new System.Windows.Forms.Label();
            this.btt_limpiar_agregar = new System.Windows.Forms.Button();
            this.btt_registrar = new System.Windows.Forms.Button();
            this.pb_logo = new System.Windows.Forms.PictureBox();
            this.lb_registro_nimusmatica = new System.Windows.Forms.Label();
            this.gb_general.SuspendLayout();
            this.gb_agregar_usuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // gb_general
            // 
            this.gb_general.BackColor = System.Drawing.Color.DimGray;
            this.gb_general.Controls.Add(this.pb_logo);
            this.gb_general.Controls.Add(this.lb_registro_nimusmatica);
            this.gb_general.Controls.Add(this.gb_agregar_usuario);
            this.gb_general.Location = new System.Drawing.Point(1, 1);
            this.gb_general.Name = "gb_general";
            this.gb_general.Size = new System.Drawing.Size(993, 964);
            this.gb_general.TabIndex = 32;
            this.gb_general.TabStop = false;
            // 
            // gb_agregar_usuario
            // 
            this.gb_agregar_usuario.Controls.Add(this.lb_show_password);
            this.gb_agregar_usuario.Controls.Add(this.lb_alerta);
            this.gb_agregar_usuario.Controls.Add(this.cb_tipo_registro);
            this.gb_agregar_usuario.Controls.Add(this.tb_password_ingreso);
            this.gb_agregar_usuario.Controls.Add(this.tb_usuario_registro);
            this.gb_agregar_usuario.Controls.Add(this.tb_nombre_registro);
            this.gb_agregar_usuario.Controls.Add(this.lb_tipo_usuario);
            this.gb_agregar_usuario.Controls.Add(this.lb_password_ingreso);
            this.gb_agregar_usuario.Controls.Add(this.lb_usuario_ingreso);
            this.gb_agregar_usuario.Controls.Add(this.lb_nombre_usuario);
            this.gb_agregar_usuario.Controls.Add(this.btt_limpiar_agregar);
            this.gb_agregar_usuario.Controls.Add(this.btt_registrar);
            this.gb_agregar_usuario.Location = new System.Drawing.Point(12, 272);
            this.gb_agregar_usuario.Name = "gb_agregar_usuario";
            this.gb_agregar_usuario.Size = new System.Drawing.Size(968, 432);
            this.gb_agregar_usuario.TabIndex = 32;
            this.gb_agregar_usuario.TabStop = false;
            // 
            // lb_show_password
            // 
            this.lb_show_password.AutoSize = true;
            this.lb_show_password.BackColor = System.Drawing.Color.Transparent;
            this.lb_show_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_show_password.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_show_password.ForeColor = System.Drawing.Color.Black;
            this.lb_show_password.Location = new System.Drawing.Point(354, 248);
            this.lb_show_password.Name = "lb_show_password";
            this.lb_show_password.Size = new System.Drawing.Size(25, 38);
            this.lb_show_password.TabIndex = 22;
            this.lb_show_password.Text = ".";
            this.lb_show_password.Visible = false;
            // 
            // lb_alerta
            // 
            this.lb_alerta.AutoSize = true;
            this.lb_alerta.BackColor = System.Drawing.Color.Transparent;
            this.lb_alerta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_alerta.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_alerta.ForeColor = System.Drawing.Color.Black;
            this.lb_alerta.Location = new System.Drawing.Point(16, 370);
            this.lb_alerta.Name = "lb_alerta";
            this.lb_alerta.Size = new System.Drawing.Size(25, 38);
            this.lb_alerta.TabIndex = 21;
            this.lb_alerta.Text = ".";
            this.lb_alerta.Visible = false;
            // 
            // cb_tipo_registro
            // 
            this.cb_tipo_registro.DisplayMember = "tipo";
            this.cb_tipo_registro.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tipo_registro.FormattingEnabled = true;
            this.cb_tipo_registro.Location = new System.Drawing.Point(258, 298);
            this.cb_tipo_registro.Name = "cb_tipo_registro";
            this.cb_tipo_registro.Size = new System.Drawing.Size(347, 37);
            this.cb_tipo_registro.TabIndex = 20;
            this.cb_tipo_registro.ValueMember = "cod";
            // 
            // tb_password_ingreso
            // 
            this.tb_password_ingreso.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_password_ingreso.Location = new System.Drawing.Point(354, 211);
            this.tb_password_ingreso.Name = "tb_password_ingreso";
            this.tb_password_ingreso.PasswordChar = '•';
            this.tb_password_ingreso.Size = new System.Drawing.Size(251, 34);
            this.tb_password_ingreso.TabIndex = 19;
            // 
            // tb_usuario_registro
            // 
            this.tb_usuario_registro.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_usuario_registro.Location = new System.Drawing.Point(315, 122);
            this.tb_usuario_registro.Name = "tb_usuario_registro";
            this.tb_usuario_registro.Size = new System.Drawing.Size(290, 34);
            this.tb_usuario_registro.TabIndex = 18;
            // 
            // tb_nombre_registro
            // 
            this.tb_nombre_registro.Font = new System.Drawing.Font("Franklin Gothic Demi", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_nombre_registro.Location = new System.Drawing.Point(166, 32);
            this.tb_nombre_registro.Name = "tb_nombre_registro";
            this.tb_nombre_registro.Size = new System.Drawing.Size(439, 34);
            this.tb_nombre_registro.TabIndex = 17;
            // 
            // lb_tipo_usuario
            // 
            this.lb_tipo_usuario.AutoSize = true;
            this.lb_tipo_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lb_tipo_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tipo_usuario.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tipo_usuario.ForeColor = System.Drawing.Color.Black;
            this.lb_tipo_usuario.Location = new System.Drawing.Point(16, 297);
            this.lb_tipo_usuario.Name = "lb_tipo_usuario";
            this.lb_tipo_usuario.Size = new System.Drawing.Size(236, 38);
            this.lb_tipo_usuario.TabIndex = 16;
            this.lb_tipo_usuario.Text = "Tipo de Usuario :";
            // 
            // lb_password_ingreso
            // 
            this.lb_password_ingreso.AutoSize = true;
            this.lb_password_ingreso.BackColor = System.Drawing.Color.Transparent;
            this.lb_password_ingreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_password_ingreso.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_password_ingreso.ForeColor = System.Drawing.Color.Black;
            this.lb_password_ingreso.Location = new System.Drawing.Point(16, 207);
            this.lb_password_ingreso.Name = "lb_password_ingreso";
            this.lb_password_ingreso.Size = new System.Drawing.Size(329, 38);
            this.lb_password_ingreso.TabIndex = 15;
            this.lb_password_ingreso.Text = "Contraseña de Ingreso :";
            // 
            // lb_usuario_ingreso
            // 
            this.lb_usuario_ingreso.AutoSize = true;
            this.lb_usuario_ingreso.BackColor = System.Drawing.Color.Transparent;
            this.lb_usuario_ingreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_usuario_ingreso.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_usuario_ingreso.ForeColor = System.Drawing.Color.Black;
            this.lb_usuario_ingreso.Location = new System.Drawing.Point(16, 118);
            this.lb_usuario_ingreso.Name = "lb_usuario_ingreso";
            this.lb_usuario_ingreso.Size = new System.Drawing.Size(278, 38);
            this.lb_usuario_ingreso.TabIndex = 14;
            this.lb_usuario_ingreso.Text = "Usuario de Ingreso :";
            // 
            // lb_nombre_usuario
            // 
            this.lb_nombre_usuario.AutoSize = true;
            this.lb_nombre_usuario.BackColor = System.Drawing.Color.Transparent;
            this.lb_nombre_usuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_nombre_usuario.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nombre_usuario.ForeColor = System.Drawing.Color.Black;
            this.lb_nombre_usuario.Location = new System.Drawing.Point(16, 28);
            this.lb_nombre_usuario.Name = "lb_nombre_usuario";
            this.lb_nombre_usuario.Size = new System.Drawing.Size(144, 38);
            this.lb_nombre_usuario.TabIndex = 13;
            this.lb_nombre_usuario.Text = "Nombre : ";
            // 
            // btt_limpiar_agregar
            // 
            this.btt_limpiar_agregar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btt_limpiar_agregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_limpiar_agregar.Enabled = false;
            this.btt_limpiar_agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btt_limpiar_agregar.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_limpiar_agregar.Location = new System.Drawing.Point(655, 170);
            this.btt_limpiar_agregar.Name = "btt_limpiar_agregar";
            this.btt_limpiar_agregar.Size = new System.Drawing.Size(258, 45);
            this.btt_limpiar_agregar.TabIndex = 9;
            this.btt_limpiar_agregar.Text = "Limpiar Campos.";
            this.btt_limpiar_agregar.UseVisualStyleBackColor = false;
            this.btt_limpiar_agregar.Click += new System.EventHandler(this.btt_limpiar_agregar_Click);
            // 
            // btt_registrar
            // 
            this.btt_registrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btt_registrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btt_registrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btt_registrar.Font = new System.Drawing.Font("Franklin Gothic Demi", 18F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btt_registrar.Location = new System.Drawing.Point(655, 74);
            this.btt_registrar.Name = "btt_registrar";
            this.btt_registrar.Size = new System.Drawing.Size(260, 45);
            this.btt_registrar.TabIndex = 8;
            this.btt_registrar.Text = "Agregar Usuario.";
            this.btt_registrar.UseVisualStyleBackColor = false;
            this.btt_registrar.Click += new System.EventHandler(this.btt_registrar_Click);
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
            // agregar_usuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 964);
            this.Controls.Add(this.gb_general);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "agregar_usuario";
            this.Text = "agregar_usuario";
            this.gb_general.ResumeLayout(false);
            this.gb_general.PerformLayout();
            this.gb_agregar_usuario.ResumeLayout(false);
            this.gb_agregar_usuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_general;
        private System.Windows.Forms.PictureBox pb_logo;
        private System.Windows.Forms.Label lb_registro_nimusmatica;
        private System.Windows.Forms.GroupBox gb_agregar_usuario;
        private System.Windows.Forms.Label lb_show_password;
        private System.Windows.Forms.Label lb_alerta;
        private System.Windows.Forms.ComboBox cb_tipo_registro;
        private System.Windows.Forms.TextBox tb_password_ingreso;
        private System.Windows.Forms.TextBox tb_usuario_registro;
        private System.Windows.Forms.TextBox tb_nombre_registro;
        private System.Windows.Forms.Label lb_tipo_usuario;
        private System.Windows.Forms.Label lb_password_ingreso;
        private System.Windows.Forms.Label lb_usuario_ingreso;
        private System.Windows.Forms.Label lb_nombre_usuario;
        private System.Windows.Forms.Button btt_limpiar_agregar;
        private System.Windows.Forms.Button btt_registrar;
    }
}