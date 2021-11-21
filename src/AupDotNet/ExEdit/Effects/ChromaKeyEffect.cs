using System;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// クロマキー
    /// </summary>
    public class ChromaKeyEffect : Effect
    {
        private const int Id = (int)EffectTypeId.ChromaKey;

        /// <summary>色相範囲</summary>
        public Trackbar HueRange => Trackbars[0];

        /// <summary>彩度範囲</summary>
        public Trackbar ChromaRange => Trackbars[1];

        /// <summary>境界補正</summary>
        public Trackbar Boundary => Trackbars[2];

        /// <summary>色彩補正</summary>
        public bool ColorCorrection
        {
            get => Checkboxes[0] != 0;
            set => Checkboxes[0] = value ? 1 : 0;
        }

        /// <summary>透過補正</summary>
        public bool TransparencyCorrection
        {
            get => Checkboxes[1] != 0;
            set => Checkboxes[1] = value ? 1 : 0;
        }

        /// <summary>キー色の取得</summary>
        public YCbCr Color { get; set; }

        /// <summary>キー(未取得)</summary>
        public int Status { get; set; }

        public short Field0x6 { get; set; }

        public ChromaKeyEffect()
            : base(EffectType.Defaults[Id])
        {
        }

        public ChromaKeyEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
        }

        public ChromaKeyEffect(Trackbar[] trackbars, int[] checkboxes, byte[] data)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
            if (data != null)
            {
                if (data.Length == Type.ExtSize)
                {
                    var span = new ReadOnlySpan<byte>(data);
                    Color = span.ToYCbCr();
                    Field0x6 = span.Slice(6, 2).ToInt16();
                    Status = span.Slice(8, 4).ToInt32();
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
            Color.ToBytes().CopyTo(data, 0);
            Field0x6.ToBytes().CopyTo(data, 6);
            Status.ToBytes().CopyTo(data, 8);
            return data;
        }
    }
}
