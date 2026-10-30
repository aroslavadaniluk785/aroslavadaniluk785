using UnityEngine;

/// Brute force over the 8x8x8 = 512 reachable ring alignments.
/// Used twice: to prove a generated board can actually be cleared before it is shown, and
/// to answer the hint button with the cheapest useful move.
public sealed class _0x9b423b05
{
    /// Does this alignment line up three identical pieces of <wanted> on one spoke?
    /// <wanted> below zero means "any triple will do".
    private static int MatchingSpoke(int[] _0xfd4dde04, int _0xab4b7a61, int _0x95719b95, int _0xbeefd6e9, int _0x833636a5)
    {
        for (int _0x5d16892b = 0; _0x5d16892b < _0x20f7bed2.Sectors; _0x5d16892b++)
        {
            int _0x9f3d62ce = Produce(_0xfd4dde04, 0, _0x5d16892b, _0xab4b7a61);
            if (_0x9f3d62ce < 0)
            {
                continue;
            }

            if (_0x833636a5 >= 0 && _0x9f3d62ce != _0x833636a5)
            {
                continue;
            }

            if (_0x9f3d62ce != Produce(_0xfd4dde04, 1, _0x5d16892b, _0x95719b95))
            {
                continue;
            }

            if (_0x9f3d62ce != Produce(_0xfd4dde04, 2, _0x5d16892b, _0xbeefd6e9))
            {
                continue;
            }

            return _0x5d16892b;
        }

        return -1;
    }

    private static int Produce(int[] _0x99c91932, int _0x50fea298, int _0x5ba64848, int _0xde4fcbfe)
    {
        return _0x99c91932[_0x50fea298 * _0x20f7bed2.Sectors + _0x20f7bed2.Wrap(_0x5ba64848 + _0xde4fcbfe)];
    }

    public int HintRing;
    public const int Unreachable = 999999;
    private static int CircularDistance(int _0x3848bdbf, int _0x8c9282b0)
    {
        int _0xc662a3ab = Mathf.Abs(_0x20f7bed2.Wrap(_0x3848bdbf) - _0x20f7bed2.Wrap(_0x8c9282b0));
        return Mathf.Min(_0xc662a3ab, _0x20f7bed2.Sectors - _0xc662a3ab);
    }

    public int HintDirection;
    /// Cheapest single ring turn that moves the board towards ANY triple.
    /// Writes HintRing / HintDirection; returns false when nothing helps.
    public bool _0xfd27bdf4(int[] _0xa90b59dd, int _0xd8e14397, int _0xf1e7fbcd, int _0xfef874de, int _0xda4195bb)
    {
        this.HintRing = 0;
        this.HintDirection = 1;
        int _0x65e01d55 = Unreachable;
        int[] _0xd514b1f8 =
        {
            _0xd8e14397,
            _0xf1e7fbcd,
            _0xfef874de
        };
        for (int _0x6c623f03 = 0; _0x6c623f03 < _0x20f7bed2.Sectors; _0x6c623f03++)
        {
            for (int _0x3ae39274 = 0; _0x3ae39274 < _0x20f7bed2.Sectors; _0x3ae39274++)
            {
                for (int _0xfcb3856a = 0; _0xfcb3856a < _0x20f7bed2.Sectors; _0xfcb3856a++)
                {
                    if (MatchingSpoke(_0xa90b59dd, _0x6c623f03, _0x3ae39274, _0xfcb3856a, _0xda4195bb) < 0)
                    {
                        continue;
                    }

                    int _0x144ce4b7 = CircularDistance(_0x6c623f03, _0xd8e14397) + CircularDistance(_0x3ae39274, _0xf1e7fbcd) + CircularDistance(_0xfcb3856a, _0xfef874de);
                    if (_0x144ce4b7 <= 0 || _0x144ce4b7 >= _0x65e01d55)
                    {
                        continue;
                    }

                    _0x65e01d55 = _0x144ce4b7;
                    int[] _0x55478210 =
                    {
                        _0x6c623f03,
                        _0x3ae39274,
                        _0xfcb3856a
                    };
                    for (int _0xf461bb66 = 0; _0xf461bb66 < _0x20f7bed2.Rings; _0xf461bb66++)
                    {
                        if (_0x20f7bed2.Wrap(_0x55478210[_0xf461bb66]) == _0x20f7bed2.Wrap(_0xd514b1f8[_0xf461bb66]))
                        {
                            continue;
                        }

                        this.HintRing = _0xf461bb66;
                        int _0x87d9f6ab = _0x20f7bed2.Wrap(_0x55478210[_0xf461bb66] - _0xd514b1f8[_0xf461bb66]);
                        this.HintDirection = _0x87d9f6ab <= _0x20f7bed2.Sectors / 2 ? 1 : -1;
                        break;
                    }
                }
            }
        }

        return _0x65e01d55 < Unreachable;
    }

    private readonly int[] _0x78ee1ba0 = new int[_0x20f7bed2.Rings * _0x20f7bed2.Sectors];
    /// Total notches needed to fill the whole order, or Unreachable.
    /// The refill stream is replayed from <refillSeed>, so the estimate matches a real run.
    public int _0xd9caabfd(int[] _0x85ed1a8c, int[] _0x5c543e7b, int[] _0x5b09e8cf, int _0x1f244954, int _0x9e8e6d49, int _0x0034613b)
    {
        System.Array.Copy(_0x85ed1a8c, this._0x78ee1ba0, this._0x78ee1ba0.Length);
        System.Random _0xbaf85faa = new System.Random(_0x9e8e6d49);
        int _0x286b1d25 = 0;
        int _0x0b40d4f0 = 0;
        int _0x0027d229 = 0;
        int _0x61234693 = 0;
        for (int _0xe858132c = 0; _0xe858132c < _0x1f244954; _0xe858132c++)
        {
            for (int _0x78e57e61 = 0; _0x78e57e61 < _0x5b09e8cf[_0xe858132c]; _0x78e57e61++)
            {
                int best = Unreachable;
                int _0xf7f969b3 = 0;
                int _0xbae09197 = 0;
                int _0x8090d7c2 = 0;
                int _0x5a75f57a = -1;
                for (int _0xc524d208 = 0; _0xc524d208 < _0x20f7bed2.Sectors; _0xc524d208++)
                {
                    for (int _0x6346af2e = 0; _0x6346af2e < _0x20f7bed2.Sectors; _0x6346af2e++)
                    {
                        for (int _0x94f0ef41 = 0; _0x94f0ef41 < _0x20f7bed2.Sectors; _0x94f0ef41++)
                        {
                            int _0x46d5b0df = MatchingSpoke(this._0x78ee1ba0, _0xc524d208, _0x6346af2e, _0x94f0ef41, _0x5c543e7b[_0xe858132c]);
                            if (_0x46d5b0df < 0)
                            {
                                continue;
                            }

                            int _0xecde8d30 = CircularDistance(_0xc524d208, _0x286b1d25) + CircularDistance(_0x6346af2e, _0x0b40d4f0) + CircularDistance(_0x94f0ef41, _0x0027d229);
                            if (_0xecde8d30 >= best)
                            {
                                continue;
                            }

                            best = _0xecde8d30;
                            _0xf7f969b3 = _0xc524d208;
                            _0xbae09197 = _0x6346af2e;
                            _0x8090d7c2 = _0x94f0ef41;
                            _0x5a75f57a = _0x46d5b0df;
                        }
                    }
                }

                if (_0x5a75f57a < 0)
                {
                    return Unreachable;
                }

                _0x61234693 += best;
                _0x286b1d25 = _0xf7f969b3;
                _0x0b40d4f0 = _0xbae09197;
                _0x0027d229 = _0x8090d7c2;
                int[] _0x9b35e020 =
                {
                    _0xf7f969b3,
                    _0xbae09197,
                    _0x8090d7c2
                };
                for (int _0x13550077 = 0; _0x13550077 < _0x20f7bed2.Rings; _0x13550077++)
                {
                    int _0xaa91d560 = _0x13550077 * _0x20f7bed2.Sectors + _0x20f7bed2.Wrap(_0x5a75f57a + _0x9b35e020[_0x13550077]);
                    this._0x78ee1ba0[_0xaa91d560] = _0xbaf85faa.Next(0, _0x0034613b);
                }
            }
        }

        return _0x61234693;
    }
}