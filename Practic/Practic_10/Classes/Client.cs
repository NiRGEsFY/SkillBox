using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Practic_10.Classes
{
    public class Client : IClient, ISerializable
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string SubName { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PassportSerries{ get; set; }

        public DateTime LastChange {  get; set; }
        public string NameChanger { get; set; }
        public List<string> ChangedDate { get; set; }
        public string[] ChangedProperties { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FirstName", FirstName);
            info.AddValue("SecondName", SecondName);
            info.AddValue("SubName", SubName);
            info.AddValue("PhoneNumber", PhoneNumber);
            info.AddValue("PassportNumber", PassportNumber);
            info.AddValue("PassportSerries", PassportSerries);
            info.AddValue("LastChange", LastChange);
            info.AddValue("NameChanger", NameChanger);
            info.AddValue("ChangedDate", ChangedDate);
            info.AddValue("ChangedProperties", ChangedProperties);
        }
        public void Room(SerializationInfo info, StreamingContext context)
        {
            this.FirstName = info.GetValue("FirstName", typeof(String)) as string;
            this.SecondName = info.GetValue("SecondName", typeof(String)) as string;
            this.SubName = info.GetValue("SubName", typeof(String)) as string;
            this.PhoneNumber = info.GetValue("PhoneNumber", typeof(String)) as string;
            this.PassportNumber = info.GetValue("PassportNumber", typeof(String)) as string;
            this.PassportSerries = info.GetValue("PassportSerries", typeof(String)) as string;
            this.LastChange = (DateTime)info.GetValue("LastChange", typeof(DateTime));
            this.ChangedDate = info.GetValue("ChangedDate", typeof(List<string>)) as List<string>;
            this.NameChanger = info.GetValue("NameChanger", typeof(String)) as string;
            this.ChangedProperties = info.GetValue("ChangedProperties", typeof(string[])) as string[];
        }
    }
}
