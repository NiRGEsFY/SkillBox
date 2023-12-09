using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Practic11.Classes
{
    public class History
    {
        private string _way;
        public List<HistoryPoint> points { get; private set; }
        public History() 
        {
            _way = "History.txt";
            points = new List<HistoryPoint>();
            LoadHistory();
        }
        ~History()
        {
            SaveHistory();
        }
        public void AddPoint(string NameChanger, string NewContext, string OldContext, string ChangeProperty)
        {
            HistoryPoint point = new HistoryPoint(NameChanger, NewContext, OldContext, ChangeProperty);
            points.Add(point);
        }
        public void SaveHistory() 
        {
            var mySerializer = new XmlSerializer(typeof(List<HistoryPoint>));
            using (var stream = new FileStream(_way, FileMode.OpenOrCreate)) 
            {
                mySerializer.Serialize(stream, points);
            }
        }
        private void LoadHistory()
        {
            var mySerializer = new XmlSerializer(typeof(List<HistoryPoint>));
            try
            {
                using (var file = new FileStream(_way, FileMode.OpenOrCreate))
                {
                    points = mySerializer.Deserialize(file) as List<HistoryPoint>;
                }
            }
            catch
            {

            }
        }
    }
}
