using System;
using System.Collections.Generic;
using System.Text;

namespace ColorDataAccess.Model
{
    public class Color : IColor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public bool IsAvailable { get; set; }

        public Color()
        {

        }

        public Color(string name, string hexCode, bool isAvailable)
        {
            Name = name;
            HexCode = hexCode;
            IsAvailable = isAvailable;
        }

        public Color(int id, string name, string hexCode, bool isAvailable)
        {
            Id = id;
            Name = name;
            HexCode = hexCode;
            IsAvailable = isAvailable;
        }
    }
}
