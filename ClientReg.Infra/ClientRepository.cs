using System;
using System.Collections.Generic;
using ClientAuth.Domain;

namespace ClientReg.Infra
{
    public class ClientRepository : IClientRepository
    {
        Dictionary<string, Client> ClientDB = new Dictionary<string, Client>();

        public void Add(Client client)
        {
            if (ClientDB.ContainsKey(client.CPF))
                throw new Exception("Client already exist");
            ClientDB.Add(client.CPF,client);
        }

        public void Delete(string CPF)
        {
            if (!ClientDB.Remove(CPF))
                throw new Exception("Nonexistent CPF.");
        }

        public Client GetByCPF(string CPF)
        {
            if(!ClientDB.ContainsKey(CPF))
                throw new Exception("Nonexistent CPF.");

            return ClientDB[CPF];
        }

        public void Update(Client client)
        {
            if (!ClientDB.ContainsKey(client.CPF))
                throw new Exception("Nonexistent CPF.");

            ClientDB[client.CPF] = client;
        }
    }
}
