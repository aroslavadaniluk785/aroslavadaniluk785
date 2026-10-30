using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class _0xdf53671d : MonoBehaviour
{
    private Touch? _0x7a3119d6(Bounds _0x76458378, TouchPhase _0x4afee488)
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
            return null;
        foreach (Touch _0x7e63d3e4 in Touch.activeTouches)
            if (_0x7e63d3e4.phase == _0x4afee488)
            {
                Vector3 _0x15ee6eed = Camera.main.ScreenToWorldPoint(_0x7e63d3e4.screenPosition);
                Vector3 _0xd794be1e = new(_0x15ee6eed.x, _0x15ee6eed.y, _0x76458378.center.z);
                if (_0x76458378.Contains(_0xd794be1e) && this._0x9eae4463(_0x7e63d3e4))
                    return _0x7e63d3e4;
            }

        return null;
    }

    private Touch? _0x05cb152e(Bounds _0xc44ee52d)
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
            return null;
        foreach (Touch _0x3ade04c0 in Touch.activeTouches)
            if (_0x3ade04c0.ended)
            {
                Vector3 _0x7a905d73 = Camera.main.ScreenToWorldPoint(_0x3ade04c0.screenPosition);
                Vector3 _0x62c21bc6 = new(_0x7a905d73.x, _0x7a905d73.y, _0xc44ee52d.center.z);
                if (_0xc44ee52d.Contains(_0x62c21bc6) && this._0x9eae4463(_0x3ade04c0))
                    return _0x3ade04c0;
            }

        return null;
    }

    public BoxCollider2D CameraTouchBounds;
    private bool _0x90bae532(Touch? _0x4f9576aa, Bounds _0x3be2209d, TouchPhase _0x83d2e1c2)
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
        {
            _0x4f9576aa = null;
            return false;
        }

        if (_0x4f9576aa != null)
            if (_0x4f9576aa.Value.phase == _0x83d2e1c2)
            {
                Vector3 _0x801da05c = Camera.main.ScreenToWorldPoint(_0x4f9576aa.Value.screenPosition);
                Vector3 _0x18aeaa3b = new(_0x801da05c.x, _0x801da05c.y, _0x3be2209d.center.z);
                if (_0x3be2209d.Contains(_0x18aeaa3b) && this._0x9eae4463(_0x4f9576aa.Value))
                    return true;
            }

        return false;
    }

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        _0x8ae4fbfc = this.gameObject.GetComponent<_0xdf53671d>();
    }

    private Touch? _0xd236059f()
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
            return null;
        foreach (Touch _0x7d46b786 in Touch.activeTouches)
            if (_0x7d46b786.ended)
                if (this._0x9eae4463(_0x7d46b786))
                    return _0x7d46b786;
        return null;
    }

    private bool _0x9eae4463(Touch? _0xb96eeb4f)
    {
        if (!_0xb96eeb4f.HasValue)
            return false;
        Vector3 _0x27a4eb65 = Camera.main.ScreenToWorldPoint(_0xb96eeb4f.Value.screenPosition);
        Vector3 _0x94b5c4c6 = _0x27a4eb65;
        _0x94b5c4c6.z = this.CameraTouchBounds.transform.position.z;
        if (this.CameraTouchBounds.bounds.Contains(_0x94b5c4c6))
            return true;
        _0xb96eeb4f = null;
        return false;
    }

    private Touch? _0xcaab39b2(Bounds _0xd4ab9e76)
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
            return null;
        foreach (Touch _0x35e05c18 in Touch.activeTouches)
            if (!_0x35e05c18.ended)
            {
                Vector3 _0x7a053961 = Camera.main.ScreenToWorldPoint(_0x35e05c18.screenPosition);
                Vector3 _0x71af4a77 = new(_0x7a053961.x, _0x7a053961.y, _0xd4ab9e76.center.z);
                if (_0xd4ab9e76.Contains(_0x71af4a77) && this._0x9eae4463(_0x35e05c18))
                    return _0x35e05c18;
            }

        return null;
    }

    private void _0x19626dd2(Touch? _0x16c41bfc)
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
        {
            _0x16c41bfc = null;
            return;
        }

        int _0xe071d5ac = _0x16c41bfc.Value.touchId;
        _0x16c41bfc = Touch.activeTouches.FirstOrDefault(_0x0bb405d7 => _0x0bb405d7.touchId == _0xe071d5ac);
        if (!this._0x9eae4463(_0x16c41bfc.Value))
            _0x16c41bfc = null;
    }

    private Touch? _0x473378fd()
    {
        if (!_0xaa3720e7.Instance._0xa4675a86)
            return null;
        foreach (Touch _0x101bdf54 in Touch.activeTouches)
            if (!_0x101bdf54.ended)
                if (this._0x9eae4463(_0x101bdf54))
                    return _0x101bdf54;
        return null;
    }

    private static _0xdf53671d _0x8ae4fbfc;
}