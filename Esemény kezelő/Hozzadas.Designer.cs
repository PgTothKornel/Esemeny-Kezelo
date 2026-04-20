namespace Esemény_kezelő
{
    partial class Hozzadas
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
            this.tb_nev = new System.Windows.Forms.TextBox();
            this.rtb_leriras = new System.Windows.Forms.RichTextBox();
            this.cb_kategoria = new System.Windows.Forms.ComboBox();
            this.cb_helyszin = new System.Windows.Forms.ComboBox();
            this.btn_torol = new System.Windows.Forms.Button();
            this.btn_hozzaad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // tb_nev
            // 
            this.tb_nev.Location = new System.Drawing.Point(307, 47);
            this.tb_nev.Name = "tb_nev";
            this.tb_nev.Size = new System.Drawing.Size(380, 20);
            this.tb_nev.TabIndex = 0;
            // 
            // rtb_leriras
            // 
            this.rtb_leriras.Location = new System.Drawing.Point(307, 80);
            this.rtb_leriras.Name = "rtb_leriras";
            this.rtb_leriras.Size = new System.Drawing.Size(380, 151);
            this.rtb_leriras.TabIndex = 1;
            this.rtb_leriras.Text = "";
            // 
            // cb_kategoria
            // 
            this.cb_kategoria.FormattingEnabled = true;
            this.cb_kategoria.Location = new System.Drawing.Point(307, 272);
            this.cb_kategoria.Name = "cb_kategoria";
            this.cb_kategoria.Size = new System.Drawing.Size(380, 21);
            this.cb_kategoria.TabIndex = 2;
            // 
            // cb_helyszin
            // 
            this.cb_helyszin.FormattingEnabled = true;
            this.cb_helyszin.Location = new System.Drawing.Point(307, 307);
            this.cb_helyszin.Name = "cb_helyszin";
            this.cb_helyszin.Size = new System.Drawing.Size(380, 21);
            this.cb_helyszin.TabIndex = 3;
            // 
            // btn_torol
            // 
            this.btn_torol.Location = new System.Drawing.Point(187, 346);
            this.btn_torol.Name = "btn_torol";
            this.btn_torol.Size = new System.Drawing.Size(114, 52);
            this.btn_torol.TabIndex = 4;
            this.btn_torol.Text = "Törlés";
            this.btn_torol.UseVisualStyleBackColor = true;
            this.btn_torol.Click += new System.EventHandler(this.tb_torol_Click);
            // 
            // btn_hozzaad
            // 
            this.btn_hozzaad.Location = new System.Drawing.Point(307, 346);
            this.btn_hozzaad.Name = "btn_hozzaad";
            this.btn_hozzaad.Size = new System.Drawing.Size(380, 52);
            this.btn_hozzaad.TabIndex = 5;
            this.btn_hozzaad.Text = "Hozzáadás";
            this.btn_hozzaad.UseVisualStyleBackColor = true;
            this.btn_hozzaad.Click += new System.EventHandler(this.btn_hozzaad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(212, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Esemény neve:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Esemény leírása:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 275);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Esemény kategóriája:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(191, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Esemény helyszíne:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(307, 237);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(380, 20);
            this.dateTimePicker1.TabIndex = 10;
            // 
            // Hozzadas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_hozzaad);
            this.Controls.Add(this.btn_torol);
            this.Controls.Add(this.cb_helyszin);
            this.Controls.Add(this.cb_kategoria);
            this.Controls.Add(this.rtb_leriras);
            this.Controls.Add(this.tb_nev);
            this.Name = "Hozzadas";
            this.Text = "Hozzadas";
            this.Load += new System.EventHandler(this.Hozzadas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_nev;
        private System.Windows.Forms.RichTextBox rtb_leriras;
        private System.Windows.Forms.ComboBox cb_kategoria;
        private System.Windows.Forms.ComboBox cb_helyszin;
        private System.Windows.Forms.Button btn_torol;
        private System.Windows.Forms.Button btn_hozzaad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}