using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WivernClient
{
    public partial class Debug : Form
    {
        PingChecker pc;
        public Debug(PingChecker pc)
        {
            InitializeComponent();
            this.pc = pc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var address = Convert.ToInt32(textBox1.Text);
            pc.Ping(address);
        }
    }
}
