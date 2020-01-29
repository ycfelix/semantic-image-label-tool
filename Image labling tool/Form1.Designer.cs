using System.Drawing;
using System.Windows.Forms;

namespace Image_labling_tool
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.canvas = new System.Windows.Forms.PictureBox();
            this.photoList = new System.Windows.Forms.ListBox();
            this.actionBar = new System.Windows.Forms.Panel();
            this.fillButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.undoButton = new System.Windows.Forms.Button();
            this.saveToFile = new System.Windows.Forms.Button();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lineMode = new System.Windows.Forms.CheckBox();
            this.dotMode = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.actionBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.canvas);
            this.panel1.Controls.Add(this.photoList);
            this.panel1.Controls.Add(this.actionBar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(697, 466);
            this.panel1.TabIndex = 0;
            // 
            // canvas
            // 
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(189, 45);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(508, 421);
            this.canvas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.canvas.TabIndex = 3;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanelMouseClick);
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelMouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanelMouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelMouseUp);
            // 
            // photoList
            // 
            this.photoList.Dock = System.Windows.Forms.DockStyle.Left;
            this.photoList.FormattingEnabled = true;
            this.photoList.HorizontalScrollbar = true;
            this.photoList.ItemHeight = 16;
            this.photoList.Location = new System.Drawing.Point(0, 45);
            this.photoList.Name = "photoList";
            this.photoList.Size = new System.Drawing.Size(189, 421);
            this.photoList.TabIndex = 2;
            this.photoList.DoubleClick += new System.EventHandler(this.LoadPhoto);
            // 
            // actionBar
            // 
            this.actionBar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.actionBar.Controls.Add(this.dotMode);
            this.actionBar.Controls.Add(this.lineMode);
            this.actionBar.Controls.Add(this.fillButton);
            this.actionBar.Controls.Add(this.button3);
            this.actionBar.Controls.Add(this.undoButton);
            this.actionBar.Controls.Add(this.saveToFile);
            this.actionBar.Controls.Add(this.pictureBox4);
            this.actionBar.Controls.Add(this.pictureBox3);
            this.actionBar.Controls.Add(this.pictureBox2);
            this.actionBar.Controls.Add(this.pictureBox1);
            this.actionBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.actionBar.Location = new System.Drawing.Point(0, 0);
            this.actionBar.Name = "actionBar";
            this.actionBar.Size = new System.Drawing.Size(697, 45);
            this.actionBar.TabIndex = 0;
            // 
            // fillButton
            // 
            this.fillButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.fillButton.Location = new System.Drawing.Point(397, 0);
            this.fillButton.Name = "fillButton";
            this.fillButton.Size = new System.Drawing.Size(75, 45);
            this.fillButton.TabIndex = 7;
            this.fillButton.Text = "Fill polygon";
            this.fillButton.UseVisualStyleBackColor = true;
            this.fillButton.Click += new System.EventHandler(this.fillButton_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Right;
            this.button3.Location = new System.Drawing.Point(472, 0);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 45);
            this.button3.TabIndex = 6;
            this.button3.Text = "Load Directory";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.LoadDirectory);
            // 
            // undoButton
            // 
            this.undoButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.undoButton.Location = new System.Drawing.Point(547, 0);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(75, 45);
            this.undoButton.TabIndex = 5;
            this.undoButton.Text = "Undo";
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // saveToFile
            // 
            this.saveToFile.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveToFile.Location = new System.Drawing.Point(622, 0);
            this.saveToFile.Name = "saveToFile";
            this.saveToFile.Size = new System.Drawing.Size(75, 45);
            this.saveToFile.TabIndex = 4;
            this.saveToFile.Text = "Save to File";
            this.saveToFile.UseVisualStyleBackColor = true;
            this.saveToFile.Click += new System.EventHandler(this.saveToFile_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Green;
            this.pictureBox4.Location = new System.Drawing.Point(153, 3);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(36, 34);
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.ColorClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Blue;
            this.pictureBox3.Location = new System.Drawing.Point(111, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 34);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.ColorClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Yellow;
            this.pictureBox2.Location = new System.Drawing.Point(69, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(36, 34);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.ColorClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(27, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 34);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.ColorClick);
            // 
            // lineMode
            // 
            this.lineMode.AutoSize = true;
            this.lineMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.lineMode.Location = new System.Drawing.Point(300, 0);
            this.lineMode.Name = "lineMode";
            this.lineMode.Size = new System.Drawing.Size(97, 45);
            this.lineMode.TabIndex = 8;
            this.lineMode.Text = "Line mode";
            this.lineMode.UseVisualStyleBackColor = true;
            this.lineMode.CheckedChanged += new System.EventHandler(this.lineMode_CheckedChanged);
            // 
            // dotMode
            // 
            this.dotMode.AutoSize = true;
            this.dotMode.Checked = true;
            this.dotMode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dotMode.Dock = System.Windows.Forms.DockStyle.Right;
            this.dotMode.Location = new System.Drawing.Point(211, 0);
            this.dotMode.Name = "dotMode";
            this.dotMode.Size = new System.Drawing.Size(89, 45);
            this.dotMode.TabIndex = 9;
            this.dotMode.Text = "dot mode";
            this.dotMode.UseVisualStyleBackColor = true;
            this.dotMode.CheckedChanged += new System.EventHandler(this.dotMode_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(697, 466);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.actionBar.ResumeLayout(false);
            this.actionBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel actionBar;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox photoList;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button saveToFile;
        private PictureBox canvas;
        private Button fillButton;
        private CheckBox dotMode;
        private CheckBox lineMode;
    }
}

