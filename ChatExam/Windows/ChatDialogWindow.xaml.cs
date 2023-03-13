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
    /// Логика взаимодействия для ChatDialogWindow.xaml
    /// </summary>
    public partial class ChatDialogWindow : Window
    {
        public ChatTwoEntities db = new ChatTwoEntities();
        public Chatroom chatroomm;
        public ChatDialogWindow(Chatroom chatroom)
        {
            InitializeComponent();
            chatroomm = chatroom;
            TopicInChatTB.Text = chatroomm.Topic;
            LVChatMemb.ItemsSource = db.Sender.Where(x => x.ID == chatroomm.ID).ToList();
            LVChatDialog.ItemsSource = db.ChatMessage.Where(x => x.Chatroom_ID == chatroomm.ID).ToList();

        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ChatMessage chatMessage = new ChatMessage();
            {
                chatMessage.Sender_ID = App.employee.ID;
                chatMessage.Chatroom_ID = chatroomm.ID;
                chatMessage.Date = DateTime.Now;
                chatMessage.Message = ChatTB.Text;
            }
            db.ChatMessage.Add(chatMessage);
            db.SaveChanges();
            LVChatDialog.ItemsSource = db.ChatMessage.Where(x => x.Chatroom_ID == chatroomm.ID).ToList();
            ChatTB.Text = "";
        }

        private void ExitChat_Click(object sender, RoutedEventArgs e)
        {
            new GeneralWindow().Show();
            this.Close();
            
        }
    }
}
