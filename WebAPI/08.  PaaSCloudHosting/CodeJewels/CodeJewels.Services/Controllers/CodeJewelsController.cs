using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CodeJewels.Models;
using CodeJewels.Data;

namespace CodeJewels.Services.Controllers
{
    public class CodeJewelsController : ApiController
    {
        private CodeJewelsContext db = new CodeJewelsContext();

        public IEnumerable<CodeJewel> GetCodeJewels()
        {
            return db.CodeJewels.AsEnumerable();
        }

        public IEnumerable<CodeJewel> GetCodeJewel(string code)
        {
            IEnumerable<CodeJewel> codeJewels = db.CodeJewels.Where(x => x.SourceCode.Contains(code));
            if (codeJewels == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return codeJewels;
        }

        public HttpResponseMessage PostCodeJewel(CodeJewel codejewel)
        {
            if (ModelState.IsValid)
            {
                db.CodeJewels.Add(codejewel);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, codejewel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = codejewel.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage PostVote(int id, bool voteUp)
        {
            var codeJewel = db.CodeJewels.FirstOrDefault(x => x.Id == id);
            if (codeJewel != null)
            {
                if (voteUp)
                {
                    codeJewel.Rating++;
                }
                else
                {
                    codeJewel.Rating--;
                }

                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }

            throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}