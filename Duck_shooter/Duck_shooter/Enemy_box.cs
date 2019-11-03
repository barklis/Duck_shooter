using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Duck_shooter
{
    class Enemy_box : System.Windows.Controls.StackPanel
    {
        int hp;
        double x;
        double y;
        double speed;

        public int Hp { get => hp; set => hp = value; }
        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Speed { get => speed; set => speed = value; }
    }

    
}
