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
    public partial class InsertForm : Form
    {
        ClientService service;
        public InsertForm(ClientService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = new Client();

                client.SetRG(RGBox.Text);
                client.SetPostalCode(ZIPBox.Text);
                client.SetName(NameBox.Text);
                client.SetEmail(EmailBox.Text);
                client.SetCPF(CPFBox.Text);
                client.SetBirth(BirthBox.Text);

                service.Add(client);

                MessageBox.Show("Done");

                RGBox.Text = "";
                ZIPBox.Text = "";
                NameBox.Text = "";
                EmailBox.Text = "";
                CPFBox.Text = "";
                BirthBox.Text = "";

            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
