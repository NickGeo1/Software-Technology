using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DietApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Random rnd= new Random();
            string id = rnd.Next(999999).ToString().PadLeft(6, '0');
            textBox4.Text = id;
        }


    }
}
