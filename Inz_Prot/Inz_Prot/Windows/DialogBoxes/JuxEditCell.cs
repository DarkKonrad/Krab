using Inz_Prot.Models.dbCustomTable;
using Inz_Prot.Windows.SpecifiedControlls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inz_Prot.dbHelpers.TableEditors;

namespace Inz_Prot.Windows.DialogBoxes
{
    public partial class JuxEditCell : Form
    {
        CustomTableDialogControls dialogControls;
        string EditedVal = "";
        public JuxEditCell(ColumnInfo info)
        {
            InitializeComponent();
            dialogControls = new CustomTableDialogControls(mainPanel, info);
        }
        private bool IsInputDataCorrect()
        {
             if (dialogControls.Type == TypeCode.Int32)
              {
                    if (!Utilities.isStringNumber(dialogControls.TxtInputValue.Text) || dialogControls.TxtInputValue.Text == "")
                    {
                        WriteErrorAndHighlightRow(dialogControls, "W polu liczbowym niedozwolone są znaki alfabetu");

                        return false;
                    }
              }

                if (dialogControls.Type == TypeCode.String)
                {
                    if (dialogControls.TxtInputValue.Text.Length > dbHelpers.NamesTypes.MAKS_DESCRIPTION_LENGHT)
                    {
                        WriteErrorAndHighlightRow(dialogControls, " Tekst przekracza maksymalną długość." + Environment.NewLine + "Maksymalna długość to 2048 znaków");
                        return false;
                    }
                }

                if (dialogControls.Type == TypeCode.Char)
                {
                    if (Utilities.StringContainsSpecialChars(dialogControls.TxtInputValue.Text) || dialogControls.TxtInputValue.Text == "")
                    {
                        WriteErrorAndHighlightRow(dialogControls, "Znaki specjalne są niedozwolone");
                        return false;
                    }
                    if (dialogControls.TxtInputValue.Text.Length > dbHelpers.NamesTypes.MAKS_SHORTTEXT_LENGHT)
                    {
                        WriteErrorAndHighlightRow(dialogControls, " Tekst przekracza maksymalną długość." + Environment.NewLine + "Maksymalna długość to 80 znaków");
                        return false;
                    }
                }
            
            return true;
        }
        private void WriteErrorAndHighlightRow(CustomTableDialogControls dialogControls, string message)
        {
            lblError.Text = message;
            lblError.Visible = true;
            dialogControls.ContainerPanel.BackColor = Color.Red;

        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Abort;
            if (!IsInputDataCorrect())
                return;

            DialogResult = DialogResult.OK;
            EditedVal= dialogControls.ValueString;
        }

        public string GetValue()
        {
            return EditedVal;
        }
    }
}
