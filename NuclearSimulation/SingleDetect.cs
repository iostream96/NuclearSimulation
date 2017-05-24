using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NuclearSimulation
{
    public partial class SingleDetect : Form
    {
        bool startFlag = false;
        int x1 = constant.xLeft;
        int x2 = constant.xRight;
        int y1 = constant.yUp;
        int y2 = constant.yDown;
        int backgroundMax = constant.backgroundMax;
        int deltaPoint = constant.deltaPoint;
        Graphics gph;
        int triggerY = constant.yUp;

        public SingleDetect()
        {
            InitializeComponent();
            gph = this.CreateGraphics();
            comboBox1.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(startFlag==false)
            {
                startFlag = true;
                drawOSC();
            }
            else
            {
                startFlag = false;
            }
        }

        private void drawOSC()
        {
            bool overTriggerFlag = false;

            while(overTriggerFlag == false)
            {
                int speedRatio;

                gph.Clear(Color.White);
                drawTicks(gph);
                drawTrigger(gph, triggerY);
                overTriggerFlag = drawWave(gph, Utils.isTrigger());

                int.TryParse(comboBox1.Text, out speedRatio);
                Delay(constant.delayTime/speedRatio);
            }
        }

        private void drawTicks(Graphics gph)
        {
            Pen p = new Pen(Color.Black, 1);
            for(int i=x1; i<= x2; i+=(x2 - x1)/5)
            {
                gph.DrawLine(p, i, y1, i, y2);
            }

            for (int i = y1; i <= y2; i += (y2 - y1) / 5)
            {
                gph.DrawLine(p, x1, i, x2, i);
            }

            return;
        }

        private void drawTrigger(Graphics gph, int y)
        {
            Pen p = new Pen(Color.Yellow, 2);

            gph.DrawLine(p, x1, y, x2, y);
            
            return;
        }

        private bool drawWave(Graphics gph, bool triggerFlag)
        {
            bool overTriggerFlag = false;
            int climMax = y2;
            Pen p = new Pen(Color.Blue, 2);

            List<Point> toDraw = new List<Point>();
            Point prev = new Point();

            toDraw = Utils.getPoint((x2 - x1) / deltaPoint, triggerFlag);
            prev = toDraw[0];

            foreach(Point o in toDraw)
            {
                gph.DrawLine(p, prev, o);
                prev = o;
                if (o.Y<climMax)
                {
                    climMax = o.Y;
                }
            }

            if (climMax<triggerY)
            {
                overTriggerFlag = true;
            }

            return overTriggerFlag;
        }

        private void SingleDetect_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Point mouse;
            mouse = PointToClient(MousePosition);
            triggerY = mouse.Y;
        }

        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < milliSecond)
            {
                Application.DoEvents();
            }
        }
    }
}