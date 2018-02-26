using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LipsEstimation
{
    #region class for JSON data in
    public class Dot
    {
        public float y { get; set; }
        public float x { get; set; }
        public string number { get; set; }
    }

    public class Face
    {
        public List<Dot> dots { get; set; }
        public int number { get; set; }
    }

    public class RootObjectIn
    {
        public List<Face> faces { get; set; }
    }
    #endregion

    #region class for JSON data out
    public class LipsOut
    {
        public int number { get; set; }
        public float a { get; set; }
        public float b { get; set; }
        public float eps { get; set; }
    }

    public class RootObjectOut
    {
        public List<LipsOut> faces { get; set; }
    }
    #endregion
}
