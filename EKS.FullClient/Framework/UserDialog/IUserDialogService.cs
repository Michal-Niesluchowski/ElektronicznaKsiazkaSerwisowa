using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKS.FullClient.Framework.UserDialog
{
    public interface IUserDialogService
    {
        string SaveFile(string defauleFileName);

        string OpenFile();

        void InformUser(string information);

        bool AskForConfirmation(string information);
    }
}
