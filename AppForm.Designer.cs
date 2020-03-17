namespace WindowsFormsApp1
{
    partial class AppForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.readCSVBotton = new System.Windows.Forms.Button();
            this.csvDataViewer = new System.Windows.Forms.DataGridView();
            this.btnToXMLConvert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.csvDataViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // readCSVBotton
            // 
            this.readCSVBotton.Location = new System.Drawing.Point(199, 387);
            this.readCSVBotton.Name = "readCSVBotton";
            this.readCSVBotton.Size = new System.Drawing.Size(125, 51);
            this.readCSVBotton.TabIndex = 2;
            this.readCSVBotton.Text = "Read CSV";
            this.readCSVBotton.UseVisualStyleBackColor = true;
            this.readCSVBotton.Click += new System.EventHandler(this.readCSVBotton_Click);
            // 
            // csvDataViewer
            // 
            this.csvDataViewer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.csvDataViewer.Location = new System.Drawing.Point(13, 13);
            this.csvDataViewer.Name = "csvDataViewer";
            this.csvDataViewer.RowHeadersWidth = 51;
            this.csvDataViewer.RowTemplate.Height = 24;
            this.csvDataViewer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.csvDataViewer.Size = new System.Drawing.Size(775, 359);
            this.csvDataViewer.TabIndex = 3;
            // 
            // btnToXMLConvert
            // 
            this.btnToXMLConvert.Location = new System.Drawing.Point(452, 387);
            this.btnToXMLConvert.Name = "btnToXMLConvert";
            this.btnToXMLConvert.Size = new System.Drawing.Size(125, 51);
            this.btnToXMLConvert.TabIndex = 4;
            this.btnToXMLConvert.Text = "Convert to XML";
            this.btnToXMLConvert.UseVisualStyleBackColor = true;
            this.btnToXMLConvert.Click += new System.EventHandler(this.btnToXMLConvert_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToXMLConvert);
            this.Controls.Add(this.csvDataViewer);
            this.Controls.Add(this.readCSVBotton);
            this.Name = "AppForm";
            this.Text = "CSV to XML Converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.csvDataViewer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button readCSVBotton;
        private System.Windows.Forms.DataGridView csvDataViewer;
        private System.Windows.Forms.Button btnToXMLConvert;
    }
}

