using UnityEngine;

/// Every world-space size in the game scene is derived here from the scene camera, so the
/// board keeps its proportions on any aspect ratio instead of relying on native art size.
public sealed class _0x20f7bed2
{
    public const int RingMiddleOrder = -15;
    public _0x20f7bed2 _0xad09e758(Camera _0xa4b8430b)
    {
        float _0x9b4fb1ae = _0xa4b8430b != null ? _0xa4b8430b.orthographicSize : 5f;
        float _0xfc1e2071 = _0xa4b8430b != null && _0xa4b8430b.aspect > 0.01f ? _0xa4b8430b.aspect : (9f / 19.5f);
        this.HalfHeight = _0x9b4fb1ae;
        this.HalfWidth = _0x9b4fb1ae * _0xfc1e2071;
        this.BoardRadius = this.HalfWidth * 0.92f;
        this.BoardCentre = new Vector3(0f, -_0x9b4fb1ae * 0.07f, 0f);
        this.SoilSize = this.BoardRadius * 2.12f;
        this.HubSize = this.BoardRadius * 0.416f;
        this.RingRadius[0] = this.BoardRadius * 0.810f;
        this.RingRadius[1] = this.BoardRadius * 0.575f;
        this.RingRadius[2] = this.BoardRadius * 0.377f;
        this.PlateSize[0] = this.BoardRadius * 1.930f;
        this.PlateSize[1] = this.BoardRadius * 1.432f;
        this.PlateSize[2] = this.BoardRadius * 1.008f;
        this.ItemSize[0] = this.BoardRadius * 0.2355f;
        this.ItemSize[1] = this.BoardRadius * 0.2167f;
        this.ItemSize[2] = this.BoardRadius * 0.1884f;
        for (int _0xdf076ffd = 0; _0xdf076ffd < Rings; _0xdf076ffd++)
        {
            this.SlotSize[_0xdf076ffd] = this.ItemSize[_0xdf076ffd] * 1.26f;
        }

        // Touch bands: the midpoints between neighbouring ring radii, so every point of the
        // board belongs to exactly one ring and the hub belongs to none.
        this.BandOuter[0] = this.BoardRadius;
        this.BandInner[0] = (this.RingRadius[0] + this.RingRadius[1]) * 0.5f;
        this.BandOuter[1] = this.BandInner[0];
        this.BandInner[1] = (this.RingRadius[1] + this.RingRadius[2]) * 0.5f;
        this.BandOuter[2] = this.BandInner[1];
        this.BandInner[2] = this.RingRadius[2] * 0.6f;
        return this;
    }

    /// Draw order corridor. Nothing the game draws may leave -19 .. -1: the scene
    /// background owns -20 and every Canvas (HUD, win/lose/pause) sits above 0.
    public const int OrderFloor = -19;
    public float HalfHeight;
    public const int ItemOrder = -11;
    public float BoardRadius;
    public static int Clamped(int _0xec3b0104)
    {
        return Mathf.Clamp(_0xec3b0104, OrderFloor, OrderCeil);
    }

    public const int Sectors = 8;
    public const int HubOrder = -9;
    public readonly float[] RingRadius = new float[Rings];
    public Vector3 BoardCentre;
    public const int RingInnerOrder = -14;
    public float HalfWidth;
    public const int SoilOrder = -18;
    /// Local position of physical cell <index> on <ring>, relative to the ring root.
    public Vector3 _0x744de2d3(int _0x604f766b, int _0x42cd277f)
    {
        float _0x97446e7e = (90f - _0x42cd277f * SectorStep) * Mathf.Deg2Rad;
        return new Vector3(Mathf.Cos(_0x97446e7e) * this.RingRadius[_0x604f766b], Mathf.Sin(_0x97446e7e) * this.RingRadius[_0x604f766b], 0f);
    }

    public const float SectorStep = 360f / Sectors;
    public const int OrderCeil = -1;
    public float HubSize;
    public int _0x563d1e19(int _0xad893802)
    {
        if (_0xad893802 == 0)
        {
            return Mathf.Clamp(RingOuterOrder, OrderFloor, OrderCeil);
        }

        if (_0xad893802 == 1)
        {
            return Mathf.Clamp(RingMiddleOrder, OrderFloor, OrderCeil);
        }

        return Mathf.Clamp(RingInnerOrder, OrderFloor, OrderCeil);
    }

    public readonly float[] BandOuter = new float[Rings];
    public readonly float[] PlateSize = new float[Rings];
    public float SoilSize;
    public const int GlowOrder = -6;
    public const int Rings = 3;
    public static int Wrap(int _0xcedd697d)
    {
        int _0x7fae803f = _0xcedd697d % Sectors;
        return _0x7fae803f < 0 ? _0x7fae803f + Sectors : _0x7fae803f;
    }

    public readonly float[] ItemSize = new float[Rings];
    public float _0x21980920(Vector3 _0x64dd43b7)
    {
        return Mathf.Atan2(_0x64dd43b7.y - this.BoardCentre.y, _0x64dd43b7.x - this.BoardCentre.x) * Mathf.Rad2Deg;
    }

    /// Which ring a world point falls on, or -1 for the hub and everything outside.
    public int _0x09062e52(Vector3 _0x9deeeb50)
    {
        float _0xf108fbba = Vector2.Distance(new Vector2(_0x9deeeb50.x, _0x9deeeb50.y), new Vector2(this.BoardCentre.x, this.BoardCentre.y));
        for (int _0x6fff8472 = 0; _0x6fff8472 < Rings; _0x6fff8472++)
        {
            if (_0xf108fbba <= this.BandOuter[_0x6fff8472] && _0xf108fbba > this.BandInner[_0x6fff8472])
            {
                return _0x6fff8472;
            }
        }

        return -1;
    }

    public const int SlotOrder = -13;
    public readonly float[] BandInner = new float[Rings];
    public readonly float[] SlotSize = new float[Rings];
    public const int RingOuterOrder = -16;
}