using System;
using System.Windows.Forms;

namespace Maternity
{
    public partial class FormInfo : Form
    {
        public FormInfo(object o)
        {
            InitializeComponent();


            LoadForm(o);
        }
        /// <summary>
        /// Отображение формы Подробнее
        /// </summary>
        /// <param name="o"></param>
        private void LoadForm(object o)
        {
            if (o is Doctor)
            {
                this.labelType.Text = "Доктор";
                var doc = (Doctor)o;

                this.textBoxName.Text = doc.Name;
                this.textBoxSurName.Text = doc.Surname;
                this.textBoxSex.Text = doc.Sex;
                this.textBoxBD.Text = doc.BirthDate;
                this.label5.Text = "Пациенты";
                this.dataGridViewItems.DataSource =
                    new { Имя = doc.Patient, Роды = doc.Patient };
            }
            else if (o is MidWife)
            {
                this.labelType.Text = "Акушер";
                var mf = (MidWife)o;
                this.textBoxName.Text = mf.Name;
                this.textBoxSurName.Text = mf.Surname;
                this.textBoxSex.Text = mf.Sex;
                this.textBoxBD.Text = mf.BirthDate;
                this.label5.Text = "Пациенты";
                this.dataGridViewItems.DataSource =
                    new { Имя = mf.Patient, Роды = mf.Patient };
            }
            else if (o is Patient)
            {
                this.labelType.Text = "Пациент";
                var p = (Patient)o;

                this.textBoxName.Text = p.Name;
                this.textBoxSurName.Text = p.Surname;
                this.textBoxSex.Text = p.Sex;
                this.textBoxBD.Text = p.BirthDate;
                this.label5.Text = "Дети";
                this.dataGridViewItems.DataSource =
                    new { Имя = p.Child, Роды = p.Child };
            }
            else if (o is Child)
            {
                this.labelType.Text = "Ребёнок";
                var c = (Child)o;

                this.textBoxName.Text = c.Name;
                this.textBoxSurName.Visible = false;
                this.textBoxSex.Visible = false;
                this.textBoxBD.Text = c.BirthDate;
                this.labelSex.Visible = false;
                this.label5.Visible = false;
                this.dataGridViewItems.Visible = false;
            }
            else if (o is Boss)
            {
                this.labelType.Text = "Директор";
                var b = (Boss)o;

                this.textBoxName.Text = b.Name;
                this.textBoxSurName.Text = b.Surname;
                this.textBoxSex.Text = b.Sex;
                this.textBoxBD.Text = b.BirthDate;
                this.label5.Visible = false;
                this.dataGridViewItems.Visible = false;
            }
            else
            {
                MessageBox.Show("Такого поля нет!");
                this.Close();
            }
        }
    }
}
