using UnityEngine;

/// Shows and hides one subtree that this project created itself.
/// Visibility of generated UI is always driven through a reference like this, never by
/// reaching into a template object by name.
public sealed class _0x5d1715c7 : MonoBehaviour
{
    public void _0xc75fde18()
    {
        if (this._content != null)
        {
            this._content.SetActive(true);
        }
    }

    public bool _0xe84b1059
    {
        get
        {
            return this._content != null && this._content.activeSelf;
        }
    }

    [SerializeField]
    private GameObject _content;
    public _0x5d1715c7 _0x342297fa(GameObject _0x31e9b9f5)
    {
        this._content = _0x31e9b9f5;
        return this;
    }

    public void _0xc9623eae()
    {
        if (this._content != null)
        {
            this._content.SetActive(false);
        }
    }
}