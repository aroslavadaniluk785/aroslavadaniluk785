using DG.Tweening;
using UnityEngine;

/// One socket on a ring: the carved recess plus the piece of produce sitting in it.
/// The cell counter-rotates against its ring so the produce never tilts.
public sealed class _0xb83a2af7 : MonoBehaviour
{
    public Vector3 _0xdfd55794
    {
        get
        {
            return this._item != null ? this._item.transform.position : this.transform.position;
        }
    }

    private int _0xd0c26cb0 = -1;
    [SerializeField]
    private SpriteRenderer _item;
    public int _0x4fa4bf53
    {
        get
        {
            return this._0xd0c26cb0;
        }
    }

    public void _0x59f1b316()
    {
        if (this._item != null)
        {
            this._item.enabled = false;
        }
    }

    public void _0x3647eaf2(float _0x340d728f)
    {
        if (this._item == null)
        {
            return;
        }

        this._item.transform.DOScale(Vector3.one * 1.16f, _0x340d728f).SetEase(Ease.OutQuad).SetLink(this._item.gameObject);
    }

    public void _0xa8471476(int _0xc188ceae, Sprite _0xf3184438)
    {
        this._0xd0c26cb0 = _0xc188ceae;
        if (this._item == null)
        {
            return;
        }

        this._item.sprite = _0xf3184438;
        this._item.color = Color.white;
        this._item.enabled = _0xf3184438 != null;
        this._item.size = new Vector2(this._0x298ec074, this._0x298ec074);
        this._item.transform.localScale = Vector3.one;
        this._item.transform.localPosition = Vector3.zero;
    }

    /// Sends the harvested produce to the order board and leaves the socket empty.
    public void _0x224b0212(Vector3 _0x6fbdea03, float _0xbb19e03c)
    {
        if (this._item == null)
        {
            return;
        }

        Transform _0xc8df2e73 = this._item.transform;
        _0xc8df2e73.DOMove(_0x6fbdea03, _0xbb19e03c).SetEase(Ease.InBack).SetLink(this._item.gameObject);
        _0xc8df2e73.DOScale(Vector3.one * 0.35f, _0xbb19e03c).SetEase(Ease.InQuad).SetLink(this._item.gameObject);
    }

    private float _0x298ec074 = 0.5f;
    public void _0xfba73a95(float _0x1633e37f)
    {
        this.transform.localRotation = Quaternion.Euler(0f, 0f, -_0x1633e37f);
    }

    public void _0xd009fe27(float _0xb6bfef5c, float _0xb48c7ab7, int _0x2127dc81, int _0x53757d02)
    {
        this._0x298ec074 = _0xb48c7ab7;
        if (this._slot != null)
        {
            this._slot.drawMode = SpriteDrawMode.Sliced;
            this._slot.size = new Vector2(_0xb6bfef5c, _0xb6bfef5c);
            this._slot.sortingOrder = _0x20f7bed2.Clamped(_0x2127dc81);
        }

        if (this._item != null)
        {
            this._item.drawMode = SpriteDrawMode.Sliced;
            this._item.size = new Vector2(_0xb48c7ab7, _0xb48c7ab7);
            this._item.sortingOrder = _0x20f7bed2.Clamped(_0x53757d02);
        }
    }

    /// Keeps the produce upright while its ring turns underneath it.
    public void _0xf696addc(float _0xcb46bb7b, float _0xe3d79657)
    {
        this.transform.DOLocalRotate(new Vector3(0f, 0f, -_0xcb46bb7b), _0xe3d79657, RotateMode.FastBeyond360).SetEase(Ease.OutBack).SetLink(this.gameObject);
    }

    /// Drop-in after a refill. Scale is driven from the computed base size, never a literal.
    public void _0x74331ad7(float _0xefb8fe07)
    {
        if (this._item == null)
        {
            return;
        }

        this._item.transform.localScale = Vector3.zero;
        this._item.transform.DOScale(Vector3.one, _0xefb8fe07).SetEase(Ease.OutBack).SetLink(this._item.gameObject);
    }

    [SerializeField]
    private SpriteRenderer _slot;
}