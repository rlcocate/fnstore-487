using FN.Store.Data.EF.Repository;
using FN.Store.Domain.Entities;
using FN.Store.Domain.Repositories;
using System.Linq;
using System.Web.Http;

namespace FN.Store.Api.Controllers
{
    public class ODataController : ApiController
    {
        private readonly IClienteRepository _clienteRepo = new ClienteRepository();

        [Queryable]
        public IQueryable<Cliente> Get()
        {
            return _clienteRepo.ObterOData();
        }
        
        protected override void Dispose(bool disposing)
        {
            _clienteRepo.Dispose();
        }
    }
}