using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;

namespace MP3_Player
{
    class EffectNode
    {
        static public bool CreateNew = false;
        public Point Effect_p;
        public string Effect_describe;
        public EffectNode(Point p)
        {
            Effect_p = p;
        }
    }
}
