using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFDocker
{
    public partial class Car : Window
    {

        public DateTime Booking { get; set; } = DateTime.Now;
        public Car()
        {
            
        }
    }
}