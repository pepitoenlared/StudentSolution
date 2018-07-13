using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class StudentBO : PersonBO
    {
        public TypeBO Type { get; set; }

        //public override void SetTime()
        //{
        //    base.SetTime();
        //}
    }
}
