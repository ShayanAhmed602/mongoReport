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
using Microsoft.Reporting.WinForms;
using MongoDB.Driver.Builders;





namespace mongo1
{

    public partial class Form3 : Form
    {
        


        public Form3()
        {
            InitializeComponent();

        }

        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("firstDB");
        static IMongoCollection<booking> collection = db.GetCollection<booking>("booking");

        private void Form3_Load(object sender, EventArgs e)
        {
            
            var client = new MongoClient();

            IMongoDatabase db = client.GetDatabase("firstDB");

            var collection = db.GetCollection<BsonDocument>("booking");
            //var report = collection.Find(Builders<BsonDocument>.Filter.Ne("name", ""));



            var report1 = collection.Find(Builders<BsonDocument>.Filter.Ne("name", BsonNull.Value)).ToList();

                    if (report1.Count() > 0)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("name");
                dt.Columns.Add("to");
                dt.Columns.Add("from");
                dt.Columns.Add("vahicle");
                dt.Columns.Add("payment");

                dt.Columns.Add("msg");
                dt.Columns.Add("phone");
                dt.Columns.Add("order");
                dt.Columns.Add("Date");
              

             
                foreach (var item in report1)
                {  try
                {

                    dt.Rows.Add(item[1], item[2], item[3], item[4], item[5], item[6], item[7], item[8], item[9]);
                }
                catch (Exception eex)
                {
                    

                }
                }
             

                dt.TableName = "booking";

                DataSet1 ds = new DataSet1();
                try
                {
                    ds.Tables.Add(dt);
                    
                    

                }
                catch (Exception ec)
                {

                }

                
               
                //da.Fill(ds, "DataTable1");
                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[2]);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(datasource);
                this.reportViewer1.RefreshReport();

                           }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension,out streamids, out warnings);
            using (System.IO.FileStream fs = new System.IO.FileStream("C:\reports", System.IO.FileMode.Create))
            {
                fs.Write(bytes,0,bytes.Length);
            }






        }
    }
}



         
         
            

            
            
    
    
        
        

          


    


       
            
     
    
