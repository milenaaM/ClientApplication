using ClientApplication.Core.Entities;
using ClientApplication.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly Context _dbContext;

        public ClientRepository(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Add(Client client)
        {
            var newClient = new Client
            {
                Id = client.Id,
                Name = client.Name,
                BirthDate = client.BirthDate
            };

            foreach (var address in client.Addresses) {
                newClient.Addresses.Add(new Address { 
                    Name = address.Name,
                    AddressType = address.AddressType,
                    Id = address.Id
                });
            }

            _dbContext.Client.Add(newClient);
            _dbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            var client = _dbContext.Client.Where(c => c.Id == id).First();
            _dbContext.Client.Remove(client);
            _dbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public async Task<List<Client>> GetClients() => await _dbContext.Client.Include(c => c.Addresses).ToListAsync();

        public async Task<Client> GetClientById(int id) => await _dbContext.Client.FirstAsync(c => c.Id == id);

        public async Task Update(Client client)
        {
            var clientToUpdate = await _dbContext.Client.Where(c => c.Id == client.Id).FirstAsync();
            _dbContext.Client.Update(clientToUpdate);
            _dbContext.SaveChanges();
        }
    }
}
