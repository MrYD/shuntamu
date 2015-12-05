namespace shuntamu.View
{
    /// <summary>
    /// ゲームモード の 基底クラス
    /// </summary>
    abstract class ModeBase
    {
        public abstract void Draw();

        public abstract void Update();
        public abstract void Init();
        public abstract void End();
    }
}
