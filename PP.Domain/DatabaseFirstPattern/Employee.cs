using System;
using System.Collections.Generic;

namespace PP.Domain.DatabaseFirstPatter
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Erole { get; set; }
        public string Office { get; set; }
    }
}
