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
    public partial class MainForm : Form
    {
        ClientService service = new ClientService();

        public MainForm()
        {
            InitializeComponent();
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            InsertForm insert = new InsertForm(service);
            insert.ShowDialog();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            UpdateForm update = new UpdateForm(service);
            update.ShowDialog();
        }
    }
}
