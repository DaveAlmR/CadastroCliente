using System;
using System.Collections.Generic;
using ClientAuth.Domain;
using ClientReg.Infra;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClientAuth.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidUser()
        {
            Client client = new Client();
            List<string> phones = new List<string>();

            client.SetBirth("15/03/1999");
            client.SetCPF("04777951103");
            client.SetEmail("davimelo72@gmail.com");
            client.SetName("David de Melo");
            phones.Add("062986182772");
            phones.Add("062912345678");
            client.SetPhone(phones);
            client.SetPostalCode("74000000");
            client.SetRG("6473364");

            Assert.AreEqual(client.Birth, "15/03/1999");
            Assert.AreEqual(client.CPF, "04777951103");
            Assert.AreEqual(client.Email, "davimelo72@gmail.com");
            Assert.AreEqual(client.Name, "David de Melo");
            Assert.AreEqual(client.PostalCode, "74000000");
            Assert.AreEqual(client.RG, "6473364");
            Assert.AreEqual(client.Phone, phones);
        }

        [TestMethod]
        public void InValidUser()
        {
            IClient client = new Client();
            List<string> phones = new List<string>();

            Assert.ThrowsException<Exception>(() => client.SetBirth("15/a3/199"));
            Assert.ThrowsException<Exception>(() => client.SetCPF("abcdeasds"));
            Assert.ThrowsException<Exception>(() => client.SetEmail("emailinvalido"));
            Assert.ThrowsException<Exception>(() => client.SetName("aa"));
            phones.Add("telefoneinvalido");
            phones.Add("telefoneinvalido");
            Assert.ThrowsException<Exception>(() => client.SetPhone(phones));
            Assert.ThrowsException<Exception>(() => client.SetPostalCode("inv"));
            Assert.ThrowsException<Exception>(() => client.SetRG("inv"));
        }

        [TestMethod]
        public void ValidInfra()
        {
            IClientRepository Rep = new ClientRepository();
            Client client = new Client();
            List<string> phones = new List<string>();

            client.SetBirth("15/03/1999");
            client.SetCPF("04777951103");
            client.SetEmail("davimelo72@gmail.com");
            client.SetName("David de Melo");
            phones.Add("062986182772");
            phones.Add("062912345678");
            client.SetPhone(phones);
            client.SetPostalCode("74000000");
            client.SetRG("6473364");

            Rep.Add(client);
            Assert.AreEqual(client, Rep.GetByCPF(client.CPF));

            client.SetName("David Almeida");
            Rep.Update(client);
            Assert.AreEqual(Rep.GetByCPF(client.CPF).Name, client.Name);

            Rep.Delete(client.CPF);
            Assert.ThrowsException<Exception>(() => Rep.GetByCPF(client.CPF));
        }
    }
}
