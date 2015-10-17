using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shuntamu.View
{
    internal class MapBlock
    {
        public MapBlock(int left)
        {
            Left = left;
            _elements = new DrawHub(new Point(0, 0), new Size(Width, 5000));
        }
        public int Left { get; set; }

        public int Width
        {
            get { return 500; }
        }

        private readonly DrawHub _elements;

        public List<MapElementBase> Elements
        {
            get { return _elements.ConvertAll(input => (MapElementBase)input); }
        }

        internal void AddElement(MapElementBase element)
        {
           _elements.Add(element);
        }
    }

}
