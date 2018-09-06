using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongo1
{
    public partial class Form1 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("firstDB");
        static IMongoCollection<student> collection = db.GetCollection<student>("students");
        
        public void ReadAllDocuments()
        {
            List<student> list = collection.AsQueryable().ToList<student>();
            dataGridView1.DataSource = list;

            if (dataGridView1.Rows.Count>0)
            {
           
            textBox1.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();

            }
            

        }



        public Form1()
        {
            InitializeComponent();
            ReadAllDocuments();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Insert Value
            student s = new student (textBox2.Text, Double.Parse(textBox3.Text));
            collection.InsertOne(s);
            ReadAllDocuments();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update
            var updateDef = Builders<student>.Update.Set("name", textBox2.Text).Set("gpa", textBox3.Text);

            collection.UpdateOne(s => s.Id == ObjectId.Parse(textBox1.Text), updateDef);
            ReadAllDocuments();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Delete Option
            
            collection.DeleteOne(s=>s.Id == ObjectId.Parse(textBox1.Text));
            ReadAllDocuments();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
