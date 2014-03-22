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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.btnReadCSV = new System.Windows.Forms.Button();
            this.btnReadTxT = new System.Windows.Forms.Button();
            this.EKGGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Draw = new System.Windows.Forms.Button();
            this.tachoGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.EKGGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachoGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReadCSV
            // 
            this.btnReadCSV.Location = new System.Drawing.Point(834, 53);
            this.btnReadCSV.Name = "btnReadCSV";
            this.btnReadCSV.Size = new System.Drawing.Size(75, 23);
            this.btnReadCSV.TabIndex = 0;
            this.btnReadCSV.Text = "Nacti CSV";
            this.btnReadCSV.UseVisualStyleBackColor = true;
            this.btnReadCSV.Click += new System.EventHandler(this.btnReadCSV_Click);
            // 
            // btnReadTxT
            // 
            this.btnReadTxT.Location = new System.Drawing.Point(834, 94);
            this.btnReadTxT.Name = "btnReadTxT";
            this.btnReadTxT.Size = new System.Drawing.Size(75, 23);
            this.btnReadTxT.TabIndex = 1;
            this.btnReadTxT.Text = "Nacti TxT";
            this.btnReadTxT.UseVisualStyleBackColor = true;
            this.btnReadTxT.Click += new System.EventHandler(this.btnReadTxT_Click);
            // 
            // EKGGraph
            // 
            chartArea1.Name = "ChartArea1";
            this.EKGGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.EKGGraph.Legends.Add(legend1);
            this.EKGGraph.Location = new System.Drawing.Point(12, 12);
            this.EKGGraph.Name = "EKGGraph";
            this.EKGGraph.Size = new System.Drawing.Size(786, 265);
            this.EKGGraph.TabIndex = 2;
            this.EKGGraph.Text = "EKGGraph";
            // 
            // Draw
            // 
            this.Draw.Location = new System.Drawing.Point(834, 142);
            this.Draw.Name = "Draw";
            this.Draw.Size = new System.Drawing.Size(75, 23);
            this.Draw.TabIndex = 3;
            this.Draw.Text = "Kreslit";
            this.Draw.UseVisualStyleBackColor = true;
            this.Draw.Click += new System.EventHandler(this.Draw_Click);
            // 
            // tachoGraph
            // 
            chartArea2.Name = "ChartArea1";
            this.tachoGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.tachoGraph.Legends.Add(legend2);
            this.tachoGraph.Location = new System.Drawing.Point(12, 283);
            this.tachoGraph.Name = "tachoGraph";
            this.tachoGraph.Size = new System.Drawing.Size(786, 273);
            this.tachoGraph.TabIndex = 4;
            this.tachoGraph.Text = "tachoGraph";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 568);
            this.Controls.Add(this.tachoGraph);
            this.Controls.Add(this.Draw);
            this.Controls.Add(this.EKGGraph);
            this.Controls.Add(this.btnReadTxT);
            this.Controls.Add(this.btnReadCSV);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.EKGGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tachoGraph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReadCSV;
        private System.Windows.Forms.Button btnReadTxT;
        private System.Windows.Forms.DataVisualization.Charting.Chart EKGGraph;
        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.DataVisualization.Charting.Chart tachoGraph;
    }
}

