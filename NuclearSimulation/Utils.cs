using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NuclearSimulation
{
    class Utils
    {
        public static List<Point> getPoint(int n, bool triggerFlag)
        {
            Random ran = new Random();
            List<Point> result = new List<Point>();

            for(int i=0; i<n; i++)
            {
                Point p = new Point();

                p.X = constant.xLeft + i * constant.deltaPoint;
                p.Y = constant.yDown - ran.Next(constant.backgroundMax);
                result.Add(p);
            }

            if(triggerFlag==true)
            {
                int climStart;
                int climHeight;

                climStart = ran.Next(constant.xLeft, constant.xRight - constant.climWidth);
                climHeight = constant.climHeightRange[ran.Next(3)];
            }

            return result;
        }

        public static bool isTrigger()
        {
            Random ran = new Random();
            bool triggerFlag = false;

            if(ran.Next(1000)/1000<constant.singleChance)
            {
                triggerFlag = true;
            }

            return triggerFlag;
        }



    }
}
