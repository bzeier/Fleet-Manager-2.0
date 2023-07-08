using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FleetManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            label2.Text = Program.hostWeb.BaseAddresses[0].ToString();
            label4.Text = Program.hostWeb.Description.Endpoints.Count.ToString();
            label10.Text = Program.Version;
        }

        public void UpdateFleets()
        {
            label7.Text = FleetInstancer.GetFleets().Count.ToString();
        }

        public void UpdateRequestLog()
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Clear();
                foreach (string item in Program.APIRequestsLog)
                {
                    listBox1.Items.Add(item.ToString());
                }
            }));

        }

        public void UpdateFleetOverview()
        {
            this.Invoke(new Action(() =>
            {
                listBox2.Items.Clear();
                foreach (Fleet fleet in FleetInstancer.GetFleets())
                {
                    string newfleet = fleet.MyName + "    | " + fleet.MyIPAdress + ":" + fleet.MyPort + "    | " + fleet.MyState.ToString();
                    listBox2.Items.Add(newfleet);
                }
            }));

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FleetInstancer.ShutDownAllFleets();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(label2.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FleetInstancer.RunNewFleet();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FleetInstancer.ShutDownAllFleets();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
