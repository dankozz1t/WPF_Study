using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WPF_Study_ServerManager.Entity
{
    public class Group
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Student> Students { get; set; } = new List<Student>();
        public Teacher Teacher { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}