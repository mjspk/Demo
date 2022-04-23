using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Body { get; set; }
        public Severity Severity { get; set; }
        public NotificationType Type { set; get; }
    }
    public enum NotificationType
    {
        ProductOperations, SystemEvent, AuthorOperations, TokenOperations, Server,Wallet
    }
    public enum Severity
    {
        High, Mid, Low
    }
}
