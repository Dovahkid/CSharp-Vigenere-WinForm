using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using vignere_library;

namespace Vigenere_Form
{
    public partial class Form1 : Form
    {
        bool isEncrypting = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string strPlainText;
            string strKey;

            try
            {
                strPlainText = txtPlainText.Text.ToUpper();
                strKey = txtKey.Text.ToUpper();


                for (int i = 0; i <= strPlainText.Length - 1; i++)
                {
                    if (!vig.alphabet.Contains(strPlainText[i].ToString()))
                    {
                        strPlainText = strPlainText.Replace(strPlainText[i].ToString(), "");
                        
                        
                    }
                }

                for (int i = 0; i <= strKey.Length - 1; i++)
                {
                    if (!vig.alphabet.Contains(strKey[i].ToString()))
                    {
                        strKey = strKey.Replace(strKey[i].ToString(), "");
                        
                    }
                }

                switch (isEncrypting)
                {
                    case true:

                        lblOutput.Text = vig.encrypt(strPlainText, strKey);
                        break;
                    case false:

                        lblOutput.Text = vig.decrypt(strPlainText, strKey);
                        break;
                    default:
                        break;
                }
                
            }
            catch
            {
                lblStatus.Text = "Please enter a valid string.";
            }
            
        }

        private void radEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            isEncrypting = true;
        }

        private void radDecrypt_CheckedChanged(object sender, EventArgs e)
        {
            isEncrypting = false;
        }
    }
}
