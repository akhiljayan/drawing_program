using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canvas
{
    public class Canvas
    {
        private int _Width { get; set; }

        private int _Height { get; set; }

        public int Width
        {
            get { return _Width + 2; }
            set { _Width = value; }
        }

        public int Height
        {
            get { return _Height + 2; }
            set { _Height = value; }
        }


    }
}
