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
            return CurrentPosition == Line.LastMarkedPosition.Value;
        }
        public void MarkPosition()
        {
            if (Line.LastMarkedPosition.Value == CurrentPosition)
                return;
            Line.LastMarkedPosition.Enqueue(CurrentPosition);
        }
        public void MoveLeft()
        {
            if (Line.LastMarkedPosition.Value == CurrentPosition - 1)
                return;

            CurrentPosition = CurrentPosition - 1;
            MarkPosition();
        }
        public void MoveRight()
        {
            if (Line.LastMarkedPosition.Value == CurrentPosition + 1)
                return;

            CurrentPosition = CurrentPosition + 1;
            MarkPosition();
        }
        public void Relax()
        {
            //Should probably print some form of status
        }
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

        public Line Line { get; private set; }
        public int CurrentPosition { get; private set; }
    }
}
