using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAuth.Domain
{
    public interface IClient
    {
        void SetName(string Name);
        void ValidateName(string Name);

        void SetBirth(string Birth);
        void ValidateBirth(string Birth);

        void SetPhone(List<string> Phone);
        void ValidatePhone(string Phone);

        void SetEmail(string Email);
        void ValidateEmail(string Email);

        void SetPostalCode(string PostalCode);
        void ValidatePostalCode(string PostalCode);

        void SetRG(string RG);
        void ValidateRG(string RG);

        void SetCPF(string CPF);
        void ValidateCPF(string CPF);

        void ValidateInstance();
    }
}
