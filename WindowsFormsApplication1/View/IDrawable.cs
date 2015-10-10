using System.Drawing;

namespace shuntamu.View
{
    /// <summary>
    /// 実装が描画可能な要素であることを保証する
    /// </summary>
    interface IDrawable
    {
        /// <summary>
        /// 基準点を元に描画するメソッド
        /// </summary>
        /// <param name="zeropoint"></param>
        void Draw(Point zeropoint);

        /// <summary>
        /// 要素の基準点に対する位置
        /// </summary>
        Point Point { get; set; }

        /// <summary>
        /// 要素のサイズ
        /// </summary>
        Size Size { get; set; }
    }
}
