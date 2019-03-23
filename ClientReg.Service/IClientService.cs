using ClientAuth.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientReg.Service
{
    public interface IClientService
    {
        void Add(Client client);
        void Delete(string CPF);
        Client GetByCPF(string CPF);
        void Update(Client client);
    }
}
