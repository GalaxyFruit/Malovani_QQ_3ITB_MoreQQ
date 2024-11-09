namespace Malovani_QQ_3ITB_MoreQQ
{
    partial class Canvas
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            deleteToolStripMenuItem = new ToolStripMenuItem();
            moveToolStripMenuItem = new ToolStripMenuItem();
            moveToFrontToolStripMenuItem = new ToolStripMenuItem();
            moveToBackToolStripMenuItem = new ToolStripMenuItem();
            fillToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { deleteToolStripMenuItem, moveToolStripMenuItem, fillToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 92);
            contextMenuStrip1.Opening += contextMenuStrip1_Opening;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // moveToolStripMenuItem
            // 
            moveToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { moveToFrontToolStripMenuItem, moveToBackToolStripMenuItem });
            moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            moveToolStripMenuItem.Size = new Size(180, 22);
            moveToolStripMenuItem.Text = "Move";
            // 
            // moveToFrontToolStripMenuItem
            // 
            moveToFrontToolStripMenuItem.Name = "moveToFrontToolStripMenuItem";
            moveToFrontToolStripMenuItem.Size = new Size(180, 22);
            moveToFrontToolStripMenuItem.Text = "MoveToFront";
            moveToFrontToolStripMenuItem.Click += moveToFrontToolStripMenuItem_Click;
            // 
            // moveToBackToolStripMenuItem
            // 
            moveToBackToolStripMenuItem.Name = "moveToBackToolStripMenuItem";
            moveToBackToolStripMenuItem.Size = new Size(180, 22);
            moveToBackToolStripMenuItem.Text = "MoveToBack";
            moveToBackToolStripMenuItem.Click += moveToBackToolStripMenuItem_Click;
            // 
            // fillToolStripMenuItem
            // 
            fillToolStripMenuItem.Name = "fillToolStripMenuItem";
            fillToolStripMenuItem.Size = new Size(180, 22);
            fillToolStripMenuItem.Text = "Fill";
            fillToolStripMenuItem.Click += fillToolStripMenuItem_Click;
            // 
            // Canvas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            DoubleBuffered = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Canvas";
            Size = new Size(699, 385);
            Paint += Canvas_Paint;
            MouseDown += Canvas_MouseDown;
            MouseMove += Canvas_MouseMove;
            MouseUp += Canvas_MouseUp;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem moveToFrontToolStripMenuItem;
        private ToolStripMenuItem moveToBackToolStripMenuItem;
        private ToolStripMenuItem fillToolStripMenuItem;
    }
}
