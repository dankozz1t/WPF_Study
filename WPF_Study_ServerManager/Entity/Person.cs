using System;

namespace WPF_Study_ServerManager.Entity
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + SecondName;
        }
    }
}