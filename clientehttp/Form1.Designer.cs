namespace clientehttp
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.txturl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtresultado = new System.Windows.Forms.TextBox();
            this.chkexibir = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtexecucoes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtvalor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.lblresult = new System.Windows.Forms.Label();
            this.lblfinalizado = new System.Windows.Forms.Label();
            this.lblproxy = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(345, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(233, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Enviar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(180, 12);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(585, 20);
            this.txturl.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "TIMEOUT(ms)";
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(214, 151);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(137, 20);
            this.txtTimeout.TabIndex = 4;
            // 
            // txtresultado
            // 
            this.txtresultado.Location = new System.Drawing.Point(31, 270);
            this.txtresultado.Multiline = true;
            this.txtresultado.Name = "txtresultado";
            this.txtresultado.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtresultado.Size = new System.Drawing.Size(911, 244);
            this.txtresultado.TabIndex = 9;
            // 
            // chkexibir
            // 
            this.chkexibir.AutoSize = true;
            this.chkexibir.Location = new System.Drawing.Point(380, 152);
            this.chkexibir.Name = "chkexibir";
            this.chkexibir.Size = new System.Drawing.Size(121, 17);
            this.chkexibir.TabIndex = 10;
            this.chkexibir.Text = "Exibir conteudo html";
            this.chkexibir.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtexecucoes);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtvalor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(126, 94);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 48);
            this.panel1.TabIndex = 11;
            // 
            // txtexecucoes
            // 
            this.txtexecucoes.Location = new System.Drawing.Point(381, 16);
            this.txtexecucoes.Name = "txtexecucoes";
            this.txtexecucoes.Size = new System.Drawing.Size(68, 20);
            this.txtexecucoes.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Execucoes";
            // 
            // txtvalor
            // 
            this.txtvalor.Location = new System.Drawing.Point(89, 15);
            this.txtvalor.Name = "txtvalor";
            this.txtvalor.Size = new System.Drawing.Size(209, 20);
            this.txtvalor.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Authorization";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(128, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 41);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Carga";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(109, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Arquivo";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 17);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(46, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tela";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(31, 236);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(0, 13);
            this.lblresult.TabIndex = 13;
            // 
            // lblfinalizado
            // 
            this.lblfinalizado.AutoSize = true;
            this.lblfinalizado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfinalizado.Location = new System.Drawing.Point(35, 521);
            this.lblfinalizado.Name = "lblfinalizado";
            this.lblfinalizado.Size = new System.Drawing.Size(52, 18);
            this.lblfinalizado.TabIndex = 14;
            this.lblfinalizado.Text = "label5";
            // 
            // lblproxy
            // 
            this.lblproxy.AutoSize = true;
            this.lblproxy.Location = new System.Drawing.Point(538, 155);
            this.lblproxy.Name = "lblproxy";
            this.lblproxy.Size = new System.Drawing.Size(33, 13);
            this.lblproxy.TabIndex = 15;
            this.lblproxy.Text = "Proxy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 558);
            this.Controls.Add(this.lblproxy);
            this.Controls.Add(this.lblfinalizado);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkexibir);
            this.Controls.Add(this.txtresultado);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Envio de Dados - Web API (Simultaneo)  NET 4.0  v 1.4";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtresultado;
        private System.Windows.Forms.CheckBox chkexibir;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtexecucoes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtvalor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.Label lblfinalizado;
        private System.Windows.Forms.Label lblproxy;
    }
}

