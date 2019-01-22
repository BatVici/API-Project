using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsweringMashine2.Core
{
    public struct Intro
    {
        public Intro(string id, string value)
        {
            Id = id;
            Value = value;
        }

       
        public string Id { get; set; }
        public string Value { get; set; }
    }
}
