using UnityEngine;

/// Builds one run: what sits in the 24 cells, what the order asks for, and the refill
/// stream. Nothing here is written out by hand - the only fixed arrangement in the
/// project is the fallback, and it is reached only when 20 generated boards in a row
/// fail the solver.
public sealed class _0xd75021d4
{
    public readonly int[] Cells = new int[CellCount];
    private const int CostCeiling = 18;
    private readonly _0x9b423b05 _0x183534bb = new _0x9b423b05();
    private void _0x509f9617(int _0xf98cc4b1)
    {
        System.Random _0x584afc70 = new System.Random(this.Seed);
        bool _0xc404ac2a = false;
        for (int _0x53deef59 = 0; _0x53deef59 < MaxAttempts && !_0xc404ac2a; _0x53deef59++)
        {
            this._0x690c13f2(_0x584afc70, _0xf98cc4b1);
            int _0x9da9927f = this._0x183534bb._0xd9caabfd(this.Cells, this.OrderTypes, this.OrderCounts, this.OrderLength, this.Seed ^ 31, this.Variety);
            _0xc404ac2a = _0x9da9927f <= CostCeiling;
            {
#if B_LOGS
                {
                    Debug.Log($"[level] tree={_0xf98cc4b1} seed={this.Seed} pass={_0x53deef59} variety={this.Variety} cost={_0x9da9927f} accepted={_0xc404ac2a}");
                }
#endif
            }
        }

        if (!_0xc404ac2a)
        {
            this._0xfff4c3c7(_0xf98cc4b1);
        }

        this._0xa8bc7f2c = new System.Random(this.Seed ^ 31);
    }

    public const int CellCount = _0x20f7bed2.Rings * _0x20f7bed2.Sectors;
    public int Variety;
    /// Fresh contents AND a fresh order, so two runs differ in what is on the board and in
    /// what is being asked for - not only in a number in the HUD.
    private void _0x690c13f2(System.Random _0x22cf077e, int _0x081307df)
    {
        for (int _0xe4bbb714 = 0; _0xe4bbb714 < CellCount; _0xe4bbb714++)
        {
            this.Cells[_0xe4bbb714] = _0x22cf077e.Next(0, this.Variety);
        }

        this.OrderLength = Mathf.Clamp(2 + _0x081307df / 5, 2, MaxOrderRows);
        int _0x7b8a502b = 0;
        int _0xe544c02c = 0;
        while (_0x7b8a502b < this.OrderLength && _0xe544c02c < 64)
        {
            _0xe544c02c++;
            int _0x062bad88 = _0x22cf077e.Next(0, this.Variety);
            bool _0x5b961d05 = false;
            for (int _0xb22f872a = 0; _0xb22f872a < _0x7b8a502b; _0xb22f872a++)
            {
                if (this.OrderTypes[_0xb22f872a] == _0x062bad88)
                {
                    _0x5b961d05 = true;
                }
            }

            if (_0x5b961d05)
            {
                continue;
            }

            this.OrderTypes[_0x7b8a502b] = _0x062bad88;
            this.OrderCounts[_0x7b8a502b] = 1 + _0x22cf077e.Next(0, 2 + _0x081307df / 6);
            _0x7b8a502b++;
        }

        this.OrderLength = Mathf.Max(1, _0x7b8a502b);
    }

    public _0xd75021d4 _0xbff93c55(int _0x61c0975a, int _0x971cbb45)
    {
        this.Seed = (_0x61c0975a * 7919) ^ (_0x971cbb45 * 104729);
        this.Variety = Mathf.Clamp(3 + _0x61c0975a / 4, 3, 5);
        this._0x509f9617(_0x61c0975a);
        return this;
    }

    public int OrderLength;
    private System.Random _0xa8bc7f2c;
    public int Seed;
    public readonly int[] OrderCounts = new int[MaxOrderRows];
    private const int MaxAttempts = 20;
    /// A guarantee, not a hope: a board that is clearable by construction.
    private void _0xfff4c3c7(int _0xb94fd032)
    {
        for (int _0xc9f31649 = 0; _0xc9f31649 < _0x20f7bed2.Rings; _0xc9f31649++)
        {
            for (int _0xf9348ee3 = 0; _0xf9348ee3 < _0x20f7bed2.Sectors; _0xf9348ee3++)
            {
                this.Cells[_0xc9f31649 * _0x20f7bed2.Sectors + _0xf9348ee3] = (_0xf9348ee3 + _0xc9f31649) % this.Variety;
            }
        }

        this.OrderLength = 2;
        this.OrderTypes[0] = 0;
        this.OrderCounts[0] = 2;
        this.OrderTypes[1] = 1;
        this.OrderCounts[1] = 1;
        {
#if B_LOGS
            {
                Debug.Log($"[level] tree={_0xb94fd032} seed={this.Seed} fell back to the guaranteed board");
            }
#endif
        }
    }

    /// Deterministic replacement for a harvested cell.
    public int _0xd2548d5b()
    {
        if (this._0xa8bc7f2c == null)
        {
            this._0xa8bc7f2c = new System.Random(this.Seed ^ 31);
        }

        return this._0xa8bc7f2c.Next(0, this.Variety);
    }

    public readonly int[] OrderTypes = new int[MaxOrderRows];
    public const int MaxOrderRows = 3;
}