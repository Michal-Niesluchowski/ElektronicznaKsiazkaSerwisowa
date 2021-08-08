using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Services.PageNavaigationService
{
    public interface IPageNavigation
    {
        Page CurrentPage { get; }

        void NavigateToPage(string pageName);

        void Initialize();
    }
}
