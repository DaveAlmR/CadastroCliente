using System;
using System.Collections.Generic;

namespace ClientAuth.Domain
{
    public class Client : IClient
    {
        public string Name { get; private set; }
        public  string Birth { get; private set; }
        public List<string> Phone { get; private set; }
        public string Email { get; private set; }
        public string PostalCode { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }

        public void SetBirth(string Birth)
        {
            ValidateBirth(Birth);
            this.Birth = Birth;
        }

        public void SetCPF(string CPF)
        {
            ValidateCPF(CPF);
            this.CPF = CPF;
        }

        public void SetEmail(string Email)
        {
            ValidateEmail(Email);
            this.Email = Email;
        }

        public void SetName(string Name)
        {
            ValidateName(Name);
            this.Name = Name;
        }

        public void SetPhone(List<string> Phone)
        {
            foreach(string it in Phone)
                ValidatePhone(it);

            this.Phone = Phone;
        }

        public void SetPostalCode(string PostalCode)
        {
            ValidatePostalCode(PostalCode);
            this.PostalCode = PostalCode;
        }

        public void SetRG(string RG)
        {
            ValidateRG(RG);
            this.RG = RG;
        }

        public void ValidateBirth(string Birth)
        {
            string[] aux = new string[3];
            int a;

            if ((aux = Birth.Split('/')).Length != 3)
                throw new Exception("Wrong date format (dd/mm/aa)");

            foreach(string it in aux)
            {
                if (it.Length != 2 && it.Length != 4 || !int.TryParse(it, out a))
                    throw new Exception("Wrong Birth format (dd/mm/aa) '"+it+"'");
            }
        }

        public void ValidateCPF(string CPF)
        {
            long a;
            if (CPF.Length != 11 || !long.TryParse(CPF, out a))
                throw new Exception("Wrong CPF format");
        }

        public void ValidateEmail(string Email)
        {
            if (!Email.Contains("@") || !Email.Contains(".") || Email.Length < 10)
                throw new Exception("Wrong Email format");
        }

        public void ValidateInstance()
        {
            if (this.Name == null || this.Email == null || this.CPF == null)
                throw new Exception("Name, Email and CPF can't be null");
        }

        public void ValidateName(string Name)
        {
            if (Name.Length < 3)
                throw new Exception("Wrong Name format");
        }

        public void ValidatePhone(string Phone)
        {
            long a;
            if (Phone.Length != 12 || !long.TryParse(Phone, out a))
                throw new Exception("Wrong phone format (DDD9NNNNNNNN)");
        }

        public void ValidatePostalCode(string PostalCode)
        {
            long a;
            if (PostalCode.Length != 8 || !long.TryParse(PostalCode, out a))
                throw new Exception("Worng PostalCode Format");
        }

        public void ValidateRG(string RG)
        {
            long a;

            if (!long.TryParse(RG, out a))
                throw new Exception("Wrong RG format");
        }
    }
}
