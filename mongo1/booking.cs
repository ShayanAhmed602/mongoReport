using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;


namespace mongo1
{
    class booking
    {
        [BsonElement("to")]
        public String To{get;set;}

        [BsonElement("from")]
        public String From{get;set;}

        [BsonElement("vahicle")]
        public String Vahicle { get; set; }

        [BsonElement("payment")]
        public String Payment { get; set; }

        //datetime left

        [BsonElement("name")]
        public String Name { get; set; }
        
        [BsonElement("msg")]
        public String Msg { get; set; }

        [BsonElement("phone")]
        public int Phone { get; set; }

        [BsonElement("order")]
        public int Order { get; set; }

        [BsonElement("Date")]
       
        public string Date { get; set; }



        public booking(string to, string from,string vahicle,string payment,string name,string msg,int phone,int order,
            string date)
        {
            To=to;
            From=from;
            Vahicle = vahicle;
            Payment = payment;
            Name = name;
            Msg = msg;
            Phone = phone;
            Order = order;
            Date = date;



        
        }




    }
}
