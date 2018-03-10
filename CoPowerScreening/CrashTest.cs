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
            do
            {
                if (SimA.CurrentPosition % 1000 == 0)
                {
                    Console.WriteLine($"{nameof(SimA)}'s position is {SimA.CurrentPosition}");
                }
                if (SimB.CurrentPosition % 1000 == 0)
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
                else
                {
                    SimA.Relax();
                    SimB.Relax();
                }

            } while (SimA.CurrentPosition != SimB.CurrentPosition);
        }

        private List<Action> MovementActions { get; set; }
        public Sim SimA { get; set; }
        public Sim SimB { get; set; }
    }
}
