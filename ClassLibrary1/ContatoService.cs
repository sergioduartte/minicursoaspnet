using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data.DatabaseContext;
using WebApi.Entidades;

namespace WebApi.Service
{
    public class ContatoService
    {
        private WebApiContext dbContext { get; set; }

        public ContatoService()
        {
            dbContext = new WebApiContext();
        }

        public Contato Create(Contato contato)
        {
            var created = dbContext.Contatos.Add(contato);
            dbContext.SaveChanges();
            return created;
        }

        public Contato Find(int id)
        {
            return dbContext.Contatos.Find(id);
        }

        public IEnumerable<Contato> FindAll()
        {
            return dbContext.Contatos.ToList();
        }

        public void Edit(Contato contato)
        {
            dbContext.Contatos.AddOrUpdate(contato);
        }

        public void Delete(Contato contato)
        {
            dbContext.Contatos.Remove(contato);
        }
    }
}
