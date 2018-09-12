using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Api.Maps;
using GoogleApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml;
using System.Xml.Linq;
using Google.Api.Maps.Service;
using System.IO;
using GoogleApi.Entities.Places.PlacesAutoComplete.Request;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace mongo1
{
    public partial class Form2 : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("firstDB");
        static IMongoCollection<booking> collection = db.GetCollection<booking>("booking");





        public Form2()
        {
            InitializeComponent();
            comboBox3.Text = DateTime.Now.ToString("hh:mm tt");


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        //autocomplete
        public List<string> OnGetAirportDetail(string name)
        {
            List<string> res = new List<string>();

            try
            {
                var _request = new PlacesAutoCompleteRequest
                {
                    ApiKey = "AIzaSyBifcB2Nk-unxkCqt2dlQo37Ikv2EFytVc",
                    Location = new GoogleApi.Entities.Maps.Common.Location(51.413984, -0.301012),

                    Input = name,

                    Language = "en",
                    Radius = 100

                };

                var _response = GoogleApi.GooglePlaces.AutoComplete.Query(_request);


                if (_response.Status == GoogleApi.Entities.Maps.Common.Enums.Status.OVER_QUERY_LIMIT)
                {

                }
                else if (_response.Status == GoogleApi.Entities.Maps.Common.Enums.Status.NOT_FOUND)
                {

                }
                else if (_response.Status == GoogleApi.Entities.Maps.Common.Enums.Status.ZERO_RESULTS)
                {

                }
                else if (_response.Status == GoogleApi.Entities.Maps.Common.Enums.Status.OK)
                {

                    var _results = _response.Predictions.DefaultIfEmpty();
                    _results = _response.Predictions.ToList();

                    foreach (var _result in _response.Predictions.Reverse())
                    {




                        res.Add(_result.Description.ToString());




                    }

                }


            }
            catch (Exception ex)
            {

            }
            return res;
        }
        private void textBox1_KeyUp_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (int)Keys.Enter)
                {

                    var autoCompleteListCollection = new AutoCompleteStringCollection();

                    autoCompleteListCollection.AddRange(OnGetAirportDetail(textBox1.Text.ToString()).ToArray());
                    textBox1.AutoCompleteCustomSource = autoCompleteListCollection;
                    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;

                }
            }
            catch (Exception ex)
            {

            }
        }


        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyValue == (int)Keys.Enter)
                {

                    var autoCompleteListCollection = new AutoCompleteStringCollection();

                    autoCompleteListCollection.AddRange(OnGetAirportDetail(textBox2.Text.ToString()).ToArray());
                    textBox2.AutoCompleteCustomSource = autoCompleteListCollection;
                    textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;
                    
                    

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                booking b = new booking(textBox1.Text, textBox2.Text, comboBox2.SelectedItem.ToString(), comboBox1.SelectedItem.ToString(), textBox3.Text, textBox4.Text, int.Parse(textBox6.Text), int.Parse(textBox5.Text),
                dateTimePicker1.Value.ToString());
                collection.InsertOne(b);

                //Clear Textbox
                textBox1.Text = "";
                textBox2.Text = "";
                this.comboBox1.SelectedItem = null;
                this.comboBox2.SelectedItem = null;
                textBox3.Text = "";
                textBox4.Text = "";
                textBox6.Text = "";
                textBox5.Text = "";
            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Enter only Numbers");
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {

            if ((e.KeyChar >= 48 && e.KeyChar <= 57 || e.KeyChar == 8))
            {
                e.Handled = false;
            }
            else
            {
                MessageBox.Show("Enter only Numbers");
                e.Handled = true;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length >= 1)
                {

                    var autoCompleteListCollection = new AutoCompleteStringCollection();

                    autoCompleteListCollection.AddRange(OnGetAirportDetail(textBox1.Text.ToString()).ToArray());
                    textBox1.AutoCompleteCustomSource = autoCompleteListCollection;
                    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text.Length > 0)
                {

                    var autoCompleteListCollection = new AutoCompleteStringCollection();

                    autoCompleteListCollection.AddRange(OnGetAirportDetail(textBox2.Text.ToString()).ToArray());
                    textBox2.AutoCompleteCustomSource = autoCompleteListCollection;
                    textBox2.AutoCompleteMode = AutoCompleteMode.Suggest;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 obj = new Form3();
            obj.Show();
            this.Hide();
        }

        

        


        }
    }


        
        
       
      
            

        
    


        




    


          

         

            

