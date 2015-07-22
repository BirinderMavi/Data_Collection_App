using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TorontoVisitorSurvey.Model
{
    [Table("Users")]
    public class Users
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string age { get; set; }
        public string city { get; set; }
        public string province { get; set; }
    }
}
