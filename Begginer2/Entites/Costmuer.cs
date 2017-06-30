using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Begginer2.Entites
{
    public class Costmuer
    {
        public Int32 ID { get; set; }
        public String Fname { get; set; }
        public String Mname { get; set; }
        public String Lname { get; set; }
        public String Address { get; set; }
        public String ContactNumber { get; set; }
        public Decimal CreditLimit { get; set; }
    }
}