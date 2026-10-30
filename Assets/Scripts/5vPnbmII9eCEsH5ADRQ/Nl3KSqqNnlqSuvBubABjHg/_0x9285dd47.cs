using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static _0x44bff367;

public class _0x9285dd47 : MonoBehaviour
{
    private void Awake()
    {
        Instance = this.gameObject.GetComponent<_0x9285dd47>();
    }

    public void _0x63373e5a()
    {
        this.LastPopIndexes.Clear();
        this._0xf456788f();
        foreach (GameObject _0x21393874 in this.GameObjectsToHide)
            if (_0x21393874 != null)
                _0x21393874.SetActive(true);
        this._0xe93ed746();
    }

    public _0x20303544 _0xa8994a5b(int _0x487191b7)
    {
        return this.Pops[_0x487191b7];
    }

    private void _0xf456788f(bool _0x78f8fdcc = false)
    {
        for (int _0x2cc30846 = 0; _0x2cc30846 < this.Pops.Count; ++_0x2cc30846)
            if (this.Pops[_0x2cc30846] != null && !(_0x2cc30846 == this.CurrentPopIndex && _0x78f8fdcc))
                this.Pops[_0x2cc30846]._0xebbb7158();
    }

    public void _0xd1016de0()
    {
        this.LastPopIndexes.RemoveAll(_0x7d96f8eb => _0x7d96f8eb == this.CurrentPopIndex);
        if (this.LastPopIndexes.Count <= 0)
            this._0x63373e5a();
        else
            this._0x77e745d1(this.LastPopIndexes.Last());
    }

    private void Start()
    {
        this.BackgroundHidden();
        foreach (_0x20303544 _0xf924f521 in this.Pops)
            if (_0xf924f521 != null)
                _0xf924f521.gameObject.SetActive(true);
    }

    public static _0x9285dd47 Instance;
    public List<int> LastPopIndexes = new();
    public List<GameObject> GameObjectsToHide;
    private void _0x2e8e799a()
    {
        this.BlurBackground.gameObject.SetActive(true);
    }

    public float ScaleDuration = 0.4f;
    public int CurrentPopIndex;
    public void _0x77e745d1(int _0xb8f4a538)
    {
        this.CurrentPopIndex = _0xb8f4a538;
        this.LastPopIndexes.Add(this.CurrentPopIndex);
        this._0xf456788f(true);
        this._0x2e8e799a();
        this.Pops[_0xb8f4a538].Show();
        foreach (GameObject _0x4ea4764e in this.GameObjectsToHide)
            _0x4ea4764e.SetActive(false);
    }

    public List<_0x20303544> Pops;
    private void BackgroundHidden()
    {
        this.BlurBackground.gameObject.SetActive(false);
    }

    public GameObject BlurBackground;
    private void _0xe93ed746()
    {
        this.Invoke(nameof(this.BackgroundHidden), this.ScaleDuration);
    }
}