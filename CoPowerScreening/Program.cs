using System;

namespace CoPowerScreening
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = new Line();
            var simA = new Sim(line);
            var simB = new Sim(line);

            var crashTest = new CrashTest(simA, simB);
            crashTest.Collide();
        }

    }
}
