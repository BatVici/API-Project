using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsweringMashine2.Core
{
    public struct Answer
    {
        public Answer(string intro,string reason,string availableAt)
        {
            Intro = intro;
            Reason = reason;
            AvailableAt = availableAt;
        }

        public string Intro { get; set; }

        public string Reason { get; set; }

        public string AvailableAt { get; set; }

    }
}
