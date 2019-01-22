using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsweringMashine2.Core
{
   public class InMemoryAnsweringMashineProvider
    {
        
        private static InMemoryAnsweringMachine answeringMachine;
        /// <summary>
        /// Shows the default Intro,Reason and Available at.This is the memory of the machine so everytime it will start with the dafault values.
        /// </summary>
        /// <param name="defaultIntro">This is the default Intro</param>
        /// <param name="defaultReason">This is the default Reason</param>
        /// <param name="defaultAvailableAt"> This is the default Available At</param>
        /// <returns></returns>
        public static InMemoryAnsweringMachine Get(string defaultIntro, string defaultReason, string defaultAvailableAt)
        {
            if (answeringMachine == null) answeringMachine = new InMemoryAnsweringMachine(defaultIntro, defaultReason, defaultAvailableAt);

            return answeringMachine;
        }
    }
}
