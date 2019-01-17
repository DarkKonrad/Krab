using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.dbTools;
using System.Diagnostics;
namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class ChangeDBCredentialsDialog : Form
    {
        public ChangeDBCredentialsDialog()
        {
            InitializeComponent();
            if(dbAgent.IsUsingDefaultCredentials == true)
            {
                checkBDefaultCred.Checked = true;
                checkBDefaultCred.CheckState = CheckState.Checked;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (checkBDefaultCred.CheckState == CheckState.Checked || checkBDefaultCred.Checked == true)        
                dbAgent.UseDefaultCredentials();
            else
                dbAgent.UseCustomCredentials(
                    txtServerAddr.Text,
                    txtDBName.Text,
                    txtUserName.Text,
                    txtDBPassword.Text);

            try
            {

            
                dbAgent.GetConnection().Open();
                if (dbAgent.GetConnection().Ping())
                    MessageBox.Show("Uzyskano odpowiedz serwera bazy danych, dane sa poprawne.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Brak odpowiedzi ze strony serwera. Dane są nieprawidłowe lub serwer jest uszkodzony", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.DialogResult = DialogResult.None;

                }

            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Error Code: " + ex.ErrorCode);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: ChangeDBCredentialsDialog_OK_CLICK");
                Debug.WriteLine(ex.TargetSite);

                MessageBox.Show("Brak odpowiedzi ze strony serwera. Dane są nieprawidłowe lub serwer jest uszkodzony", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Exception Message: " + ex.Message);
                Debug.WriteLine("Exception Source: " + ex.Source);
                Debug.WriteLine("ERROR: ChangeDBCredentialsDialog_OK_CLICK");
                Debug.WriteLine(ex.TargetSite);

                MessageBox.Show("Brak odpowiedzi ze strony serwera. Dane są nieprawidłowe lub serwer jest uszkodzony", "Uwaga", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.DialogResult = DialogResult.None;
            }

            finally
            {
                dbAgent.GetConnection().Close();
            }
            
        }
    }
}
