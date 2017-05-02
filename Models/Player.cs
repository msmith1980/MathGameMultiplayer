using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public sealed class Player
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public int TimeElapsed { get; set; }

        public List<PlayerMathOperation> MathOps { get; set; }

        public Player()
        {
            MathOps = new List<PlayerMathOperation>();
        }
    }
}
