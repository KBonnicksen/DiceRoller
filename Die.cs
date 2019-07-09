using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRoller
{
    /// <summary>
    /// Represents a single multi-sided die
    /// </summary>
    class Die
    {
        private byte faceValue;
        private byte numberOfSides;
        private static Random rand;

        static Die()
        {
            //You will never call the static class in code, it 
            //will be called during runtime
            rand = new Random();
        }

        /// <summary>
        /// Creates a standart 6-sided die
        /// </summary>
        public Die() : this(6)
        {
        }

        /// <summary>
        /// Creates a die with the specified number of sides
        /// </summary>
        /// <param name="numberOfSides"></param>
        public Die(byte numberOfSides)
        {
            this.numberOfSides = numberOfSides;
            Roll();
        }

        public byte FaceValue
        {
            get { return faceValue; }
            private set //Because you only want to be able to set it within the class
            {
                if(value == 0)
                    throw new Exception("Die cannot be 0");

                faceValue = value;
            }
        }

        public bool IsHeld { get; set; }
 
        /// <summary>
        /// Rolls the die, sets face value to generated number 
        /// and returns generated number
        /// </summary>
        public byte Roll()
        {
            //if the die is held, return current face value
            if (IsHeld)
            {
                return FaceValue;
            }
            const byte MinDieValue = 1;

            //offset because of exclusice upper bound for random
            byte MaxDieValue = (byte)(numberOfSides + 1);

            byte result = (byte)rand.Next(MinDieValue, MaxDieValue);
            FaceValue = result;

            return result;
        }
    }
}
