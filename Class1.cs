using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCast
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Unix
    {
        public string fa { get; set; }
        public int en { get; set; }
    }

    public class Timestamp
    {
        public string fa { get; set; }
        public int en { get; set; }
    }

    public class Number
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Timezone
    {
        public string name { get; set; }
        public Number number { get; set; }
    }

    public class Season
    {
        public string name { get; set; }
        public Number number { get; set; }
    }

    public class Short
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Full2
    {
        public string fa { get; set; }
        public string en { get; set; }
        public Short @short { get; set; }
        public Official official { get; set; }
        public Unofficial unofficial { get; set; }
    }

    public class Hour
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Minute
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Second
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Microsecond
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Shift
    {
        public string @short { get; set; }
        public string full { get; set; }
    }

    public class Time12
    {
        public Hour hour { get; set; }
        public Minute minute { get; set; }
        public Second second { get; set; }
        public Microsecond microsecond { get; set; }
        public Shift shift { get; set; }
    }

    public class Time24
    {
        public Hour hour { get; set; }
        public Minute minute { get; set; }
        public Second second { get; set; }
    }

    public class Iso
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Usual
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Official
    {
        public Iso iso { get; set; }
        public Usual usual { get; set; }
    }

    public class Unofficial
    {
        public Iso iso { get; set; }
        public Usual usual { get; set; }
    }

    public class Gregorian
    {
        public Iso iso { get; set; }
        public Usual usual { get; set; }
    }

    public class Ghamari
    {
        public Iso iso { get; set; }
        public Usual usual { get; set; }
    }

    public class Other
    {
        public Gregorian gregorian { get; set; }
        public Ghamari ghamari { get; set; }
    }

    public class Days
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Percent
    {
        public string fa { get; set; }
        public string en { get; set; }
    }

    public class Agone
    {
        public Days days { get; set; }
        public Percent percent { get; set; }
    }

    public class Left
    {
        public Days days { get; set; }
        public Percent percent { get; set; }
    }

    public class Year
    {
        public string name { get; set; }
        public string animal { get; set; }
        public string leapyear { get; set; }
        public Agone agone { get; set; }
        public Left left { get; set; }
        public Number number { get; set; }
    }

    public class Month
    {
        public string name { get; set; }
        public string asterism { get; set; }
        public Number number { get; set; }
    }

    public class Local
    {
        public string text { get; set; }
        public bool holiday { get; set; }
    }
    public class holy
    {
        public string text { get; set; }
        public bool holiday { get; set; }
    }
    public class global
    {
        public string text { get; set; }
        public bool holiday { get; set; }
    }

    public class Events
    {
        public Local local { get; set; }
        public holy holy { get; set; }
        public global global { get; set; }
    }

    public class Day
    {
        public string name { get; set; }
        public Events events { get; set; }
        public Number number { get; set; }
    }

    public class Weekday
    {
        public string name { get; set; }
        public string champ { get; set; }
        public Number number { get; set; }
    }

    public class Date
    {
        public Other other { get; set; }
        public Year year { get; set; }
        public Month month { get; set; }
        public Day day { get; set; }
        public Weekday weekday { get; set; }
    }

    public class Root
    {
        public Unix unix { get; set; }
        public Timestamp timestamp { get; set; }
        public Timezone timezone { get; set; }
        public Season season { get; set; }
        public Time12 time12 { get; set; }
        public Time24 time24 { get; set; }
        public Date date { get; set; }
    }


}
