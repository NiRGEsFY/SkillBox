using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic11.Classes
{
    public class HistoryPoint
    {
        public HistoryPoint() { }
        public HistoryPoint(string NameChanger,string NewContext,string OldContext, string ChangeProperty) 
        {
            this.OldContext = OldContext;
            this.NameChanger = NameChanger;
            this.NewContext = NewContext;
            this.ChangeProperty = ChangeProperty;
            this.ChangePoint = DateTime.Now;
        }
        public DateTime ChangePoint { get; set; }
        public string NameChanger { get; set; }
        public string NewContext {  get; set; }
        public string OldContext { get; set; }
        public string ChangeProperty {  get; set; }
    }
}
