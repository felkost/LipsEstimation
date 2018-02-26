using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipsEstimation
{
    public class Lips
    {
        public float a, b, eps;
        private float x1, y1, x2, y2, x3, y3, x4, y4, x5, y5, x6, y6, x7, y7, x8, y8;
        public Lips(float x1, float y1,
                    float x2, float y2,
                    float x3, float y3,
                    float x4, float y4,
                    float x5, float y5,
                    float x6, float y6,
                    float x7, float y7,
                    float x8, float y8)
        {
            this.x1 = x1; this.y1 = y1; this.x2 = x2; this.y2 = y2; this.x3 = x3; this.y3 = y3;
            this.x4 = x4; this.y4 = y4; this.x5 = x5; this.y5 = y5; this.x6 = x6; this.y6 = y6;
            this.x7 = x7; this.y7 = y7; this.x8 = x8; this.y8 = y8;
        }

        public void BiuldModelLips()
        {
            List<float> lb = new List<float>();
            List<float> la = new List<float>();

            this.a = GetEllipseA() / 2.0f;
            this.b = GetEllipseB() / 2.0f;
            this.eps = GetEllipseEps(this.a, this.b);
        }

        private float GetEllipseA()
        {
            float d1 =(float)Math.Sqrt((x1-x5)*(x1-x5)+(y1-y5)*(y1-y5));
            float d2 = (float)Math.Sqrt((x2 - x6) * (x2 - x6) + (y2 - y6) * (y2 - y6));
            float d3 = (float)Math.Sqrt((x4 - x8) * (x4 - x8) + (y4 - y8) * (y4 - y8));
            return (d1 + d2 + d3) / 3.0f;
        }

        private float GetEllipseB()
        {
            float d1 = (float)Math.Sqrt((x3 - x7) * (x3 - x7) + (y3 - y7) * (y3 - y7));
            float d2 = (float)Math.Sqrt((x2 - x6) * (x2 - x6) + (y2 - y6) * (y2 - y6));
            float d3 = (float)Math.Sqrt((x4 - x8) * (x4 - x8) + (y4 - y8) * (y4 - y8));
            return (d1 + d2 + d3) / 3.0f;
        }

        private float GetEllipseEps(float a, float b)
        {
            if(a > b )
                return (float)Math.Sqrt(a - b) / (float)Math.Sqrt(a);
            else
                return (float)Math.Sqrt(b  - a ) / (float)Math.Sqrt(b);
        }
    }
}
