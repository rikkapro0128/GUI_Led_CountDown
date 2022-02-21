using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace AppControllLedCountDown
{
    public partial class FormControll : Form
    {
        static SerialPort _serialPort;
        int[] listBraudRate = { 1200, 2400, 4800, 9600, 19200, 38400 };
        string[] listBoard = { "Arduino Mega", "PIC18F4550" };
        string[] ports;
        static string choosePort;
        static int chooseBraudrate;
        static bool isConneted = false;
        static int numSet = 99;
        static int stack;
        public FormControll()
        {
            InitializeComponent();
            ports = SerialPort.GetPortNames();
            initSerial(ports[0]);
            initValueForm();
        }

        private void formControllLoad(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.panel1.BackColor = Color.FromArgb(185, 185, 245);
            this.sevenSegmentsDisplay1.SegmentOffColor = Color.FromArgb(215, 215, 247);
        }

        public void initSerial(string portName)
        {
            _serialPort = new SerialPort();
            _serialPort.PortName = portName;
            _serialPort.BaudRate = listBraudRate[3];
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            chooseBraudrate = listBraudRate[3]; // set choose listBraudRate global
            choosePort = portName; // set choose choosePort global
        }

        public void initValueForm()
        {
            // select default for port
            metroComboBox1.Items.AddRange(ports);
            metroComboBox1.SelectedItem = choosePort;
            // select default for braudrate
            foreach(int braudrate in listBraudRate)
            {
                metroComboBox2.Items.Add(braudrate);
            }
            metroComboBox2.SelectedItem = chooseBraudrate;
            // defalault 7 segment
            this.sevenSegmentsDisplay1.Value = 0;
            // default numset 
            metroTextBox1.Text = numSet.ToString();
        }

        private void App_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void characterAnime_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rjButton3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rjButton5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chooseBraudrate = (int)metroComboBox2.SelectedItem;
            if (_serialPort.IsOpen)
            {
                MessageBox.Show("You must be Disconnect Port before connect same orther!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _serialPort.BaudRate = chooseBraudrate;
            }
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void sevenSegmentsDisplay1_Load(object sender, EventArgs e)
        {
            this.sevenSegmentsDisplay1.Value = 28;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    MessageBox.Show("Serial is conneted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else
                {
                    _serialPort.Open();
                    isConneted = true;
                    rjButton1.Enabled = false;
                    rjButton2.Enabled = true;
                    metroComboBox1.Enabled = false;
                    metroComboBox2.Enabled = false;
                    label7.Text = "Connected!";
                    label7.ForeColor = Color.ForestGreen;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Serial Can't Connect\n Please check connect!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_serialPort.IsOpen)
                {
                    _serialPort.Close();
                    isConneted = false;
                    rjButton2.Enabled = false;
                    rjButton1.Enabled = true;
                    metroComboBox1.Enabled = true;
                    metroComboBox2.Enabled = true;
                    label7.Text = "Disconnected!";
                    label7.ForeColor = Color.Firebrick;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Serial Can't Disconnect\n Please check connect!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            choosePort = metroComboBox1.SelectedItem.ToString();
            if(_serialPort.IsOpen) {
                MessageBox.Show("You must be Disconnect Port before connect same orther!", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {
                _serialPort.PortName = choosePort;
            }
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void sevenSegmentsDisplay1_Load_1(object sender, EventArgs e)
        {

        }

        private void metroTextBox1_Changed(object sender, EventArgs e)
        {
            try
            {
                if(metroTextBox1.Text == "")
                {
                    numSet = 0;
                }
                else
                {
                    numSet = int.Parse(metroTextBox1.Text);
                }
            }
            catch (Exception)
            {
                metroTextBox1.Text = numSet.ToString();
            }
        }

        async private void rjButton6_Click(object sender, EventArgs e)
        {
            stack = int.Parse(metroTextBox1.Text);
            if (stack >= 0 && stack < 100)
            {
                while (true)
                {
                    this.sevenSegmentsDisplay1.Value = stack;
                    await Task.Delay(100);
                    stack--;
                    if (stack < 0)
                    {
                        break;
                    }
                }
            }else
            {
                MessageBox.Show("This range is 0 to 99!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
