using UnityEngine;
using TMPro;

/// Bootstraps the menu scene: the bottom sheet, the garden map, the settings sheet and
/// the how-to-play sheet, all built from this project's own objects inside the template
/// panel that already exists.
public sealed class _0xf6b95e08 : MonoBehaviour
{
    public Sprite _0xd759b031
    {
        get
        {
            return this._panelWood;
        }
    }

    private _0x0556c6af _0x319a0805;
    public Sprite _0x90cd8602
    {
        get
        {
            return this._basketIcon;
        }
    }

    [SerializeField]
    private Sprite _tutDrag;
    public Sprite _0x8827b646
    {
        get
        {
            return this._tutLine;
        }
    }

    [SerializeField]
    private Sprite _emblem;
    public void _0x532c024b()
    {
        if (this._0xb553fab8 != null)
        {
            this._0xb553fab8._0x1adbf993();
        }
    }

    [SerializeField]
    private Sprite _tutLine;
    private void Start()
    {
        RectTransform _0x8f8e8957 = this.transform as RectTransform;
        if (_0x8f8e8957 == null)
        {
            return;
        }

        this._0x7c1ed6ea = this.gameObject.AddComponent<_0xb0d316c9>();
        this._0x7c1ed6ea._0x66b89a25(this, _0x8f8e8957, this._playButtonRect);
        this._0xa2f611e5 = this.gameObject.AddComponent<_0x32bd8421>();
        this._0xa2f611e5._0xfa2bb7bc(this, _0x8f8e8957);
        this._0x319a0805 = this.gameObject.AddComponent<_0x0556c6af>();
        this._0x319a0805._0x8ab4770c(this, _0x8f8e8957);
        this._0xb553fab8 = this.gameObject.AddComponent<_0x3a59c935>();
        this._0xb553fab8._0x77601200(this, _0x8f8e8957);
        if (!_0x744cf847._0x856f0ab8)
        {
            this._0x532c024b();
        }
    }

    public void _0x45dd8f9f()
    {
        if (this._0xa2f611e5 != null)
        {
            this._0xa2f611e5._0x19887fea();
        }
    }

    public Sprite _0x13661abf
    {
        get
        {
            return this._btnSecondary;
        }
    }

    public Sprite _0x4cd1b832
    {
        get
        {
            return this._gardener;
        }
    }

    private _0x32bd8421 _0xa2f611e5;
    /// The settings sheet can reset the garden; the sheet counters have to follow at once,
    /// so the change is visible in the same frame the button is pressed.
    public void _0xd826e288()
    {
        if (this._0x7c1ed6ea != null)
        {
            this._0x7c1ed6ea._0x50bd6d8a();
        }

        if (this._0xa2f611e5 != null)
        {
            this._0xa2f611e5._0x42ed82b3();
        }
    }

    [SerializeField]
    private Sprite _panelWood;
    public Sprite _0xd8c787b7
    {
        get
        {
            return this._treeGrown;
        }
    }

    [SerializeField]
    private Sprite _treeLocked;
    public void _0x77df0c28()
    {
        if (this._0x319a0805 != null)
        {
            this._0x319a0805._0x5720d840();
        }
    }

    [SerializeField]
    private Sprite _btnPrimary;
    public Sprite _0x5f4b4c5c
    {
        get
        {
            return this._treeLocked;
        }
    }

    [SerializeField]
    private Sprite _treeBare;
    public Sprite _0x7a65e18c
    {
        get
        {
            return this._tutOrder;
        }
    }

    [SerializeField]
    private Sprite _btnSecondary;
    [SerializeField]
    private Sprite _treeGrown;
    [SerializeField]
    private Sprite _tutOrder;
    public Sprite _0x982957fd
    {
        get
        {
            return this._treeBare;
        }
    }

    public Sprite _0x65660cd1
    {
        get
        {
            return this._btnPrimary;
        }
    }

    [SerializeField]
    private Sprite _gardener;
    public Sprite _0xfa51635f
    {
        get
        {
            return this._emblem;
        }
    }

    private _0x3a59c935 _0xb553fab8;
    [SerializeField]
    private RectTransform _playButtonRect;
    public TMP_FontAsset _0x9e093146
    {
        get
        {
            return this._font;
        }
    }

    public Sprite _0xad238d11
    {
        get
        {
            return this._tutDrag;
        }
    }

    private _0xb0d316c9 _0x7c1ed6ea;
    [SerializeField]
    private Sprite _basketIcon;
    [SerializeField]
    private TMP_FontAsset _font;
}