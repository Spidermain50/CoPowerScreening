using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;

namespace CoPowerScreening
{
    public class Line
    {
        private List<Unit> _units;

        public Line()
        {
            _units = new List<Unit>();
        }

        
        public List<Unit> Units
        {
            get
            {
                _units = _units.OrderBy(u => u.Value).ToList();
                return _units;
            }
            set
            {
                _units = value;
            }
        }
    }

    public class Unit
    {
        public Unit(int value)
        {
            Value = value;            
        }
        public void MarkUnit()
        {
            IsMarked = true;
        }
            
        public int Value { get; set; }
        public bool IsMarked { get; set; }
    }

}
