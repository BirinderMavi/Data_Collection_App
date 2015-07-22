using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorontoVisitorSurvey.Model
{
    class DB : SQLiteAsyncConnection
    {
        static public string GetDBPath()
        {
            return Path.Combine(Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "SurveyToronto.db");
        }

        public DB(string databasePath)
            : base(databasePath, true)
        {
        }

        public async Task Init()
        {
            await CreateTableAsync<Users>();
            await CreateTableAsync<SurveyInfoQuestions>();
        }
    }
}
