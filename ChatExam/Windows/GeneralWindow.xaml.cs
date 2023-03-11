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
    /// Логика взаимодействия для GeneralWindow.xaml
    /// </summary>
    public partial class GeneralWindow : Window
    {
        public ChatTwoEntities db = new ChatTwoEntities();
        public GeneralWindow()
        {
            InitializeComponent();
            LVGChat.ItemsSource = db.ChatMessage.ToList();
            
        }

        private void FinderBtn_Click(object sender, RoutedEventArgs e)
        {
            new EmpFinderWindow().Show();
            
        }

        private void CloseApplicBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
