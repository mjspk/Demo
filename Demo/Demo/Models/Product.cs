using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; internal set; }
    }
}
