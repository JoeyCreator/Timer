using System;
using System.Collections.Generic;
using System.Timers;

static class TimerExample
{
    static Timer _timer;
    static List<DateTime> _results = new List<DateTime>();

    public static void Start()
    {
        // Part 1: set up the timer for 3 seconds.
        var timer = new Timer(3000);
        // To add the elapsed event handler:
        // ... Type "_timer.Elapsed += " and press tab twice.
        timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
        timer.Enabled = true;
        _timer = timer;
    }

    static void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Part 2: add DateTime for each timer event.
        _results.Add(DateTime.Now);
    }

    public static void PrintTimes()
    {
        // Print all the recorded times from the timer.
        if (_results.Count > 0)
        {
            Console.WriteLine("TIMES:");
            foreach (var time in _results)
            {
                Console.Write(time.ToShortTimeString() + " ");
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        TimerExample.Start();
        // Part 3: call PrintTimes every 3 seconds.
        while (true)
        {
            // Print results.
            TimerExample.PrintTimes();
            // Wait 2 seconds.
            Console.WriteLine("WAITING");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
