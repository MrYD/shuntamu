using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using shuntamu.View.AutumnGround;

namespace shuntamu.View
{
    /// <summary>
    /// Map の 抽象クラス
    /// このクラスを継承して Map を生成する
    /// </summary>
    abstract class MapBase : IDrawable
    {
        protected MapBase(int blocknumber)
        {
            Blocks = new List<MapBlock>();
            Point = new Point(0, 0);
            Size = new Size(blocknumber * 500, 5000);
            for (int i = 0; i < blocknumber; i++)
            {
                Blocks.Add(new MapBlock(i * 500));
            }
        }

        public List<MapBlock> Blocks { get; set; }
        private List<Floor> _floors = new List<Floor>();
        private Point _currentPoint = new Point(0, 0);
        private List<MapElementBase> _elements = new List<MapElementBase>();

        public int CurrentBlockNumber
        {
            get { return GetBlockNumber(_currentPoint.X); }
        }

        public Point CurrentPoint
        {
            get { return _currentPoint; }
            set
            {
                int newBlockNumber = GetBlockNumber(value.X);
                if (CurrentBlockNumber != newBlockNumber)
                {
                    _currentPoint = value;
                    UpdateElement();
                }
                else
                {
                    _currentPoint = value;
                }

            }
        }

        public List<MapElementBase> Elements
        {
            get { return _elements; }
            set { _elements = value; }
        }

        public void AddElement(MapElementBase element)
        {
            var item = element as Floor;
            if (item != null)
            {
                _floors.Add(item);
                return;
            }
            foreach (var block in Blocks)
            {
                if (element.Top.X >= block.Left && element.Top.X <= block.Left + block.Width)
                {
                    block.AddElement(element);
                }
            }

        }

        public MapBlock CurrentBlock
        {
            get { return Blocks[CurrentBlockNumber]; }
        }

        public void UpdateElement()
        {
            var newBlockNumber = CurrentBlockNumber;
            Elements = new List<MapElementBase>();
            foreach (var element in _floors)
            {
                if (element.IsActive)
                    Elements.Add(element);
            }
            foreach (var element in Blocks[newBlockNumber].Elements)
            {
                if (element.IsActive)
                    Elements.Add(element);
            }
            if (newBlockNumber + 1 < Blocks.Count)
                foreach (var element in Blocks[newBlockNumber + 1].Elements)
                {
                    if (element.IsActive)
                        Elements.Add(element);
                }
            if (newBlockNumber - 1 >= 0)
                foreach (var element in Blocks[newBlockNumber - 1].Elements)
                {
                    if (element.IsActive)
                        Elements.Add(element);
                }
        }

        private int GetBlockNumber(int left)
        {
            for (int index = 0; index < Blocks.Count; index++)
            {
                var block = Blocks[index];
                if (left >= block.Left && left <= block.Left + block.Width)
                {
                    return index;
                }
            }
            //throw new Exception();
            return 0;
        }

        public void Draw(Point zeropoint)
        {
            foreach (var element in Elements)
            {
                element.Draw(zeropoint);
            }
        }

        public void Update(Point point)
        {
            CurrentPoint = point;
            for (int index = 0; index < Elements.Count; index++)
            {
                var variable = Elements[index];
                if (variable is MotionObject)
                {
                    if (((MotionObject)variable).IsActive)
                    {
                        ((MotionObject)variable).Update(this);
                    }
                    else
                    {
                        Elements.Remove(variable);
                    }
                }
            }
        }

        public Point Point { get; set; }

        public Size Size { get; set; }

        internal void AddElementNow(MapElementBase element)
        {
            _elements.Add(element);
        }
    }
}
