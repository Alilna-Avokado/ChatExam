using ChatExam.DataBase;
using ChatExam.Windows;
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

namespace ChatExam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ChatTwoEntities db = new ChatTwoEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TBLogin.Text == String.Empty || TBPassword.Text == String.Empty)
            {
                MessageBox.Show("Введите данные!");
                return;
            }

            var auth = db.Employee.FirstOrDefault(x => x.UserName == TBLogin.Text && x.Password == TBPassword.Text);

            if (auth != null)
            {
                App.employee = auth;    
                new GeneralWindow().Show();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует!");
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
