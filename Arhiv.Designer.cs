namespace FestivalVelenje3
{
    partial class Arhiv
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImePredstave = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vstopnina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Kraj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NaslovGledalisca = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gledalisce = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.ImePredstave,
            this.Vstopnina,
            this.Kraj,
            this.NaslovGledalisca,
            this.Gledalisce});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(58, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(663, 387);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // ID
            // 
            this.ID.Text = "ID";
            // 
            // ImePredstave
            // 
            this.ImePredstave.Text = "Datum nastopa";
            this.ImePredstave.Width = 110;
            // 
            // Vstopnina
            // 
            this.Vstopnina.Text = "Ime Predstave";
            // 
            // Kraj
            // 
            this.Kraj.Text = "Gledalisce";
            this.Kraj.Width = 110;
            // 
            // NaslovGledalisca
            // 
            this.NaslovGledalisca.Text = "Datum Spremembe";
            this.NaslovGledalisca.Width = 163;
            // 
            // Gledalisce
            // 
            this.Gledalisce.Text = "Nastop ID";
            this.Gledalisce.Width = 109;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Nazaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Arhiv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Name = "Arhiv";
            this.Text = "Arhiv";
            this.Load += new System.EventHandler(this.Arhiv_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader ImePredstave;
        private System.Windows.Forms.ColumnHeader Vstopnina;
        private System.Windows.Forms.ColumnHeader Kraj;
        private System.Windows.Forms.ColumnHeader NaslovGledalisca;
        private System.Windows.Forms.ColumnHeader Gledalisce;
        private System.Windows.Forms.Button button1;
    }
}