﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1
{
    public class Author
    {
        public long Code { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTimeOffset DateOfBirth { get; }

        public Author(long code, string name, string surname, DateTimeOffset dateOfBirth)
        {
            Code = code;
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
        }

        public override bool Equals(Object obj)
        {
            if (!(obj is Author)) return false;
            return ((Author)obj).Code == Code;
        }
    }
}
