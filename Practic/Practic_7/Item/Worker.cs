using Practic_7.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_7
{
    public struct Worker
    {
        private uint id;

        public uint Id 
        {
            set 
            {
                if (value <= 0)
                    id = 1;
                else
                    id = value;  
            }
            get 
            { 
                return id; 
            }
        }

        public DateTime CreateTime;

        public FullName FullName;

        public uint Age;

        public uint Height;

        public DateTime BurnTime;

        public string BurnPlace;
    }
}
