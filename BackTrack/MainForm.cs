﻿using EmilGraph.Graphs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EmilGraph
{
    public partial class MainForm : Form
    {
        string filename = "";
        GraphGUI graph;
        public MainForm()
        {
            InitializeComponent();
            picture.Image = new Bitmap(picture.Size.Width, picture.Size.Height);
            graph = new GraphGUI(picture, 30, 2);
            cmbBox.SelectedIndex = 0;
        }

        private void TopAdd_Click(object sender, EventArgs e)
        {
            topForm addForm = new topForm(picture.Size.Width, picture.Size.Height);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                graph.Add(addForm.point);
            }
        }

        private void FileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            graph.Clear();
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (graph.Load(open.FileName))
                {
                    MessageBox.Show("Файл успешно загружен!");
                    filename = open.FileName;
                }
                else
                {
                    MessageBox.Show("Загрузить файл не удалось!");
                }
            }
            open.Dispose();
        }

        private void FileCreate_Click(object sender, EventArgs e)
        {
            filename = "";
            graph.Clear();
        }

        private void TaskMenu_Click(object sender, EventArgs e)
        {
            using(TaskForm form = new TaskForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (form.topIndex < 0 || form.topIndex >= graph.Count || form.distance <= 0)
                {
                    MessageBox.Show("Введены некорректные данные!");
                    return;
                }
                graph.Task(form.topIndex, form.distance);
            }
        }

        private void TopDelete_Click(object sender, EventArgs e)
        {
            TopDelForm delForm = new TopDelForm(graph.Count - 1);
            if (delForm.ShowDialog() == DialogResult.OK)
            {
                graph.Delete(delForm.num);
            }
        }

        private void EdgeAdd_Click(object sender, EventArgs e)
        {
            EdgeForm edgeForm = new EdgeForm(graph.Count - 1);
            if (edgeForm.ShowDialog() == DialogResult.OK)
            {
                graph.Connect(edgeForm.tuple.Item1, edgeForm.tuple.Item2, edgeForm.tuple.Item3);
            }
        }

        private void EdgeDelete_Click(object sender, EventArgs e)
        {
            EdgeForm edgeForm = new EdgeForm(graph.Count - 1);
            if (edgeForm.ShowDialog() == DialogResult.OK)
            {
                graph.Disconnect(edgeForm.tuple.Item1, edgeForm.tuple.Item2);
            }
        }

        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbBox.SelectedIndex == 0)
            {
                graph.Add(new Point(e.X, e.Y));
            }
            else
            {
                graph.Delete(new Point(e.X, e.Y));
            }
        }

        private void FileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                graph.Save(saveFile.FileName);
            }
            saveFile.Dispose();
        }

        private void FileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                graph.Save(saveFile.FileName);
            }
            saveFile.Dispose();
        }
    }
}
