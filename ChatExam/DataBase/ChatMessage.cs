//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatExam.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatMessage
    {
        public int ID { get; set; }
        public Nullable<int> Sender_ID { get; set; }
        public Nullable<int> Chatroom_ID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Message { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Sender Sender { get; set; }
    }
}
