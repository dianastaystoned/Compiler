namespace splash_scrren_2._0
{
    partial class FrmCompiler
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompiler));
            this.label1 = new System.Windows.Forms.Label();
            this.PanelCodigo = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dtgTokens = new System.Windows.Forms.DataGridView();
            this.txtTraduccion = new System.Windows.Forms.RichTextBox();
            this.btnCrear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.PicSalir = new System.Windows.Forms.PictureBox();
            this.PicStart = new System.Windows.Forms.PictureBox();
            this.PicCodigo = new System.Windows.Forms.PictureBox();
            this.cmbPuertos = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSalir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Old English Text MT", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label1.Location = new System.Drawing.Point(397, -1);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 44);
            this.label1.TabIndex = 8;
            this.label1.Text = "stay stoned compiler";
            // 
            // PanelCodigo
            // 
            this.PanelCodigo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PanelCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelCodigo.Location = new System.Drawing.Point(41, 48);
            this.PanelCodigo.Margin = new System.Windows.Forms.Padding(5);
            this.PanelCodigo.Name = "PanelCodigo";
            this.PanelCodigo.Size = new System.Drawing.Size(250, 314);
            this.PanelCodigo.TabIndex = 0;
            this.PanelCodigo.Text = "";
            this.PanelCodigo.TextChanged += new System.EventHandler(this.PanelCodigo_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dtgTokens
            // 
            this.dtgTokens.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.dtgTokens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgTokens.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTokens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtgTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgTokens.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtgTokens.EnableHeadersVisualStyles = false;
            this.dtgTokens.GridColor = System.Drawing.Color.White;
            this.dtgTokens.Location = new System.Drawing.Point(301, 48);
            this.dtgTokens.Margin = new System.Windows.Forms.Padding(5);
            this.dtgTokens.MultiSelect = false;
            this.dtgTokens.Name = "dtgTokens";
            this.dtgTokens.ReadOnly = true;
            this.dtgTokens.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Indigo;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgTokens.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtgTokens.RowHeadersVisible = false;
            this.dtgTokens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgTokens.Size = new System.Drawing.Size(508, 256);
            this.dtgTokens.TabIndex = 13;
            // 
            // txtTraduccion
            // 
            this.txtTraduccion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTraduccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTraduccion.Location = new System.Drawing.Point(819, 48);
            this.txtTraduccion.Margin = new System.Windows.Forms.Padding(5);
            this.txtTraduccion.Name = "txtTraduccion";
            this.txtTraduccion.Size = new System.Drawing.Size(243, 314);
            this.txtTraduccion.TabIndex = 15;
            this.txtTraduccion.Text = "";
            // 
            // btnCrear
            // 
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.Location = new System.Drawing.Point(494, 312);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(72, 62);
            this.btnCrear.TabIndex = 16;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::splash_scrren_2._0.Properties.Resources.folder__1_;
            this.pictureBox1.Location = new System.Drawing.Point(574, 314);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(65, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // PicSalir
            // 
            this.PicSalir.BackColor = System.Drawing.Color.Transparent;
            this.PicSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicSalir.Image = global::splash_scrren_2._0.Properties.Resources.cancel;
            this.PicSalir.Location = new System.Drawing.Point(722, 314);
            this.PicSalir.Margin = new System.Windows.Forms.Padding(5);
            this.PicSalir.Name = "PicSalir";
            this.PicSalir.Size = new System.Drawing.Size(61, 60);
            this.PicSalir.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicSalir.TabIndex = 12;
            this.PicSalir.TabStop = false;
            this.PicSalir.Click += new System.EventHandler(this.PicSalir_Click);
            // 
            // PicStart
            // 
            this.PicStart.BackColor = System.Drawing.Color.Transparent;
            this.PicStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.PicStart.Image = global::splash_scrren_2._0.Properties.Resources.running;
            this.PicStart.Location = new System.Drawing.Point(649, 314);
            this.PicStart.Margin = new System.Windows.Forms.Padding(5);
            this.PicStart.Name = "PicStart";
            this.PicStart.Size = new System.Drawing.Size(65, 60);
            this.PicStart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicStart.TabIndex = 11;
            this.PicStart.TabStop = false;
            this.PicStart.Click += new System.EventHandler(this.PicStart_Click);
            // 
            // PicCodigo
            // 
            this.PicCodigo.BackColor = System.Drawing.Color.Transparent;
            this.PicCodigo.Location = new System.Drawing.Point(5, 48);
            this.PicCodigo.Margin = new System.Windows.Forms.Padding(5);
            this.PicCodigo.Name = "PicCodigo";
            this.PicCodigo.Size = new System.Drawing.Size(36, 314);
            this.PicCodigo.TabIndex = 10;
            this.PicCodigo.TabStop = false;
            this.PicCodigo.Click += new System.EventHandler(this.PicCodigo_Click);
            this.PicCodigo.Paint += new System.Windows.Forms.PaintEventHandler(this.PicCodigo_Paint);
            // 
            // cmbPuertos
            // 
            this.cmbPuertos.FormattingEnabled = true;
            this.cmbPuertos.Location = new System.Drawing.Point(299, 343);
            this.cmbPuertos.Name = "cmbPuertos";
            this.cmbPuertos.Size = new System.Drawing.Size(189, 28);
            this.cmbPuertos.TabIndex = 19;
            this.cmbPuertos.SelectedIndexChanged += new System.EventHandler(this.cmbPuertos_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(346, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Puertos:";
            // 
            // FrmCompiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1076, 386);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbPuertos);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.txtTraduccion);
            this.Controls.Add(this.dtgTokens);
            this.Controls.Add(this.PicSalir);
            this.Controls.Add(this.PicStart);
            this.Controls.Add(this.PicCodigo);
            this.Controls.Add(this.PanelCodigo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "FrmCompiler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCompiler";
            this.Load += new System.EventHandler(this.FrmCompiler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgTokens)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicSalir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicCodigo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox PanelCodigo;
        private System.Windows.Forms.PictureBox PicCodigo;
        private System.Windows.Forms.PictureBox PicStart;
        private System.Windows.Forms.PictureBox PicSalir;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dtgTokens;
        private System.Windows.Forms.RichTextBox txtTraduccion;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbPuertos;
        private System.Windows.Forms.Label label2;
    }
}