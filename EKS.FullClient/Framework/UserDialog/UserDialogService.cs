using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EKS.FullClient.Framework.UserDialog
{
    public class UserDialogService : IUserDialogService
    {
        private const string Title = "Elektroniczna Książka Serwisowa";


        public string SaveFile(string defauleFileName)
        {
            var fileDialog = new SaveFileDialog();
            fileDialog.FileName = defauleFileName;
            fileDialog.DefaultExt = ".xml";
            fileDialog.Filter = "XML document (.xml) | *.xml";

            Nullable<bool> outcome = fileDialog.ShowDialog();

            if (outcome == true)
            {
                return fileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        public string OpenFile()
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Filter = "XML document (.xml) | *.xml";

            Nullable<bool> outcome = fileDialog.ShowDialog();

            if (outcome == true)
            {
                return fileDialog.FileName;
            }
            else
            {
                return "";
            }
        }

        public void InformUser(string information)
        {
            MessageBox.Show(information, Title, MessageBoxButton.OK);
        }

        public bool AskForConfirmation(string information)
        {
            var result = MessageBox.Show(information, Title, MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
