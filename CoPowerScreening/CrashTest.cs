using System;
using System.Collections.Generic;
using System.Text;

namespace CoPowerScreening
{
    public class CrashTest
    {
        public CrashTest(Sim simA, Sim simB)
        {
            SimA = simA;
            SimB = simB;
        }

        public void Collide()
        {            
            Console.WriteLine($"{nameof(SimA)}'s starting position is {SimA.CurrentPosition}");
            Console.WriteLine($"{nameof(SimB)}'s starting position is {SimB.CurrentPosition}");
            do
            {
                if (SimA.CurrentPosition % 100 == 0)
                {
                    Console.WriteLine($"{nameof(SimA)}'s position is {SimA.CurrentPosition}");
                }
                if (SimB.CurrentPosition % 100 == 0)
                {
                    Console.WriteLine($"{nameof(SimB)}'s position is {SimB.CurrentPosition}");
                }
                if (SimA.CurrentPosition <= SimB.CurrentPosition)
                {
                    SimA.MoveRight();
                    SimB.MoveLeft();
                }
                else if (SimA.CurrentPosition >= SimB.CurrentPosition)
                {
                    SimA.MoveLeft();
                    SimB.MoveRight();
                }

            } while (SimA.CurrentPosition != SimB.CurrentPosition);
            Console.WriteLine($"{nameof(SimA)}'s stopped at position {SimA.CurrentPosition}");
            Console.WriteLine($"{nameof(SimB)}'s stopped at position {SimB.CurrentPosition}");
            Console.ReadLine();
        }

        public Sim SimA { get; set; }
        public Sim SimB { get; set; }
    }
}
