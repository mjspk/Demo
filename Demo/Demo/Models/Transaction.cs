using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Transaction
    {
        public Wallet Wallet { get; set; }  
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Name { get; set; }
        public double USD { get; set; }
        public int Unt { get; set; }
        public TransactionsStatus Status { get; set; }
        public DateTime Date { set; get; }= DateTime.Now;
        public string Hash { get; internal set; }
    }
    public enum TransactionsStatus
    {
        Pending,Failed,Sent,Received
    }
   
}
