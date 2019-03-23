using ClientAuth.Domain;
using ClientReg.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientRed.Win.UI
{
    public partial class UpdateForm : Form
    {
        ClientService service;
        public UpdateForm(ClientService service)
        {
            InitializeComponent();

            this.service = service;
            
            ZIPBox.Enabled = false;
            NameBox.Enabled = false;
            EmailBox.Enabled = false;
            BirthBox.Enabled = false;
            RGBox.Enabled = false;
            
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = service.GetByCPF(UpdateCPFBox.Text);

                ZIPBox.Text = client.PostalCode;
                NameBox.Text = client.Name;
                EmailBox.Text = client.Email;
                BirthBox.Text = client.Birth;
                RGBox.Text = client.RG;

                ZIPBox.Enabled = true;
                NameBox.Enabled = true;
                EmailBox.Enabled = true;
                UpdateCPFBox.Enabled = false;
                BirthBox.Enabled = true;
                RGBox.Enabled = true;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            if (UpdateCPFBox.Enabled)
            {
                MessageBox.Show("Before, do a search");
                return;
            }

            try
            {
                Client client = service.GetByCPF(UpdateCPFBox.Text);

                client.SetBirth(BirthBox.Text);
                client.SetCPF(client.CPF);
                client.SetEmail(EmailBox.Text);
                client.SetName(NameBox.Text);
                client.SetPostalCode(ZIPBox.Text);
                client.SetRG(RGBox.Text);

                service.Update(client);

                MessageBox.Show("Done");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (UpdateCPFBox.Enabled)
            {
                MessageBox.Show("Before, do a search");
                return;
            }

            try
            {
                service.Delete(UpdateCPFBox.Text);

                NameBox.Text = "";
                EmailBox.Text = "";
                BirthBox.Text = "";
                ZIPBox.Text = "";
                RGBox.Text = "";
                UpdateCPFBox.Text = "";

                ZIPBox.Enabled = false;
                NameBox.Enabled = false;
                EmailBox.Enabled = false;
                BirthBox.Enabled = false;
                RGBox.Enabled = false;
                UpdateCPFBox.Enabled = true;

                MessageBox.Show("Done");
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}

