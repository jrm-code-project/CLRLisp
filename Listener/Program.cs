﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listener
{
    class Program
    {
        static void Main (string[] args) {
            object form = LispLib.Reader.Read ();
        }
    }
}
