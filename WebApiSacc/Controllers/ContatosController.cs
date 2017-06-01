using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Entidades;
using WebApi.Service;

namespace WebApiSacc.Controllers
{
    [EnableCors(origins:"*", headers:"*", methods:"*")]
    public class ContatosController : ApiController
    {
        private ContatoService contatoService = new ContatoService();

        private class Result
        {
            public IList<Contato> data { get; set; }
        }

        // GET: api/Contatos
        public IHttpActionResult Get()
        {
            var result = new Result { data = contatoService.FindAll().ToList() };
            return Ok(result);
        }
        
        // GET: api/Contatos/5
        public Contato Get(int id)
        {
            return contatoService.Find(id);
        }

        // POST: api/Contatos
        public void Post([FromBody]Contato contato)
        {
            contatoService.Create(contato);
        }

        // PUT: api/Contatos/5
        public void Put(int id, [FromBody]Contato contato)
        {
            contatoService.Edit(contato);
        }

        // DELETE: api/Contatos/5
        public void Delete(Contato contato)
        {
            contatoService.Delete(contato);
        }
    }
}
