using System.Windows.Forms;

namespace GulkortetNETFramework
{
    partial class GuldkortetServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuldkortetServer));
            this.StartServer = new System.Windows.Forms.Button();
            this.MessageView = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartServer
            // 
            this.StartServer.BackColor = System.Drawing.Color.Red;
            this.StartServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartServer.Location = new System.Drawing.Point(653, 359);
            this.StartServer.Name = "StartServer";
            this.StartServer.Size = new System.Drawing.Size(155, 79);
            this.StartServer.TabIndex = 0;
            this.StartServer.Text = "Start Server";
            this.StartServer.UseVisualStyleBackColor = false;
            this.StartServer.Click += new System.EventHandler(this.StartServer_Click);
            // 
            // MessageView
            // 
            this.MessageView.HideSelection = false;
            this.MessageView.Location = new System.Drawing.Point(12, 12);
            this.MessageView.Name = "MessageView";
            this.MessageView.Size = new System.Drawing.Size(622, 426);
            this.MessageView.TabIndex = 1;
            this.MessageView.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(640, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 138);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // GuldkortetServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(834, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MessageView);
            this.Controls.Add(this.StartServer);
            this.Name = "GuldkortetServer";
            this.Text = "GuldkortetServer";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartServer;
        private ListView MessageView;
        private PictureBox pictureBox1;
    }
}

