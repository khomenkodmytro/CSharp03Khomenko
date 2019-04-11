﻿using System;

namespace Lab02Khomenko.Model
{
    public class Storage
    {
        public event Action<Person> PersonChanged;

        public Person Person { get; private set; }

        public void ChangeInfo(Person person)
        {
            Person = person;
            PersonChanged?.Invoke(person);
        }
    }
}
