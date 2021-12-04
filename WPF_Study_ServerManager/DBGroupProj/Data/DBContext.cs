using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WPF_Study_ServerManager.Entity
{
    [Serializable]
    public class DBContext
    {
        private DBContext() { }
        private static DBContext _instance;
        public static DBContext getInstance() => _instance ?? (_instance = new DBContext());

        public event Action<string> Notify;
        public event Action<string> Error;

        public string FileName = "myDb.xml";

        public List<Group> Groups { get; set; } = new List<Group>();

        public void Seed()
        {
            Teacher n1 = new Teacher() { FirstName = "Александр", SecondName = "Никитин", Item = "PHP" };
            Teacher n2 = new Teacher() { FirstName = "Иван", SecondName = "Долголуцкий", Item = "..." };

            Group pv011 = new Group() {Name = "PV011", Teacher = n2};
            pv011.Students.Add(new Student() { FirstName = "Дмитрий", SecondName = "Осипов", Progress = 11});
            pv011.Students.Add(new Student() { FirstName = "Андрей", SecondName = "Федоров", Progress = 10});

            Group pu011 = new Group() { Name = "PU011", Teacher = n1};
            pu011.Students.Add(new Student() { FirstName = "Алекс", SecondName = "Данько", Progress = 12});
            pu011.Students.Add(new Student() { FirstName = "Костя", SecondName = "Твердов", Progress = 12});

            Groups.Add(pv011);
            Groups.Add(pu011);
        }

        public void Load()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Group>));

            try
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    Groups = (List<Group>)formatter.Deserialize(fs);
                    Notify("Load Ok");
                }
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }


        public void Save()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Group>));

            try
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, Groups);
                    Notify("Save");
                }
            }
            catch (Exception e)
            {
                Error(e.Message);
            }
        }
    }
}