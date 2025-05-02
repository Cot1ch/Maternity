using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;

namespace Maternity
{
    public partial class Form1 : Form
    {
        private Maternity maternity;
        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.ImageLocation = $"{Directory.GetCurrentDirectory()}\\..\\..\\resourses\\3938185.png";
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
        }


        private void DeserializeXML(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            if (!File.Exists(path))
            {
                MessageBox.Show($"Нет доступа к файлу: {path}");
                return;
            }

            try
            {
                MemoryStream rawData = new MemoryStream(File.ReadAllBytes(path));
                XmlSerializer xmls = new XmlSerializer(typeof(Maternity));
                maternity = (Maternity)xmls.Deserialize(rawData);

                LoadTreeNode(maternity);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка обработки XML данных");
            }
        }

        private void DeserializeJSON(string path)
        {
            if (!File.Exists(path))
            {
                MessageBox.Show($"Нет доступа к файлу: {path}");
                return;
            }

            try
            {
                maternity = JsonSerializer.Deserialize<Maternity>(File.ReadAllText(path));
                LoadTreeNode(maternity);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Ошибка обработки JSON данных");
            }

        }


        private void LoadTreeNode(Maternity maternity)
        {
            TreeNode node = new TreeNode(maternity.Name);

            var Bnode = new TreeNode("Заведующий");
            node.Nodes.Add(Bnode);

            var MNode = new TreeNode("Акушерки");
            node.Nodes.Add(MNode);

            var DNode = new TreeNode("Доктора");
            node.Nodes.Add(DNode);

            var PNode = new TreeNode("Пациенты");
            node.Nodes.Add(PNode);

            var CNode = new TreeNode("Дети");
            node.Nodes.Add(CNode);

            this.treeView1.Nodes.Add(node);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var treenode = this.treeView1.SelectedNode;

            if (treenode != null)
            {
                if (treenode.Text == "Акушерки")
                {
                    this.dataGridView1.DataSource = maternity.mids.midWives.ToList();
                }
                else if (treenode.Text== "Доктора")
                {
                    this.dataGridView1.DataSource = maternity.docs.docs.ToList();
                }
                else if (treenode.Text == "Пациенты")
                {
                    this.dataGridView1.DataSource = maternity.patients.patients.ToList();
                }
                else if (treenode.Text == "Дети")
                {
                    this.dataGridView1.DataSource = maternity.children.children.ToList();
                }
                else if (treenode.Text == "Заведующий")
                {
                    this.dataGridView1.DataSource = new { maternity.Boss.Id, maternity.Boss.Name, maternity.Boss.Surname};
                }
                if (this.dataGridView1.DataSource == null || this.dataGridView1.Columns.Count == 0)
                {
                    MessageBox.Show("Ошибка при выборе объекта");
                    return;
                }

                this.dataGridView1.RowHeadersVisible = false;
                this.dataGridView1.Columns[0].Visible = false;
                for (int i = 3; i < dataGridView1.Columns.Count; i++)
                {
                    this.dataGridView1.Columns[i].Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Ошибка!\nУзел пуст");
            }
        }

        private void buttonXML_Click(object sender, EventArgs e)
        {
            if (openFileDialogXML.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            DeserializeXML(openFileDialogXML.FileName);
        }

        private void buttonJSON_Click(object sender, EventArgs e)
        {
            if(openFileDialogJSON.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            DeserializeJSON(openFileDialogJSON.FileName);
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                switch (this.treeView1.SelectedNode.Text)
                {
                    case "Акушерки":
                        new FormInfo(maternity.mids.midWives.
                            Where(x => x.Id.ToString() == this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList()[0]).Show();
                        break;
                    case "Дети":
                        new FormInfo(maternity.children.children.
                            Where(x => x.Id.ToString() == this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList()[0]).Show();
                        break;
                    case "Доктора":
                        new FormInfo(maternity.docs.docs.
                            Where(x => x.Id.ToString() == this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList()[0]).Show();
                        break;
                    case "Пациенты":
                        new FormInfo(maternity.patients.patients.
                            Where(x => x.Id.ToString() == this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).ToList()[0]).Show();
                        break;
                    case "Заведующий":
                        new FormInfo(maternity.Boss).Show();
                        break;
                    default:
                        new FormInfo(null);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
