using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EKS.FullClient.Services.PageNavaigationService
{
    internal class PageItem
    {
        public string Name { get; set; }

        public Page Page { get; set; }

        public PageItem(string name, Page page)
        {
            this.Name = name;
            this.Page = page;
        }
    }
}
