namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// ラスター
    /// </summary>
    public class RasterEffect : Effect
    {
        /// <summary>
        /// ラスターのフィルタ効果定義。
        /// </summary>
        public static EffectType EffectType { get; }

        /// <summary>横幅</summary>
        public Trackbar Width => Trackbars[0];

        /// <summary>高さ</summary>
        public Trackbar Height => Trackbars[1];

        /// <summary>周期</summary>
        public Trackbar Period => Trackbars[2];

        /// <summary>縦ラスター</summary>
        public bool Vertical
        {
            get => Checkboxes[0] != 0;
            set => Checkboxes[0] = value ? 1 : 0;
        }

        /// <summary>ランダム振幅</summary>
        public bool Random
        {
            get => Checkboxes[1] != 0;
            set => Checkboxes[1] = value ? 1 : 0;
        }

        /// <summary>
        /// <see cref="RasterEffect"/> のインスタンスを初期化します。
        /// </summary>
        public RasterEffect()
            : base(EffectType)
        {
        }

        /// <summary>
        /// トラックバーとチェックボックスの値を指定して <see cref="RasterEffect"/> のインスタンスを初期化します。
        /// </summary>
        /// <param name="trackbars">トラックバー</param>
        /// <param name="checkboxes">チェックボックス</param>
        public RasterEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType, trackbars, checkboxes)
        {
        }

        static RasterEffect()
        {
            EffectType = new EffectType(
                63, 0x04000020, 3, 2, 0, "ラスター",
                new TrackbarDefinition[]
                {
                    new TrackbarDefinition("横幅", 1, 0, 2000, 100),
                    new TrackbarDefinition("高さ", 1, 0, 2000, 100),
                    new TrackbarDefinition("周期", 100, -4000, 4000, 100),
                },
                new CheckboxDefinition[]
                {
                    new CheckboxDefinition("縦ラスター", true, 0),
                    new CheckboxDefinition("ランダム振幅", true, 0),
                }
            );
        }
    }
}
