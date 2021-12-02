namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// 拡張色設定(フィルタオブジェクト)
    /// </summary>
    public class ColorSettingExFilterEffect : NoExtDataEffect
    {
        public static EffectType EffectType { get; }

        /// <summary>R, H</summary>
        public Trackbar R => Trackbars[0];

        /// <summary>G, S</summary>
        public Trackbar G => Trackbars[1];

        /// <summary>B, V</summary>
        public Trackbar B => Trackbars[2];

        /// <summary>RGB⇔HSV</summary>
        public bool HSV
        {
            get => Checkboxes[0] != 0;
            set => Checkboxes[0] = value ? 1 : 0;
        }

        public ColorSettingExFilterEffect()
            : base(EffectType)
        {
        }

        public ColorSettingExFilterEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType, trackbars, checkboxes)
        {
        }

        static ColorSettingExFilterEffect()
        {
            EffectType = new EffectType(
                77, 0x04000200, 3, 3, 0, "拡張色設定",
                new TrackbarDefinition[]
                {
                    new TrackbarDefinition("R", 0, 0, 255, 0),  // HSVの時はmax=360
                    new TrackbarDefinition("G", 0, 0, 255, 0),  // HSVの時はmax=100
                    new TrackbarDefinition("B", 0, 0, 255, 0),  // HSVの時はmax=100
                },
                new CheckboxDefinition[]
                {
                    new CheckboxDefinition("RGB⇔HSV", true, 0),
                    new CheckboxDefinition("開始色", false, 0),
                    new CheckboxDefinition("終了色", false, 0),
                }
            );
        }
    }
}
