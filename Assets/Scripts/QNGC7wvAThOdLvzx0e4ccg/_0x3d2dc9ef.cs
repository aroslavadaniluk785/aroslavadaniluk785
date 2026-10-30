using UnityEngine;
using UnityEngine.EventSystems;

/// Turns a drag over the board into ring notches.
/// Input arrives as uGUI pointer events from the scene EventSystem, which runs on the new
/// Input System module - there is no legacy input anywhere and no extra actions asset.
public sealed class _0x3d2dc9ef : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData _0x353d3105)
    {
        Vector3 _0xa8529203;
        if (this._0xc0e06154 == null || !this._0x35f7021f(_0x353d3105, out _0xa8529203))
        {
            return;
        }

        int _0x5294b59a = this._0xc0e06154._0x09062e52(_0xa8529203);
        this._0xfbdfee75 = _0x5294b59a;
        this._0x62c7ca16 = 0f;
        this._0x7c590147 = this._0xc0e06154._0x21980920(_0xa8529203);
        if (_0x5294b59a >= 0 && this._0xb5fb47e2 != null)
        {
            this._0xb5fb47e2._0x772726c7(_0x5294b59a);
        }
    }

    private bool _0x35f7021f(PointerEventData _0x905e2a74, out Vector3 _0xa594420c)
    {
        _0xa594420c = Vector3.zero;
        if (this._0x4359770b == null || _0x905e2a74 == null)
        {
            return false;
        }

        Vector3 _0x2eb92430 = new Vector3(_0x905e2a74.position.x, _0x905e2a74.position.y, -this._0x4359770b.transform.position.z);
        _0xa594420c = this._0x4359770b.ScreenToWorldPoint(_0x2eb92430);
        return true;
    }

    private float _0x62c7ca16;
    private float _0x7c590147;
    private Camera _0x4359770b;
    private int _0xfbdfee75 = -1;
    private _0xd2425d92 _0xb5fb47e2;
    public _0x3d2dc9ef _0x7dc62539(_0xd2425d92 _0x2afca9d7, Camera _0xd1d59558, _0x20f7bed2 _0x42e90b04)
    {
        this._0xb5fb47e2 = _0x2afca9d7;
        this._0x4359770b = _0xd1d59558;
        this._0xc0e06154 = _0x42e90b04;
        return this;
    }

    private _0x20f7bed2 _0xc0e06154;
    public void OnPointerUp(PointerEventData _0xb05493cc)
    {
        this._0xfbdfee75 = -1;
        this._0x62c7ca16 = 0f;
    }

    /// Half a sector: a notch fires once the finger has travelled this far around the hub.
    public const float DegreesPerNotch = 22.5f;
    public void OnDrag(PointerEventData _0xfcde017f)
    {
        Vector3 _0x7f3712a2;
        if (this._0xfbdfee75 < 0 || this._0xc0e06154 == null || !this._0x35f7021f(_0xfcde017f, out _0x7f3712a2))
        {
            return;
        }

        float _0xdd4567ca = this._0xc0e06154._0x21980920(_0x7f3712a2);
        float delta = Mathf.DeltaAngle(this._0x7c590147, _0xdd4567ca);
        this._0x7c590147 = _0xdd4567ca;
        this._0x62c7ca16 += delta;
        while (Mathf.Abs(this._0x62c7ca16) >= DegreesPerNotch)
        {
            int _0x5280ced2 = this._0x62c7ca16 > 0f ? 1 : -1;
            this._0x62c7ca16 -= _0x5280ced2 * DegreesPerNotch;
            if (this._0xb5fb47e2 != null)
            {
                this._0xb5fb47e2._0x880e7deb(this._0xfbdfee75, _0x5280ced2);
            }
        }
    }
}