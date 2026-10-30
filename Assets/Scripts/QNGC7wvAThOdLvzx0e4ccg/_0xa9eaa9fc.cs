using UnityEngine;

/// The only limiter in this game: turns. There is no clock anywhere.
/// Running out does NOT end the run - the delivery expires, a new one arrives and play
/// continues, so a player who never harvests still sees a live board for well over a
/// minute before the fourth expiry closes the round.
public sealed class _0xa9eaa9fc
{
    public void _0x971598c5()
    {
        this.Left += RefundPerHarvest;
    }

    public void _0x11a27ba1()
    {
        this.Left = Mathf.Max(0, this.Left - 1);
        this.Spent++;
    }

    public int Start;
    public int Expiries;
    /// A new delivery arrives with a full budget. Returns false once the fourth one has
    /// expired, which is the only way to lose.
    public bool _0x5e8bc3fa()
    {
        this.Expiries++;
        this.Left = this.Start;
        return this.Expiries < ExpiriesBeforeLose;
    }

    public const int RefundPerHarvest = 4;
    public _0xa9eaa9fc _0xb38c635d(int _0x4f302cf3)
    {
        this.Start = _0x4f302cf3 < 4 ? 34 : (_0x4f302cf3 < 8 ? 30 : 26);
        this.Left = this.Start;
        this.Expiries = 0;
        this.Spent = 0;
        return this;
    }

    public const int ExpiriesBeforeLose = 4;
    public bool _0xd001c26d
    {
        get
        {
            return this.Left <= 0;
        }
    }

    public int Spent;
    public int Left;
}