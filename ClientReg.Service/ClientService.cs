using System;
using ClientAuth.Domain;
using ClientReg.Infra;

namespace ClientReg.Service
{
    public class ClientService : IClientService
    {
        ClientRepository ClientRep = new ClientRepository();

        public void Add(Client client)
        {
            client.ValidateInstance();
            ClientRep.Add(client);
        }

        public void Delete(string CPF)
        {
            ClientRep.Delete(CPF);
        }

        public Client GetByCPF(string CPF)
        {
            return ClientRep.GetByCPF(CPF);
        }

        public void Update(Client client)
        {
            client.ValidateInstance();
            ClientRep.Update(client);
        }
    }
}
