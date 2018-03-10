using System;
using System.Collections.Generic;
using System.Text;

namespace CoPowerScreening
{
    /// <summary>
    /// ISim interface
    /// </summary>
    public interface ISim
    {
        /// <summary>
        /// Moves the sim character one unit on the line to the left
        /// </summary>
        void MoveLeft();
        /// <summary>
        /// Moves the sim character one unit on the line to the right
        /// </summary>
        void MoveRight(); 
        /// <summary>
        /// Commands the sim character to not do anything
        /// </summary>
        void Relax();
        /// <summary>
        /// Puts a mark on the line at the current position of the sim character
        /// </summary>
        void MarkPosition();
        /// <summary>
        /// Inspects the current position of the sim character for a mark and returns true if one is found, false if one is not found.
        /// </summary>
        /// <returns></returns>
        bool IsCurrentPositionMarked(); 
    }
}
