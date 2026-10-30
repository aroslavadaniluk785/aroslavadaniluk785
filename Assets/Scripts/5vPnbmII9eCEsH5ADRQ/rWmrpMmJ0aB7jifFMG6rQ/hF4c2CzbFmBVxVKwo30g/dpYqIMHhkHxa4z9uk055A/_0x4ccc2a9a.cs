using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class _0x4ccc2a9a : MonoBehaviour
{
    public Slider AnimationSlider;
    private static bool _0x6355eb92 = false;
    public GameObject Content;
    public float SecondPassSliderValue = 0.5f;
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x4ccc2a9a>();
    }

    private Sequence _0xebf67026;
    public GameObject Background;
    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == _0x44bff367._0x7725f086.SCENE_0 && !_0x6355eb92)
        {
            this._0x3d4f6282();
        }
        else
        {
            this._0xe2e63494();
        }
    }

    private void _0x3d4f6282()
    {
        this.AnimationSlider.value = 0.05f;
        _0x6355eb92 = !_0x6355eb92;
        this._0xebf67026 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x8aae35af => this.AnimationSlider.value = _0x8aae35af, 1f, this.FirstAnimationTime)).SetEase(Ease.Linear).OnComplete(() =>
        {
            _0x2ed2b7a2._0x18e4497d?._0x7d939e35();
        });
    }

    public float FirstAnimationTime = 10.0f;
    public void _0xe2e63494()
    {
        this._0xa8030761();
        bool _0xfa0839fc = _0x6355eb92;
        this._0xebf67026 = DOTween.Sequence().Append(DOTween.To(() => this.AnimationSlider.value, _0x8aae35af => this.AnimationSlider.value = _0x8aae35af, _0xfa0839fc ? 1f : this.SecondPassSliderValue, this.DefaultAnimationTime)).SetEase(Ease.Linear);
        _0x6355eb92 = !_0x6355eb92;
    }

    public GameObject Error;
    public void _0xc1724b1b()
    {
        {
#if B_LOGS
            {
                Debug.Log($"[Test] Animate Force");
            }
#endif
        }

        this._0xebf67026?.Kill();
        if (AnimationSlider != null)
            this.AnimationSlider.value = 1f;
        _0x6355eb92 = false;
    }

    public void _0x9378a12a()
    {
        this._0xebf67026?.Pause();
    }

    public static _0x4ccc2a9a Instance;
    public void _0xa8030761()
    {
        this._0xebf67026?.Kill();
        this.AnimationSlider.value = _0x6355eb92 ? this.SecondPassSliderValue : 0.05f;
    }

    public float DefaultAnimationTime = 0.4f;
    public void _0xfcf31e79()
    {
        this._0xebf67026?.Play();
    }
}