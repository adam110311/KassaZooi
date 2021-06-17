using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FancyCashRegister.Domain.Models;
using FancyCashRegister.Services.Data;

namespace FancyCashRegister.Forms
{
    public partial class RapportageForm : Form
    {
        public RapportageForm()
        {
            InitializeComponent();
        }

        private void btnRapportAanmaken_Click(object sender, EventArgs e)
        {
            var datumVan = new DateTimeOffset( dtStart.Value);
            var datumTot = new DateTimeOffset(dtTot.Value);

            var bestandsnaam = txtBestandsnaam.Text;

            var orderRepo = new OrderRepository();

            IEnumerable<Order> ordersInPeriode = orderRepo.GetOrdersInPeriode(datumVan, datumTot);

            var rapportHeader = $"datum aanmaak;order id; aantal items; totaalprijs{Environment.NewLine}";

            File.WriteAllText(bestandsnaam, rapportHeader, Encoding.UTF8);

            foreach(var order in ordersInPeriode)
            {
                var regel = $"{order.DatumAanmaak:yyyy-MM-dd hh:mm};{order.OrderId};{order.Producten.Count()};{order.TotaalPrijs:C2}{Environment.NewLine}";
                File.AppendAllText(bestandsnaam, regel, Encoding.UTF8);
            }



        }

        private void btnKiesBestand_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtBestandsnaam.Text = ofd.FileName;
            }
        }

        private void RapportageForm_Load(object sender, EventArgs e)
        {
            vulBestandsnaamTextbox();
        }

        private void dtStart_ValueChanged(object sender, EventArgs e)
        {
            vulBestandsnaamTextbox();
        }

        private void dtTot_ValueChanged(object sender, EventArgs e)
        {
            vulBestandsnaamTextbox();
        }

        private void vulBestandsnaamTextbox()
        {
            txtBestandsnaam.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"overzicht_orers_{dtStart.Value:yyyyMMdd}_{dtTot.Value:yyyyMMdd}.csv");
        }
    }
}
