using System;
using System.Drawing;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// 発光(フィルタオブジェクト)
    /// </summary>
    public class EmissionFilterEffect : Effect
    {
        private const int Id = (int)EffectTypeId.EmissionFilter;

        /// <summary>強さ</summary>
        public Trackbar Intensity => Trackbars[0];

        /// <summary>拡散</summary>
        public Trackbar Diffusion => Trackbars[1];

        /// <summary>しきい値</summary>
        public Trackbar Threshold => Trackbars[2];

        /// <summary>拡散速度</summary>
        public Trackbar DiffusionRate => Trackbars[3];

        /// <summary>光色の設定</summary>
        public Color Color { get; set; }

        /// <summary>光色の設定(色指定なし)</summary>
        public bool NoColor { get; set; }

        public EmissionFilterEffect()
            : base(EffectType.Defaults[Id])
        {
        }

        public EmissionFilterEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
        }

        public EmissionFilterEffect(Trackbar[] trackbars, int[] checkboxes, byte[] data)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
            if (data != null)
            {
                if (data.Length == Type.ExtSize)
                {
                    var span = new ReadOnlySpan<byte>(data);
                    Color = span.ToColor();
                    NoColor = span[3] != 0;
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
            data[3] = (byte)(NoColor ? 1 : 0);
            return data;
        }
    }
}