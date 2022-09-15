using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Emtities
{
    public class Students
    {
        public string  Firtname { get; set; }
        public string Lastname { get; set; }
        public string Fathername { get; set; }
        public DateTime BirthDate { get; set; }
        public int Id { get; set; }
    }
}
