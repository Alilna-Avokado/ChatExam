using ChatExam.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChatExam.Windows
{
    /// <summary>
    /// Логика взаимодействия для EmpFinderWindow.xaml
    /// </summary>
    public partial class EmpFinderWindow : Window
    {
        public ChatTwoEntities db = new ChatTwoEntities();
        public EmpFinderWindow()
        {
            InitializeComponent();
            LVDep.ItemsSource = db.Department.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = db.Sender.ToList();

            if (SearchTB.Text != String.Empty && SearchTB.Text != null)
            {
                search = db.Sender.Where(x => x.Name.Contains(SearchTB.Text)).ToList();
            }

            LVSender.ItemsSource = search;

        }
    }
}
