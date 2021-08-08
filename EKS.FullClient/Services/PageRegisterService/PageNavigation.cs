using EKS.FullClient.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace EKS.FullClient.Services.PageNavaigationService
{
    public class PageNavigation : IPageNavigation
    {
        private List<PageItem> _pages = new List<PageItem>();

        public Page CurrentPage { get; private set; }

        public void Initialize()
        {
            RegisterPage("HomePage", new HomePage());
            RegisterPage("NewCar", new NewCarPage());
            var frame = (Frame)Window.;
        }

        public void NavigateToPage(string pageName)
        {
            CurrentPage = _pages.Where(pi => pi.Name == pageName).
                Select(pi => pi.Page).FirstOrDefault();
        }

        private void RegisterPage(string pageName, Page page)
        {
            _pages.Add(new PageItem(pageName, page));
        }
    }
}
