﻿using BookLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLib
{
    public class Book : IBook
    {
        public IEnumerable<T_BOOK> ShowBooks()
        {
            return new List<T_BOOK>();
        }
    }
}