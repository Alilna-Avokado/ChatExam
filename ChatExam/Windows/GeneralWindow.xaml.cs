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
using System.Windows.Navigation;
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
            LVGChat.ItemsSource = db.Sender.ToList();
            
        }

        private void FinderBtn_Click(object sender, RoutedEventArgs e)
        {
            new EmpFinderWindow().Show();
            
        }

        private void CloseApplicBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LVGChat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var idChat = LVGChat.SelectedItem as Sender;
                var item = db.Chatroom.Where(x => x.ID == idChat.Chatroom_ID).FirstOrDefault();
                new ChatDialogWindow(item).Show();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show($"{ex}"); }
        }
    }
}
