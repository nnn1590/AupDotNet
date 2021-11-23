using System;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// 色ずれ(フィルタオブジェクト)
    /// </summary>
    public class ColorShiftFilterEffect : Effect
    {
        private const int Id = (int)EffectTypeId.ColorShiftFilter;

        /// <summary>ずれ幅</summary>
        public Trackbar Shift => Trackbars[0];

        /// <summary>角度</summary>
        public Trackbar Angle => Trackbars[1];

        /// <summary>強さ</summary>
        public Trackbar Intensity => Trackbars[2];

        /// <summary>
        /// 色ずれの種類
        /// <list type="bullet">
        ///     <item>0. 赤緑</item>
        ///     <item>1. 赤青</item>
        ///     <item>2. 緑青</item>
        /// </list>
        /// </summary>
        public int ShiftType { get; set; }

        public ColorShiftFilterEffect()
            : base(EffectType.Defaults[Id])
        {
        }

        public ColorShiftFilterEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
        }

        public ColorShiftFilterEffect(Trackbar[] trackbars, int[] checkboxes, byte[] data)
            : base(EffectType.Defaults[Id], trackbars, checkboxes)
        {
            if (data != null)
            {
                if (data.Length == Type.ExtSize)
                {
                    var span = new ReadOnlySpan<byte>(data);
                    ShiftType = span.Slice(0, 4).ToInt32();
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
            ShiftType.ToBytes().CopyTo(data, 0);
            return data;
        }
    }
}