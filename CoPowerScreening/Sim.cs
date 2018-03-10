using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace CoPowerScreening
{
    public class Sim 
    {
        public Sim(Line line)
        {
            Line = line;
            CurrentPosition = GenerateRandomNumber();
            MarkPosition();
        }

        public bool IsCurrentPositionMarked()
        {
            return Line.Units[CurrentPosition].IsMarked;
        }

        public void MarkPosition()
        {
            var unitToMark = Line.Units?.FirstOrDefault(u => u.Value == CurrentPosition);
            if(unitToMark == null)
            {
                unitToMark = new Unit(CurrentPosition);
            }
            unitToMark.MarkUnit();
            Line.Units.Add(unitToMark);
        }

        public void MoveLeft()
        {
            var nextMarkedUnitToTheLeft = Line.Units.Last(u => u.Value < CurrentPosition);

            if (nextMarkedUnitToTheLeft == null)
                return;

            //see if unit exists
            var nextUnit = Line.Units.SingleOrDefault(u => u.Value == (CurrentPosition - 1));
            if (nextUnit != null)
            {
                if (nextUnit.IsMarked)
                {
                    //another sim is here or has been here
                    Relax();
                    return;
                }
            }
            else
            {
                CurrentPosition = CurrentPosition - 1;
                nextUnit = new Unit(CurrentPosition);
                nextUnit.MarkUnit();
                Line.Units.Add(nextUnit);
            }
        }
        public void MoveRight()
        {
            var nextMarkedUnitToTheRight = Line.Units.First(u => u.Value > CurrentPosition);

            if (nextMarkedUnitToTheRight == null)
                return;

            //see if unit exists
            var nextUnit = Line.Units.SingleOrDefault(u => u.Value == (CurrentPosition + 1));
            if (nextUnit != null)
            {
                if (nextUnit.IsMarked)
                {
                    //another sim is here or has been here
                    return;
                }
            }
            else
            {
                CurrentPosition = CurrentPosition + 1;
                nextUnit = new Unit(CurrentPosition);
                nextUnit.MarkUnit();
                Line.Units.Add(nextUnit);
            }
        }

        public void Relax()
        {
            //Should probably print some form of status
        }

        public Line Line { get; private set; }
        public int CurrentPosition { get; private set; }

        private int GenerateRandomNumber()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);

            //convert 4 bytes to an integer
            var randomInteger = BitConverter.ToUInt32(byteArray, 0);

            var byteArray2 = new byte[8];
            provider.GetBytes(byteArray2);

            //convert 8 bytes to a double
            return BitConverter.ToInt16(byteArray2, 0);
        }

    }
}
