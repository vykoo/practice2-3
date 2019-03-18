using System.Windows.Controls;
using Sukhoviy02.ViewModels;
using Sukhoviy02.Models;

namespace Sukhoviy02.Views
{
    /// <summary>
    /// Interaction logic for CalendarView.xaml
    /// </summary>
    public partial class CalendarView
    {

        private PersonViewModel _personViewModel;

        public CalendarView()
        {
            InitializeComponent();
            _personViewModel = new PersonViewModel();
            DataContext = _personViewModel;
        }
    }
}
