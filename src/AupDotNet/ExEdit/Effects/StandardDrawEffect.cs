using System;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// 標準描画
    /// </summary>
    public class StandardDrawEffect : Effect
    {
        public static EffectType EffectType { get; }

        public Trackbar X => Trackbars[0];
        public Trackbar Y => Trackbars[1];
        public Trackbar Z => Trackbars[2];
        public Trackbar Zoom => Trackbars[3];
        public Trackbar Alpha => Trackbars[4];
        public Trackbar Rotate => Trackbars[5];

        public BlendMode BlendMode { get; set; }

        public StandardDrawEffect()
            : base(EffectType)
        {
        }

        public StandardDrawEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType, trackbars, checkboxes)
        {
        }

        public StandardDrawEffect(Trackbar[] trackbars, int[] checkboxes, byte[] data)
            : base(EffectType, trackbars, checkboxes)
        {
            if (data != null)
            {
                if (data.Length == Type.ExtSize)
                {
                    var span = new ReadOnlySpan<byte>(data);
                    BlendMode = (BlendMode)span.Slice(0, 4).ToInt32();
                }
                else if (data.Length != 0)
                {
                    throw new ArgumentException("data's length is invalid.");
                }
            }
        }

        public override byte[] DumpExtData()
        {
            var data = new byte[Type.ExtSize];
            ((int)BlendMode).ToBytes().CopyTo(data, 0);
            return data;
        }

        static StandardDrawEffect()
        {
            EffectType = new EffectType(
                10, 0x440004D0, 6, 1, 4, "標準描画",
                new TrackbarDefinition[]
                {
                    new TrackbarDefinition("X", 10, -999999, 999999, 0),
                    new TrackbarDefinition("Y", 10, -999999, 999999, 0),
                    new TrackbarDefinition("Z", 10, -999999, 999999, 0),
                    new TrackbarDefinition("拡大率", 100, 0, 500000, 10000),
                    new TrackbarDefinition("透明度", 10, 0, 1000, 0),
                    new TrackbarDefinition("回転", 100, -360000, 360000, 0),
                },
                new CheckboxDefinition[]
                {
                    new CheckboxDefinition("通常", false, 0),
                }
            );
        }
    }
}
