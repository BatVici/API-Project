using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsweringMashine2.Core
{
    public  interface IAnsweringMachine
    {

        /// <summary>
        /// Adds introduction
        /// </summary>
        /// <param name="value"> The value of the introduction</param>
        /// <returns> The found introduction</returns>
        Intro AddIntroduction(string value);
        /// <summary>
        /// Adds reason
        /// </summary>
        /// <param name="value" >The value of the reason</param>
        /// <returns> The found reason</returns>
        Reason AddReason(string value);
        /// <summary>
        /// Adds available at(last part of the sentence/when can they reach me)
        /// </summary>
        /// <param name="value" >The value of the available at</param>
        /// <returns> The found last part of the sentence(when can they reach me )</returns>
        AvailableAt AddAvailableAt(string value);
        /// <summary>
        /// Retrieves a randomized answer 
        /// </summary>
        /// <returns>The randomized answer </returns>
        Answer GetAnswer();
        /// <summary>
        /// Retrieves a specific answer
        /// </summary>
        /// <param name="part">The part of the answer part</param>
        /// <param name="word" >The word of the answer part</param>
        /// <returns>An answer containing the specified word </returns>
        Answer GetSpecificAnswer(AnswerPart part, string word);
        /// <summary>
        /// Updates the answer part
        /// </summary>
        /// <param name="part" >The part of the answer part</param>
        /// <param name="id" >The id of the answer part</param>
        /// <param name="value" >The value of the answer part</param>
        void Update(AnswerPart part,string id,string value);
        /// <summary>
        /// Deletes the answer part
        /// </summary>
        /// <param name="part">The part of the answer part</param>
        /// <param name="id">The id of the answer part</param>
        void Delete(AnswerPart part,string id);
    }
}
