namespace Circuits
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonEXIT = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonINPUT = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOUTPUT = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAnd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonOr = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonNot = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCOPY = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEVALUATE = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSTARTC = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonENDC = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonINPUT,
            this.toolStripButtonOUTPUT,
            this.toolStripSeparator2,
            this.toolStripButtonAnd,
            this.toolStripButtonOr,
            this.toolStripButtonNot,
            this.toolStripSeparator1,
            this.toolStripButtonCOPY,
            this.toolStripButtonEVALUATE,
            this.toolStripSeparator3,
            this.toolStripButtonSTARTC,
            this.toolStripButtonENDC,
            this.toolStripSeparator4,
            this.toolStripButtonEXIT});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 28);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 28);
            // 
            // toolStripButtonEXIT
            // 
            this.toolStripButtonEXIT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonEXIT.BackColor = System.Drawing.Color.Red;
            this.toolStripButtonEXIT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonEXIT.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonEXIT.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonEXIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEXIT.Name = "toolStripButtonEXIT";
            this.toolStripButtonEXIT.Size = new System.Drawing.Size(43, 25);
            this.toolStripButtonEXIT.Text = "EXIT";
            this.toolStripButtonEXIT.Click += new System.EventHandler(this.toolStripButtonEXIT_Click);
            // 
            // toolStripButtonINPUT
            // 
            this.toolStripButtonINPUT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonINPUT.Image = global::Circuits.Properties.Resources.InputIcon;
            this.toolStripButtonINPUT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonINPUT.Name = "toolStripButtonINPUT";
            this.toolStripButtonINPUT.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonINPUT.Text = "INPUT";
            this.toolStripButtonINPUT.Click += new System.EventHandler(this.toolStripButtonINPUT_Click);
            // 
            // toolStripButtonOUTPUT
            // 
            this.toolStripButtonOUTPUT.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOUTPUT.Image = global::Circuits.Properties.Resources.OutputIcon;
            this.toolStripButtonOUTPUT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOUTPUT.Name = "toolStripButtonOUTPUT";
            this.toolStripButtonOUTPUT.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonOUTPUT.Text = "INPUT";
            this.toolStripButtonOUTPUT.ToolTipText = "OUTPUT";
            this.toolStripButtonOUTPUT.Click += new System.EventHandler(this.toolStripButtonOUTPUT_Click);
            // 
            // toolStripButtonAnd
            // 
            this.toolStripButtonAnd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAnd.Image = global::Circuits.Properties.Resources.AndIcon;
            this.toolStripButtonAnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAnd.Name = "toolStripButtonAnd";
            this.toolStripButtonAnd.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonAnd.Text = "AND Gate";
            this.toolStripButtonAnd.Click += new System.EventHandler(this.toolStripButtonAnd_Click);
            // 
            // toolStripButtonOr
            // 
            this.toolStripButtonOr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonOr.Image = global::Circuits.Properties.Resources.OrIcon;
            this.toolStripButtonOr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOr.Name = "toolStripButtonOr";
            this.toolStripButtonOr.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonOr.Text = "OR Gate";
            this.toolStripButtonOr.Click += new System.EventHandler(this.toolStripButtonOr_Click);
            // 
            // toolStripButtonNot
            // 
            this.toolStripButtonNot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonNot.Image = global::Circuits.Properties.Resources.NotIcon;
            this.toolStripButtonNot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNot.Name = "toolStripButtonNot";
            this.toolStripButtonNot.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonNot.Text = "NOT Gate";
            this.toolStripButtonNot.ToolTipText = "NOT Gate";
            this.toolStripButtonNot.Click += new System.EventHandler(this.toolStripButtonNot_Click);
            // 
            // toolStripButtonCOPY
            // 
            this.toolStripButtonCOPY.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCOPY.Image = global::Circuits.Properties.Resources.CopyIcon;
            this.toolStripButtonCOPY.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCOPY.Name = "toolStripButtonCOPY";
            this.toolStripButtonCOPY.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonCOPY.Text = "missing feature";
            this.toolStripButtonCOPY.ToolTipText = "COPY";
            this.toolStripButtonCOPY.Click += new System.EventHandler(this.toolStripButtonCOPY_Click);
            // 
            // toolStripButtonEVALUATE
            // 
            this.toolStripButtonEVALUATE.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEVALUATE.Image = global::Circuits.Properties.Resources.EvaluateIcon;
            this.toolStripButtonEVALUATE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEVALUATE.Name = "toolStripButtonEVALUATE";
            this.toolStripButtonEVALUATE.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonEVALUATE.Text = "EVALUATE";
            this.toolStripButtonEVALUATE.Click += new System.EventHandler(this.toolStripButtonEVALUATE_Click);
            // 
            // toolStripButtonSTARTC
            // 
            this.toolStripButtonSTARTC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSTARTC.Image = global::Circuits.Properties.Resources.StartCompoundIcon;
            this.toolStripButtonSTARTC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSTARTC.Name = "toolStripButtonSTARTC";
            this.toolStripButtonSTARTC.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonSTARTC.Text = "START COMPOUND";
            this.toolStripButtonSTARTC.Click += new System.EventHandler(this.toolStripButtonSTARTC_Click);
            // 
            // toolStripButtonENDC
            // 
            this.toolStripButtonENDC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonENDC.Image = global::Circuits.Properties.Resources.EndCompoundIcon;
            this.toolStripButtonENDC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonENDC.Name = "toolStripButtonENDC";
            this.toolStripButtonENDC.Size = new System.Drawing.Size(23, 25);
            this.toolStripButtonENDC.Text = "END COMPOUND";
            this.toolStripButtonENDC.Click += new System.EventHandler(this.toolStripButtonENDC_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Circuits 25\'";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAnd;
        private System.Windows.Forms.ToolStripButton toolStripButtonOr;
        private System.Windows.Forms.ToolStripButton toolStripButtonNot;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonEXIT;
        private System.Windows.Forms.ToolStripButton toolStripButtonOUTPUT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonENDC;
        private System.Windows.Forms.ToolStripButton toolStripButtonCOPY;
        private System.Windows.Forms.ToolStripButton toolStripButtonEVALUATE;
        private System.Windows.Forms.ToolStripButton toolStripButtonSTARTC;
        private System.Windows.Forms.ToolStripButton toolStripButtonINPUT;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    }
}

