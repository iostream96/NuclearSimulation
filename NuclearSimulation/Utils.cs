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
                int heightRatio;

                climStart = ran.Next(result.Count() - constant.climWidth);
                climHeight = constant.climHeightRange[ran.Next(constant.climHeightCount)];
                heightRatio = climHeight / constant.shapeMax;

                for (int i=0; i<constant.climWidth; i++)
                {
                    Point climPoint = new Point();

                    climPoint = result[i + climStart];
                    climPoint.Y = constant.yDown - constant.climShape[i] * heightRatio;
                    result[i + climStart] = climPoint;
                }
            }

            return result;
        }

        public static bool isTrigger()
        {
            Random ran = new Random();
            bool triggerFlag = false;
            double ranChance;

            ranChance = (double)ran.Next(1000) / 1000.0;
            if(ranChance<constant.singleChance)
            {
                triggerFlag = true;
            }

            return triggerFlag;
        }

        public static List<int> getSpectraData(int n, string nuclideType)
        {
            List<int> result = new List<int>();

            return result;
        }

    }
}
