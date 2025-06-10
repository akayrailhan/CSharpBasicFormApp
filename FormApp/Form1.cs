using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FormAppEntities db = new FormAppEntities();
 
        private void btnList_Click(object sender, EventArgs e)
        {
            var customers = db.Guide.ToList();
            dataGridView1.DataSource = customers;

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = textBox2.Text;
            guide.GuideSurname = textBox3.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Guide added succesfully");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var guide = db.Guide.Find(id);
            if (guide != null)
            {
                db.Guide.Remove(guide);
                db.SaveChanges();
                MessageBox.Show("Guide deleted succesfully");
            }
            else
            {
                MessageBox.Show("Guide not found");
            }

        }

        private void getListById_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var guide = db.Guide.Find(id);
            if (guide != null)
            {
                dataGridView1.DataSource = new List<Guide> { guide };
            }
            else
            {
                MessageBox.Show("Guide not found");
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            var guide = db.Guide.Find(id);
            if (guide != null)
            {
                guide.GuideName = textBox2.Text;
                guide.GuideSurname = textBox3.Text;
                db.SaveChanges();
                MessageBox.Show("Guide updated succesfully");
            }
            else
            {
                MessageBox.Show("Guide not found");
            }

        }
    }
}
