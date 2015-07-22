using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using SQLite;
using System.Collections.ObjectModel;
using TorontoVisitorSurvey.Model;

namespace TorontoVisitorSurvey
{
    class InfoLogic:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DB db;
        private ObservableCollection<SurveyInfoQuestions> ocUsers;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ObservableCollection<SurveyInfoQuestions> UserCollection
        {
            get { return ocUsers; }
        }

        public async Task Init()
        {
            db = new DB(DB.GetDBPath());
            await db.Init();

            AsyncTableQuery<SurveyInfoQuestions> atqu = db.Table<SurveyInfoQuestions>();
            List<SurveyInfoQuestions> lUsers = await atqu.ToListAsync();
            ocUsers = new ObservableCollection<SurveyInfoQuestions>(lUsers);
        }

        public async Task CreateResponse(string Cntower, string Ripley, string Wonderland, string Zoo, string Rogers)
        {
            SurveyInfoQuestions x = new SurveyInfoQuestions() { cntower = Cntower, ripley = Ripley, wonderland = Wonderland, zoo = Zoo, rogers = Rogers };
            ocUsers.Add(x);
            await db.InsertAsync(x);
        }

        private string cntower;
        public string CnTower
        {
            get { return cntower; }
            set { cntower = value; OnPropertyChanged("CnTower"); }
        }

        private string ripley;
        public string Ripley
        {
            get { return ripley; }
            set { ripley = value; OnPropertyChanged("Ripley"); }
        }

        private string wonderland;
        public string Wonderland
        {
            get { return wonderland; }
            set { wonderland = value; OnPropertyChanged("Wonderland"); }
        }

        private string zoo;

        public string Zoo
        {
            get { return zoo; }
            set { zoo = value; OnPropertyChanged("Zoo"); }
        }
        private string rogers;

        public string Rogers
        {
            get { return rogers; }
            set { rogers = value; OnPropertyChanged("Rogers"); }
        }
    }
}
