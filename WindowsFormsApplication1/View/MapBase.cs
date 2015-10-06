using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using shuntamu.Util;

namespace shuntamu.View
{
    /// <summary>
    /// Map の 抽象クラス
    /// このクラスを継承して Map を生成する
    /// </summary>
    abstract class MapBase : IDrawable
    {
        protected MapBase(Size size)
        {
            _elements = new DrawHub(new Point(0, 0), size);
        }

        private readonly DrawHub _elements;

        public List<MapElementBase> Elements
        {
            get { return _elements.ConvertAll(input => (MapElementBase)input); } 
        }

        public void AddElement(MapElementBase element)
        {
            _elements.Add(element);
        }

        public void Draw(Point zeropoint)
        {
            _elements.Draw(zeropoint);
        }

        public Point Point
        {
            get { return _elements.Point; }
            set { _elements.Point = value; }
        }

        public Size Size
        {
            get { return _elements.Size; }
            set { _elements.Size = value; }
        }
    }
}
