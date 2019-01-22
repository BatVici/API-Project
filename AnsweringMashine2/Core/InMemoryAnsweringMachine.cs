using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnsweringMashine2.Exceptions;


namespace AnsweringMashine2.Core
{   
    public class InMemoryAnsweringMachine : IAnsweringMachine
    {
        
        private string DefaultIntro { get; }
        private string DefaultReason { get; }
        private string DefaultAvailableAt { get; }

        private List<Intro> intros;
        private List<Reason> reasons;
        private List<AvailableAt> availableAts;

        
        public InMemoryAnsweringMachine()
        {
            intros = new List<Intro>();
            reasons = new List<Reason>();
            availableAts = new List<AvailableAt>();
        }
        /// <summary>
        /// The default value of Intro,Reason,Available At
        /// </summary>
        /// <param name="defaultIntro"> The default value of Intro</param>
        /// <param name="defaultReason">The default value of Reason</param>
        /// <param name="defaultAvailableAt">The default value of Available at</param>
        public InMemoryAnsweringMachine(string defaultIntro, string defaultReason, string defaultAvailableAt)
               : this()
        {
            DefaultIntro = defaultIntro;
            DefaultReason = defaultReason;
            DefaultAvailableAt = defaultAvailableAt;
        }

       /// <summary>
       /// Adding new availableAt
       /// </summary>
       /// <param name="value"> The value of the new Available At</param>
       /// <returns></returns>
        public AvailableAt AddAvailableAt(string value)
        {
          
            if (availableAts.FindAll(it => it.Value.Equals(value)).Count > 0) throw new AnswerPartAlreadyExistException();

            var id = Guid.NewGuid().ToString();
            var availableAtPart = new AvailableAt(id, value);

            availableAts.Add(availableAtPart);

            return availableAtPart;

        }
        /// <summary>
        /// Adding new Introduction
        /// </summary>
        /// <param name="value"> The value of the new instruction</param>
        /// <returns></returns>
        public Intro AddIntroduction(string value)
        {
            if (intros.FindAll(it => it.Value.Equals(value)).Count > 0) throw new AnswerPartAlreadyExistException();

            var id = Guid.NewGuid().ToString();
            var introPart = new Intro(id, value);

            intros.Add(introPart);

            return introPart;
        }
        /// <summary>
        /// Adding new reason
        /// </summary>
        /// <param name="value"> The value of the new reason</param>
        /// <returns></returns>
        public Reason AddReason(string value)
        {
            if (reasons.FindAll(it => it.Value.Equals(value)).Count > 0) throw new AnswerPartAlreadyExistException();

            var id = Guid.NewGuid().ToString();
            var reasonPart = new Reason(id, value);

            reasons.Add(reasonPart);

            return reasonPart;
        }
        /// <summary>
        /// Deletes the answerParts
        /// </summary>
        /// <param name="part"> The part of the answer part</param>
        /// <param name="id">The id of the answer part</param>
        public void Delete(AnswerPart part, string id)
        {
        
            switch(part)
            {
                case AnswerPart.Intro :
                    var intro = intros.FindAll(it => it.Id == id);
                    if (intro.Count == 0) throw new AnswerPartNotFoundException();
                    intros.Remove(intro.First());
                    break;

                case AnswerPart.Reason:
                    var reason = reasons.FindAll(it => it.Id == id);
                    if (reason.Count == 0) throw new AnswerPartNotFoundException();
                    reasons.Remove(reason.First());
                    break;

                case AnswerPart.AvailableAt:
                    var availableAt = availableAts.FindAll(it => it.Id == id);
                    if (availableAt.Count == 0) throw new AnswerPartNotFoundException();
                    availableAts.Remove(availableAt.First());
                    break;
            }
        }
       
        public Answer GetAnswer()
        {
            
            var answer = new Answer();
            var randomizer = new Random();
  
            if (intros.Count == 0) answer.Intro = DefaultIntro;
            else answer.Intro = intros.ElementAt(randomizer.Next(0, intros.Count - 1)).Value;

            if (reasons.Count == 0) answer.Reason = DefaultReason;
            else answer.Reason = reasons.ElementAt(randomizer.Next(0, reasons.Count - 1)).Value;

            if (availableAts.Count == 0) answer.AvailableAt = DefaultAvailableAt;
            else answer.AvailableAt = availableAts.ElementAt(randomizer.Next(0, intros.Count - 1)).Value;

            return answer;
        }
        /// <summary>
        /// Gets a specified answer(if there is a new part added it prints it,the others remain default)
        /// </summary>
        /// <param name="part">The part of the answer</param>
        /// <param name="word">The word</param>
        /// <returns></returns>
        public Answer GetSpecificAnswer(AnswerPart part, string word)
        {
            var defaultAnswer = GetAnswer();

            switch (part)
            {
                case AnswerPart.Intro:
                    var intro = intros.FindAll(it => it.Value.Contains(word));
                    if (intro.Count == 0) return defaultAnswer;
                    else return new Answer(intro.First().Value, defaultAnswer.Reason, defaultAnswer.AvailableAt);

                case AnswerPart.Reason:
                    var reason = reasons.FindAll(it => it.Value.Contains(word));
                    if (reason.Count == 0) return defaultAnswer;
                    else return new Answer(defaultAnswer.Intro, reason.First().Value, defaultAnswer.AvailableAt);

                case AnswerPart.AvailableAt:
                    var availableAt = availableAts.FindAll(it => it.Value.Contains(word));
                    if (availableAt.Count == 0) return defaultAnswer;
                    else return new Answer(defaultAnswer.Intro, defaultAnswer.Reason, availableAt.First().Value);

                default:
                    return defaultAnswer;
            }
        }
        /// <summary>
        /// Adds new Intro,Reason and available at
        /// </summary>
        /// <param name="part">The part of the answer</param>
        /// <param name="id">The id of the answer</param>
        /// <param name="value">The value of the answer</param>
        public void Update(AnswerPart part, string id, string value)
        {
            switch (part)
            {
                case AnswerPart.Intro:
                    var intro = intros.FindAll(it => it.Id == id);
                    if (intro.Count == 0) throw new AnswerPartNotFoundException();
                    intros.Remove(intro.First());
                    intros.Add(new Intro(id, value));
                    break;

                case AnswerPart.Reason:
                    var reason = reasons.FindAll(it => it.Id == id);
                    if (reason.Count == 0) throw new AnswerPartNotFoundException();
                    reasons.Remove(reason.First());
                    reasons.Add(new Reason(id, value));
                    break;

                case AnswerPart.AvailableAt:
                    var availableAt = availableAts.FindAll(it => it.Id == id);
                    if (availableAt.Count == 0) throw new AnswerPartNotFoundException();
                    availableAts.Remove(availableAt.First());
                    availableAts.Add(new AvailableAt(id, value));
                    break;
            }
        }
    }
}
