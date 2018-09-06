using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;



namespace mongo1
{
    class student
    {
    [BsonId]
        public ObjectId Id {get; set;}
    [BsonElement("name")]
    public String Name {get; set;}
    [BsonElement("gpa")]
    public Double GPA {get; set;}

    public student(string name, double gpa)
    {
    
    Name= name;
    GPA=gpa;

    }




    }
}
