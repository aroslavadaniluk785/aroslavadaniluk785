using DG.Tweening;
using UnityEngine;

/// The three turning rings, their 24 sockets and the harvest animation.
/// Every size comes from RingLayoutMath, which derives from the scene camera, and every
/// sprite order is one of its named constants - nothing here is an eyeballed number.
public sealed class _0x12c26713 : MonoBehaviour
{
    /// The plate of a ring is created BEFORE its sockets, so the wooden frame can never
    /// cover the produce it frames.
    private void _0x4c6fcf37()
    {
        this._0x755707ee = new _0xb83a2af7[_0xd75021d4.CellCount];
        for (int _0x74e1680c = 0; _0x74e1680c < _0x20f7bed2.Rings; _0x74e1680c++)
        {
            GameObject _0x7468c0e0 = new GameObject(_0xfb942387._0xa3db12d3(new byte[4] { 112, 75, 76, 69 }, 34), typeof(Transform));
            _0x7468c0e0.transform.SetParent(this.transform, false);
            _0x7468c0e0.transform.localPosition = Vector3.zero;
            _0x7468c0e0.transform.localScale = Vector3.one;
            this._0x0086c18d[_0x74e1680c] = _0x7468c0e0.transform;
            Sprite _0x2bb29b21 = _0x74e1680c < this._ringSprites.Length ? this._ringSprites[_0x74e1680c] : null;
            this._0x3ef7ed17[_0x74e1680c] = this._0xdeb13fd3(_0x7468c0e0.transform, _0xfb942387._0xa3db12d3(new byte[5] { 42, 22, 27, 14, 31 }, 122), _0x2bb29b21, this._0xfd06462d.PlateSize[_0x74e1680c], this._0xfd06462d._0x563d1e19(_0x74e1680c));
            for (int _0x3e43dd34 = 0; _0x3e43dd34 < _0x20f7bed2.Sectors; _0x3e43dd34++)
            {
                _0xb83a2af7 _0x48136304 = Instantiate(this._cellPrefab, _0x7468c0e0.transform);
                _0x48136304.transform.localPosition = this._0xfd06462d._0x744de2d3(_0x74e1680c, _0x3e43dd34);
                _0x48136304.transform.localScale = Vector3.one;
                _0x48136304._0xd009fe27(this._0xfd06462d.SlotSize[_0x74e1680c], this._0xfd06462d.ItemSize[_0x74e1680c], _0x20f7bed2.SlotOrder, _0x20f7bed2.ItemOrder);
                this._0x755707ee[_0x74e1680c * _0x20f7bed2.Sectors + _0x3e43dd34] = _0x48136304;
            }
        }
    }

    [SerializeField]
    private Sprite _hubSprite;
    private void _0x2f75514c()
    {
        this._0xdeb13fd3(this.transform, _0xfb942387._0xa3db12d3(new byte[3] { 236, 209, 198 }, 164), this._hubSprite, this._0xfd06462d.HubSize, _0x20f7bed2.HubOrder);
    }

    public void _0xdb267deb(int _0x310920f1)
    {
        this._0x2205008a();
        SpriteRenderer _0x3d9f3e5d = this._0x3ef7ed17[Mathf.Clamp(_0x310920f1, 0, _0x20f7bed2.Rings - 1)];
        if (_0x3d9f3e5d == null)
        {
            return;
        }

        _0x3d9f3e5d.DOColor(_0x47f8534e.Gold, 0.3f).SetLoops(6, LoopType.Yoyo).SetLink(_0x3d9f3e5d.gameObject);
    }

    private void OnDestroy()
    {
        for (int _0x36bcb2f9 = 0; _0x36bcb2f9 < _0x20f7bed2.Rings; _0x36bcb2f9++)
        {
            if (this._0x3ef7ed17[_0x36bcb2f9] != null)
            {
                DOTween.Kill(this._0x3ef7ed17[_0x36bcb2f9]);
            }

            if (this._0x0086c18d[_0x36bcb2f9] != null)
            {
                DOTween.Kill(this._0x0086c18d[_0x36bcb2f9]);
            }
        }

        if (this._0x2f084c60 == null)
        {
            return;
        }

        for (int _0xb30ee7e7 = 0; _0xb30ee7e7 < this._0x2f084c60.Length; _0xb30ee7e7++)
        {
            if (this._0x2f084c60[_0xb30ee7e7] != null)
            {
                DOTween.Kill(this._0x2f084c60[_0xb30ee7e7]);
            }
        }
    }

    public void _0x4cc5d3c9(int _0x4c2fbe23, _0xd75021d4 _0x194d609e, float _0x005715d8)
    {
        this._0x2205008a();
        for (int _0x76c56f99 = 0; _0x76c56f99 < _0x20f7bed2.Rings; _0x76c56f99++)
        {
            int _0x472f8749 = _0x76c56f99 * _0x20f7bed2.Sectors + _0x20f7bed2.Wrap(_0x4c2fbe23 + this._0xbf880b68[_0x76c56f99]);
            int _0x43a0197e = _0x194d609e._0xd2548d5b();
            this._0x50aadd4a[_0x472f8749] = _0x43a0197e;
            _0xb83a2af7 _0xc8f78d19 = this._0x755707ee[_0x472f8749];
            _0xc8f78d19._0xa8471476(_0x43a0197e, this._0xb1081ef3(_0x43a0197e));
            _0xc8f78d19._0x74331ad7(_0x005715d8);
        }
    }

    public int _0x7fe56efc
    {
        get
        {
            return this._0x3d92330d;
        }
    }

    private _0xb83a2af7[] _0x755707ee;
    /// Spokes where all three rings currently show the same produce.
    public int _0x110f8a27(int[] _0xdccb1194)
    {
        this._0x2205008a();
        int _0x68d8a7cc = 0;
        for (int _0x6d990997 = 0; _0x6d990997 < _0x20f7bed2.Sectors; _0x6d990997++)
        {
            int _0x34e1c3df = this._0xd5a43299(0, _0x6d990997);
            if (_0x34e1c3df < 0)
            {
                continue;
            }

            if (_0x34e1c3df != this._0xd5a43299(1, _0x6d990997))
            {
                continue;
            }

            if (_0x34e1c3df != this._0xd5a43299(2, _0x6d990997))
            {
                continue;
            }

            _0xdccb1194[_0x68d8a7cc] = _0x6d990997;
            _0x68d8a7cc++;
        }

        return _0x68d8a7cc;
    }

    private bool _0x4ab6179f;
    [SerializeField]
    private Sprite[] _ringSprites = new Sprite[_0x20f7bed2.Rings];
    public void _0xc104b05f(int _0x6c8fce94)
    {
        this._0x2205008a();
        SpriteRenderer _0xde24b30d = this._0x2f084c60[_0x20f7bed2.Wrap(_0x6c8fce94)];
        if (_0xde24b30d == null)
        {
            return;
        }

        _0xde24b30d.color = _0x47f8534e.Fade(_0x47f8534e.Gold, 0f);
        _0xde24b30d.DOFade(0.9f, 0.16f).SetLoops(2, LoopType.Yoyo).SetLink(_0xde24b30d.gameObject);
    }

    private readonly int[] _0x50aadd4a = new int[_0xd75021d4.CellCount];
    [SerializeField]
    private _0xb83a2af7 _cellPrefab;
    private Sprite _0xb1081ef3(int _0xe0b3d3b0)
    {
        if (_0xe0b3d3b0 < 0 || this._produceSprites == null || _0xe0b3d3b0 >= this._produceSprites.Length)
        {
            return null;
        }

        return this._produceSprites[_0xe0b3d3b0];
    }

    public int _0xd5a43299(int _0xe2562aae, int _0x414ae2e5)
    {
        return this._0x50aadd4a[_0xe2562aae * _0x20f7bed2.Sectors + _0x20f7bed2.Wrap(_0x414ae2e5 + this._0xbf880b68[_0xe2562aae])];
    }

    private readonly SpriteRenderer[] _0x3ef7ed17 = new SpriteRenderer[_0x20f7bed2.Rings];
    /// Built on demand rather than in Start, so whoever needs the board first gets it
    /// ready instead of depending on the order of Start calls.
    public void _0x2205008a()
    {
        if (this._0x4ab6179f)
        {
            return;
        }

        this._0x4ab6179f = true;
        if (this._camera == null)
        {
            this._camera = Camera.main;
        }

        this._0xfd06462d = new _0x20f7bed2()._0xad09e758(this._camera);
        this.transform.position = this._0xfd06462d.BoardCentre;
        this.transform.localScale = Vector3.one;
        this._0x9e6de9be();
        this._0x4c6fcf37();
        this._0x2f75514c();
        this._0x857a469e();
    }

    /// One notch. The ring turns and every socket turns back by the same amount, so the
    /// produce never tilts.
    public void _0xfa3a0fc5(int _0xd816307e, int _0xa9006cc8, float _0xe5b54d1a)
    {
        this._0x2205008a();
        int _0x0e175e4e = Mathf.Clamp(_0xd816307e, 0, _0x20f7bed2.Rings - 1);
        this._0xbf880b68[_0x0e175e4e] = this._0xbf880b68[_0x0e175e4e] + _0xa9006cc8;
        float _0xd544828e = this._0xbf880b68[_0x0e175e4e] * _0x20f7bed2.SectorStep;
        Transform _0x05d47d1e = this._0x0086c18d[_0x0e175e4e];
        _0x05d47d1e.DORotate(new Vector3(0f, 0f, _0xd544828e), _0xe5b54d1a, RotateMode.FastBeyond360).SetEase(Ease.OutBack).SetLink(_0x05d47d1e.gameObject);
        for (int _0x7565d1ba = 0; _0x7565d1ba < _0x20f7bed2.Sectors; _0x7565d1ba++)
        {
            this._0x755707ee[_0x0e175e4e * _0x20f7bed2.Sectors + _0x7565d1ba]._0xf696addc(_0xd544828e, _0xe5b54d1a);
        }
    }

    public void _0x88289bbf(float _0x031ff088)
    {
        this._0x2205008a();
        for (int _0x6806d802 = 0; _0x6806d802 < _0x20f7bed2.Rings; _0x6806d802++)
        {
            if (this._0x3ef7ed17[_0x6806d802] == null)
            {
                continue;
            }

            this._0x3ef7ed17[_0x6806d802].DOColor(_0x47f8534e.Fade(Color.white, 0.45f), _0x031ff088).SetLink(this._0x3ef7ed17[_0x6806d802].gameObject);
        }
    }

    private void _0x9e6de9be()
    {
        this._0xdeb13fd3(this.transform, _0xfb942387._0xa3db12d3(new byte[4] { 246, 202, 204, 201 }, 165), this._soilSprite, this._0xfd06462d.SoilSize, _0x20f7bed2.SoilOrder);
    }

    public void _0xef26d12c(int _0x385212af, Vector3 _0x23eda340, float _0x43e8a4d3, float _0xab0678bd)
    {
        this._0x2205008a();
        for (int _0x366e10c6 = 0; _0x366e10c6 < _0x20f7bed2.Rings; _0x366e10c6++)
        {
            _0xb83a2af7 _0xecc2fbe4 = this._0x732db66c(_0x366e10c6, _0x385212af);
            _0xecc2fbe4._0x3647eaf2(_0x43e8a4d3);
            _0xecc2fbe4._0x224b0212(_0x23eda340, _0xab0678bd);
        }
    }

    private void _0x857a469e()
    {
        this._0x2f084c60 = new SpriteRenderer[_0x20f7bed2.Sectors];
        float _0x807ada85 = this._0xfd06462d.BoardRadius * 0.52f;
        float _0xc682d772 = this._0xfd06462d.BoardRadius * 0.95f;
        for (int _0xacde9439 = 0; _0xacde9439 < _0x20f7bed2.Sectors; _0xacde9439++)
        {
            GameObject _0x513de167 = Instantiate(this._glowPrefab, this.transform);
            float _0xd04813f3 = (90f - _0xacde9439 * _0x20f7bed2.SectorStep) * Mathf.Deg2Rad;
            _0x513de167.transform.localPosition = new Vector3(Mathf.Cos(_0xd04813f3) * _0x807ada85, Mathf.Sin(_0xd04813f3) * _0x807ada85, 0f);
            _0x513de167.transform.localRotation = Quaternion.Euler(0f, 0f, -_0xacde9439 * _0x20f7bed2.SectorStep);
            _0x513de167.transform.localScale = Vector3.one;
            SpriteRenderer _0xa50a57fb = _0x513de167.GetComponent<SpriteRenderer>();
            if (_0xa50a57fb != null)
            {
                _0xa50a57fb.drawMode = SpriteDrawMode.Sliced;
                _0xa50a57fb.size = new Vector2(_0xc682d772, _0xc682d772);
                _0xa50a57fb.sortingOrder = _0x20f7bed2.Clamped(_0x20f7bed2.GlowOrder);
                _0xa50a57fb.color = _0x47f8534e.Fade(_0x47f8534e.Gold, 0f);
            }

            this._0x2f084c60[_0xacde9439] = _0xa50a57fb;
        }
    }

    public int _0x444672ee(int _0x369133e3)
    {
        return this._0xbf880b68[Mathf.Clamp(_0x369133e3, 0, _0x20f7bed2.Rings - 1)];
    }

    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private GameObject _glowPrefab;
    private SpriteRenderer _0xdeb13fd3(Transform _0xca428bc7, string _0x062bebd7, Sprite _0xbf3c91a1, float _0x548c6cec, int _0xd2f6c951)
    {
        GameObject _0x03f4776e = new GameObject(_0x062bebd7, typeof(SpriteRenderer));
        _0x03f4776e.transform.SetParent(_0xca428bc7, false);
        _0x03f4776e.transform.localPosition = Vector3.zero;
        _0x03f4776e.transform.localScale = Vector3.one;
        SpriteRenderer _0x9dfd5b45 = _0x03f4776e.GetComponent<SpriteRenderer>();
        _0x9dfd5b45.sprite = _0xbf3c91a1;
        _0x9dfd5b45.drawMode = SpriteDrawMode.Sliced;
        _0x9dfd5b45.size = new Vector2(_0x548c6cec, _0x548c6cec);
        _0x9dfd5b45.sortingOrder = _0x20f7bed2.Clamped(_0xd2f6c951);
        return _0x9dfd5b45;
    }

    /// A gold wash on the chosen ring. Selection is free and costs no turn.
    public void _0x115823be(int _0xf8968bc5)
    {
        this._0x2205008a();
        this._0x3d92330d = Mathf.Clamp(_0xf8968bc5, 0, _0x20f7bed2.Rings - 1);
        for (int _0x2da98eb5 = 0; _0x2da98eb5 < _0x20f7bed2.Rings; _0x2da98eb5++)
        {
            if (this._0x3ef7ed17[_0x2da98eb5] == null)
            {
                continue;
            }

            this._0x3ef7ed17[_0x2da98eb5].color = _0x2da98eb5 == this._0x3d92330d ? _0x47f8534e.Gold : Color.white;
        }

        Transform _0xf2e5a33a = this._0x0086c18d[this._0x3d92330d];
        if (_0xf2e5a33a != null)
        {
            _0xf2e5a33a.DOPunchScale(Vector3.one * 0.03f, 0.22f, 5, 0.9f).SetLink(_0xf2e5a33a.gameObject);
        }
    }

    public void _0x8da215ed(int[] _0x68f61314)
    {
        this._0x2205008a();
        for (int _0x9ad7c9b1 = 0; _0x9ad7c9b1 < _0x20f7bed2.Rings; _0x9ad7c9b1++)
        {
            this._0xbf880b68[_0x9ad7c9b1] = 0;
            this._0x0086c18d[_0x9ad7c9b1].localRotation = Quaternion.identity;
        }

        for (int _0x65eee3d7 = 0; _0x65eee3d7 < _0xd75021d4.CellCount; _0x65eee3d7++)
        {
            this._0x50aadd4a[_0x65eee3d7] = _0x68f61314[_0x65eee3d7];
            this._0x755707ee[_0x65eee3d7]._0xa8471476(_0x68f61314[_0x65eee3d7], this._0xb1081ef3(_0x68f61314[_0x65eee3d7]));
            this._0x755707ee[_0x65eee3d7]._0xfba73a95(0f);
        }

        this._0x115823be(0);
    }

    private _0x20f7bed2 _0xfd06462d;
    [SerializeField]
    private Sprite[] _produceSprites = new Sprite[5];
    private int _0x3d92330d = -1;
    public _0xb83a2af7 _0x732db66c(int _0x944874d2, int _0x55c84818)
    {
        this._0x2205008a();
        return this._0x755707ee[_0x944874d2 * _0x20f7bed2.Sectors + _0x20f7bed2.Wrap(_0x55c84818 + this._0xbf880b68[_0x944874d2])];
    }

    private readonly int[] _0xbf880b68 = new int[_0x20f7bed2.Rings];
    public _0x20f7bed2 _0x0c5c28f2
    {
        get
        {
            this._0x2205008a();
            return this._0xfd06462d;
        }
    }

    private readonly Transform[] _0x0086c18d = new Transform[_0x20f7bed2.Rings];
    private SpriteRenderer[] _0x2f084c60;
    [SerializeField]
    private Sprite _soilSprite;
    public int[] _0x6ba4c048
    {
        get
        {
            return this._0x50aadd4a;
        }
    }
}

internal static class _0xfb942387
{
    internal static string _0xa3db12d3(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}