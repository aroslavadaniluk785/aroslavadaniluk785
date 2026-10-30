using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

/// Owns one run of the puzzle: builds the HUD, drives the rings, resolves harvests and
/// decides when the delivery expires, when the tree is restored and when it is over.
public sealed class _0xd2425d92 : MonoBehaviour
{
    [SerializeField]
    private _0x12c26713 _board;
    private const float LiftTime = 0.12f;
    private const int HintsPerTree = 3;
    private void _0x941cb264(int _0x9e725365, int _0xb390c5d8, int _0x3f78bc36)
    {
        if (this._pops != null)
        {
            this._pops._0x29fb7cc2(_0x9e725365, _0xb390c5d8, _0x3f78bc36);
        }
    }

    private void _0xd857cf03()
    {
        if (this._hud != null)
        {
            this._hud._0xeb8c3692();
        }
    }

    [SerializeField]
    private _0x32ce2a44 _hud;
    /// One notch costs one turn. Input stays locked until the ring has settled, which is
    /// what makes the baseline length of a run predictable.
    public void _0x880e7deb(int _0x10208543, int _0x78d29b8f)
    {
        if (!this._0x88f82542 || this._board == null || this._0x7a6080f8 == null)
        {
            return;
        }

        this._0xe18693ae = true;
        this._0x7a6080f8._0x11a27ba1();
        this._board._0x115823be(_0x10208543);
        this._board._0xfa3a0fc5(_0x10208543, _0x78d29b8f, RingTurnTime);
        if (this._hud != null)
        {
            this._hud._0x515475ac(this._0x7a6080f8.Left);
            this._hud._0xc23690cc();
        }

        {
#if B_LOGS
            {
                Debug.Log($"[turn] ring={_0x10208543} dir={_0x78d29b8f} left={this._0x7a6080f8.Left} spent={this._0x7a6080f8.Spent}");
            }
#endif
        }

        DOVirtual.DelayedCall(RingTurnTime + SettleTime, () => this._0xafcf0e81()).SetLink(this.gameObject);
    }

    private _0x0d2a82d0 _0xe578ffab;
    private void OnDestroy()
    {
        DOTween.Kill(this.gameObject);
    }

    /// The HUD belongs inside the scene template panel. If that host is ever missing the
    /// director makes its own canvas rather than shipping a game with no HUD.
    private RectTransform _0x7f0cdd2b()
    {
        if (this._hudRoot != null)
        {
            return this._hudRoot;
        }

        GameObject _0x0231f559 = new GameObject(_0xc58fbf63._0x625e73ab(new byte[17] { 226, 196, 215, 193, 192, 203, 237, 208, 193, 227, 196, 201, 201, 199, 196, 198, 206 }, 165), typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
        Canvas _0x3bb5f921 = _0x0231f559.GetComponent<Canvas>();
        _0x3bb5f921.renderMode = RenderMode.ScreenSpaceOverlay;
        _0x3bb5f921.sortingOrder = FallbackCanvasOrder;
        CanvasScaler _0x87972dd9 = _0x0231f559.GetComponent<CanvasScaler>();
        _0x87972dd9.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        _0x87972dd9.referenceResolution = new Vector2(1242f, 2688f);
        _0x87972dd9.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
        this._hudRoot = _0x0231f559.GetComponent<RectTransform>();
        return this._hudRoot;
    }

    /// A fresh board and a fresh order. Called at the start of the run and again whenever
    /// a delivery expires, so no two deliveries look the same.
    private void _0xcb5f77e1(bool _0x1479e662)
    {
        this._0xc811c65a = new _0xd75021d4()._0xbff93c55(this._0xfac7571a, this._0x066a2096 + (_0x1479e662 ? 0 : 1000));
        if (_0x1479e662)
        {
            this._0xe578ffab = new _0x0d2a82d0()._0xb80d4cab(this._0xc811c65a.OrderTypes, this._0xc811c65a.OrderCounts, this._0xc811c65a.OrderLength);
            this._0x7a6080f8 = new _0xa9eaa9fc()._0xb38c635d(this._0xfac7571a);
            this._0x2398df50 = HintsPerTree;
        }

        if (this._board != null)
        {
            this._board._0x8da215ed(this._0xc811c65a.Cells);
            this._0xc5dbe5e8();
        }

        if (this._hud != null)
        {
            this._hud._0xa77791c4(this._0xe578ffab);
            this._hud._0x515475ac(this._0x7a6080f8.Left);
            this._hud._0x1a809ce1(this._0x2398df50);
        }

        this._0xe18693ae = false;
    }

    private const float FlyTime = 0.42f;
    public void _0x31e3126e(int _0x5c0994ca)
    {
        if (this._board == null)
        {
            return;
        }

        this._0x880e7deb(this._board._0x7fe56efc, _0x5c0994ca);
    }

    private void Start()
    {
        this._0xfac7571a = _0x744cf847._0x8ce537ac;
        this._0x066a2096 = _0x744cf847._0x5fb9f0b9;
        if (this._camera == null)
        {
            this._camera = Camera.main;
        }

        if (this._board != null)
        {
            this._board._0x2205008a();
        }

        if (this._pops != null)
        {
            this._pops._0xfd32591f();
        }

        RectTransform _0x695d17eb = this._0x7f0cdd2b();
        if (this._hud != null && this._board != null)
        {
            this._hud._0x879cfcac(_0x695d17eb, this, this._camera, this._board._0x0c5c28f2);
        }

        this._0xcb5f77e1(true);
        DOVirtual.DelayedCall(HintSoftenDelay, () => this._0xd857cf03()).SetLink(this.gameObject);
    }

    private bool _0x88f82542
    {
        get
        {
            if (this._0xe18693ae || this._0xbdb7e2e3)
            {
                return false;
            }

            _0xaa3720e7 _0xb057ae50 = _0xaa3720e7.Instance;
            return _0xb057ae50 == null || _0xb057ae50._0xa4675a86;
        }
    }

    /// A freshly scattered board may already hold triples. They are replaced before the
    /// player ever sees them, so the first move is always the player's own.
    private void _0xc5dbe5e8()
    {
        for (int _0x69d1f42c = 0; _0x69d1f42c < CascadeGuard; _0x69d1f42c++)
        {
            int _0xd4fda0c6 = this._board._0x110f8a27(this._0x1e1ff720);
            if (_0xd4fda0c6 <= 0)
            {
                return;
            }

            for (int _0x73e5b3db = 0; _0x73e5b3db < _0xd4fda0c6; _0x73e5b3db++)
            {
                this._board._0x4cc5d3c9(this._0x1e1ff720[_0x73e5b3db], this._0xc811c65a, 0.01f);
            }
        }
    }

    private void _0x09382b70()
    {
        if (this._0xbdb7e2e3)
        {
            return;
        }

        if (this._0xe578ffab != null && this._0xe578ffab._0xc982578c)
        {
            this._0xd313728d();
            return;
        }

        this._0xc5dbe5e8();
        this._0xe18693ae = false;
        if (this._0x7a6080f8 != null && this._0x7a6080f8._0xd001c26d)
        {
            this._0xd2b0de7e();
        }
    }

    private void _0x6606bf6b()
    {
        if (this._0xbdb7e2e3)
        {
            return;
        }

        this._0xbdb7e2e3 = true;
        this._0xe18693ae = true;
        _0x744cf847._0x5fb9f0b9 = this._0x066a2096 + 1;
        _0x744cf847._0x90fc7e1b = _0x744cf847._0x90fc7e1b + this._0xe578ffab.BasketTotal;
        if (this._board != null)
        {
            this._board._0x88289bbf(0.3f);
        }

        int _0x35e61cf6 = this._0xe578ffab.BasketTotal;
        DOVirtual.DelayedCall(PopDelay, () => this._0x06fe79ed(_0x35e61cf6)).SetLink(this.gameObject);
    }

    private readonly int[] _0x1e1ff720 = new int[_0x20f7bed2.Sectors];
    public void _0x01d36440()
    {
        if (this._0xbdb7e2e3)
        {
            return;
        }

        _0xaa3720e7 _0x9f059ffd = _0xaa3720e7.Instance;
        if (_0x9f059ffd != null)
        {
            _0x9f059ffd._0xfcdfb188(false);
        }

        if (this._pops != null)
        {
            this._pops._0x02be0408();
        }
    }

    private const float RingTurnTime = 0.46f;
    [SerializeField]
    private Camera _camera;
    public void _0x78940167()
    {
        _0xaa3720e7 _0xe240579e = _0xaa3720e7.Instance;
        if (_0xe240579e == null)
        {
            return;
        }

        _0xe240579e._0xfcdfb188(true);
        _0xe240579e._0x4fdc6a2f(_0x44bff367._0x7725f086.SCENE_0);
    }

    private bool _0xbdb7e2e3;
    private const int CascadeGuard = 12;
    /// Running out of turns does not end the run: a new delivery arrives and the board
    /// stays on screen. Only the fourth expiry closes the round.
    private void _0xd2b0de7e()
    {
        if (this._0xbdb7e2e3)
        {
            return;
        }

        this._0xe18693ae = true;
        if (this._hud != null)
        {
            this._hud._0xd2c673e4(ExpiryHold);
        }

        bool _0x4118acb5 = this._0x7a6080f8._0x5e8bc3fa();
        {
#if B_LOGS
            {
                Debug.Log($"[expire] count={this._0x7a6080f8.Expiries} alive={_0x4118acb5}");
            }
#endif
        }

        if (!_0x4118acb5)
        {
            DOVirtual.DelayedCall(ExpiryHold, () => this._0x6606bf6b()).SetLink(this.gameObject);
            return;
        }

        DOVirtual.DelayedCall(ExpiryHold, () => this._0xcb5f77e1(false)).SetLink(this.gameObject);
    }

    private void _0xafcf0e81()
    {
        if (this._0xbdb7e2e3 || this._board == null)
        {
            return;
        }

        int _0x3432bf9d = this._board._0x110f8a27(this._0x1e1ff720);
        if (_0x3432bf9d <= 0)
        {
            this._0xe18693ae = false;
            if (this._0x7a6080f8._0xd001c26d)
            {
                this._0xd2b0de7e();
            }

            return;
        }

        for (int _0xebcb9ff9 = 0; _0xebcb9ff9 < _0x3432bf9d; _0xebcb9ff9++)
        {
            int _0x26ba03b6 = this._0x1e1ff720[_0xebcb9ff9];
            int _0xaac2b75e = this._board._0xd5a43299(0, _0x26ba03b6);
            this._board._0xc104b05f(_0x26ba03b6);
            this._board._0xef26d12c(_0x26ba03b6, this._hud != null ? this._hud._0x7d83f684 : Vector3.zero, LiftTime, FlyTime);
            this._0xe578ffab._0xfadaa528(_0xaac2b75e, _0x20f7bed2.Rings);
            this._0x7a6080f8._0x971598c5();
            {
#if B_LOGS
                {
                    Debug.Log($"[harvest] spoke={_0x26ba03b6} produce={_0xaac2b75e} basket={this._0xe578ffab.BasketTotal} left={this._0x7a6080f8.Left}");
                }
#endif
            }
        }

        if (this._hud != null)
        {
            this._hud._0xa77791c4(this._0xe578ffab);
            this._hud._0x515475ac(this._0x7a6080f8.Left);
            this._hud._0xc23690cc();
        }

        if (_0x744cf847._0x4d7aec3d)
        {
            Handheld.Vibrate();
        }

        int _0x2a7ecb12 = _0x3432bf9d;
        DOVirtual.DelayedCall(FlashTime + FlyTime, () => this._0x99d79605(_0x2a7ecb12)).SetLink(this.gameObject);
    }

    private int _0x066a2096;
    /// Canvas order for the fallback HUD host. Strictly below the popup canvases at 10.
    private const int FallbackCanvasOrder = 5;
    private void _0xd313728d()
    {
        if (this._0xbdb7e2e3)
        {
            return;
        }

        this._0xbdb7e2e3 = true;
        this._0xe18693ae = true;
        int _0xed0db321 = Mathf.Max(_0x744cf847._0x5f18a4d3, this._0xfac7571a + 1);
        _0x744cf847._0x5f18a4d3 = _0xed0db321;
        _0x744cf847._0x8ce537ac = Mathf.Min(this._0xfac7571a + 1, _0x744cf847.TreeCount - 1);
        _0x744cf847._0x5fb9f0b9 = 0;
        _0x744cf847._0x90fc7e1b = _0x744cf847._0x90fc7e1b + this._0xe578ffab.BasketTotal;
        if (this._board != null)
        {
            this._board._0x88289bbf(0.3f);
        }

        int _0x3ecf1218 = this._0x7a6080f8.Spent;
        int _0x40fe9d4b = this._0xe578ffab.BasketTotal;
        int _0x0c10760f = this._0xfac7571a + 1;
        DOVirtual.DelayedCall(PopDelay, () => this._0x941cb264(_0x3ecf1218, _0x40fe9d4b, _0x0c10760f)).SetLink(this.gameObject);
    }

    public void _0x772726c7(int _0xc5521126)
    {
        if (!this._0x88f82542 || this._board == null)
        {
            return;
        }

        this._board._0x115823be(_0xc5521126);
    }

    private const float FlashTime = 0.16f;
    private const float ExpiryHold = 1.1f;
    private bool _0xe18693ae;
    private _0xd75021d4 _0xc811c65a;
    private readonly _0x9b423b05 _0xa3f0a392 = new _0x9b423b05();
    private _0xa9eaa9fc _0x7a6080f8;
    [SerializeField]
    private RectTransform _hudRoot;
    private int _0x2398df50 = HintsPerTree;
    private const float RefillTime = 0.28f;
    private int _0xfac7571a;
    public void _0x974f31f2()
    {
        if (!this._0x88f82542 || this._0x2398df50 <= 0 || this._board == null)
        {
            return;
        }

        this._0x2398df50--;
        if (this._hud != null)
        {
            this._hud._0x1a809ce1(this._0x2398df50);
            this._hud._0xb287ac77();
        }

        bool _0x6819e1e8 = this._0xa3f0a392._0xfd27bdf4(this._board._0x6ba4c048, this._board._0x444672ee(0), this._board._0x444672ee(1), this._board._0x444672ee(2), this._0xe578ffab != null ? this._0xe578ffab._0x2981f5f1 : -1);
        if (!_0x6819e1e8)
        {
            _0x6819e1e8 = this._0xa3f0a392._0xfd27bdf4(this._board._0x6ba4c048, this._board._0x444672ee(0), this._board._0x444672ee(1), this._board._0x444672ee(2), -1);
        }

        if (!_0x6819e1e8)
        {
            return;
        }

        this._board._0x115823be(this._0xa3f0a392.HintRing);
        this._board._0xdb267deb(this._0xa3f0a392.HintRing);
    }

    private const float SettleTime = 0.16f;
    [SerializeField]
    private _0x29e98311 _pops;
    private void _0x06fe79ed(int _0xf2364827)
    {
        if (this._pops != null)
        {
            this._pops._0xf298aad1(_0xf2364827);
        }
    }

    private const float HintSoftenDelay = 20f;
    private const float PopDelay = 0.45f;
    private void _0x99d79605(int _0xae73c7b9)
    {
        if (this._0xbdb7e2e3 || this._board == null)
        {
            return;
        }

        for (int _0x362ae1e0 = 0; _0x362ae1e0 < _0xae73c7b9; _0x362ae1e0++)
        {
            this._board._0x4cc5d3c9(this._0x1e1ff720[_0x362ae1e0], this._0xc811c65a, RefillTime);
        }

        DOVirtual.DelayedCall(RefillTime, () => this._0x09382b70()).SetLink(this.gameObject);
    }
}

internal static class _0xc58fbf63
{
    internal static string _0x625e73ab(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}