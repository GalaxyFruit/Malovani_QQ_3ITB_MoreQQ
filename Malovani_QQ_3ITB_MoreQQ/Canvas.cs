﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Malovani_QQ_3ITB_MoreQQ
{
    public partial class Canvas : UserControl
    {
        public event Action ShapesChanged;

        public ContextMenuStrip CanvasContextMenuStrip => contextMenuStrip1;
        private int currentShapeIndex = -1;


        private List<Shape> shapes = new List<Shape>();
        public IReadOnlyList<Shape> Shapes => shapes;

        Shape currentShape = null;
        bool isDragging = false;

        public Canvas()
        {
            InitializeComponent();
        }

        public void AddShape(Shape shape)
        {
            shapes.Add(shape);
            Invalidate();
            ShapesChanged?.Invoke();
        }

        public void ClearShapes()
        {
            shapes.Clear();
            currentShape = null;
            Invalidate();
            ShapesChanged?.Invoke();
        }

        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (currentShape != null)
                {
                    currentShape.SetDragOffset(e.X, e.Y);
                    isDragging = true;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (currentShape != null)
                {
                    // HINT : contextMenuStrip1.Items[1].Enabled = false;
                    contextMenuStrip1.Show(this, e.Location);
                }
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (shapes.Count == 0) return;

            if (isDragging)
            {
                currentShape.Move(e.X, e.Y);
            }
            else
            {
                var shape = shapes.FirstOrDefault(s => s.IsMouseOver(e.X, e.Y));
                if (shape != null)
                {
                    if (currentShape != null)
                        currentShape.Highlight(false);

                    currentShape = shape;
                    currentShape.Highlight(true);
                }
                else
                {
                    if (currentShape != null)
                    {
                        currentShape.Highlight(false);
                        currentShape = null;
                    }
                }
            }
            Invalidate();
            ShapesChanged?.Invoke();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (shapes.Count == 0) return;

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            shapes.ForEach(shape => shape.Draw(e.Graphics));
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapes.Remove(currentShape);
            currentShape = null;
            Invalidate();
            ShapesChanged?.Invoke();
        }

        private void fillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentShape != null)
            {
                currentShape.ToggleFill();

                fillToolStripMenuItem.Text = currentShape.IsFilled() ? "Unfill" : "Fill";

                Invalidate();
                ShapesChanged?.Invoke();
            }
        }






        private void moveToFrontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentShape != null)
            {
                int index = shapes.IndexOf(currentShape);
                if (index < shapes.Count - 1)
                {
                    shapes.RemoveAt(index);
                    shapes.Insert(index + 1, currentShape); 
                    Invalidate(); 
                    ShapesChanged?.Invoke();
                }
            }
        }

        private void moveToBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentShape != null)
            {
                int index = shapes.IndexOf(currentShape);
                if (index > 0)
                {
                    shapes.RemoveAt(index);
                    shapes.Insert(index - 1, currentShape);
                    Invalidate();
                    ShapesChanged?.Invoke();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (currentShape != null)
            {
                currentShapeIndex = shapes.IndexOf(currentShape);

                moveToFrontToolStripMenuItem.Enabled = currentShapeIndex < shapes.Count - 1; 
                moveToBackToolStripMenuItem.Enabled = currentShapeIndex > 0;
            }
        }

        public void SetCurrentShape(Shape shape)
        {
            currentShape = shape;
            Invalidate();
        }

    }
}
