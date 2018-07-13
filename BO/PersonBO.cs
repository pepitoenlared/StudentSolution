using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BO
{
    public abstract class PersonBO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char Gender { get; set; }
        //public DateTime Time { get; set; }
        public string Time { get; set; }

        public virtual void SetTime()
        {
            this.Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        public virtual void SetTime(string time)
        {
            //CultureInfo MyCultureInfo = new CultureInfo("de-DE");
            //this.Time = DateTime.Parse(time, MyCultureInfo);
            this.Time = DateTime.ParseExact(time, "yyyyMMddHHmmss", CultureInfo.InvariantCulture).ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
