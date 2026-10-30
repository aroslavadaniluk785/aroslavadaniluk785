using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x98551277 : MonoBehaviour
{
    public Button Button;
    public int LoadSceneId;
    private void Awake()
    {
        if (this.Button == null)
            if (!this.TryGetComponent(out this.Button))
                this.Button = this.GetComponentInChildren<Button>();
    }

    private void Start()
    {
        if (this.IsLoadCurrentScene)
            this.Button.onClick.AddListener(() =>
            {
                _0xaa3720e7.Instance._0x4fdc6a2f(SceneManager.GetActiveScene().buildIndex);
            });
        else
            this.Button.onClick.AddListener(() => _0xaa3720e7.Instance._0x4fdc6a2f(this.LoadSceneId));
    }

    public bool IsLoadCurrentScene;
}