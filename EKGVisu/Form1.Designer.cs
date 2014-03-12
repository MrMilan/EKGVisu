namespace EKGVisu
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnReadCSV = new System.Windows.Forms.Button();
            this.btnReadTxT = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Draw = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadCSV
            // 
            this.btnReadCSV.Location = new System.Drawing.Point(584, 546);
            this.btnReadCSV.Name = "btnReadCSV";
            this.btnReadCSV.Size = new System.Drawing.Size(75, 23);
            this.btnReadCSV.TabIndex = 0;
            this.btnReadCSV.Text = "Nacti CSV";
            this.btnReadCSV.UseVisualStyleBackColor = true;
            this.btnReadCSV.Click += new System.EventHandler(this.btnReadCSV_Click);
            // 
            // btnReadTxT
            // 
            this.btnReadTxT.Location = new System.Drawing.Point(503, 546);
            this.btnReadTxT.Name = "btnReadTxT";
            this.btnReadTxT.Size = new System.Drawing.Size(75, 23);
            this.btnReadTxT.TabIndex = 1;
            this.btnReadTxT.Text = "Nacti TxT";
            this.btnReadTxT.UseVisualStyleBackColor = true;
            this.btnReadTxT.Click += new System.EventHandler(this.btnReadTxT_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(20, 22);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1094, 518);
            this.chart1.TabIndex = 2;
            this.chart1.Text = "chart1";
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(422, 546);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(75, 23);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "Kreslit";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 568);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.btnReadTxT);
            this.Controls.Add(this.btnReadCSV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadCSV;
        private System.Windows.Forms.Button btnReadTxT;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Draw;
    }
}

