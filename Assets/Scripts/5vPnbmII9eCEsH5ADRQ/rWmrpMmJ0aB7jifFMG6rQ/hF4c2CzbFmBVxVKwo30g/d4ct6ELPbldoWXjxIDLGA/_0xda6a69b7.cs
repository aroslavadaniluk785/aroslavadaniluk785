using UnityEngine;
using UnityEngine.UI;

public class _0xda6a69b7 : MonoBehaviour
{
    public bool IsPhysicsRunOnClick;
    public Button Button;
    private void Start()
    {
        this.Button.onClick.AddListener(() => _0xaa3720e7.Instance._0xfcdfb188(this.IsPhysicsRunOnClick));
    }

    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }
}