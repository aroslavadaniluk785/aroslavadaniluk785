using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class _0xd7b317ba : MonoBehaviour
{
    private void _0x9be8110c()
    {
        float _0xd0e8b101, _0xebf3aae9, _0x85b685d1, _0x565f2526;
        if (this._0xe29e8854 == _0x79ad2a17.Landscape)
            this._0x4e858d06.orthographicSize = 1f / this._0x4e858d06.aspect * this._0x60f4942b / 2f;
        else
            this._0x4e858d06.orthographicSize = this._0x60f4942b / 2f;
        this._0x48547ff1 = 2f * this._0x4e858d06.orthographicSize;
        this._0x2e520548 = this._0x48547ff1 * this._0x4e858d06.aspect;
        float _0x15705ce5 = this._0x4e858d06.transform.position.x;
        float _0xf43154d9 = this._0x4e858d06.transform.position.y;
        _0xd0e8b101 = _0x15705ce5 - this._0x2e520548 / 2;
        _0xebf3aae9 = _0x15705ce5 + this._0x2e520548 / 2;
        _0x85b685d1 = _0xf43154d9 + this._0x48547ff1 / 2;
        _0x565f2526 = _0xf43154d9 - this._0x48547ff1 / 2;
        this._0x432a1164 = new Vector3(_0xd0e8b101, _0x565f2526, 0);
        this._0xd1f777c1 = new Vector3(_0x15705ce5, _0x565f2526, 0);
        this._0xbe7420bd = new Vector3(_0xebf3aae9, _0x565f2526, 0);
        this._0xb3ab5322 = new Vector3(_0xd0e8b101, _0xf43154d9, 0);
        this._0xe62078bb = new Vector3(_0x15705ce5, _0xf43154d9, 0);
        this._0x0ae8f6b7 = new Vector3(_0xebf3aae9, _0xf43154d9, 0);
        this._0x6e24249d = new Vector3(_0xd0e8b101, _0x85b685d1, 0);
        this._0x1d971585 = new Vector3(_0x15705ce5, _0x85b685d1, 0);
        this._0x974bf54e = new Vector3(_0xebf3aae9, _0x85b685d1, 0);
    }

    public enum _0x79ad2a17
    {
        Landscape,
        Portrait
    }

    private Vector3 _0xbe7420bd { get; set; }

    private new Camera _0x4e858d06;
    private void OnDrawGizmos()
    {
        Gizmos.color = this._0xf43cba87;
        Matrix4x4 _0x39b50649 = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
        if (this._0x4e858d06.orthographic)
        {
            float _0xe77b78ad = this._0x4e858d06.farClipPlane - this._0x4e858d06.nearClipPlane;
            float _0xe6c63bef = (this._0x4e858d06.farClipPlane + this._0x4e858d06.nearClipPlane) * 0.5f;
            Gizmos.DrawWireCube(new Vector3(0, 0, _0xe6c63bef), new Vector3(this._0x4e858d06.orthographicSize * 2 * this._0x4e858d06.aspect, this._0x4e858d06.orthographicSize * 2, _0xe77b78ad));
        }
        else
        {
            Gizmos.DrawFrustum(Vector3.zero, this._0x4e858d06.fieldOfView, this._0x4e858d06.farClipPlane, this._0x4e858d06.nearClipPlane, this._0x4e858d06.aspect);
        }

        Gizmos.matrix = _0x39b50649;
    }

    private Vector3 _0x0ae8f6b7 { get; set; }
    //public bool executeInUpdate;
    private float _0x2e520548 { get; set; }

    private _0x79ad2a17 _0xe29e8854 = _0x79ad2a17.Portrait;
    private static _0xd7b317ba _0x03445ac4;
    private Vector3 _0x1d971585 { get; set; }
    private Vector3 _0x6e24249d { get; set; }

    private Color _0xf43cba87 = Color.white;
    private Vector3 _0x974bf54e { get; set; }

    private void Awake()
    {
        this._0x4e858d06 = this.GetComponent<Camera>();
        _0x03445ac4 = this;
        this._0x9be8110c();
    }

    private float _0x60f4942b = 1;
    private Vector3 _0x432a1164 { get; set; }
    private Vector3 _0xb3ab5322 { get; set; }
    private Vector3 _0xe62078bb { get; set; }
    private Vector3 _0xd1f777c1 { get; set; }
    private float _0x48547ff1 { get; set; }
}