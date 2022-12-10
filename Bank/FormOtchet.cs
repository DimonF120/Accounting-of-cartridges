using System;
using System.Windows.Forms;

namespace Bank
{
    public partial class FormOtchet : Form
    {        
        FormMenu f = (FormMenu)System.Windows.Forms.Application.OpenForms["FormMenu"];

        public FormOtchet()
        {
            InitializeComponent();
            textBoxKatr.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonKatr_Click(object sender, EventArgs e)
        {
            FormDGVOtchet f = new FormDGVOtchet();
            this.Close();
        }
    }
}