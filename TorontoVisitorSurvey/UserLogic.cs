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
    class UserLogic:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        DB db;
        private ObservableCollection<Users> ocUsers;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public ObservableCollection<Users> UserCollection
        {
            get { return ocUsers; }
        }

        public async Task Init()
        {
            db = new DB(DB.GetDBPath());
            await db.Init();

            AsyncTableQuery<Users> atqu = db.Table<Users>();
            List<Users> lUsers = await atqu.ToListAsync();
            ocUsers = new ObservableCollection<Users>(lUsers);
        }

        public async Task CreateUser(string firstName, string lastName, string Age, string City, string Province)
        {
            Users u = new Users() { firstname = firstName, lastname = lastName, age=Age, city=City , province=Province };
            ocUsers.Add(u);
            await db.InsertAsync(u);
        }

        private string firstname;
        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged("FirstName"); }
        }

        private string lastname;
        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged("LastName"); }
        }

        private string age;
        public string Age
        {
            get { return age; }
            set { age = value; OnPropertyChanged("Age"); }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }
        private string province;

        public string Province
        {
            get { return province; }
            set { province = value; OnPropertyChanged("Province"); }
        }

        
    }
}
