using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CurrentBid { get; set; }
        public BidStatus BidStatus { set; get; }
        public string ActiveDue { get; internal set; }
    }
    public enum BidStatus
    {
        None,Higher,Lower
    }
}
