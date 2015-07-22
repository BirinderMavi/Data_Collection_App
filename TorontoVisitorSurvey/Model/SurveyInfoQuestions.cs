using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TorontoVisitorSurvey.Model
{
    [Table("Responses")]
    public class SurveyInfoQuestions
    {
        public string cntower { get; set; }
        public string ripley { get; set; }
        public string wonderland { get; set; }
        public string zoo { get; set; }
        public string rogers { get; set; }
    }
}
