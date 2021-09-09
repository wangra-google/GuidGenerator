using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace GuidGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MD5 md5Hash = MD5.Create();

        public string CounterName
        {
            get;
            set;
        }

        public string CounterDesc
        {
            get;
            set;
        }

        public Guid GuidHash
        {
            get
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(CounterName + CounterDesc));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                Guid guid = new Guid(sBuilder.ToString());
                return guid;
            }
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            CounterName = NameTextBox.Text;
            CounterDesc = DescriptionTextBox.Text;

            Guid guid = GuidHash;
            GuidTextBox.Text = guid.ToString();
        }
    }
}
