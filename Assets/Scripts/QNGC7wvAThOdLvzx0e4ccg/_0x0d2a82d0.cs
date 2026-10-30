using UnityEngine;

/// The delivery note: which produce the tree owes and how much of it is already in the
/// basket. Nothing here touches the view; the HUD reads these values back.
public sealed class _0x0d2a82d0
{
    public bool _0x08d6b21a(int _0xaf02c2d2)
    {
        return _0xaf02c2d2 >= 0 && _0xaf02c2d2 < this.Length && this.Delivered[_0xaf02c2d2] >= this.Required[_0xaf02c2d2];
    }

    /// A harvest of a type the order does not ask for still counts towards the basket:
    /// no move is ever wasted, which is what keeps the game forgiving.
    public bool _0xfadaa528(int _0x0eeab445, int pieces)
    {
        this.BasketTotal += pieces;
        for (int _0xc7ac59f3 = 0; _0xc7ac59f3 < this.Length; _0xc7ac59f3++)
        {
            if (this.Types[_0xc7ac59f3] != _0x0eeab445)
            {
                continue;
            }

            if (this.Delivered[_0xc7ac59f3] >= this.Required[_0xc7ac59f3])
            {
                return false;
            }

            this.Delivered[_0xc7ac59f3]++;
            return true;
        }

        return false;
    }

    public bool _0xc982578c
    {
        get
        {
            for (int _0x5a394f3b = 0; _0x5a394f3b < this.Length; _0x5a394f3b++)
            {
                if (this.Delivered[_0x5a394f3b] < this.Required[_0x5a394f3b])
                {
                    return false;
                }
            }

            return true;
        }
    }

    public readonly int[] Types = new int[_0xd75021d4.MaxOrderRows];
    public int BasketTotal;
    public readonly int[] Delivered = new int[_0xd75021d4.MaxOrderRows];
    public int Length;
    /// The produce the order still wants most, for the hint. -1 when everything is in.
    public int _0x2981f5f1
    {
        get
        {
            for (int _0x438c50c0 = 0; _0x438c50c0 < this.Length; _0x438c50c0++)
            {
                if (this.Delivered[_0x438c50c0] < this.Required[_0x438c50c0])
                {
                    return this.Types[_0x438c50c0];
                }
            }

            return -1;
        }
    }

    public _0x0d2a82d0 _0xb80d4cab(int[] _0xa5de228d, int[] _0x67046f31, int _0x52d75f30)
    {
        this.Length = Mathf.Clamp(_0x52d75f30, 1, _0xd75021d4.MaxOrderRows);
        for (int _0xcf688e12 = 0; _0xcf688e12 < this.Length; _0xcf688e12++)
        {
            this.Types[_0xcf688e12] = _0xa5de228d[_0xcf688e12];
            this.Required[_0xcf688e12] = Mathf.Max(1, _0x67046f31[_0xcf688e12]);
            this.Delivered[_0xcf688e12] = 0;
        }

        this.BasketTotal = 0;
        return this;
    }

    public readonly int[] Required = new int[_0xd75021d4.MaxOrderRows];
}