using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AnsweringMashine2.Core;
using AnsweringMashine2.Exceptions;

namespace AnsweringMachineREST.Controllers
{
    public class AnswerController : ApiController
    {
        private IAnsweringMachine machine = InMemoryAnsweringMashineProvider.Get("Hello there, ", "I am busy right now, ", "call me later.");

        // GET api/values
        public HttpResponseMessage Get()
        {
            var answer = machine.GetAnswer();

            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }

        [HttpGet]
        [Route("api/answer/addIntro")]
        public HttpResponseMessage AddIntro([FromUri] string value)
        {
            try
            {
                machine.AddIntroduction(value);
            }
            catch(AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/answer/addReason")]
        public HttpResponseMessage AddReason([FromUri] string value)
        {
            try
            {
                machine.AddReason(value);
            }
            catch (AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/answer/addAvailableAt")]
        public HttpResponseMessage AddAvailableAt([FromUri] string value)
        {
            try
            {
                machine.AddAvailableAt(value);
            }
            catch (AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post()
        {
            var answer = machine.GetAnswer();

            return Request.CreateResponse(HttpStatusCode.OK, answer);
        }


        [HttpPost]
        [Route("api/answer/addIntro")]
        public HttpResponseMessage NewIntro([FromUri] string value)
        {
            try
            {
                machine.AddIntroduction(value);
            }
            catch (AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/answer/addReason")]
        public HttpResponseMessage NewReason([FromUri] string value)
        {
            try
            {
                machine.AddReason(value);
            }
            catch (AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("api/answer/addAvailableAt")]
        public HttpResponseMessage NewAvailableAt([FromUri] string value)
        {
            try
            {
                machine.AddAvailableAt(value);
            }
            catch (AnswerPartAlreadyExistException e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
