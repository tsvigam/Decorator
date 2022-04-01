using System;
using System.Collections;

namespace Decorator
{
    public class Human
    {
        public static int Age;
        public static double MaxPulse;

        public static double Algoritm1(int Age)
        {
            return MaxPulse = 220 - Age;
        }

        public static double Algoritm2(int Age)
        {
            return MaxPulse = 205.8 - (0.685 * Age);
        }
    }

    public abstract class Watch
    {
        public string Name { get; protected set; }
        private ArrayList features = new ArrayList();

        public Watch(string n)
        {
            features.Add("Measure Rate Advantage");
            features.Add("Show Time");
            this.Name = n;
        }

        public void ShowTime()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay.ToString());
        }
        public abstract double MeasureRate();

        public virtual ArrayList getFeatures()
        {
            return new ArrayList(features);
        }
    }
    public class WatchActive : Watch
    {
        public WatchActive(int age) : base("WatchActiv")
        {
            Human.Age = age;

        }

        public override double MeasureRate()
        {
            return Human.Algoritm1(Human.Age);
        }
    }

    public class WatchClassic : Watch
    {
        public WatchClassic(int age) : base("WatchClassic")
        {
            Human.Age = age;
        }

        public override double MeasureRate()
        {
            return Human.Algoritm2(Human.Age);
        }
    }

    public abstract class Decorator : Watch
    {
        protected Watch watch;

        public void SetWatch(Watch w)
        {
            watch = w;
        }

        public Decorator(string n, Watch w) : base(n)
        {
            SetWatch(w);
        }

        public override double MeasureRate()
        {
            if (watch != null)
                return watch.MeasureRate();
            else
                return 0;
        }
    }

    public class NfcDecorator : Decorator
    {
        public ArrayList exFeaturesNfc = new ArrayList();
        public NfcDecorator(Watch w) : base(w.Name + " with Nfc func", w)
        { }

        public override ArrayList getFeatures()
        {
            ArrayList newList = new ArrayList(watch.getFeatures());
            newList.Add("Nfc Function");
            return newList;
        }
    }

    public class CallDecorator : Decorator
    {
        public ArrayList exFeaturesCall { get; private set; } = new ArrayList();
        public CallDecorator(Watch w) : base(w.Name + " with Call func", w)
        { }

        public override ArrayList getFeatures()
        {
            ArrayList newList = new ArrayList(watch.getFeatures());
            newList.Add("CallFunction");
            return newList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Watch w1 = new WatchClassic(23);
            Console.WriteLine(w1.MeasureRate());
            w1 = new NfcDecorator(w1);
            w1 = new CallDecorator(w1);
            foreach (string s in w1.getFeatures())
                Console.WriteLine(s);
            Console.WriteLine(w1.Name);
        }
    }
}
