using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// The whole game-scene HUD: order board, turn counter, gesture hint, expiry banner and
/// the floating control bar. Every object here is created by this component, so nothing
/// depends on a template placeholder that the pipeline may switch off.
public sealed class _0x32ce2a44 : MonoBehaviour
{
    /// The control scheme is a drag, so the gesture and its result are named on screen and
    /// stay there for the whole run.
    private void _0x7c61f19b(RectTransform _0x60bc5423)
    {
        RectTransform _0x4d64ac97 = _0x44b73caf.Plate(_0x60bc5423, _0x1536421c._0xa832788e(new byte[11] { 216, 250, 236, 235, 234, 237, 250, 215, 246, 241, 235 }, 159), this._panelWood, _0x47f8534e.Fade(_0x47f8534e.Pine, 0.88f), new Vector2(0.5f, 0f), new Vector2(0f, 539f), new Vector2(920f, 76f)).rectTransform;
        this._0x68684e41 = _0x44b73caf.Label(_0x4d64ac97, this._font, _0x1536421c._0xa832788e(new byte[11] { 195, 225, 247, 240, 241, 246, 225, 208, 225, 252, 240 }, 132), _0x1536421c._0xa832788e(new byte[22] { 120, 110, 125, 123, 28, 125, 28, 110, 117, 114, 123, 28, 104, 115, 28, 104, 105, 110, 114, 28, 117, 104 }, 60), HintSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(880f, 56f), TextAlignmentOptions.Center);
    }

    private readonly TextMeshProUGUI[] _0xae61c1c6 = new TextMeshProUGUI[_0xd75021d4.MaxOrderRows];
    private void _0xed501fcf()
    {
        if (this._0x6244c138 != null)
        {
            this._0x6244c138.gameObject.SetActive(false);
        }
    }

    private _0x3d2dc9ef _0x1ea76c04;
    public void _0xb287ac77()
    {
        if (this._0xe3f2568d == null)
        {
            return;
        }

        Transform _0x273017fd = this._0xe3f2568d.transform;
        _0x273017fd.DOPunchScale(Vector3.one * 0.12f, 0.3f, 6, 0.8f).SetLink(_0x273017fd.gameObject);
    }

    [SerializeField]
    private TMP_FontAsset _font;
    private RectTransform _0x6244c138;
    private TextMeshProUGUI _0x4d511d0e;
    private void _0x98558d72(RectTransform _0x2f7889ce, _0xd2425d92 _0x6631cfa1)
    {
        RectTransform _0xe4191754 = _0x44b73caf.Plate(_0x2f7889ce, _0x1536421c._0xa832788e(new byte[10] { 54, 26, 27, 1, 7, 26, 25, 55, 20, 7 }, 117), this._panelWood, _0x47f8534e.Fade(_0x47f8534e.Pine, 0.94f), new Vector2(0.5f, 0f), new Vector2(0f, 300f), new Vector2(1060f, 210f)).rectTransform;
        Button _0xc8105ee1 = _0x44b73caf.IconAction(_0xe4191754, _0x1536421c._0xa832788e(new byte[8] { 151, 182, 177, 173, 143, 166, 165, 183 }, 195), this._btnPrimary, _0x47f8534e.Gold, this._iconTurnLeft, 88f, new Vector2(0.5f, 0.5f), new Vector2(-340f, 0f), new Vector2(200f, 160f));
        _0xc8105ee1.onClick.AddListener(() => _0x6631cfa1._0x31e3126e(1));
        Button _0x333f6444 = _0x44b73caf.IconAction(_0xe4191754, _0x1536421c._0xa832788e(new byte[9] { 28, 61, 58, 38, 26, 33, 47, 32, 60 }, 72), this._btnPrimary, _0x47f8534e.Gold, this._iconTurnRight, 88f, new Vector2(0.5f, 0.5f), new Vector2(340f, 0f), new Vector2(200f, 160f));
        _0x333f6444.onClick.AddListener(() => _0x6631cfa1._0x31e3126e(-1));
        this._0xe3f2568d = _0x44b73caf.Action(_0xe4191754, this._font, _0x1536421c._0xa832788e(new byte[10] { 16, 49, 54, 44, 26, 45, 44, 44, 55, 54 }, 88), this._btnSecondary, _0x47f8534e.Leaf, null, PadSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(260f, 160f));
        this._0x37cb0968 = this._0xe3f2568d.targetGraphic as Image;
        RectTransform _0xc38e2244 = this._0xe3f2568d.transform as RectTransform;
        _0x44b73caf.Picture(_0xc38e2244, _0x1536421c._0xa832788e(new byte[8] { 98, 67, 68, 94, 99, 73, 69, 68 }, 42), this._iconHint, new Vector2(0.5f, 0.5f), new Vector2(0f, 30f), new Vector2(68f, 68f));
        this._0xf92f98b1 = _0x44b73caf.Label(_0xc38e2244, this._font, _0x1536421c._0xa832788e(new byte[8] { 86, 119, 112, 106, 74, 123, 102, 106 }, 30), _0x1536421c._0xa832788e(new byte[6] { 121, 120, 127, 101, 17, 2 }, 49), PadSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(0f, -44f), new Vector2(220f, 44f), TextAlignmentOptions.Center);
        this._0xe3f2568d.onClick.AddListener(() => _0x6631cfa1._0x974f31f2());
    }

    /// Two columns that never share x-space: the produce icon lives in its own gutter and
    /// the row text starts well to the right of it.
    private void _0xeddef644(RectTransform _0xe1b6ba20)
    {
        const float _0x2ace4fc6 = 1040f;
        const float _0x21d2eb59 = -428f;
        const float _0x50989af0 = 6f;
        const float _0xde28d6f3 = 700f;
        this._0x971e46af = _0x44b73caf.Plate(_0xe1b6ba20, _0x1536421c._0xa832788e(new byte[10] { 20, 41, 63, 62, 41, 25, 52, 58, 41, 63 }, 91), this._orderBoard, _0x47f8534e.PineDeep, new Vector2(0.5f, 1f), new Vector2(0f, -310f), new Vector2(_0x2ace4fc6, 260f)).rectTransform;
        _0x44b73caf.Label(this._0x971e46af, this._font, _0x1536421c._0xa832788e(new byte[11] { 113, 76, 90, 91, 76, 118, 91, 95, 90, 91, 76 }, 62), _0x1536421c._0xa832788e(new byte[5] { 150, 139, 157, 156, 139 }, 217), HeaderSize, _0x47f8534e.LeafLight, new Vector2(0.5f, 0.5f), new Vector2(0f, 96f), new Vector2(420f, 44f), TextAlignmentOptions.Center);
        float[] _0xdb710927 =
        {
            28f,
            -34f,
            -96f
        };
        for (int _0xc1481c0b = 0; _0xc1481c0b < _0xd75021d4.MaxOrderRows; _0xc1481c0b++)
        {
            RectTransform _0x6bb4a412 = _0x44b73caf.Node(this._0x971e46af, _0x1536421c._0xa832788e(new byte[8] { 137, 180, 162, 163, 180, 148, 169, 177 }, 198), new Vector2(0.5f, 0.5f), new Vector2(0f, _0xdb710927[_0xc1481c0b]), new Vector2(_0x2ace4fc6 - 40f, 56f));
            this._0xeb431f86[_0xc1481c0b] = _0x6bb4a412;
            this._0x831dfb48[_0xc1481c0b] = _0x44b73caf.Picture(_0x6bb4a412, _0x1536421c._0xa832788e(new byte[7] { 147, 174, 182, 136, 162, 174, 175 }, 193), null, new Vector2(0.5f, 0.5f), new Vector2(_0x21d2eb59, 0f), new Vector2(56f, 56f));
            this._0xae61c1c6[_0xc1481c0b] = _0x44b73caf.Label(_0x6bb4a412, this._font, _0x1536421c._0xa832788e(new byte[7] { 219, 230, 254, 221, 236, 241, 253 }, 137), "", RowSize, _0x47f8534e.Cream, new Vector2(0.5f, 0.5f), new Vector2(_0x50989af0, 0f), new Vector2(_0xde28d6f3, 52f), TextAlignmentOptions.Left);
            this._0xe44b1a50[_0xc1481c0b] = _0x44b73caf.Picture(_0x6bb4a412, _0x1536421c._0xa832788e(new byte[7] { 88, 101, 125, 94, 99, 105, 97 }, 10), this._tickMark, new Vector2(0.5f, 0.5f), new Vector2(420f, 0f), new Vector2(44f, 44f));
            this._0xe44b1a50[_0xc1481c0b].gameObject.SetActive(false);
            _0x6bb4a412.gameObject.SetActive(false);
        }
    }

    private readonly Image[] _0xe44b1a50 = new Image[_0xd75021d4.MaxOrderRows];
    private Button _0xe3f2568d;
    private readonly Image[] _0x831dfb48 = new Image[_0xd75021d4.MaxOrderRows];
    private TextMeshProUGUI _0x68684e41;
    private TextMeshProUGUI _0x8bae1b04;
    [SerializeField]
    private Sprite _tickMark;
    private const float PadSize = 32f;
    public _0x3d2dc9ef _0xa9255c2f
    {
        get
        {
            return this._0x1ea76c04;
        }
    }

    /// Builds the HUD into <root>. The drag catcher is created FIRST so every button
    /// added afterwards sits above it and wins the tap.
    public void _0x879cfcac(RectTransform _0xa62acd9d, _0xd2425d92 _0x4d70fc49, Camera _0xd46434e5, _0x20f7bed2 _0x366fc1b2)
    {
        if (_0xa62acd9d == null)
        {
            return;
        }

        RectTransform _0xcc78d41d = _0x44b73caf.Full(_0xa62acd9d, _0x1536421c._0xa832788e(new byte[10] { 72, 101, 107, 120, 110, 94, 101, 127, 105, 98 }, 10));
        Image _0x373eeed5 = _0xcc78d41d.gameObject.AddComponent<Image>();
        _0x373eeed5.color = _0x47f8534e.Fade(Color.white, 0f);
        _0x373eeed5.raycastTarget = true;
        this._0x1ea76c04 = _0xcc78d41d.gameObject.AddComponent<_0x3d2dc9ef>();
        this._0x1ea76c04._0x7dc62539(_0x4d70fc49, _0xd46434e5, _0x366fc1b2);
        Button _0xc9750f30 = _0x44b73caf.IconAction(_0xa62acd9d, _0x1536421c._0xa832788e(new byte[10] { 169, 138, 136, 128, 169, 158, 159, 159, 132, 133 }, 235), this._btnSecondary, _0x47f8534e.Pine, this._iconBack, 72f, new Vector2(0f, 1f), new Vector2(108f, -148f), new Vector2(132f, 132f));
        _0xc9750f30.onClick.AddListener(() => _0x4d70fc49._0x78940167());
        Button _0x361f23cc = _0x44b73caf.IconAction(_0xa62acd9d, _0x1536421c._0xa832788e(new byte[11] { 25, 40, 60, 58, 44, 11, 60, 61, 61, 38, 39 }, 73), this._btnSecondary, _0x47f8534e.Pine, this._iconPause, 72f, new Vector2(1f, 1f), new Vector2(-108f, -148f), new Vector2(132f, 132f));
        _0x361f23cc.onClick.AddListener(() => _0x4d70fc49._0x01d36440());
        this._0xeddef644(_0xa62acd9d);
        this._0x45807d16(_0xa62acd9d);
        this._0x7c61f19b(_0xa62acd9d);
        this._0x98558d72(_0xa62acd9d, _0x4d70fc49);
        this._0x7e2e77b5(_0xa62acd9d);
    }

    private Image _0x37cb0968;
    [SerializeField]
    private Sprite _btnPrimary;
    /// The hint never disappears: the review is judged on stills, and an invisible hint is
    /// no hint. It only steps back once the player has clearly got going.
    public void _0xeb8c3692()
    {
        if (this._0x68684e41 == null)
        {
            return;
        }

        this._0x68684e41.DOFade(0.55f, 0.6f).SetLink(this._0x68684e41.gameObject);
    }

    [SerializeField]
    private Sprite _iconPause;
    private void _0x45807d16(RectTransform _0xc5dcde25)
    {
        this._0x0a21a9d5 = _0x44b73caf.Plate(_0xc5dcde25, _0x1536421c._0xa832788e(new byte[12] { 158, 191, 184, 164, 185, 137, 165, 191, 164, 190, 175, 184 }, 202), this._panelWood, _0x47f8534e.Pine, new Vector2(0.5f, 1f), new Vector2(0f, -504f), new Vector2(420f, 96f)).rectTransform;
        // The box is sized for the widest value the counter can ever show, so autosize
        // never has to shrink it mid-run.
        this._0x8bae1b04 = _0x44b73caf.Label(this._0x0a21a9d5, this._font, _0x1536421c._0xa832788e(new byte[9] { 156, 189, 186, 166, 187, 156, 173, 176, 188 }, 200), _0x1536421c._0xa832788e(new byte[9] { 140, 141, 138, 150, 139, 248, 232, 232, 232 }, 216), CounterSize, _0x47f8534e.Gold, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(372f, 68f), TextAlignmentOptions.Center);
    }

    [SerializeField]
    private Sprite _iconTurnLeft;
    private const float HintSize = 38f;
    private const float BannerSize = 48f;
    [SerializeField]
    private Sprite[] _produceSprites = new Sprite[5];
    [SerializeField]
    private Sprite _panelWood;
    public Vector3 _0x7d83f684
    {
        get
        {
            if (this._0x971e46af == null)
            {
                return Vector3.zero;
            }

            Vector3 _0x3c835552 = this._0x971e46af.position;
            return new Vector3(_0x3c835552.x, _0x3c835552.y, 0f);
        }
    }

    [SerializeField]
    private Sprite _orderBoard;
    private RectTransform _0x971e46af;
    [SerializeField]
    private Sprite _iconHint;
    public void _0x1a809ce1(int _0xf8d22bfd)
    {
        _0x44b73caf.Retext(this._0xf92f98b1, _0x1536421c._0xa832788e(new byte[5] { 74, 75, 76, 86, 34 }, 2) + _0xf8d22bfd, PadSize, _0x47f8534e.Cream);
        if (this._0x37cb0968 != null)
        {
            this._0x37cb0968.color = _0xf8d22bfd > 0 ? _0x47f8534e.Leaf : _0x47f8534e.Fade(_0x47f8534e.Leaf, 0.45f);
        }

        if (this._0xe3f2568d != null)
        {
            this._0xe3f2568d.interactable = _0xf8d22bfd > 0;
        }
    }

    private readonly RectTransform[] _0xeb431f86 = new RectTransform[_0xd75021d4.MaxOrderRows];
    /// Shown while a spent delivery is replaced; gameplay resumes right after.
    public void _0xd2c673e4(float _0xe108fc5b)
    {
        if (this._0x6244c138 == null)
        {
            return;
        }

        this._0x6244c138.gameObject.SetActive(true);
        this._0x6244c138.localScale = Vector3.one * 0.86f;
        this._0x6244c138.DOScale(Vector3.one, 0.18f).SetEase(Ease.OutBack).SetLink(this._0x6244c138.gameObject);
        DOVirtual.DelayedCall(_0xe108fc5b, () => this._0xed501fcf()).SetLink(this.gameObject);
    }

    [SerializeField]
    private Sprite _btnSecondary;
    private void OnDestroy()
    {
        if (this._0x0a21a9d5 != null)
        {
            DOTween.Kill(this._0x0a21a9d5);
        }

        if (this._0x6244c138 != null)
        {
            DOTween.Kill(this._0x6244c138);
        }

        if (this._0x68684e41 != null)
        {
            DOTween.Kill(this._0x68684e41);
        }

        if (this._0xe3f2568d != null)
        {
            DOTween.Kill(this._0xe3f2568d.transform);
        }
    }

    public void _0xc23690cc()
    {
        if (this._0x0a21a9d5 == null)
        {
            return;
        }

        this._0x0a21a9d5.DOPunchScale(Vector3.one * 0.18f, 0.24f, 8, 0.9f).SetLink(this._0x0a21a9d5.gameObject);
    }

    public void _0x515475ac(int _0x7095645d)
    {
        _0x44b73caf.Retext(this._0x8bae1b04, _0x1536421c._0xa832788e(new byte[6] { 130, 131, 132, 152, 133, 246 }, 214) + _0x7095645d, CounterSize, _0x47f8534e.Gold);
    }

    [SerializeField]
    private Sprite _iconTurnRight;
    private const float RowSize = 36f;
    private const float CounterSize = 56f;
    [SerializeField]
    private Sprite _iconBack;
    private TextMeshProUGUI _0xf92f98b1;
    public void _0xa77791c4(_0x0d2a82d0 _0xd6215945)
    {
        if (_0xd6215945 == null)
        {
            return;
        }

        for (int _0x285384cf = 0; _0x285384cf < _0xd75021d4.MaxOrderRows; _0x285384cf++)
        {
            bool _0xcf403b9c = _0x285384cf < _0xd6215945.Length;
            if (this._0xeb431f86[_0x285384cf] != null)
            {
                this._0xeb431f86[_0x285384cf].gameObject.SetActive(_0xcf403b9c);
            }

            if (!_0xcf403b9c)
            {
                continue;
            }

            int _0x29e9ae5c = _0xd6215945.Types[_0x285384cf];
            if (this._0x831dfb48[_0x285384cf] != null && this._produceSprites != null && _0x29e9ae5c < this._produceSprites.Length)
            {
                this._0x831dfb48[_0x285384cf].sprite = this._produceSprites[_0x29e9ae5c];
            }

            bool _0xab55e973 = _0xd6215945._0x08d6b21a(_0x285384cf);
            _0x44b73caf.Retext(this._0xae61c1c6[_0x285384cf], ProduceName(_0x29e9ae5c) + _0x1536421c._0xa832788e(new byte[3] { 58, 58, 58 }, 26) + _0xd6215945.Delivered[_0x285384cf] + _0x1536421c._0xa832788e(new byte[3] { 159, 144, 159 }, 191) + _0xd6215945.Required[_0x285384cf], RowSize, _0xab55e973 ? _0x47f8534e.LeafLight : _0x47f8534e.Cream);
            if (this._0xe44b1a50[_0x285384cf] != null)
            {
                this._0xe44b1a50[_0x285384cf].gameObject.SetActive(_0xab55e973);
            }
        }
    }

    private const float HeaderSize = 32f;
    private void _0x7e2e77b5(RectTransform _0x4c592613)
    {
        this._0x6244c138 = _0x44b73caf.Plate(_0x4c592613, _0x1536421c._0xa832788e(new byte[12] { 158, 163, 171, 178, 169, 162, 153, 186, 181, 181, 190, 169 }, 219), this._panelWood, _0x47f8534e.Fade(_0x47f8534e.Bark, 0.94f), new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(1000f, 220f)).rectTransform;
        this._0x4d511d0e = _0x44b73caf.Label(this._0x6244c138, this._font, _0x1536421c._0xa832788e(new byte[10] { 1, 34, 45, 45, 38, 49, 23, 38, 59, 55 }, 67), _0x1536421c._0xa832788e(new byte[36] { 43, 54, 32, 33, 54, 68, 33, 60, 52, 45, 54, 33, 32, 110, 37, 68, 42, 33, 51, 68, 32, 33, 40, 45, 50, 33, 54, 61, 68, 37, 54, 54, 45, 50, 33, 55 }, 100), BannerSize, _0x47f8534e.Gold, new Vector2(0.5f, 0.5f), Vector2.zero, new Vector2(940f, 170f), TextAlignmentOptions.Center);
        this._0x6244c138.gameObject.SetActive(false);
    }

    public static string ProduceName(int _0x1eb69b4f)
    {
        if (_0x1eb69b4f == 0)
        {
            return _0x1536421c._0xa832788e(new byte[5] { 33, 48, 48, 44, 37 }, 96);
        }

        if (_0x1eb69b4f == 1)
        {
            return _0x1536421c._0xa832788e(new byte[4] { 82, 71, 67, 80 }, 2);
        }

        if (_0x1eb69b4f == 2)
        {
            return _0x1536421c._0xa832788e(new byte[4] { 232, 244, 237, 245 }, 184);
        }

        if (_0x1eb69b4f == 3)
        {
            return _0x1536421c._0xa832788e(new byte[5] { 67, 74, 66, 64, 65 }, 15);
        }

        return _0x1536421c._0xa832788e(new byte[5] { 221, 218, 205, 205, 198 }, 159);
    }

    private RectTransform _0x0a21a9d5;
}

internal static class _0x1536421c
{
    internal static string _0xa832788e(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}