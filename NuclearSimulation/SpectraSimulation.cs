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
    public partial class SpectraSimulation : Form
    {
        bool startFlag = false;
        int x1 = constant.xLeft;
        int x2 = constant.xRight;
        int y1 = constant.yUp;
        int y2 = constant.yDown;
        int channelWidth = constant.channelWidth;
        Graphics gph;

        public SpectraSimulation()
        {
            InitializeComponent();
            gph = this.CreateGraphics();
            comboBox2.Text = "1";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startFlag==false)
            {
                string nuclideType;

                startFlag = true;
                nuclideType = comboBox1.Text;
                drawSpectra(nuclideType);
            }
            else
            {
                startFlag = false;
            }
        }

        private void drawSpectra(string nuclideType)
        {
            List<int> spectraData = new List<int>();
            List<int> channelData = new List<int>();
            Pen p = new Pen(Color.Blue, 1);

            drawTicks();
            spectraData = Utils.getSpectraData((x2-x1)/channelWidth, nuclideType);
            
            for(int i=0; i<constant.climHeightCount; i++)
            {
                channelData.Add(0);
            }

            foreach(int o in spectraData)
            {
                Rectangle toDraw = new Rectangle();

                channelData[o]++;
                toDraw.X = o * constant.channelWidth;
                toDraw.Y = channelData[o] * constant.countHeight;
                toDraw.Width = constant.channelWidth;
                toDraw.Height = constant.countHeight;
                gph.DrawRectangle(p, toDraw);
            }
        }

        private void drawTicks()
        {
            Pen p = new Pen(Color.Black, 1);

            gph.DrawLine(p, x1, y2, x2, y2);
            gph.DrawLine(p, x1, y2, x1, y1);
            
            return;
        }

    }
}
