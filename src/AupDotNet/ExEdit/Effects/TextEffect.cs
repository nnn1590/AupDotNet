using System;
using System.Drawing;
using System.IO;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit.Effects
{
    /// <summary>
    /// 文字修飾の種類。
    /// </summary>
    public enum TextType
    {
        /// <summary>標準文字</summary>
        Normal = 0,
        /// <summary>影付き文字</summary>
        Shadow = 1,
        /// <summary>影付き文字(薄)</summary>
        LightShadow = 2,
        /// <summary>縁取り文字</summary>
        Outline = 3,
        /// <summary>縁取り文字(細)</summary>
        ThinOutline = 4,
    }

    /// <summary>
    /// 文字揃え、縦書きの種類
    /// </summary>
    public enum TextAlign
    {
        TopLeft = 0,
        TopCenter,
        TopRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        BottomLeft,
        BottomCenter,
        BottomRight,
        VerticalRightTop,
        VerticalRightMiddle,
        VerticalRightBottom,
        VerticalCenterTop,
        VerticalCenterMiddle,
        VerticalCenterBottom,
        VerticalLeftTop,
        VerticalLeftMiddle,
        VerticalLeftBottom,
    }

    /// <summary>
    /// テキスト
    /// </summary>
    public class TextEffect : Effect
    {
        public readonly int MaxFontLength = 32;
        public readonly int MaxTextLength = 2048;
        public static EffectType EffectType { get; }

        /// <summary>サイズ</summary>
        public Trackbar Size => Trackbars[0];

        /// <summary>表示速度</summary>
        public Trackbar Speed => Trackbars[1];

        /// <summary>自動スクロール</summary>
        public bool AutoScroll
        {
            get => Checkboxes[2] != 0;
            set => Checkboxes[2] = value ? 1 : 0;
        }

        /// <summary>文字毎に個別オブジェクト</summary>
        public bool Split
        {
            get => Checkboxes[0] != 0;
            set => Checkboxes[0] = value ? 1 : 0;
        }

        /// <summary>移動座標上に表示する</summary>
        public bool DisplayOnMoving
        {
            get => Checkboxes[1] != 0;
            set => Checkboxes[1] = value ? 1 : 0;
        }

        public bool Bold
        {
            get => Checkboxes[3] != 0;
            set => Checkboxes[3] = value ? 1 : 0;
        }

        public bool Italic
        {
            get => Checkboxes[4] != 0;
            set => Checkboxes[4] = value ? 1 : 0;
        }

        /// <summary>文字装飾</summary>
        public TextType TextType { get; set; }

        /// <summary>オブジェクトの長さを自動調整</summary>
        public bool AutoAdjust { get; set; }

        /// <summary>滑らかにする</summary>
        public bool Soft { get; set; } = true;

        /// <summary>等間隔モード</summary>
        public bool Monospace { get; set; }

        /// <summary>文字揃え,縦書き</summary>
        public TextAlign Align { get; set; }

        /// <summary>字間</summary>
        public int SpacingX { get; set; }

        /// <summary>行間</summary>
        public int SpacingY { get; set; }

        /// <summary>高精度モード</summary>
        public bool Precision { get; set; } = true;

        /// <summary>文字色の設定</summary>
        public Color Color { get; set; }

        /// <summary>影・縁色の設定</summary>
        public Color Color2 { get; set; }

        public string _font = "MS UI Gothic";
        public string Font
        {
            get => _font;
            set
            {
                if (value.GetSjisByteCount() >= MaxFontLength)
                {
                    throw new MaxByteCountOfStringException(nameof(Font), MaxFontLength);
                }
                _font = value;
            }
        }

        private string _text = "";
        public string Text
        {
            get => _text;
            set
            {
                if (value.GetUTF16ByteCount() >= MaxTextLength)
                {
                    throw new MaxByteCountOfStringException(nameof(Text), MaxTextLength);
                }
                _text = value;
            }
        }

        public TextEffect()
            : base(EffectType)
        {
        }

        public TextEffect(Trackbar[] trackbars, int[] checkboxes)
            : base(EffectType, trackbars, checkboxes)
        {
        }

        public TextEffect(Trackbar[] trackbars, int[] checkboxes, ReadOnlySpan<byte> data)
            : base(EffectType, trackbars, checkboxes, data)
        {
        }

        protected override void ParseExtDataInternal(ReadOnlySpan<byte> data)
        {
            TextType = (TextType)data[0];
            AutoAdjust = data[1] != 0;
            Soft = data[2] != 0;
            Monospace = data[3] != 0;
            Align = (TextAlign)data[4];
            SpacingX = unchecked((sbyte)data[5]);
            SpacingY = unchecked((sbyte)data[6]);
            Precision = data[7] != 0;
            Color = data.Slice(8, 4).ToColor();
            Color2 = data.Slice(0xC, 4).ToColor();
            Font = data.Slice(0x10, MaxFontLength).ToCleanSjisString();
            Text = data.Slice(0x30, MaxTextLength).ToCleanUTF16String();
        }

        public override byte[] DumpExtData()
        {
            var data = new byte[Type.ExtSize];
            data[0] = (byte)TextType;
            data[1] = (byte)(AutoAdjust ? 1 : 0);
            data[2] = (byte)(Soft ? 1 : 0);
            data[3] = (byte)(Monospace ? 1 : 0);
            data[4] = (byte)Align;
            data[5] = unchecked((byte)SpacingX);
            data[6] = unchecked((byte)SpacingY);
            data[7] = (byte)(Precision ? 1 : 0);
            Color.ToBytes().CopyTo(data, 8);
            Color2.ToBytes().CopyTo(data, 0xC);
            Font.ToSjisBytes(MaxFontLength).CopyTo(data, 0x10);
            Text.ToUTF16Bytes(MaxTextLength).CopyTo(data, 0x30);
            return data;
        }

        public override void ExportExtData(TextWriter writer)
        {
            writer.Write("type=");
            writer.WriteLine((int)TextType);
            writer.Write("autoadjust=");
            writer.WriteLine(AutoAdjust ? '1' : '0');
            writer.Write("soft=");
            writer.WriteLine(Soft ? '1' : '0');
            writer.Write("monospace=");
            writer.WriteLine(Monospace ? '1' : '0');
            writer.Write("align=");
            writer.WriteLine((int)Align);
            writer.Write("spacing_x=");
            writer.WriteLine(unchecked((byte)SpacingX));
            writer.Write("spacing_y=");
            writer.WriteLine(unchecked((byte)SpacingY));
            writer.Write("precision=");
            writer.WriteLine(Precision ? '1' : '0');
            writer.Write("color=");
            writer.WriteLine(ExeditUtil.ColorToString(Color));
            writer.Write("color2=");
            writer.WriteLine(ExeditUtil.ColorToString(Color2));
            writer.Write("font=");
            writer.WriteLine(Font);
            writer.Write("text=");
            writer.WriteLine(Text.ToUTF16ByteString(MaxTextLength));
        }

        static TextEffect()
        {
            EffectType = new EffectType(
                3, 0x04000408, 2, 5, 2096, "テキスト",
                new TrackbarDefinition[]
                {
                    new TrackbarDefinition("サイズ", 1, 1, 1000, 34),
                    new TrackbarDefinition("表示速度", 10, 0, 8000, 0),
                },
                new CheckboxDefinition[]
                {
                    new CheckboxDefinition("文字毎に個別オブジェクト", true, 0),
                    new CheckboxDefinition("移動座標上に表示する", true, 0),
                    new CheckboxDefinition("自動スクロール", true, 0),
                    new CheckboxDefinition("B", true, 0),
                    new CheckboxDefinition("I", true, 0),
                }
            );
        }
    }
}
