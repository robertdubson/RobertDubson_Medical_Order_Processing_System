using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic;
using DataModel;
namespace Mappers
{
    public class ClientMapper : IMapper<ClientEntity, Client>
    {
        public ClientEntity FromDomainToEntity(Client example)
        {
            return new ClientEntity(example.ID, example.Name, example.LocationID, example.PasswordHash, example.UserName, example.Phone, example.EMail);
        }

        public Client FromEntityToDomain(ClientEntity example)
        {
            return new Client(example.ID, example.ClientName, example.Phone, example.EMail, example.LocationID, example.PasswordHash, example.UserName);
        }

        public ClientEntity NewExample(Client example)
        {
            return new ClientEntity(example.PasswordHash, example.Name, example.UserName, example.LocationID, example.Phone, example.EMail);
        }
    }
}
