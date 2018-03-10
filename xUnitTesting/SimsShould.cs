using CoPowerScreening;
using System;
using Xunit;


namespace xUnitTesting
{
    public class SimsShould
    {
        [Fact]
        public void BeOnSameLine()
        {
            var line = new Line();
            var sim1 = new Sim(line);
            var sim2 = new Sim(line);

            Assert.Same(sim1.Line, sim2.Line);
        }

        [Fact]
        public void RelaxIfThereAreNoOtherSims()
        {
            var line = new Line();
            var sim = new Sim(line);

            var startingPosition = sim.CurrentPosition;

            sim.MoveRight();
            
            Assert.True(startingPosition == sim.CurrentPosition);
        }
    }
}
