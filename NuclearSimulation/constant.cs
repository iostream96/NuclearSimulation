using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NuclearSimulation
{
    class constant
    {
        public const int xLeft = 100;
        public const int xRight = 850;
        public const int yUp = 50;
        public const int yDown = 400;
        public const int backgroundMax = 30;
        public const int deltaPoint = 3;
        public const double singleChance = 0.5;
        public static readonly int[] climShape = new int[37]{ 4, 4, 6, 8, 10, 14, 16, 20, 24, 29, 34, 38, 44, 48, 52, 55, 58, 60, 60, 60, 58, 55, 52, 48, 44, 38, 34, 29, 24, 20, 16, 14, 10, 8, 6, 4, 4 };
        public const int climWidth= 37;
        public const int shapeMax = 60;
        public static readonly int[] climHeightRange = new int[3] { 100, 170, 250 };
        public const int climHeightCount = 3;
        public const int delayTime = 500;
    }
}
