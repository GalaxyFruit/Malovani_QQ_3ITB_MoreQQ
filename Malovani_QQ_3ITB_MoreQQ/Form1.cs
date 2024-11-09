﻿using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace Malovani_QQ_3ITB_MoreQQ
{
    public partial class Form1 : Form
    {
        /*
     Zeptat se DJ na svìtla
     TODO: 
     * volba barvy ---
     * hezèí vykreslení ---
     * hezèí èára ---
     * pøesouvání objektù ---
     * clear objektù ---
     * square ---
     * reflexe - (assembly)
     * ukládání
     */

        FileManager fileManager = new FileManager();

        public Form1()
        {
            InitializeComponent();
            canvas1.ShapesChanged += OnShapesChanged;
        }

        private void OnShapesChanged()
        {
            listBox1.Items.Clear();
            foreach (var item in canvas1.Shapes)
            {
                listBox1.Items.Add(item);
            }
            UpdateLabel1();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Assembly ass = Assembly.GetExecutingAssembly();
            LoadTypesFromAssembly(ass);

            if (comboBox1.Items.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void LoadTypesFromAssembly(Assembly ass)
        {
            var types = ass.GetTypes();
            var shapeTypes = types.Where(t =>
            {
                if (t.IsSubclassOf(typeof(Shape)))
                {
                    fileManager.AddAssembly(t, ass);
                    return true;
                }
                return false;
            });

            comboBox1.Items.AddRange(shapeTypes.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedType = comboBox1.SelectedItem as Type;
            if (selectedType != null)
            {
                var newShape = Activator.CreateInstance(
                    selectedType,
                    canvas1.Width / 2,
                    canvas1.Height / 2,
                    checkBox1.Checked,
                    button1.BackColor
                    ) as Shape;
                canvas1.AddShape(newShape);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button1.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Do you really want to destroy all your work?",
                "Are you sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                ) == DialogResult.Yes)
            {
                canvas1.ClearShapes();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            //sfd.FileName = ""; // default path
            sfd.Filter = "Shapes JSON (.json)|*.json";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                fileManager.SaveShapes(path, canvas1.Shapes);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Shapes JSON (.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                var shapes = fileManager.LoadShapes(path);
                int notLoadedCounter = 0;
                foreach (var shape in shapes)
                {
                    if (shape != null)
                        canvas1.AddShape(shape);
                    else
                        notLoadedCounter++;
                }
                if (notLoadedCounter > 0)
                {
                    MessageBox.Show($"{notLoadedCounter} objektů se nepodařilo načíst, protože chybí knihovny, ze kterých byly vytvořeny.");
                }
            }
        }

        private void addMoreShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Shapes Library (.dll)|*.dll";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string path = ofd.FileName;
                Assembly ass = fileManager.LoadAssemblyFromFile(path);

                if (ass != null)
                {
                    fileManager.CacheDll(path);
                    LoadTypesFromAssembly(ass);
                }
                else
                {
                    MessageBox.Show("Nepodařilo se načíst knihovnu " + path);
                }
            }
        }

        private void loadShapesFromAppDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Assembly> asses = fileManager.GetAllCachedDlls();
            asses.ForEach(ass => LoadTypesFromAssembly(ass));
        }

        private void UpdateLabel1()
        {
            label1.Text = $"Počet: {listBox1.Items.Count}";
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && listBox1.SelectedItem != null)
            {
                canvas1.CanvasContextMenuStrip.Show(listBox1, e.Location);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if (index >= 0 && index < listBox1.Items.Count)
            {
                canvas1.Shapes.ToList().ForEach(shape => shape.Highlight(false));

                var selectedShape = listBox1.Items[index] as Shape;
                if (selectedShape != null)
                {
                    selectedShape.Highlight(true);
                    canvas1.Invalidate();
                }
            }
        }
    }
}
