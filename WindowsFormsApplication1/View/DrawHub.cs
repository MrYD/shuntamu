using System;
using System.Collections.Generic;
using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// List<IDrawable> を IDrawable に対応付ける ハブクラス
    /// </summary>
    class DrawHub : List<IDrawable>, IDrawable
    {
        /// <summary>
        /// ハブ自体の 位置 と サイズ
        /// </summary>
        private Point _point;
        private Size _size;

        /// <summary>
        /// コンストラクター
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        public DrawHub(Point point, Size size)
        {
            _point = point;
            _size = size;
        }

        /// <summary>
        /// IDrawable の 実装
        /// 要素 を 全て描画
        /// </summary>
        /// <param name="zeropoint"></param>
        public void Draw(Point zeropoint)
        {
            for (int index = 0; index < this.Count; index++)
            {
                var itr = this[index];
                itr.Draw(zeropoint);
            }
        }

        /// <summary>
        /// IDrawable の 実装
        /// Get:ハブ自体の 位置 を取得
        /// Set:ハブ自体の 位置 を変更
        ///     要素すべての 位置 を相対的に変更
        /// </summary>
        public Point Point
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// IDrawable の 実装
        /// Get:ハブ自体の サイズ を取得
        /// Set:ハブ自体の サイズ を変更
        ///     要素すべての サイズ を相対的に変更
        /// </summary>
        public Size Size
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
