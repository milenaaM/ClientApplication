using ClientApplication.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Core.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task Add(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }
}
