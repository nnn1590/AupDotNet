using System;
using Karoterra.AupDotNet.Extensions;

namespace Karoterra.AupDotNet.ExEdit
{
    public struct YCbCr : IEquatable<YCbCr>
    {
        public short Y { get; }
        public short Cb { get; }
        public short Cr { get; }

        public YCbCr(int y, int cb, int cr)
        {
            Y = (short)y;
            Cb = (short)cb;
            Cr = (short)cr;
        }

        public override bool Equals(object obj)
            => obj is YCbCr other && Equals(other);

        public bool Equals(YCbCr other)
            => Y == other.Y && Cb == other.Cb && Cr == other.Cr;

        public override int GetHashCode()
            => Y ^ Cb ^ Cr;

        public static bool operator ==(YCbCr lhs, YCbCr rhs) => lhs.Equals(rhs);

        public static bool operator !=(YCbCr lhs, YCbCr rhs) => !(lhs == rhs);

        public byte[] ToBytes()
        {
            var b = new byte[6];
            Y.ToBytes().CopyTo(b, 0);
            Cb.ToBytes().CopyTo(b, 2);
            Cr.ToBytes().CopyTo(b, 4);
            return b;
        }
    }
}