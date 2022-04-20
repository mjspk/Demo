using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; internal set; }
        public string Initl { get; internal set; }
        public Color Color { get; internal set; }
    }
}
