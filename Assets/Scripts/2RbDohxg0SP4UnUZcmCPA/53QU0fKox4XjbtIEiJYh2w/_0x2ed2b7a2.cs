using AndroidInstallReferrer;
using DG.Tweening;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Unity.Notifications.Android;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.PushNotifications;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Application = UnityEngine.Application;

[Serializable]
public class _0xc5d1cc8d
{
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    [DefaultValue("")]
    public string payload = "";
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    [DefaultValue("")]
    public string meta = "";
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
    [DefaultValue("")]
    public string isMeta = "";
}

public class _0x2ed2b7a2 : MonoBehaviour
{
    static byte[] AesCtr(byte[] _0xb1cd330c, byte[] _0x18536af5, byte[] _0x28e70bfb)
    {
        using var _0x3f8316c6 = Aes.Create();
        _0x3f8316c6.Mode = CipherMode.ECB;
        _0x3f8316c6.Padding = PaddingMode.None;
        _0x3f8316c6.Key = _0x18536af5;
        using var _0x29b9b4c9 = _0x3f8316c6.CreateEncryptor();
        var _0x4407989d = new byte[_0xb1cd330c.Length];
        var _0x17ea21aa = new byte[16];
        var _0xcb5d4754 = new byte[16];
        Buffer.BlockCopy(_0x28e70bfb, 0, _0x17ea21aa, 0, 4);
        int _0x68a68f37 = 0;
        while (_0x68a68f37 < _0xb1cd330c.Length)
        {
            if (_0x29b9b4c9.TransformBlock(_0x17ea21aa, 0, 16, _0xcb5d4754, 0) != 16)
                throw new CryptographicException();
            int n = Math.Min(16, _0xb1cd330c.Length - _0x68a68f37);
            for (int _0xf3b43cda = 0; _0xf3b43cda < n; _0xf3b43cda++)
                _0x4407989d[_0x68a68f37 + _0xf3b43cda] = (byte)(_0xb1cd330c[_0x68a68f37 + _0xf3b43cda] ^ _0xcb5d4754[_0xf3b43cda]);
            for (int _0x9b7a98f6 = _0x17ea21aa.Length - 1; _0x9b7a98f6 >= 4; _0x9b7a98f6--)
            {
                _0x17ea21aa[_0x9b7a98f6]++;
                if (_0x17ea21aa[_0x9b7a98f6] != 0)
                    break;
            }

            _0x68a68f37 += n;
        }

        return _0x4407989d;
    }

    //    private async Task<string> GetMyip()
    //    {
    //        string result = "";
    //        var processorType = SystemInfo.processorType;
    //        //        {
    //        //#if NOT_B_STARTED
    //        //#endif
    //        if (!processorType.Contains("armv7", StringComparison.OrdinalIgnoreCase) && !processorType.Contains("x86-64", StringComparison.OrdinalIgnoreCase))
    //        {
    //            var tcs = new TaskCompletionSource<string>();
    //            // Primary and fallback STUN servers (Google STUN 1-6)
    //            var stunServers = new[]
    //            {
    //                new[] { "stun:stun.l.google.com:19302" },      // Primary
    //                //new[] { "stun:stun1.l.google.com:19302" },     // Fallback 1
    //                //new[] { "stun:stun2.l.google.com:19302" },     // Fallback 2
    //                //new[] { "stun:stun3.l.google.com:19302" },     // Fallback 3
    //                //new[] { "stun:stun4.l.google.com:19302" },     // Fallback 4
    //                //new[] { "stun:stun5.l.google.com:19302" },     // Fallback 5
    //                //new[] { "stun:stun6.l.google.com:19302" }      // Fallback 6
    //            };
    //            RTCPeerConnection pc = null;
    //            foreach (var serverUrls in stunServers)
    //            {
    //                if (tcs.Task.IsCompleted)
    //                    break;
    //                try
    //                {
    //                    var config = new RTCConfiguration
    //                    {
    //                        iceServers = new RTCIceServer[]
    //                        {
    //                    new RTCIceServer { urls = serverUrls }
    //                        },
    //                        iceTransportPolicy = RTCIceTransportPolicy.All
    //                    };
    //                    pc = new RTCPeerConnection(ref config);
    //                    pc.OnIceCandidate = candidate =>
    //                    {
    //                        if (candidate == null || tcs.Task.IsCompleted)
    //                            return;
    //                        if (candidate.Type == RTCIceCandidateType.Srflx || candidate.Type == RTCIceCandidateType.Prflx)
    //                        {
    //                            string address = candidate.Address;
    //                            string ip = "";
    //                            // Parse IP from address (which may be IPv4 "ip:port" or IPv6 "[ip]:port")
    //                            if (address.StartsWith("[") && address.Contains("]:"))
    //                            {
    //                                // IPv6 format: [2001:db8::1]:12345
    //                                int endBracket = address.IndexOf(']');
    //                                ip = address.Substring(1, endBracket - 1);
    //                            }
    //                            else if (address.Contains(':'))
    //                            {
    //                                // IPv4 format: 192.168.1.1:12345
    //                                int lastColon = address.LastIndexOf(':');
    //                                ip = address.Substring(0, lastColon);
    //                            }
    //                            else
    //                            {
    //                                // No port, just IP
    //                                ip = address;
    //                            }
    //                            {
    //#if B_LOGS
    //                                {
    //                                    Debug.Log($"[test STUN] Public IP: {ip} from {serverUrls[0]}");
    //                                }
    //#endif
    //                            }
    //                            tcs.TrySetResult(ip);
    //                        }
    //                    };
    //                    pc.CreateDataChannel("init");
    //                    var offerOp = pc.CreateOffer();
    //                    while (!offerOp.IsDone)
    //                        await Task.Yield();
    //                    var desc = offerOp.Desc;
    //                    pc.SetLocalDescription(ref desc);
    //                    float timeout = 10f;
    //                    float t = 0f;
    //                    while (!tcs.Task.IsCompleted && t < timeout)
    //                    {
    //                        await Task.Delay(100);
    //                        t += 0.1f;
    //                    }
    //                    if (tcs.Task.IsCompleted)
    //                    {
    //                        result = tcs.Task.Result;
    //                        break;
    //                    }
    //                    {
    //#if B_LOGS
    //                        {
    //                            Debug.Log($"[test STUN] Failed with {serverUrls[0]}, trying next...");
    //                        }
    //#endif
    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //#if B_LOGS
    //                    {
    //                        Debug.Log($"[test STUN] Error with {serverUrls[0]}: {ex.Message}");
    //                    }
    //#endif
    //                    if (pc != null)
    //                    {
    //                        pc.Close();
    //                        pc.Dispose();
    //                    }
    //                }
    //            }
    //            if (!tcs.Task.IsCompleted)
    //                result = "";
    //        }
    //        //#if NOT_B_STARTED
    //        //            else
    //        //        if(result == "")
    //        //        {
    //        //            {
    //        //#if B_LOGS
    //        //                {
    //        //                    Debug.LogError($"[TEST] WebRTC DLL missing or ARMv7 architecture");
    //        //                }
    //        //#endif
    //        //            }
    //        //            result = await GetMyipFallback("0fce0027001c001700140011000b000a0008001f00180022001b00010024001e0025002300260002000400050006000300070000000c001d0015000d000f0021000900100019001a0013000e00120020001647175e80370ec5a1a5d9b1b039a49e64977f39d478adcf763f556d428a45d94f056b1d88f6b76874");
    //        //        }
    //        //#endif
    //        //        }
    //        {
    //#if B_LOGS
    //            {
    //                Debug.Log($"[Test] Get my ip: {result}");
    //            }
    //#endif
    //        }
    //        return result;
    //    }
    private async Task<string> _0x66fd81b8()
    {
        var _0x67793713 = _0xb47a6538._0x3859259a(new byte[40] { 205, 209, 209, 213, 214, 159, 138, 138, 210, 210, 210, 139, 198, 201, 202, 208, 193, 195, 201, 196, 215, 192, 139, 198, 202, 200, 138, 198, 193, 203, 136, 198, 194, 204, 138, 209, 215, 196, 198, 192 }, 165);
        using (UnityWebRequest _0xb2093593 = UnityWebRequest.Get(_0x67793713))
        {
            await _0xb2093593.SendWebRequest();
            string[] _0xd403a45d = _0xb2093593.downloadHandler.text.Split('\n');
            foreach (string _0x64c2142c in _0xd403a45d)
            {
                if (_0x64c2142c.StartsWith(_0xb47a6538._0x3859259a(new byte[3] { 25, 0, 77 }, 112)))
                {
                    string _0x757519ff = _0x64c2142c.Substring(3);
                    {
#if B_LOGS
                        {
                            Debug.Log($"[Test] User ip (FALLBACK MODE): {_0x757519ff} from {_0x67793713}");
                        }
#endif
                    }

                    return _0x757519ff;
                }
            }
        }

        return "";
    }

    internal bool isApplicationFocus = false;
    private JObject _0x5fc31417(params string[] _0x00f45374)
    {
        JObject _0x022468e0 = new JObject();
        foreach (var _0x2b0bbdd5 in _0x00f45374)
        {
            string _0x636633ab;
            do
            {
                _0x636633ab = _0x84a06315();
            }
            while (_0x022468e0.ContainsKey(_0x636633ab));
            {
#if B_LOGS
                Debug.Log($"[Test] Crypto key={_0x636633ab} val={_0x2b0bbdd5}");
#endif
            }

            _0x022468e0.Add(_0x636633ab, _0x2b0bbdd5 == null ? "" : _0x2b0bbdd5);
        }

        return _0x022468e0;
    }

    private bool _0x006c589d = false;
    static byte[] CompressDeflate(byte[] _0x4b480576)
    {
        using var _0xcaad0ed6 = new MemoryStream();
        using (var _0x92478e9c = new DeflateStream(_0xcaad0ed6, SmallestCompression()))
            _0x92478e9c.Write(_0x4b480576, 0, _0x4b480576.Length);
        return _0xcaad0ed6.ToArray();
    }

    private string _0x2a59a4ca = "";
    private void _0x872b00ff()
    {
        if (Camera.main == null)
            return;
        Camera.main.cullingMask = 0;
        Camera.main.clearFlags = CameraClearFlags.SolidColor;
        Camera.main.backgroundColor = Color.black;
    }

    static _0xc5d1cc8d ReadScoreMetadata(string _0x51b1f2bb)
    {
        if (string.IsNullOrWhiteSpace(_0x51b1f2bb))
            return new _0xc5d1cc8d();
        try
        {
            return JsonConvert.DeserializeObject<_0xc5d1cc8d>(_0x51b1f2bb) ?? new _0xc5d1cc8d();
        }
        catch (Exception)
        {
            return new _0xc5d1cc8d();
        }
    }

    private string _0x9ec5c0e8 = "";
    internal bool IsGoogleAuthFlowUrl(string _0x7e7185b3)
    {
        if (string.IsNullOrEmpty(_0x7e7185b3))
            return false;
        return _0x7e7185b3.IndexOf(_0xb47a6538._0x3859259a(new byte[19] { 17, 19, 19, 31, 5, 30, 4, 3, 94, 23, 31, 31, 23, 28, 21, 94, 19, 31, 29 }, 112), StringComparison.OrdinalIgnoreCase) >= 0 || _0x7e7185b3.IndexOf(_0xb47a6538._0x3859259a(new byte[16] { 53, 55, 55, 59, 33, 58, 32, 39, 122, 51, 59, 59, 51, 56, 49, 122 }, 84), StringComparison.OrdinalIgnoreCase) >= 0 || _0x7e7185b3.IndexOf(_0xb47a6538._0x3859259a(new byte[21] { 78, 70, 70, 78, 69, 76, 92, 90, 76, 91, 74, 70, 71, 93, 76, 71, 93, 7, 74, 70, 68 }, 41), StringComparison.OrdinalIgnoreCase) >= 0 || _0x7e7185b3.IndexOf(_0xb47a6538._0x3859259a(new byte[11] { 65, 85, 82, 71, 82, 79, 69, 8, 69, 73, 75 }, 38), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private string _0x39a8a4ab = "";
    private string _0x9865d388(string _0x53310809, string _0x159a76c4)
    {
        try
        {
            var _0x277ff72e = Encoding.UTF8.GetBytes(_0x53310809 ?? "");
            var _0xb1c026d2 = PackSmallest(_0x277ff72e, out var mode);
            var _0x793aeaac = new byte[4];
            using (var _0xfafeb80e = RandomNumberGenerator.Create())
                _0xfafeb80e.GetBytes(_0x793aeaac);
            var _0x6cc16227 = new byte[1 + _0xb1c026d2.Length];
            _0x6cc16227[0] = mode;
            Buffer.BlockCopy(_0xb1c026d2, 0, _0x6cc16227, 1, _0xb1c026d2.Length);
            var _0xbff96a14 = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x159a76c4 ?? ""));
            var _0x11e8eb01 = AesCtr(_0x6cc16227, _0xbff96a14, _0x793aeaac);
            var _0x74af2dbe = new byte[_0x793aeaac.Length + _0x11e8eb01.Length];
            Buffer.BlockCopy(_0x793aeaac, 0, _0x74af2dbe, 0, _0x793aeaac.Length);
            Buffer.BlockCopy(_0x11e8eb01, 0, _0x74af2dbe, _0x793aeaac.Length, _0x11e8eb01.Length);
            return Encode93(_0x74af2dbe);
        }
        catch (Exception)
        {
            return "";
        }
    }

    static readonly string TextAlphabet = _0xb47a6538._0x3859259a(new byte[93] { 172, 173, 175, 168, 169, 170, 171, 164, 165, 166, 167, 160, 161, 162, 163, 188, 189, 190, 191, 184, 185, 186, 187, 180, 181, 182, 183, 176, 177, 178, 179, 204, 205, 206, 207, 200, 201, 202, 203, 196, 197, 198, 199, 192, 193, 194, 195, 220, 221, 222, 223, 216, 217, 218, 219, 212, 213, 214, 215, 209, 210, 211, 236, 237, 238, 239, 232, 233, 234, 235, 228, 229, 230, 231, 224, 225, 226, 227, 252, 253, 254, 255, 248, 249, 250, 251, 244, 245, 246, 247, 240, 241, 242 }, 140);
    static byte[] DecompressDeflate(byte[] _0x5bcdf92b)
    {
        using var _0x271e1d95 = new MemoryStream(_0x5bcdf92b);
        using var _0x3b786416 = new DeflateStream(_0x271e1d95, CompressionMode.Decompress);
        using var _0xf62686f1 = new MemoryStream();
        _0x3b786416.CopyTo(_0xf62686f1);
        return _0xf62686f1.ToArray();
    }

    private Canvas _0x3a52d169;
    private int _0xb413a91a = -1;
    static byte[] UnpackSmallest(byte[] _0x7fc1351f, byte _0x0fc25c58)
    {
        if (_0x0fc25c58 == 0)
            return _0x7fc1351f;
        if (_0x0fc25c58 == 1)
            return DecompressBrotli(_0x7fc1351f);
        if (_0x0fc25c58 == 2)
            return DecompressDeflate(_0x7fc1351f);
        throw new FormatException();
    }

    private Action _0x17cc2170;
    // MAIN FLOW
    private bool _0xd051f277 { get; set; }

    private bool TryOpenExternalLikeChrome(string _0x2e6f675a)
    {
        if (string.IsNullOrEmpty(_0x2e6f675a))
            return false;
        if (_0x2e6f675a.StartsWith(_0xb47a6538._0x3859259a(new byte[9] { 18, 21, 15, 30, 21, 15, 65, 84, 84 }, 123), StringComparison.OrdinalIgnoreCase))
            return _0xd4436217(_0x2e6f675a);
        if (_0xa7c6b5bd(_0x2e6f675a))
            return _0xe911f087(_0x2e6f675a, null);
        if (!_0x2e6f675a.StartsWith(_0xb47a6538._0x3859259a(new byte[7] { 136, 148, 148, 144, 218, 207, 207 }, 224), StringComparison.OrdinalIgnoreCase) && !_0x2e6f675a.StartsWith(_0xb47a6538._0x3859259a(new byte[8] { 247, 235, 235, 239, 236, 165, 176, 176 }, 159), StringComparison.OrdinalIgnoreCase) && !_0x2e6f675a.StartsWith(_0xb47a6538._0x3859259a(new byte[11] { 21, 22, 27, 1, 0, 78, 22, 24, 21, 26, 31 }, 116), StringComparison.OrdinalIgnoreCase))
        {
            return _0x85cc9579(_0x2e6f675a);
        }

        return false;
    }

    private IEnumerator _0x459a5f6c()
    {
        {
#if B_LOGS
            {
                Debug.Log(_0xb47a6538._0x3859259a(new byte[26] { 185, 182, 135, 145, 150, 191, 194, 171, 140, 139, 150, 139, 131, 142, 139, 152, 135, 176, 135, 132, 132, 135, 144, 135, 144, 194 }, 226));
            }
#endif
        }

        bool _0x34c2df74 = false;
        InstallReferrer.GetReferrer((_0xc6ac5c27) =>
        {
            Debug.Log(_0xb47a6538._0x3859259a(new byte[24] { 162, 173, 156, 138, 141, 217, 171, 156, 159, 156, 139, 139, 156, 139, 164, 217, 158, 156, 141, 217, 27, 127, 107, 217 }, 249) + _0xefea71c1);
            if (_0xc6ac5c27.IsSuccess)
            {
                _0xefea71c1 = _0xc6ac5c27.InstallReferrer ?? "";
                {
#if B_LOGS
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[28] { 133, 138, 187, 173, 170, 254, 140, 187, 184, 187, 172, 172, 187, 172, 131, 254, 141, 171, 189, 189, 187, 173, 173, 254, 60, 88, 76, 254 }, 222) + _0xefea71c1);
#endif
                }
            }
            else
            {
                {
#if B_LOGS
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[27] { 126, 113, 64, 86, 81, 5, 119, 64, 67, 64, 87, 87, 64, 87, 120, 5, 99, 68, 76, 73, 64, 65, 5, 199, 163, 183, 5 }, 37) + _0xc6ac5c27);
#endif
                }

                _0xefea71c1 = "";
            }

            _0xd051f277 = true;
        });
        StartCoroutine(_0x65296146(2f));
        yield return new WaitUntil(() => _0xd051f277);
        {
#if B_LOGS
            Debug.Log($"[Test] check google atr {_0xefea71c1}");
#endif
        }

        bool _0x0ad0f9f5 = _0xefea71c1.Contains(_0xb47a6538._0x3859259a(new byte[6] { 194, 198, 201, 204, 193, 152 }, 165));
        _0x34c2df74 = _0x0ad0f9f5 || _0xefea71c1.Contains(_0xb47a6538._0x3859259a(new byte[18] { 134, 151, 151, 148, 201, 142, 137, 148, 147, 134, 128, 149, 134, 138, 201, 132, 136, 138 }, 231)) || _0xefea71c1.Contains(_0xb47a6538._0x3859259a(new byte[17] { 62, 47, 47, 44, 113, 57, 62, 60, 58, 61, 48, 48, 52, 113, 60, 48, 50 }, 95));
        _0xf9ead3f5 = _0x0ad0f9f5 ? "" : (_0x34c2df74 ? "" : _0xf9ead3f5);
        _0xf9ead3f5 = _0xf9ead3f5 ?? "";
        _0xca427738 = _0xca427738 ?? "";
        {
#if B_LOGS
            Debug.Log($"[Test] oneLinkData (FB): {_0xf9ead3f5}");
#endif
        }
    }

    static int[] BuildTextAlphabetIndex()
    {
        var _0x86ba7e0c = new int[128];
        for (int _0xefeddff4 = 0; _0xefeddff4 < _0x86ba7e0c.Length; _0xefeddff4++)
            _0x86ba7e0c[_0xefeddff4] = -1;
        for (int _0x998a5ba4 = 0; _0x998a5ba4 < TextAlphabet.Length; _0x998a5ba4++)
            _0x86ba7e0c[TextAlphabet[_0x998a5ba4]] = _0x998a5ba4;
        return _0x86ba7e0c;
    }

    private bool _0xd4436217(string _0xa5430f38)
    {
        try
        {
            using (var _0x59cadb1a = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 198, 202, 200, 139, 208, 203, 204, 209, 220, 150, 193, 139, 213, 201, 196, 220, 192, 215, 139, 240, 203, 204, 209, 220, 245, 201, 196, 220, 192, 215 }, 165)))
            using (var _0x54c721e6 = _0x59cadb1a.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 45, 59, 60, 60, 43, 32, 58, 15, 45, 58, 39, 56, 39, 58, 55 }, 78)))
            using (var _0xa849a95c = _0x54c721e6.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[17] { 24, 26, 11, 47, 30, 28, 20, 30, 24, 26, 50, 30, 17, 30, 24, 26, 13 }, 127)))
            using (var _0x276ab7a5 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[22] { 231, 232, 226, 244, 233, 239, 226, 168, 229, 233, 232, 242, 227, 232, 242, 168, 207, 232, 242, 227, 232, 242 }, 134)))
            using (var _0xc3d4dbfe = _0x276ab7a5.CallStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[8] { 42, 59, 40, 41, 63, 15, 40, 51 }, 90), _0xa5430f38, 1))
            {
                string _0xe48c03f3 = _0xc3d4dbfe.Call<string>(_0xb47a6538._0x3859259a(new byte[14] { 87, 85, 68, 99, 68, 66, 89, 94, 87, 117, 72, 68, 66, 81 }, 48), _0xb47a6538._0x3859259a(new byte[20] { 158, 142, 147, 139, 143, 153, 142, 163, 154, 157, 144, 144, 158, 157, 159, 151, 163, 137, 142, 144 }, 252));
                string _0x27214385 = _0xc3d4dbfe.Call<string>(_0xb47a6538._0x3859259a(new byte[10] { 39, 37, 52, 16, 33, 35, 43, 33, 39, 37 }, 64));
                _0xc3d4dbfe.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[11] { 67, 70, 70, 97, 67, 86, 71, 69, 77, 80, 91 }, 34), _0xb47a6538._0x3859259a(new byte[33] { 232, 231, 237, 251, 230, 224, 237, 167, 224, 231, 253, 236, 231, 253, 167, 234, 232, 253, 236, 238, 230, 251, 240, 167, 203, 219, 198, 222, 218, 200, 203, 197, 204 }, 137));
                _0xc3d4dbfe.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[11] { 47, 56, 48, 50, 43, 56, 24, 37, 41, 47, 60 }, 93), _0xb47a6538._0x3859259a(new byte[20] { 229, 245, 232, 240, 244, 226, 245, 216, 225, 230, 235, 235, 229, 230, 228, 236, 216, 242, 245, 235 }, 135));
                if (_0xc3d4dbfe.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 215, 192, 214, 202, 201, 211, 192, 228, 198, 209, 204, 211, 204, 209, 220 }, 165), _0xa849a95c) != null)
                {
                    WLog(_0xb47a6538._0x3859259a(new byte[24] { 251, 208, 202, 215, 213, 221, 244, 209, 211, 221, 152, 215, 200, 221, 214, 152, 209, 214, 204, 221, 214, 204, 130, 152 }, 184) + _0xa5430f38);
                    _0xc3d4dbfe.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[8] { 124, 121, 121, 91, 113, 124, 122, 110 }, 29), 0x10000000);
                    _0x54c721e6.Call(_0xb47a6538._0x3859259a(new byte[13] { 126, 121, 108, 127, 121, 76, 110, 121, 100, 123, 100, 121, 116 }, 13), _0xc3d4dbfe);
                    return true;
                }

                if (_0x5a398009(_0x27214385))
                    return true;
                if (!string.IsNullOrEmpty(_0xe48c03f3))
                {
                    WLog(_0xb47a6538._0x3859259a(new byte[28] { 5, 46, 52, 41, 43, 35, 10, 47, 45, 35, 102, 47, 40, 50, 35, 40, 50, 102, 32, 39, 42, 42, 36, 39, 37, 45, 124, 102 }, 70) + _0xe48c03f3);
                    if (_0xa7c6b5bd(_0xe48c03f3))
                        return _0xe911f087(_0xe48c03f3, _0x27214385);
                    return _0x85cc9579(_0xe48c03f3);
                }

                WLog(_0xb47a6538._0x3859259a(new byte[30] { 158, 181, 175, 178, 176, 184, 145, 180, 182, 184, 253, 180, 179, 169, 184, 179, 169, 253, 179, 178, 253, 181, 188, 179, 185, 177, 184, 175, 231, 253 }, 221) + _0xa5430f38);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0xb47a6538._0x3859259a(new byte[26] { 140, 167, 189, 160, 162, 170, 131, 166, 164, 170, 239, 166, 161, 187, 170, 161, 187, 239, 169, 174, 166, 163, 170, 171, 245, 239 }, 207) + e.Message);
            return true;
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        _0x1e6b6cd9();
    }

    private IEnumerator _0x133b81dc(string _0x926ca69e)
    {
        if (_0x08850ab8 != null && _0x3d2694bf)
            yield break;
        _0x08850ab8 = gameObject.AddComponent<UniWebView>();
        _0xa890a3c0(_0x08850ab8);
        _0x10cc52a9(_0x08850ab8);
        _0x08850ab8.BackgroundColor = Color.clear;
        var _0x1d1e1345 = SceneManager.GetActiveScene().GetRootGameObjects();
        if (Camera.main != null)
        {
            Camera.main.clearFlags = CameraClearFlags.SolidColor;
            Camera.main.backgroundColor = Color.clear;
            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForEndOfFrame();
        _0x2bdaf96f();
        yield return new WaitForEndOfFrame();
        _0x3d2694bf = true;
        _0x13c64a51();
        _0x545f6c5a(true);
        _0x77ad7fb7 = false;
        _0x446c8b35 = false;
        _0xcf47aac5.Clear();
        _0xb413a91a = -1;
        firstLoadShown = false;
        _0xaa09c69b = false;
        _0xc175709f = false;
        _0x08850ab8.SetUserAgent("");
        _0x82936c1e = Time.realtimeSinceStartup;
        _0x08850ab8.Stop();
        _0x08850ab8.Load(_0x926ca69e);
        _0x08850ab8.Show(false, UniWebViewTransitionEdge.None, 0f, null);
        WLog(_0xb47a6538._0x3859259a(new byte[25] { 133, 169, 161, 166, 232, 159, 173, 170, 158, 161, 173, 191, 232, 129, 166, 161, 188, 161, 169, 164, 232, 155, 160, 167, 191 }, 200));
    }

    private async Task _0x5374ca2d(string _0xc45a456b)
    {
        if (_0x75ef1d8f || string.IsNullOrEmpty(_0x2a59a4ca) || string.IsNullOrEmpty(_0xc45a456b) || _0x006c589d)
            return;
        _0x75ef1d8f = true;
        try
        {
            JObject _0x2c1d5de6 = _0x5fc31417(_0xc45a456b, _0x2a59a4ca, _0xa1e9d3b9());
            {
#if B_LOGS
                {
                    Debug.Log($"[Test][Load Pass] Send total: {_0xc45a456b} payload: {_0x2c1d5de6}");
                }
#endif
            }

            var _0x8a5d6329 = _0x9865d388(_0x2c1d5de6.ToString(), _0x2a59a4ca);
            await _0x65fe19f2(LeaderboardId, 2d, _0x8a5d6329);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[24] { 53, 58, 43, 61, 58, 51, 78, 34, 1, 15, 10, 78, 30, 15, 29, 29, 78, 11, 28, 28, 1, 28, 84, 78 }, 110) + e.Message);
#endif
            }
        }
    }

    private async void Start()
    {
        await _0xc292b91b();
    }

    private bool _0x7b9ad95f = false;
    private bool _0x0b832fc1()
    {
        if (_0xe4083edc())
            return true;
        if (_0x08850ab8 != null && _0x08850ab8.CanGoBack)
        {
            WLog(_0xb47a6538._0x3859259a(new byte[36] { 185, 144, 131, 149, 134, 144, 131, 148, 209, 147, 144, 146, 154, 209, 220, 207, 209, 156, 144, 152, 159, 209, 166, 148, 147, 167, 152, 148, 134, 209, 182, 158, 179, 144, 146, 154 }, 241));
            _0x08850ab8.GoBack();
            return true;
        }

        return false;
    }

    private void _0x2c3122eb()
    {
        if (_0x08850ab8 == null)
            return;
        if (_0x446c8b35)
            _0x08850ab8.SetUserAgent(_0x7f8bacbd());
        else
            _0x08850ab8.SetUserAgent("");
    }

    internal Rect lastSafe = Rect.zero;
    private GameObject _0x87ef7093;
    private bool _0x5a398009(string _0xf28c6135)
    {
        if (string.IsNullOrEmpty(_0xf28c6135))
            return false;
        try
        {
            using (var _0xe18c852a = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 122, 118, 116, 55, 108, 119, 112, 109, 96, 42, 125, 55, 105, 117, 120, 96, 124, 107, 55, 76, 119, 112, 109, 96, 73, 117, 120, 96, 124, 107 }, 25)))
            using (var _0xfbc3bcf4 = _0xe18c852a.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 56, 46, 41, 41, 62, 53, 47, 26, 56, 47, 50, 45, 50, 47, 34 }, 91)))
            using (var _0x4a5b86bb = _0xfbc3bcf4.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[17] { 74, 72, 89, 125, 76, 78, 70, 76, 74, 72, 96, 76, 67, 76, 74, 72, 95 }, 45)))
            using (var _0x5287587d = _0x4a5b86bb.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[25] { 87, 85, 68, 124, 81, 69, 94, 83, 88, 121, 94, 68, 85, 94, 68, 118, 95, 66, 96, 81, 83, 91, 81, 87, 85 }, 48), _0xf28c6135))
            {
                if (_0x5287587d == null)
                    return false;
                WLog(_0xb47a6538._0x3859259a(new byte[37] { 7, 44, 54, 43, 41, 33, 8, 45, 47, 33, 100, 40, 37, 49, 42, 39, 44, 100, 45, 42, 55, 48, 37, 40, 40, 33, 32, 100, 52, 37, 39, 47, 37, 35, 33, 126, 100 }, 68) + _0xf28c6135);
                _0x5287587d.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[8] { 209, 212, 212, 246, 220, 209, 215, 195 }, 176), 0x10000000);
                _0xfbc3bcf4.Call(_0xb47a6538._0x3859259a(new byte[13] { 153, 158, 139, 152, 158, 171, 137, 158, 131, 156, 131, 158, 147 }, 234), _0x5287587d);
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

    private string _0xed1c249a = "";
    private string _0xf9ead3f5 { get; set; }

    internal bool IsAboutBlank(string _0x3f064b28)
    {
        if (string.IsNullOrEmpty(_0x3f064b28))
            return false;
        return _0x3f064b28.StartsWith(_0xb47a6538._0x3859259a(new byte[11] { 211, 208, 221, 199, 198, 136, 208, 222, 211, 220, 217 }, 178), StringComparison.OrdinalIgnoreCase);
    }

    internal string _0x49900c7c(string _0x4cfd02a7)
    {
        int _0x88578566 = _0x4cfd02a7.IndexOf(_0xb47a6538._0x3859259a(new byte[3] { 213, 216, 129 }, 188), StringComparison.OrdinalIgnoreCase);
        if (_0x88578566 < 0)
            return null;
        string _0x099b9ef3 = _0x4cfd02a7.Substring(_0x88578566 + 3);
        int _0x8c3269b8 = _0x099b9ef3.IndexOf('&');
        return _0x8c3269b8 >= 0 ? _0x099b9ef3.Substring(0, _0x8c3269b8) : _0x099b9ef3;
    }

    private string _0xd801d00f = "";
    public void _0x7d939e35()
    {
        if (_0x3d2694bf)
            return;
        {
#if B_LOGS
            {
                Debug.Log(_0xb47a6538._0x3859259a(new byte[33] { 78, 65, 112, 102, 97, 72, 53, 65, 124, 120, 112, 103, 53, 122, 96, 97, 53, 56, 43, 53, 120, 122, 99, 112, 53, 97, 122, 53, 102, 118, 112, 123, 112 }, 21));
            }
#endif
        }

        _0x1e6b6cd9();
    }

    private string _0x3d8706ac = "";
    private static readonly string WindowsDesktopUserAgent = _0xb47a6538._0x3859259a(new byte[111] { 92, 126, 107, 120, 125, 125, 112, 62, 36, 63, 33, 49, 57, 70, 120, 127, 117, 126, 102, 98, 49, 95, 69, 49, 32, 33, 63, 33, 42, 49, 70, 120, 127, 39, 37, 42, 49, 105, 39, 37, 56, 49, 80, 97, 97, 125, 116, 70, 116, 115, 90, 120, 101, 62, 36, 34, 38, 63, 34, 39, 49, 57, 90, 89, 69, 92, 93, 61, 49, 125, 120, 122, 116, 49, 86, 116, 114, 122, 126, 56, 49, 82, 121, 99, 126, 124, 116, 62, 32, 35, 33, 63, 33, 63, 33, 63, 33, 49, 66, 112, 119, 112, 99, 120, 62, 36, 34, 38, 63, 34, 39 }, 17);
    private readonly List<UniWebViewPopup> _0xcf47aac5 = new List<UniWebViewPopup>();
    private string _0xa065aa73()
    {
        string _0x0b1cb348 = _0x7f8bacbd();
        if (string.IsNullOrEmpty(_0x0b1cb348))
            return _0xb47a6538._0x3859259a(new byte[7] { 83, 74, 76, 65, 5, 21, 30 }, 37);
        string _0x282baaae = _0x0b1cb348.Replace(_0xb47a6538._0x3859259a(new byte[1] { 70 }, 26), _0xb47a6538._0x3859259a(new byte[2] { 248, 248 }, 164)).Replace(_0xb47a6538._0x3859259a(new byte[1] { 174 }, 137), _0xb47a6538._0x3859259a(new byte[2] { 124, 7 }, 32));
        var _0xa1bb6edc = Regex.Match(_0x0b1cb348, _0xb47a6538._0x3859259a(new byte[12] { 85, 126, 100, 121, 123, 115, 57, 62, 74, 114, 61, 63 }, 22));
        string _0x272c200f = _0xa1bb6edc.Success ? _0xa1bb6edc.Groups[1].Value : _0xb47a6538._0x3859259a(new byte[3] { 113, 114, 112 }, 64);
        return _0xb47a6538._0x3859259a(new byte[12] { 127, 49, 34, 57, 52, 35, 62, 56, 57, 127, 126, 44 }, 87) + _0xb47a6538._0x3859259a(new byte[8] { 145, 134, 149, 199, 146, 134, 218, 192 }, 231) + _0x282baaae + _0xb47a6538._0x3859259a(new byte[2] { 34, 62 }, 5) + _0xb47a6538._0x3859259a(new byte[30] { 117, 98, 113, 35, 115, 113, 108, 119, 108, 62, 77, 98, 117, 106, 100, 98, 119, 108, 113, 45, 115, 113, 108, 119, 108, 119, 122, 115, 102, 56 }, 3) + _0xb47a6538._0x3859259a(new byte[121] { 121, 106, 113, 124, 107, 118, 112, 113, 63, 123, 122, 121, 55, 112, 125, 117, 51, 116, 122, 102, 51, 105, 126, 115, 54, 100, 107, 109, 102, 100, 80, 125, 117, 122, 124, 107, 49, 123, 122, 121, 118, 113, 122, 79, 109, 112, 111, 122, 109, 107, 102, 55, 112, 125, 117, 51, 116, 122, 102, 51, 100, 120, 122, 107, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 109, 122, 107, 106, 109, 113, 63, 105, 126, 115, 36, 98, 51, 124, 112, 113, 121, 118, 120, 106, 109, 126, 125, 115, 122, 37, 107, 109, 106, 122, 98, 54, 36, 98, 124, 126, 107, 124, 119, 55, 122, 54, 100, 98, 98 }, 31) + _0xb47a6538._0x3859259a(new byte[26] { 62, 63, 60, 114, 42, 40, 53, 46, 53, 118, 125, 47, 41, 63, 40, 27, 61, 63, 52, 46, 125, 118, 47, 59, 115, 97 }, 90) + _0xb47a6538._0x3859259a(new byte[52] { 157, 156, 159, 209, 137, 139, 150, 141, 150, 213, 222, 152, 137, 137, 175, 156, 139, 138, 144, 150, 151, 222, 213, 140, 152, 215, 139, 156, 137, 149, 152, 154, 156, 209, 214, 167, 180, 150, 131, 144, 149, 149, 152, 165, 214, 214, 213, 222, 222, 208, 208, 194 }, 249) + _0xb47a6538._0x3859259a(new byte[37] { 223, 222, 221, 147, 203, 201, 212, 207, 212, 151, 156, 203, 215, 218, 207, 221, 212, 201, 214, 156, 151, 156, 247, 210, 213, 206, 195, 155, 218, 201, 214, 205, 131, 215, 156, 146, 128 }, 187) + _0xb47a6538._0x3859259a(new byte[34] { 161, 160, 163, 237, 181, 183, 170, 177, 170, 233, 226, 179, 160, 171, 161, 170, 183, 226, 233, 226, 130, 170, 170, 162, 169, 160, 229, 140, 171, 166, 235, 226, 236, 254 }, 197) + _0xb47a6538._0x3859259a(new byte[30] { 136, 137, 138, 196, 156, 158, 131, 152, 131, 192, 203, 129, 141, 148, 184, 131, 153, 143, 132, 188, 131, 133, 130, 152, 159, 203, 192, 217, 197, 215 }, 236) + _0xb47a6538._0x3859259a(new byte[48] { 237, 235, 224, 226, 239, 248, 235, 185, 236, 248, 253, 164, 226, 251, 235, 248, 247, 253, 234, 163, 194, 226, 251, 235, 248, 247, 253, 163, 190, 218, 241, 235, 246, 244, 240, 236, 244, 190, 181, 239, 252, 235, 234, 240, 246, 247, 163, 190 }, 153) + _0x272c200f + _0xb47a6538._0x3859259a(new byte[35] { 97, 59, 106, 61, 36, 52, 39, 40, 34, 124, 97, 1, 41, 41, 33, 42, 35, 102, 5, 46, 52, 41, 43, 35, 97, 106, 48, 35, 52, 53, 47, 41, 40, 124, 97 }, 70) + _0x272c200f + _0xb47a6538._0x3859259a(new byte[238] { 242, 168, 249, 174, 183, 167, 180, 187, 177, 239, 242, 155, 186, 161, 232, 148, 234, 151, 167, 180, 187, 177, 242, 249, 163, 176, 167, 166, 188, 186, 187, 239, 242, 231, 225, 242, 168, 136, 249, 184, 186, 183, 188, 185, 176, 239, 161, 167, 160, 176, 249, 165, 185, 180, 161, 179, 186, 167, 184, 239, 242, 148, 187, 177, 167, 186, 188, 177, 242, 249, 178, 176, 161, 157, 188, 178, 189, 144, 187, 161, 167, 186, 165, 172, 131, 180, 185, 160, 176, 166, 239, 179, 160, 187, 182, 161, 188, 186, 187, 253, 252, 174, 167, 176, 161, 160, 167, 187, 245, 133, 167, 186, 184, 188, 166, 176, 251, 167, 176, 166, 186, 185, 163, 176, 253, 174, 180, 167, 182, 189, 188, 161, 176, 182, 161, 160, 167, 176, 239, 242, 180, 167, 184, 242, 249, 183, 188, 161, 187, 176, 166, 166, 239, 242, 227, 225, 242, 249, 184, 186, 183, 188, 185, 176, 239, 161, 167, 160, 176, 249, 184, 186, 177, 176, 185, 239, 242, 242, 249, 165, 185, 180, 161, 179, 186, 167, 184, 239, 242, 148, 187, 177, 167, 186, 188, 177, 242, 249, 165, 185, 180, 161, 179, 186, 167, 184, 131, 176, 167, 166, 188, 186, 187, 239, 242, 228, 225, 251, 229, 251, 229, 242, 249, 160, 180, 147, 160, 185, 185, 131, 176, 167, 166, 188, 186, 187, 239, 242 }, 213) + _0x272c200f + _0xb47a6538._0x3859259a(new byte[117] { 49, 47, 49, 47, 49, 47, 56, 98, 54, 36, 98, 98, 36, 80, 125, 117, 122, 124, 107, 49, 123, 122, 121, 118, 113, 122, 79, 109, 112, 111, 122, 109, 107, 102, 55, 111, 109, 112, 107, 112, 51, 56, 106, 108, 122, 109, 94, 120, 122, 113, 107, 91, 126, 107, 126, 56, 51, 100, 120, 122, 107, 37, 121, 106, 113, 124, 107, 118, 112, 113, 55, 54, 100, 109, 122, 107, 106, 109, 113, 63, 106, 126, 123, 36, 98, 51, 124, 112, 113, 121, 118, 120, 106, 109, 126, 125, 115, 122, 37, 107, 109, 106, 122, 98, 54, 36, 98, 124, 126, 107, 124, 119, 55, 122, 54, 100, 98 }, 31) + _0xb47a6538._0x3859259a(new byte[5] { 141, 217, 216, 217, 203 }, 240);
    }

    internal void Update()
    {
        if (_0x08850ab8 == null)
            return;
        if (_0xd0b10ca7())
            _0xabd5bd3a();
        if (!isApplicationFocus || isApplicationPause)
            return;
        _0x2bdaf96f();
        if (_0x7b9ad95f && _0xe855809d != null)
            _0xe855809d.Rotate(0f, 0f, -360f * Time.deltaTime);
    }

    private string GetUrlHost(string _0xba2e5bee)
    {
        if (string.IsNullOrEmpty(_0xba2e5bee))
            return null;
        Uri _0x2bff0992;
        if (!Uri.TryCreate(_0xba2e5bee, UriKind.Absolute, out _0x2bff0992))
            return null;
        string _0x3367ea2d = _0x2bff0992.Host;
        if (_0x3367ea2d.StartsWith(_0xb47a6538._0x3859259a(new byte[4] { 197, 197, 197, 156 }, 178), StringComparison.OrdinalIgnoreCase))
            _0x3367ea2d = _0x3367ea2d.Substring(4);
        return _0x3367ea2d;
    }

    internal Button _0xb33158b1(string _0xec9371ba, Transform _0xe7aaff4c)
    {
        var _0x27bbe319 = new GameObject(_0xec9371ba + _0xb47a6538._0x3859259a(new byte[3] { 116, 66, 88 }, 54), typeof(RectTransform), typeof(Image), typeof(Button));
        var _0x6a967837 = _0x27bbe319.GetComponent<RectTransform>();
        _0x6a967837.SetParent(_0xe7aaff4c, false);
        var _0x3eb4ebcf = _0x27bbe319.GetComponent<Image>();
        _0x3eb4ebcf.color = new Color(0.92f, 0.92f, 0.95f, 1f);
        var _0x76438ac6 = _0x27bbe319.GetComponent<Button>();
        var _0x809869d4 = _0x76438ac6.colors;
        _0x809869d4.highlightedColor = new Color(0.85f, 0.85f, 0.9f);
        _0x809869d4.pressedColor = new Color(0.8f, 0.8f, 0.88f);
        _0x76438ac6.colors = _0x809869d4;
        var _0x49671fcf = new GameObject(_0xb47a6538._0x3859259a(new byte[4] { 113, 64, 93, 81 }, 37), typeof(RectTransform), typeof(Text));
        var _0xec0bea90 = _0x49671fcf.GetComponent<RectTransform>();
        _0xec0bea90.SetParent(_0x27bbe319.transform, false);
        _0xec0bea90.anchorMin = Vector2.zero;
        _0xec0bea90.anchorMax = Vector2.one;
        _0xec0bea90.offsetMin = _0xec0bea90.offsetMax = Vector2.zero;
        var _0x46e187b6 = _0x49671fcf.GetComponent<Text>();
        _0x46e187b6.text = _0xec9371ba;
        _0x46e187b6.alignment = TextAnchor.MiddleCenter;
        _0x46e187b6.color = Color.black;
        _0x46e187b6.font = Resources.GetBuiltinResource<Font>(_0xb47a6538._0x3859259a(new byte[9] { 27, 40, 51, 59, 54, 116, 46, 46, 60 }, 90));
        _0x46e187b6.fontSize = 28;
        WLog(_0xb47a6538._0x3859259a(new byte[14] { 105, 88, 79, 75, 94, 79, 104, 95, 94, 94, 69, 68, 10, 13 }, 42) + _0xec9371ba + _0xb47a6538._0x3859259a(new byte[1] { 204 }, 235));
        return _0x76438ac6;
    }

    private string _0x536afd90()
    {
        return _0xb47a6538._0x3859259a(new byte[12] { 100, 42, 57, 34, 47, 56, 37, 35, 34, 100, 101, 55 }, 76) + _0xb47a6538._0x3859259a(new byte[8] { 35, 52, 39, 117, 32, 52, 104, 114 }, 85) + WindowsDesktopUserAgent + _0xb47a6538._0x3859259a(new byte[2] { 73, 85 }, 110) + _0xb47a6538._0x3859259a(new byte[30] { 186, 173, 190, 236, 188, 190, 163, 184, 163, 241, 130, 173, 186, 165, 171, 173, 184, 163, 190, 226, 188, 190, 163, 184, 163, 184, 181, 188, 169, 247 }, 204) + _0xb47a6538._0x3859259a(new byte[121] { 46, 61, 38, 43, 60, 33, 39, 38, 104, 44, 45, 46, 96, 39, 42, 34, 100, 35, 45, 49, 100, 62, 41, 36, 97, 51, 60, 58, 49, 51, 7, 42, 34, 45, 43, 60, 102, 44, 45, 46, 33, 38, 45, 24, 58, 39, 56, 45, 58, 60, 49, 96, 39, 42, 34, 100, 35, 45, 49, 100, 51, 47, 45, 60, 114, 46, 61, 38, 43, 60, 33, 39, 38, 96, 97, 51, 58, 45, 60, 61, 58, 38, 104, 62, 41, 36, 115, 53, 100, 43, 39, 38, 46, 33, 47, 61, 58, 41, 42, 36, 45, 114, 60, 58, 61, 45, 53, 97, 115, 53, 43, 41, 60, 43, 32, 96, 45, 97, 51, 53, 53 }, 72) + _0xb47a6538._0x3859259a(new byte[26] { 19, 18, 17, 95, 7, 5, 24, 3, 24, 91, 80, 2, 4, 18, 5, 54, 16, 18, 25, 3, 80, 91, 2, 22, 94, 76 }, 119) + _0xb47a6538._0x3859259a(new byte[130] { 229, 228, 231, 169, 241, 243, 238, 245, 238, 173, 166, 224, 241, 241, 215, 228, 243, 242, 232, 238, 239, 166, 173, 166, 180, 175, 177, 161, 169, 214, 232, 239, 229, 238, 246, 242, 161, 207, 213, 161, 176, 177, 175, 177, 186, 161, 214, 232, 239, 183, 181, 186, 161, 249, 183, 181, 168, 161, 192, 241, 241, 237, 228, 214, 228, 227, 202, 232, 245, 174, 180, 178, 182, 175, 178, 183, 161, 169, 202, 201, 213, 204, 205, 173, 161, 237, 232, 234, 228, 161, 198, 228, 226, 234, 238, 168, 161, 194, 233, 243, 238, 236, 228, 174, 176, 179, 177, 175, 177, 175, 177, 175, 177, 161, 210, 224, 231, 224, 243, 232, 174, 180, 178, 182, 175, 178, 183, 166, 168, 186 }, 129) + _0xb47a6538._0x3859259a(new byte[30] { 250, 251, 248, 182, 238, 236, 241, 234, 241, 178, 185, 238, 242, 255, 234, 248, 241, 236, 243, 185, 178, 185, 201, 247, 240, 173, 172, 185, 183, 165 }, 158) + _0xb47a6538._0x3859259a(new byte[34] { 28, 29, 30, 80, 8, 10, 23, 12, 23, 84, 95, 14, 29, 22, 28, 23, 10, 95, 84, 95, 63, 23, 23, 31, 20, 29, 88, 49, 22, 27, 86, 95, 81, 67 }, 120) + _0xb47a6538._0x3859259a(new byte[30] { 231, 230, 229, 171, 243, 241, 236, 247, 236, 175, 164, 238, 226, 251, 215, 236, 246, 224, 235, 211, 236, 234, 237, 247, 240, 164, 175, 179, 170, 184 }, 131) + _0xb47a6538._0x3859259a(new byte[449] { 83, 85, 94, 92, 81, 70, 85, 7, 82, 70, 67, 26, 92, 69, 85, 70, 73, 67, 84, 29, 124, 92, 69, 85, 70, 73, 67, 29, 0, 100, 79, 85, 72, 74, 78, 82, 74, 0, 11, 81, 66, 85, 84, 78, 72, 73, 29, 0, 22, 21, 23, 0, 90, 11, 92, 69, 85, 70, 73, 67, 29, 0, 96, 72, 72, 64, 75, 66, 7, 100, 79, 85, 72, 74, 66, 0, 11, 81, 66, 85, 84, 78, 72, 73, 29, 0, 22, 21, 23, 0, 90, 11, 92, 69, 85, 70, 73, 67, 29, 0, 105, 72, 83, 26, 102, 24, 101, 85, 70, 73, 67, 0, 11, 81, 66, 85, 84, 78, 72, 73, 29, 0, 21, 19, 0, 90, 122, 11, 74, 72, 69, 78, 75, 66, 29, 65, 70, 75, 84, 66, 11, 87, 75, 70, 83, 65, 72, 85, 74, 29, 0, 112, 78, 73, 67, 72, 80, 84, 0, 11, 64, 66, 83, 111, 78, 64, 79, 98, 73, 83, 85, 72, 87, 94, 113, 70, 75, 82, 66, 84, 29, 65, 82, 73, 68, 83, 78, 72, 73, 15, 14, 92, 85, 66, 83, 82, 85, 73, 7, 119, 85, 72, 74, 78, 84, 66, 9, 85, 66, 84, 72, 75, 81, 66, 15, 92, 70, 85, 68, 79, 78, 83, 66, 68, 83, 82, 85, 66, 29, 0, 95, 31, 17, 0, 11, 69, 78, 83, 73, 66, 84, 84, 29, 0, 17, 19, 0, 11, 74, 72, 69, 78, 75, 66, 29, 65, 70, 75, 84, 66, 11, 74, 72, 67, 66, 75, 29, 0, 0, 11, 87, 75, 70, 83, 65, 72, 85, 74, 29, 0, 112, 78, 73, 67, 72, 80, 84, 0, 11, 87, 75, 70, 83, 65, 72, 85, 74, 113, 66, 85, 84, 78, 72, 73, 29, 0, 22, 18, 9, 23, 9, 23, 0, 11, 82, 70, 97, 82, 75, 75, 113, 66, 85, 84, 78, 72, 73, 29, 0, 22, 21, 23, 9, 23, 9, 23, 9, 23, 0, 90, 14, 28, 90, 90, 28, 104, 69, 77, 66, 68, 83, 9, 67, 66, 65, 78, 73, 66, 119, 85, 72, 87, 66, 85, 83, 94, 15, 87, 85, 72, 83, 72, 11, 0, 82, 84, 66, 85, 102, 64, 66, 73, 83, 99, 70, 83, 70, 0, 11, 92, 64, 66, 83, 29, 65, 82, 73, 68, 83, 78, 72, 73, 15, 14, 92, 85, 66, 83, 82, 85, 73, 7, 82, 70, 67, 28, 90, 11, 68, 72, 73, 65, 78, 64, 82, 85, 70, 69, 75, 66, 29, 83, 85, 82, 66, 90, 14, 28, 90, 68, 70, 83, 68, 79, 15, 66, 14, 92, 90 }, 39) + _0xb47a6538._0x3859259a(new byte[112] { 172, 173, 174, 224, 187, 171, 186, 173, 173, 166, 228, 239, 191, 161, 172, 188, 160, 239, 228, 249, 241, 250, 248, 225, 243, 172, 173, 174, 224, 187, 171, 186, 173, 173, 166, 228, 239, 160, 173, 161, 175, 160, 188, 239, 228, 249, 248, 240, 248, 225, 243, 172, 173, 174, 224, 187, 171, 186, 173, 173, 166, 228, 239, 169, 190, 169, 161, 164, 159, 161, 172, 188, 160, 239, 228, 249, 241, 250, 248, 225, 243, 172, 173, 174, 224, 187, 171, 186, 173, 173, 166, 228, 239, 169, 190, 169, 161, 164, 128, 173, 161, 175, 160, 188, 239, 228, 249, 248, 252, 248, 225, 243 }, 200) + _0xb47a6538._0x3859259a(new byte[45] { 251, 253, 246, 244, 248, 230, 225, 235, 224, 248, 161, 224, 225, 251, 224, 250, 236, 231, 252, 251, 238, 253, 251, 178, 250, 225, 235, 234, 233, 230, 225, 234, 235, 180, 242, 236, 238, 251, 236, 231, 167, 234, 166, 244, 242 }, 143) + _0xb47a6538._0x3859259a(new byte[721] { 5, 3, 8, 10, 7, 16, 3, 81, 30, 3, 24, 22, 76, 6, 24, 31, 21, 30, 6, 95, 28, 16, 5, 18, 25, 60, 20, 21, 24, 16, 95, 19, 24, 31, 21, 89, 6, 24, 31, 21, 30, 6, 88, 74, 6, 24, 31, 21, 30, 6, 95, 28, 16, 5, 18, 25, 60, 20, 21, 24, 16, 76, 23, 4, 31, 18, 5, 24, 30, 31, 89, 0, 88, 10, 7, 16, 3, 81, 2, 76, 34, 5, 3, 24, 31, 22, 89, 0, 88, 95, 5, 30, 61, 30, 6, 20, 3, 50, 16, 2, 20, 89, 88, 74, 24, 23, 89, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 1, 30, 24, 31, 5, 20, 3, 75, 81, 18, 30, 16, 3, 2, 20, 86, 88, 79, 76, 65, 13, 13, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 25, 30, 7, 20, 3, 75, 81, 31, 30, 31, 20, 86, 88, 79, 76, 65, 13, 13, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 28, 16, 9, 92, 6, 24, 21, 5, 25, 86, 88, 79, 76, 65, 13, 13, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 28, 16, 9, 92, 21, 20, 7, 24, 18, 20, 92, 6, 24, 21, 5, 25, 86, 88, 79, 76, 65, 88, 3, 20, 5, 4, 3, 31, 81, 10, 28, 16, 5, 18, 25, 20, 2, 75, 23, 16, 29, 2, 20, 93, 28, 20, 21, 24, 16, 75, 0, 93, 30, 31, 18, 25, 16, 31, 22, 20, 75, 31, 4, 29, 29, 93, 16, 21, 21, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 3, 20, 28, 30, 7, 20, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 16, 21, 21, 52, 7, 20, 31, 5, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 3, 20, 28, 30, 7, 20, 52, 7, 20, 31, 5, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 21, 24, 2, 1, 16, 5, 18, 25, 52, 7, 20, 31, 5, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 3, 20, 5, 4, 3, 31, 81, 23, 16, 29, 2, 20, 74, 12, 12, 74, 24, 23, 89, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 1, 30, 24, 31, 5, 20, 3, 75, 81, 23, 24, 31, 20, 86, 88, 79, 76, 65, 13, 13, 2, 95, 24, 31, 21, 20, 9, 62, 23, 89, 86, 25, 30, 7, 20, 3, 75, 81, 25, 30, 7, 20, 3, 86, 88, 79, 76, 65, 88, 3, 20, 5, 4, 3, 31, 81, 10, 28, 16, 5, 18, 25, 20, 2, 75, 5, 3, 4, 20, 93, 28, 20, 21, 24, 16, 75, 0, 93, 30, 31, 18, 25, 16, 31, 22, 20, 75, 31, 4, 29, 29, 93, 16, 21, 21, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 3, 20, 28, 30, 7, 20, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 16, 21, 21, 52, 7, 20, 31, 5, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 3, 20, 28, 30, 7, 20, 52, 7, 20, 31, 5, 61, 24, 2, 5, 20, 31, 20, 3, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 12, 93, 21, 24, 2, 1, 16, 5, 18, 25, 52, 7, 20, 31, 5, 75, 23, 4, 31, 18, 5, 24, 30, 31, 89, 88, 10, 3, 20, 5, 4, 3, 31, 81, 23, 16, 29, 2, 20, 74, 12, 12, 74, 3, 20, 5, 4, 3, 31, 81, 30, 3, 24, 22, 89, 0, 88, 74, 12, 74, 12, 18, 16, 5, 18, 25, 89, 20, 88, 10, 12 }, 113) + _0xb47a6538._0x3859259a(new byte[5] { 248, 172, 173, 172, 190 }, 133);
    }

    static byte[] PackSmallest(byte[] _0x5b77a22e, out byte _0x758511e6)
    {
        var _0x3191290e = CompressBrotli(_0x5b77a22e);
        var _0x9fba8d65 = CompressDeflate(_0x5b77a22e);
        if (_0x3191290e.Length < _0x5b77a22e.Length && _0x3191290e.Length <= _0x9fba8d65.Length)
        {
            _0x758511e6 = 1;
            return _0x3191290e;
        }

        if (_0x9fba8d65.Length < _0x5b77a22e.Length)
        {
            _0x758511e6 = 2;
            return _0x9fba8d65;
        }

        _0x758511e6 = 0;
        return _0x5b77a22e;
    }

    private string _0xe4937544 = "";
    private bool _0x85cc9579(string _0x1346e78e)
    {
        try
        {
            using (var _0xce256260 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 143, 131, 129, 194, 153, 130, 133, 152, 149, 223, 136, 194, 156, 128, 141, 149, 137, 158, 194, 185, 130, 133, 152, 149, 188, 128, 141, 149, 137, 158 }, 236)))
            using (var _0x070075f0 = _0xce256260.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 116, 98, 101, 101, 114, 121, 99, 86, 116, 99, 126, 97, 126, 99, 110 }, 23)))
            using (var _0xd8409e59 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[15] { 93, 82, 88, 78, 83, 85, 88, 18, 82, 89, 72, 18, 105, 78, 85 }, 60)))
            using (var _0xc53fbd88 = _0xd8409e59.CallStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[5] { 161, 176, 163, 162, 180 }, 209), _0x1346e78e))
            using (var _0x34420b10 = new AndroidJavaObject(_0xb47a6538._0x3859259a(new byte[22] { 87, 88, 82, 68, 89, 95, 82, 24, 85, 89, 88, 66, 83, 88, 66, 24, 127, 88, 66, 83, 88, 66 }, 54), _0xb47a6538._0x3859259a(new byte[26] { 230, 233, 227, 245, 232, 238, 227, 169, 238, 233, 243, 226, 233, 243, 169, 230, 228, 243, 238, 232, 233, 169, 209, 206, 194, 208 }, 135), _0xc53fbd88))
            {
                WLog(_0xb47a6538._0x3859259a(new byte[26] { 169, 130, 152, 133, 135, 143, 166, 131, 129, 143, 202, 133, 154, 143, 132, 202, 143, 146, 158, 143, 152, 132, 139, 134, 208, 202 }, 234) + _0x1346e78e);
                _0x34420b10.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[11] { 157, 152, 152, 191, 157, 136, 153, 155, 147, 142, 133 }, 252), _0xb47a6538._0x3859259a(new byte[33] { 123, 116, 126, 104, 117, 115, 126, 52, 115, 116, 110, 127, 116, 110, 52, 121, 123, 110, 127, 125, 117, 104, 99, 52, 88, 72, 85, 77, 73, 91, 88, 86, 95 }, 26));
                _0x34420b10.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[8] { 22, 19, 19, 49, 27, 22, 16, 4 }, 119), 0x10000000);
                _0x070075f0.Call(_0xb47a6538._0x3859259a(new byte[13] { 76, 75, 94, 77, 75, 126, 92, 75, 86, 73, 86, 75, 70 }, 63), _0x34420b10);
                return true;
            }
        }
        catch (Exception e)
        {
            WLog(_0xb47a6538._0x3859259a(new byte[28] { 179, 152, 130, 159, 157, 149, 188, 153, 155, 149, 208, 149, 136, 132, 149, 130, 158, 145, 156, 208, 150, 145, 153, 156, 149, 148, 202, 208 }, 240) + e.Message);
            Application.OpenURL(_0x1346e78e);
            return true;
        }
    }

    private int _0xb13d9fa9 = 0;
    private string _0xefea71c1 = "";
    private int _0x89f99ab1 = 5, _0xdf684570 = 5, _0xcba688f4 = 5, _0xb12c604b = 5;
    private void _0xe0b93ba5(string _0xd9db64a6)
    {
        bool _0x1bd8bf41 = !string.IsNullOrEmpty(_0xd9db64a6);
        if (_0x1bd8bf41)
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[13] { 104, 103, 86, 64, 71, 110, 19, 96, 91, 92, 68, 9, 19 }, 51) + _0xd9db64a6);
#endif
            }

            _0x855cd1c6(_0xd9db64a6);
            return;
        }
        else
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[39] { 61, 50, 3, 21, 18, 59, 70, 32, 7, 10, 10, 4, 7, 5, 13, 70, 132, 224, 244, 70, 33, 7, 11, 3, 70, 78, 8, 9, 70, 0, 15, 8, 7, 10, 70, 51, 52, 42, 79 }, 102));
#endif
            }

            _0x1e6b6cd9();
            return;
        }
    }

    private void _0xf2cec61b()
    {
        if (_0xc175709f)
        {
            WLog(_0xb47a6538._0x3859259a(new byte[18] { 43, 22, 7, 26, 78, 15, 2, 28, 11, 15, 10, 23, 78, 29, 6, 1, 25, 0 }, 110));
            return;
        }

        _0x545f6c5a(false);
        WLog(_0xb47a6538._0x3859259a(new byte[46] { 40, 4, 12, 11, 69, 50, 0, 7, 51, 12, 0, 18, 69, 53, 16, 22, 13, 69, 43, 10, 17, 12, 3, 12, 6, 4, 17, 12, 10, 11, 69, 77, 13, 4, 23, 1, 18, 4, 23, 0, 69, 7, 4, 6, 14, 76 }, 101));
        ++_0xb13d9fa9;
        _0x99b9f781();
        if (_0xb13d9fa9 <= 1)
            return;
        if (_0xdf27e3ba())
        {
            WLog(_0xb47a6538._0x3859259a(new byte[37] { 129, 188, 173, 176, 228, 183, 175, 173, 180, 180, 161, 160, 228, 233, 250, 228, 180, 171, 180, 177, 180, 183, 228, 183, 176, 173, 168, 168, 228, 171, 180, 161, 170, 161, 160, 254, 228 }, 196) + _0xcf47aac5.Count);
            return;
        }

        Application.Quit();
    }

    static readonly int[] _0x2dbb7090 = BuildTextAlphabetIndex();
    internal void _0x2bdaf96f()
    {
        Rect _0x501031db = Screen.safeArea;
        Vector2 _0x40095ea2 = new Vector2(Screen.width, Screen.height);
        if (_0x501031db == lastSafe && _0x40095ea2 == lastSize)
            return;
        // Apply manual padding
        _0x501031db.xMin += _0xcba688f4;
        _0x501031db.xMax -= _0xb12c604b;
        _0x501031db.yMin += _0xdf684570;
        _0x501031db.yMax -= _0x89f99ab1;
        // Convert Unity safe area -> native WebView frame
        Rect _0x0a4be8d5 = new Rect(_0x501031db.x, _0x40095ea2.y - _0x501031db.y - _0x501031db.height, // Y flip for native coordinate system
 _0x501031db.width, _0x501031db.height);
        _0x08850ab8.Frame = _0x0a4be8d5;
        lastSafe = Screen.safeArea;
        lastSize = _0x40095ea2;
    }

    private string _0x30283b6c;
    private string _0xa8f2fc49 = "";
    private void _0xffcf30d0()
    {
        _0x446c8b35 = true;
        if (_0x08850ab8 != null)
            _0x08850ab8.SetUserAgent(_0x7f8bacbd());
    }

    private void OnApplicationFocus(bool _0x27b7636b)
    {
        isApplicationFocus = _0x27b7636b;
        if (_0x27b7636b && _0x3d2694bf)
        {
            _0x3f1601bf();
        }
    }

    private bool _0xaa09c69b = false;
    private string _0xe51014ea = "";
    private string _0x123a55a0;
    private string _0x3697af2d = "";
    static System.IO.Compression.CompressionLevel SmallestCompression()
    {
        return Enum.IsDefined(typeof(System.IO.Compression.CompressionLevel), 3) ? (System.IO.Compression.CompressionLevel)3 : System.IO.Compression.CompressionLevel.Optimal;
    }

    private void OnApplicationPause(bool _0x15a71021)
    {
        isApplicationPause = _0x15a71021;
    }

    internal bool firstLoadShown = false;
    async Task<CommState> _0xb472490e()
    {
        var _0xc33b1200 = await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId, new GetPlayerScoreOptions { IncludeMetadata = true });
        var _0xfbc7df40 = ReadScoreMetadata(_0xc33b1200 != null ? _0xc33b1200.Metadata : null);
        if (string.IsNullOrEmpty(_0xfbc7df40.isMeta))
            return default;
        var _0xf556ccca = _0xa83f475f(_0xfbc7df40.isMeta, _0x2a59a4ca);
        if (_0xf556ccca != _0xb47a6538._0x3859259a(new byte[4] { 159, 153, 158, 142 }, 235) && _0xf556ccca != _0xb47a6538._0x3859259a(new byte[5] { 50, 53, 56, 39, 49 }, 84))
            return default;
        var _0xbed71479 = _0xa83f475f(_0xfbc7df40.meta ?? "", _0x2a59a4ca);
        return new CommState(true, _0xf556ccca == _0xb47a6538._0x3859259a(new byte[4] { 127, 121, 126, 110 }, 11), _0xbed71479);
    }

    private async Task _0x2dfea959()
    {
        {
#if B_LOGS
            Debug.Log($"[Test] Send click");
#endif
        }

        _0x6f7b4306 = _0xb47a6538._0x3859259a(new byte[5] { 245, 242, 255, 224, 246 }, 147);
        _0x9ec5c0e8 = /*IsRunningOnEmulator() ? "running" :*/ "";
        _0x3846805f = DateTime.UtcNow.Ticks.ToString();
        _0x66e491c7 = "";
        JObject _0xd36e2803 = _0x5fc31417(_0x83c01375, _0x3697af2d, _0x3d8706ac, _0xefea71c1, _0xf9ead3f5, _0xca427738, _0xa8f2fc49, _0xe51014ea, _0xed1c249a, _0x6f7b4306, _0xd801d00f, _0x39a8a4ab, _0xc008ea12.ToString(), _0x32a0e5ab, _0x3846805f, _0x2a59a4ca, _0x8f629a96, _0x334b7c04, _0xbd054c09, _0xa1e9d3b9());
        var _0x3667205c = _0x9865d388(_0xd36e2803.ToString(), _0x2a59a4ca);
        {
#if B_LOGS
            {
                Debug.Log($"[Test][First Run] Send Payload for first run: {_0xd36e2803}");
            }
#endif
        }

        try
        {
            await _0x65fe19f2(LeaderboardId, 1d, _0x3667205c);
            await Task.Delay(500);
            string _0x66e16255 = "";
            for (int _0x2dc6a330 = 0; _0x2dc6a330 < 20; _0x2dc6a330++)
            {
                if (await _0x9cb8fb31(1, 1))
                {
                    await _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[7] { 247, 249, 250, 246, 254, 240, 241 }, 149));
                    _0x1e6b6cd9();
                    return;
                }

                _0x66e16255 = await _0xeca62b5b(1, 500);
                if (!string.IsNullOrEmpty(_0x66e16255))
                    break;
            }

            _0xe0b93ba5(_0x66e16255);
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[22] { 110, 97, 112, 102, 97, 104, 21, 114, 80, 91, 80, 71, 84, 89, 21, 80, 71, 71, 90, 71, 15, 21 }, 53) + e.Message);
#endif
            }

            _0x1e6b6cd9();
        }
    }

    private string _0x8f629a96 = "";
    private bool _0xe4083edc()
    {
        var _0xa22bea80 = _0x83de8bc0();
        if (_0xa22bea80 == null)
            return false;
        WLog(_0xb47a6538._0x3859259a(new byte[31] { 157, 180, 167, 177, 162, 180, 167, 176, 245, 183, 180, 182, 190, 245, 248, 235, 245, 165, 186, 165, 160, 165, 245, 146, 186, 151, 180, 182, 190, 239, 245 }, 213) + _0xa22bea80.Id);
        _0xa22bea80.GoBack();
        return true;
    }

    private ApplicationInstallMode _0xc008ea12 = ApplicationInstallMode.Unknown;
    private string _0xbd054c09 = "";
    // WEB VIEW LOGIC
    public bool _0x3d2694bf { get; set; }

    private IEnumerator _0x9db78dbd(IEnumerator _0xdb73fa92, TaskCompletionSource<bool> _0x6b453fbf)
    {
        yield return _0xdb73fa92;
        _0x6b453fbf.SetResult(true);
    }

    private string _0x3846805f = "";
    private string _0xca427738 { get; set; }

    static string Encode93(byte[] _0x4a771388)
    {
        var _0x90780b7c = new byte[_0x4a771388.Length + 1];
        _0x90780b7c[0] = 1;
        Buffer.BlockCopy(_0x4a771388, 0, _0x90780b7c, 1, _0x4a771388.Length);
        var _0xe90e8953 = FromBigEndian(_0x90780b7c);
        var _0x6eb99da7 = new Stack<char>();
        var _0x5006f343 = new System.Numerics.BigInteger(TextAlphabet.Length);
        while (_0xe90e8953 > 0)
        {
            _0xe90e8953 = System.Numerics.BigInteger.DivRem(_0xe90e8953, _0x5006f343, out var rem);
            _0x6eb99da7.Push(TextAlphabet[(int)rem]);
        }

        return new string (_0x6eb99da7.ToArray());
    }

    private async Task<bool> _0xfb79136c()
    {
        _0x4ccc2a9a.Instance?._0x9378a12a();
        PushNotificationsService.Instance.OnRemoteNotificationReceived += (_0x87891185) =>
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[32] { 185, 182, 135, 145, 150, 191, 194, 183, 140, 139, 150, 155, 194, 178, 151, 145, 138, 194, 172, 141, 150, 139, 132, 139, 129, 131, 150, 139, 141, 140, 216, 194 }, 226) + string.Join(_0xb47a6538._0x3859259a(new byte[1] { 112 }, 121), _0x87891185));
                }
#endif
            }
        };
        try
        {
            _0x3d8706ac = await PushNotificationsService.Instance.RegisterForPushNotificationsAsync();
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[31] { 70, 73, 120, 110, 105, 64, 61, 91, 124, 116, 113, 120, 121, 61, 105, 114, 61, 122, 120, 105, 61, 109, 104, 110, 117, 61, 105, 114, 118, 120, 115 }, 29));
                }
#endif
            }

            _0x3d8706ac = "";
        }

        _0x9fb4bdae = !string.IsNullOrEmpty(_0x3d8706ac);
        _0xbd054c09 = _0xa1e9d3b9();
        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[25] { 22, 25, 40, 62, 57, 16, 109, 24, 35, 36, 57, 52, 109, 29, 56, 62, 37, 109, 25, 34, 38, 40, 35, 119, 109 }, 77) + _0x3d8706ac);
#endif
        }

        _0x4ccc2a9a.Instance?._0xfcf31e79();
        return false;
    }

    private void WLog(string _0x9fc00af6)
    {
#if B_LOGS
        {
            Debug.Log(_0xb47a6538._0x3859259a(new byte[7] { 49, 62, 15, 25, 30, 55, 74 }, 106) + _0x9fc00af6);
        }
#endif
    }

    private async Task _0xc292b91b()
    {
        if (await _0x548fdd7a())
            return;
        if (await _0xfb79136c())
            return;
        if (await _0x70c29c6d())
            return;
        _0x90462fc6();
        await _0x50f4dd8a(_0x459a5f6c());
        _0xe51014ea = await _0x66fd81b8();
        await _0x2dfea959();
    }

    internal bool isDestroyedForce = false;
    private void _0xf71cc2bf(string _0x4c0fb6ba)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[34] { 41, 38, 23, 1, 6, 47, 82, 52, 23, 6, 17, 26, 82, 55, 10, 6, 0, 19, 82, 34, 7, 1, 26, 82, 54, 19, 6, 19, 82, 32, 19, 5, 72, 82 }, 114) + _0x4c0fb6ba);
#endif
            }
        }

        var _0x29f8205b = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x4c0fb6ba);
        StartCoroutine(_0x04121fb0(_0x29f8205b));
    }

    private string _0xa09065a1;
    private string _0x334b7c04 = "";
    private bool OpenUrlExternally(string _0x59475500)
    {
        return _0x85cc9579(_0x59475500);
    }

    private string _0xa83f475f(string _0x05974a0d, string _0x245442a4)
    {
        try
        {
            if (string.IsNullOrEmpty(_0x05974a0d))
                return "";
            var _0x643c1ef6 = Decode93(_0x05974a0d);
            if (_0x643c1ef6.Length < 5)
                return "";
            var _0xdc970b94 = new byte[4];
            Buffer.BlockCopy(_0x643c1ef6, 0, _0xdc970b94, 0, 4);
            var _0x6721c277 = new byte[_0x643c1ef6.Length - 4];
            Buffer.BlockCopy(_0x643c1ef6, 4, _0x6721c277, 0, _0x6721c277.Length);
            var _0xd5673122 = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(_0x245442a4 ?? ""));
            var _0x8939e38c = AesCtr(_0x6721c277, _0xd5673122, _0xdc970b94);
            var _0x0c32b280 = new byte[_0x8939e38c.Length - 1];
            Buffer.BlockCopy(_0x8939e38c, 1, _0x0c32b280, 0, _0x0c32b280.Length);
            return Encoding.UTF8.GetString(UnpackSmallest(_0x0c32b280, _0x8939e38c[0]));
        }
        catch (Exception)
        {
            return "";
        }
    }

    private static string ReadPushField(Dictionary<string, object> _0x75942087, string _0x6a7621d5)
    {
        if (_0x75942087 == null || string.IsNullOrEmpty(_0x6a7621d5))
            return string.Empty;
        if (_0x75942087.TryGetValue(_0xb47a6538._0x3859259a(new byte[16] { 19, 18, 9, 20, 27, 20, 30, 28, 9, 20, 18, 19, 57, 28, 9, 28 }, 125), out var raw))
        {
            try
            {
                var _0x3dc816ff = JsonConvert.DeserializeObject<Dictionary<string, object>>(raw?.ToString());
                if (_0x3dc816ff != null && _0x3dc816ff.TryGetValue(_0x6a7621d5, out var nestedVal))
                {
                    var _0xc9936f30 = nestedVal?.ToString();
                    if (!string.IsNullOrEmpty(_0xc9936f30))
                        return _0xc9936f30;
                }
            }
            catch
            {
            }
        }

        if (_0x75942087.TryGetValue(_0x6a7621d5, out var flatVal))
            return flatVal?.ToString() ?? string.Empty;
        return string.Empty;
    }

    private void _0xa890a3c0(UniWebView _0x58c32b15)
    {
        _0x58c32b15.BackgroundColor = Color.clear;
        _0x58c32b15.SetSupportMultipleWindows(true, true);
        _0x58c32b15.SetBackButtonEnabled(false);
        _0x08850ab8.SetUserAgent(_0x7f8bacbd());
    }

    private string _0x66e491c7 = "";
    private void _0x10cc52a9(UniWebView _0x0353957e)
    {
        if (_0x35822957)
            return;
        _0x35822957 = true;
        _0x0353957e.AddUrlScheme(_0xb47a6538._0x3859259a(new byte[2] { 50, 33 }, 70));
        _0x0353957e.AddUrlScheme(_0xb47a6538._0x3859259a(new byte[6] { 197, 194, 216, 201, 194, 216 }, 172));
        _0x0353957e.AddUrlScheme(_0xb47a6538._0x3859259a(new byte[6] { 1, 13, 30, 7, 9, 24 }, 108));
        _0x0353957e.OnMessageReceived += (_0x6f4ea1fb, _0x2ef1d985) =>
        {
            if (TryOpenExternalLikeChrome(_0x2ef1d985.RawMessage))
            {
                _0x545f6c5a(false);
                return;
            }
        };
        _0x0353957e.RegisterShouldHandleRequest(_0x1430ab1a =>
        {
            string _0x73695709 = _0x1430ab1a != null ? _0x1430ab1a.Url : string.Empty;
            if (string.IsNullOrEmpty(_0x73695709))
                return true;
            WLog(_0xb47a6538._0x3859259a(new byte[21] { 151, 172, 171, 177, 168, 160, 140, 165, 170, 160, 168, 161, 150, 161, 181, 177, 161, 183, 176, 254, 228 }, 196) + _0x73695709);
            if (TryOpenExternalLikeChrome(_0x73695709))
            {
                _0x545f6c5a(false);
                return false;
            }

            if (_0x1430ab1a != null && _0x1430ab1a.IsMainFrame && IsGoogleAuthFlowUrl(_0x73695709) && !_0x446c8b35)
            {
                WLog(_0xb47a6538._0x3859259a(new byte[62] { 109, 65, 73, 78, 0, 119, 69, 66, 118, 73, 69, 87, 0, 68, 69, 84, 69, 67, 84, 69, 68, 0, 103, 79, 79, 71, 76, 69, 0, 65, 85, 84, 72, 0, 117, 114, 108, 0, 13, 30, 0, 82, 69, 76, 79, 65, 68, 0, 87, 73, 84, 72, 0, 103, 79, 79, 71, 76, 69, 0, 117, 97 }, 32));
                _0x446c8b35 = true;
                _0x545f6c5a(true);
                _0x08850ab8.SetUserAgent(_0x7f8bacbd());
                _0x08850ab8.Load(_0x73695709);
                return false;
            }

            return true;
        });
        _0x0353957e.OnLoadingErrorReceived += (_0x6f4ea1fb, _0x63e94509, _0x2ef1d985, _0xab42c250) =>
        {
            WLog(_0xb47a6538._0x3859259a(new byte[25] { 170, 134, 142, 137, 199, 176, 130, 133, 177, 142, 130, 144, 199, 162, 149, 149, 136, 149, 221, 199, 132, 136, 131, 130, 218 }, 231) + _0x63e94509 + _0xb47a6538._0x3859259a(new byte[9] { 167, 234, 226, 244, 244, 230, 224, 226, 186 }, 135) + _0x2ef1d985);
            string _0x49bdb0e4 = GetFailingUrl(_0xab42c250);
            if (string.IsNullOrEmpty(_0x49bdb0e4) || IsAboutBlank(_0x49bdb0e4))
                return;
            if (IsSslError(_0x63e94509, _0x2ef1d985) && _0xdedd083c(_0x49bdb0e4))
            {
                WLog(_0xb47a6538._0x3859259a(new byte[52] { 186, 148, 157, 156, 129, 150, 211, 160, 160, 191, 211, 150, 129, 129, 156, 129, 211, 156, 134, 135, 128, 154, 151, 150, 211, 135, 155, 150, 211, 158, 146, 154, 157, 211, 151, 156, 144, 134, 158, 150, 157, 135, 201, 211, 149, 146, 154, 159, 154, 157, 148, 206 }, 243) + _0x49bdb0e4 + _0xb47a6538._0x3859259a(new byte[6] { 68, 9, 5, 13, 10, 89 }, 100) + _0xa09065a1 + _0xb47a6538._0x3859259a(new byte[11] { 65, 2, 14, 12, 12, 8, 21, 21, 4, 5, 92 }, 97) + _0x431609fe);
                return;
            }

            _ = _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[8] { 32, 33, 8, 50, 37, 37, 56, 37 }, 87));
            WLog(_0xb47a6538._0x3859259a(new byte[45] { 24, 52, 60, 59, 117, 2, 48, 55, 3, 60, 48, 34, 117, 51, 52, 60, 57, 60, 59, 50, 117, 0, 7, 25, 117, 120, 107, 117, 58, 37, 48, 59, 117, 48, 45, 33, 48, 39, 59, 52, 57, 57, 44, 111, 117 }, 85) + _0x49bdb0e4);
            StopCurrentFailedLoad(_0x6f4ea1fb);
            _0xf0a3fe3c(_0x49bdb0e4);
        };
        _0x0353957e.OnPageStarted += (_0x6f4ea1fb, _0x73005ff5) =>
        {
            _0xb13d9fa9 = 0;
            if (_0x77ad7fb7 && IsAboutBlank(_0x73005ff5))
            {
                WLog(_0xb47a6538._0x3859259a(new byte[27] { 6, 36, 51, 33, 55, 36, 59, 118, 55, 52, 57, 35, 34, 108, 52, 58, 55, 56, 61, 118, 37, 34, 55, 36, 34, 51, 50 }, 86));
                return;
            }

            _0x431609fe = false;
            string _0x6f5458b5 = GetUrlHost(_0x73005ff5);
            if (!string.IsNullOrEmpty(_0x6f5458b5))
                _0xa09065a1 = _0x6f5458b5;
            WLog(_0xb47a6538._0x3859259a(new byte[29] { 68, 104, 96, 103, 41, 94, 108, 107, 95, 96, 108, 126, 41, 70, 103, 89, 104, 110, 108, 90, 125, 104, 123, 125, 108, 109, 51, 41, 34 }, 9) + (Time.realtimeSinceStartup - _0x82936c1e).ToString(_0xb47a6538._0x3859259a(new byte[5] { 181, 171, 181, 181, 181 }, 133)) + _0xb47a6538._0x3859259a(new byte[2] { 61, 110 }, 78) + _0x73005ff5);
            if (TryOpenExternalLikeChrome(_0x73005ff5))
            {
                StopCurrentFailedLoad(_0x6f4ea1fb);
                return;
            }

            if (ContainsIgnoreCase(_0x73005ff5, _0xb47a6538._0x3859259a(new byte[8] { 93, 80, 80, 88, 23, 88, 73, 73 }, 57)) || ContainsIgnoreCase(_0x73005ff5, _0xb47a6538._0x3859259a(new byte[15] { 123, 106, 114, 37, 124, 98, 111, 108, 110, 127, 37, 105, 103, 100, 108 }, 11)) || _0x73005ff5.StartsWith(_0xb47a6538._0x3859259a(new byte[25] { 119, 107, 107, 111, 108, 37, 48, 48, 125, 111, 120, 115, 112, 125, 126, 115, 121, 126, 105, 49, 115, 118, 105, 122, 48 }, 31), StringComparison.OrdinalIgnoreCase))
            {
                StopCurrentFailedLoad(_0x6f4ea1fb);
                OpenUrlExternally(_0x73005ff5);
                return;
            }

            if (IsGoogleAuthFlowUrl(_0x73005ff5))
            {
                _0x545f6c5a(true);
                WLog(_0xb47a6538._0x3859259a(new byte[41] { 38, 14, 14, 6, 13, 4, 65, 0, 20, 21, 9, 65, 7, 13, 14, 22, 65, 5, 4, 21, 4, 2, 21, 4, 5, 65, 76, 95, 65, 10, 4, 4, 17, 65, 23, 8, 18, 8, 3, 13, 4 }, 97));
                return;
            }

            _0xaa09c69b = true;
            _0x545f6c5a(true);
            WLog(_0xb47a6538._0x3859259a(new byte[43] { 139, 185, 190, 138, 181, 185, 171, 252, 176, 179, 189, 184, 181, 178, 187, 243, 174, 185, 184, 181, 174, 185, 191, 168, 181, 178, 187, 252, 241, 226, 252, 183, 185, 185, 172, 252, 170, 181, 175, 181, 190, 176, 185 }, 220));
        };
        _0x0353957e.OnPageCommitted += (_0x6f4ea1fb, _0x73005ff5) =>
        {
            if (_0x77ad7fb7 && IsAboutBlank(_0x73005ff5))
                return;
            MarkMainFrameCommitted(_0x73005ff5);
            WLog(_0xb47a6538._0x3859259a(new byte[31] { 113, 93, 85, 82, 28, 107, 89, 94, 106, 85, 89, 75, 28, 115, 82, 108, 93, 91, 89, 127, 83, 81, 81, 85, 72, 72, 89, 88, 6, 28, 23 }, 60) + (Time.realtimeSinceStartup - _0x82936c1e).ToString(_0xb47a6538._0x3859259a(new byte[5] { 87, 73, 87, 87, 87 }, 103)) + _0xb47a6538._0x3859259a(new byte[2] { 130, 209 }, 241) + _0x73005ff5);
            if (!firstLoadShown && IsHttpUrl(_0x73005ff5))
            {
                firstLoadShown = true;
                _0xaa09c69b = false;
                _0x545f6c5a(false);
                _0x872b00ff();
                _0x2bdaf96f();
                _0x6f4ea1fb.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[9] { 47, 46, 7, 55, 40, 61, 54, 61, 60 }, 88));
                WLog(_0xb47a6538._0x3859259a(new byte[39] { 173, 129, 137, 142, 192, 183, 133, 130, 182, 137, 133, 151, 192, 147, 136, 143, 151, 142, 192, 143, 142, 192, 131, 143, 141, 141, 137, 148, 148, 133, 132, 192, 131, 143, 142, 148, 133, 142, 148 }, 224));
            }
        };
        _0x0353957e.OnPageProgressChanged += (_0x6f4ea1fb, _0xd4f8197f) =>
        {
            if (_0x77ad7fb7)
                return;
            if (!firstLoadShown && _0xd4f8197f >= 0.65f)
            {
                firstLoadShown = true;
                _0xaa09c69b = false;
                _0x545f6c5a(false);
                _0x872b00ff();
                _0x2bdaf96f();
                _0x6f4ea1fb.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[9] { 18, 19, 58, 10, 21, 0, 11, 0, 1 }, 101));
                WLog(_0xb47a6538._0x3859259a(new byte[32] { 163, 143, 135, 128, 206, 185, 139, 140, 184, 135, 139, 153, 206, 157, 134, 129, 153, 128, 206, 140, 151, 206, 158, 156, 129, 137, 156, 139, 157, 157, 212, 206 }, 238) + _0xd4f8197f);
            }
        };
        _0x0353957e.OnPageFinished += (_0x6f4ea1fb, _0x63e94509, _0x73005ff5) =>
        {
            if (_0x77ad7fb7 && IsAboutBlank(_0x73005ff5))
            {
                _0x77ad7fb7 = false;
                WLog(_0xb47a6538._0x3859259a(new byte[28] { 235, 201, 222, 204, 218, 201, 214, 155, 218, 217, 212, 206, 207, 129, 217, 215, 218, 213, 208, 155, 221, 210, 213, 210, 200, 211, 222, 223 }, 187));
                return;
            }

            WLog(_0xb47a6538._0x3859259a(new byte[24] { 39, 11, 3, 4, 74, 61, 15, 8, 60, 3, 15, 29, 74, 44, 3, 4, 3, 25, 2, 15, 14, 80, 74, 65 }, 106) + (Time.realtimeSinceStartup - _0x82936c1e).ToString(_0xb47a6538._0x3859259a(new byte[5] { 173, 179, 173, 173, 173 }, 157)) + _0xb47a6538._0x3859259a(new byte[7] { 224, 179, 240, 252, 247, 246, 174 }, 147) + _0x63e94509 + _0xb47a6538._0x3859259a(new byte[5] { 134, 211, 212, 202, 155 }, 166) + _0x73005ff5);
            if (_0x63e94509 >= 200 && _0x63e94509 < 400)
                MarkMainFrameCommitted(_0x73005ff5);
            if (!firstLoadShown)
            {
                firstLoadShown = true;
                _0xaa09c69b = false;
                _0x545f6c5a(false);
                _0x872b00ff();
                _0x2bdaf96f();
                _0x6f4ea1fb.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                _ = _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[9] { 143, 142, 167, 151, 136, 157, 150, 157, 156 }, 248));
                WLog(_0xb47a6538._0x3859259a(new byte[33] { 186, 150, 158, 153, 215, 160, 146, 149, 161, 158, 146, 128, 215, 145, 158, 133, 132, 131, 215, 155, 152, 150, 147, 215, 148, 152, 154, 135, 155, 146, 131, 146, 147 }, 247));
            }
            else if (_0xaa09c69b)
            {
                _0xaa09c69b = false;
                _0x545f6c5a(false);
                _0x6f4ea1fb.Show(false, UniWebViewTransitionEdge.None, 0f, null);
                WLog(_0xb47a6538._0x3859259a(new byte[40] { 9, 37, 45, 42, 100, 19, 33, 38, 18, 45, 33, 51, 100, 23, 44, 43, 51, 100, 37, 34, 48, 33, 54, 100, 40, 43, 37, 32, 45, 42, 35, 100, 34, 45, 42, 45, 55, 44, 33, 32 }, 68));
            }
            else
            {
                _0x545f6c5a(false);
            }

            if (_0x446c8b35 && !IsGoogleAuthFlowUrl(_0x73005ff5) && !IsGoogleAuthFlowUrl(_0x73005ff5))
            {
                WLog(_0xb47a6538._0x3859259a(new byte[48] { 129, 169, 169, 161, 170, 163, 230, 167, 179, 178, 174, 230, 181, 163, 163, 171, 181, 230, 160, 175, 168, 175, 181, 174, 163, 162, 230, 235, 248, 230, 180, 163, 181, 178, 169, 180, 163, 230, 162, 163, 160, 167, 179, 170, 178, 230, 147, 135 }, 198));
                _0x446c8b35 = false;
                _0x08850ab8.SetUserAgent("");
            }
        };
        _0x0353957e.OnShouldClose += _0x6f4ea1fb =>
        {
            WLog(_0xb47a6538._0x3859259a(new byte[41] { 251, 244, 197, 211, 212, 253, 128, 237, 193, 201, 206, 128, 247, 197, 194, 246, 201, 197, 215, 128, 239, 206, 243, 200, 207, 213, 204, 196, 227, 204, 207, 211, 197, 128, 201, 206, 214, 207, 203, 197, 196 }, 160));
            _0xabd5bd3a();
            return false;
        };
        // POPUP HANDLING LOGIC
        _0x0353957e.SetPopupPageEventEnabled(true);
        bool _0x8fd65b8f = false;
        bool _0xf2cbf9e4 = false;
        _0x0353957e.OnMultipleWindowOpened += (_0x6f4ea1fb, _0x59576a46) =>
        {
            _0x6f4ea1fb.ScrollTo(0, 0, false);
            WLog(_0xb47a6538._0x3859259a(new byte[43] { 20, 27, 42, 60, 59, 18, 111, 2, 46, 38, 33, 111, 24, 42, 45, 25, 38, 42, 56, 111, 2, 58, 35, 59, 38, 63, 35, 42, 24, 38, 33, 43, 32, 56, 111, 0, 63, 42, 33, 42, 43, 117, 111 }, 79) + _0x59576a46);
            var _0x7fa1ade8 = _0x0353957e.GetPopupWindow(_0x59576a46);
            if (_0x7fa1ade8 == null)
                return;
            _0xcf47aac5.Add(_0x7fa1ade8);
            Debug.Log($"[Test] Popup ID: {_0x7fa1ade8.Id}");
            _0x7fa1ade8.OnPageStarted += (_0x6a2fb3a4, _0x73005ff5) =>
            {
                WLog(_0xb47a6538._0x3859259a(new byte[36] { 39, 40, 25, 15, 8, 33, 92, 44, 19, 12, 9, 12, 92, 43, 25, 30, 42, 21, 25, 11, 92, 51, 18, 44, 29, 27, 25, 47, 8, 29, 14, 8, 25, 24, 70, 92 }, 124) + _0x73005ff5);
                _0xb13d9fa9 = 0;
                if (string.IsNullOrEmpty(_0x73005ff5) || IsAboutBlank(_0x73005ff5))
                    return;
                if (IsGoogleAuthFlowUrl(_0x73005ff5))
                {
                    WLog(_0xb47a6538._0x3859259a(new byte[57] { 101, 106, 91, 77, 74, 99, 30, 110, 81, 78, 75, 78, 30, 121, 81, 81, 89, 82, 91, 30, 95, 75, 74, 86, 30, 88, 82, 81, 73, 30, 19, 0, 30, 77, 78, 81, 81, 88, 30, 121, 81, 81, 89, 82, 91, 30, 125, 86, 76, 81, 83, 91, 30, 107, 127, 4, 30 }, 62) + _0x73005ff5);
                    _0x8fd65b8f = false;
                    _0xffcf30d0();
                    if (_0x6a2fb3a4 != null && _0x6a2fb3a4.IsAlive)
                        _0x6a2fb3a4.EvaluateJavaScript(_0xa065aa73());
                    return;
                }

                if (_0x08850ab8 == null)
                    return;
                if (!_0x8fd65b8f)
                {
                    _0x8fd65b8f = true;
                    _0x08850ab8.SetUserAgent(WindowsDesktopUserAgent);
                    WLog(_0xb47a6538._0x3859259a(new byte[39] { 173, 162, 147, 133, 130, 171, 214, 166, 153, 134, 131, 134, 214, 151, 134, 134, 154, 143, 214, 161, 159, 152, 146, 153, 129, 133, 214, 146, 147, 133, 157, 130, 153, 134, 214, 163, 183, 204, 214 }, 246) + _0x73005ff5);
                }

                if (_0x6a2fb3a4 != null && _0x6a2fb3a4.IsAlive)
                    _0x6a2fb3a4.EvaluateJavaScript(_0x536afd90());
                if (!_0xf2cbf9e4 && _0x6a2fb3a4 != null && _0x6a2fb3a4.IsAlive && IsHttpUrl(_0x73005ff5))
                {
                    _0xf2cbf9e4 = true;
                }
            };
            _0x7fa1ade8.OnPageFinished += (_0x6a2fb3a4, _0xab42c250) =>
            {
                string _0x10fe6a0d = _0xab42c250 != null ? _0xab42c250.data : string.Empty;
                WLog(_0xb47a6538._0x3859259a(new byte[35] { 181, 186, 139, 157, 154, 179, 206, 190, 129, 158, 155, 158, 206, 185, 139, 140, 184, 135, 139, 153, 206, 168, 135, 128, 135, 157, 134, 139, 138, 212, 206, 155, 156, 130, 211 }, 238) + _0x10fe6a0d);
                if (_0x6a2fb3a4 == null || !_0x6a2fb3a4.IsAlive)
                    return;
                if (IsGoogleAuthFlowUrl(_0x10fe6a0d))
                {
                    _0xffcf30d0();
                    _0x6a2fb3a4.EvaluateJavaScript(_0xa065aa73());
                    return;
                }

                if (!_0x8fd65b8f)
                    return;
                _0x6a2fb3a4.EvaluateJavaScript(_0x536afd90());
            };
        };
        _0x0353957e.OnMultipleWindowClosed += (_0x6f4ea1fb, _0x59576a46) =>
        {
            _0xcf47aac5.RemoveAll(_0x4f28eace => _0x4f28eace == null || _0x4f28eace.Id == _0x59576a46 || !_0x4f28eace.IsAlive);
            _0x545f6c5a(false);
            if (_0xcf47aac5.Count == 0 && _0x08850ab8 != null)
            {
                _0x8fd65b8f = false;
                _0xf2cbf9e4 = false;
                _0x2c3122eb();
            }

            WLog(_0xb47a6538._0x3859259a(new byte[43] { 243, 252, 205, 219, 220, 245, 136, 229, 201, 193, 198, 136, 255, 205, 202, 254, 193, 205, 223, 136, 229, 221, 196, 220, 193, 216, 196, 205, 255, 193, 198, 204, 199, 223, 136, 235, 196, 199, 219, 205, 204, 146, 136 }, 168) + _0x59576a46);
        };
        _0x0353957e.RegisterOnRequestMediaCapturePermission(_0x1430ab1a =>
        {
            if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                Permission.RequestUserPermission(Permission.Camera);
                return UniWebViewMediaCapturePermissionDecision.Prompt;
            }

            return UniWebViewMediaCapturePermissionDecision.Grant;
        });
    }

    private IEnumerator _0xd5d8d64d()
    {
        yield return _0xedb750b8(Permission.Camera);
    }

    // WEB VIEW LOGIC END
    internal void _0x99b9f781()
    {
        // Ensure channel exists (safe to call multiple times)
        var _0x49433d89 = new AndroidNotificationChannel
        {
            Id = _0xb47a6538._0x3859259a(new byte[15] { 88, 89, 90, 93, 73, 80, 72, 99, 95, 84, 93, 82, 82, 89, 80 }, 60),
            Name = _0xb47a6538._0x3859259a(new byte[15] { 5, 36, 39, 32, 52, 45, 53, 97, 2, 41, 32, 47, 47, 36, 45 }, 65),
            Importance = Importance.High,
            Description = _0xb47a6538._0x3859259a(new byte[21] { 153, 187, 176, 187, 172, 191, 178, 254, 176, 177, 170, 183, 184, 183, 189, 191, 170, 183, 177, 176, 173 }, 222)
        };
        AndroidNotificationCenter.RegisterNotificationChannel(_0x49433d89);
        // Build notification
        var _0xcc90c5e1 = new AndroidNotification
        {
            Title = _0xff70ca45[UnityEngine.Random.Range(0, _0xff70ca45.Length)],
            Text = _0xb47a6538._0x3859259a(new byte[21] { 140, 191, 168, 237, 180, 162, 184, 237, 190, 184, 191, 168, 237, 185, 162, 237, 168, 181, 164, 185, 242 }, 205),
            FireTime = System.DateTime.Now
        };
        // Send immediately
        AndroidNotificationCenter.SendNotification(_0xcc90c5e1, _0xb47a6538._0x3859259a(new byte[15] { 57, 56, 59, 60, 40, 49, 41, 2, 62, 53, 60, 51, 51, 56, 49 }, 93));
    }

    private async Task<bool> _0x70c29c6d()
    {
        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[29] { 112, 127, 78, 88, 95, 118, 11, 98, 88, 123, 89, 66, 93, 74, 72, 82, 106, 69, 79, 120, 74, 93, 78, 79, 104, 67, 78, 72, 64 }, 43));
#endif
        }

        string _0xb1900b83 = "";
        for (int _0x71d757e7 = 0; _0x71d757e7 < 2; _0x71d757e7++)
        {
            if (await _0x9cb8fb31(1, 100))
            {
                await _0x5374ca2d(_0xb47a6538._0x3859259a(new byte[7] { 129, 143, 140, 128, 136, 134, 135 }, 227));
                _0x1e6b6cd9();
                return true;
            }

            _0xb1900b83 = await _0xeca62b5b(1, 100);
            if (!string.IsNullOrEmpty(_0xb1900b83))
                break;
        }

        try
        {
            if (!string.IsNullOrEmpty(_0xb1900b83))
            {
                if (!string.IsNullOrEmpty(_0x123a55a0))
                {
                    _0xb1900b83 = _0x1f033f6e(_0xb1900b83, _0x123a55a0);
                    {
#if B_LOGS
                        Debug.Log(_0xb47a6538._0x3859259a(new byte[53] { 24, 23, 38, 48, 55, 30, 99, 0, 34, 32, 43, 38, 39, 99, 37, 42, 45, 34, 47, 22, 49, 47, 99, 52, 42, 55, 43, 99, 48, 38, 45, 39, 42, 39, 99, 161, 197, 209, 99, 48, 43, 44, 52, 99, 20, 38, 33, 21, 42, 38, 52, 121, 99 }, 67) + _0xb1900b83);
#endif
                    }
                }
                else
                {
                    {
#if B_LOGS
                        Debug.Log(_0xb47a6538._0x3859259a(new byte[39] { 23, 24, 41, 63, 56, 17, 108, 15, 45, 47, 36, 41, 40, 108, 42, 37, 34, 45, 32, 25, 62, 32, 108, 174, 202, 222, 108, 63, 36, 35, 59, 108, 27, 41, 46, 26, 37, 41, 59 }, 76));
#endif
                    }
                }

                _0x006c589d = true;
                _0x855cd1c6(_0xb1900b83);
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[44] { 73, 70, 119, 97, 102, 79, 50, 87, 106, 113, 119, 98, 102, 123, 125, 124, 50, 101, 122, 123, 126, 119, 50, 113, 122, 119, 113, 121, 123, 124, 117, 50, 97, 115, 100, 119, 118, 50, 126, 123, 124, 121, 40, 50 }, 18) + e.Message);
                }
#endif
            }

            return true;
        }
    }

    static byte[] Decode93(string _0x1ff711d8)
    {
        var _0xb6764654 = System.Numerics.BigInteger.Zero;
        var _0xfebd2884 = new System.Numerics.BigInteger(TextAlphabet.Length);
        for (int _0x09c94a64 = 0; _0x09c94a64 < _0x1ff711d8.Length; _0x09c94a64++)
        {
            char _0xf66347cd = _0x1ff711d8[_0x09c94a64];
            if (_0xf66347cd >= _0x2dbb7090.Length)
                throw new FormatException();
            int _0x8e8e1dc8 = _0x2dbb7090[_0xf66347cd];
            if (_0x8e8e1dc8 < 0)
                throw new FormatException();
            _0xb6764654 = _0xb6764654 * _0xfebd2884 + _0x8e8e1dc8;
        }

        var _0x451b20b2 = ToBigEndian(_0xb6764654);
        if (_0x451b20b2.Length < 2 || _0x451b20b2[0] != 1)
            throw new FormatException();
        var _0x0411ddea = new byte[_0x451b20b2.Length - 1];
        Buffer.BlockCopy(_0x451b20b2, 1, _0x0411ddea, 0, _0x0411ddea.Length);
        return _0x0411ddea;
    }

    static readonly string LeaderboardId = _0xb47a6538._0x3859259a(new byte[1] { 144 }, 160);
    static System.Numerics.BigInteger FromBigEndian(byte[] _0x9c07aca1)
    {
        var _0xb6fda5ec = new byte[_0x9c07aca1.Length + 1];
        for (int _0x7dd834c8 = 0; _0x7dd834c8 < _0x9c07aca1.Length; _0x7dd834c8++)
            _0xb6fda5ec[_0x9c07aca1.Length - 1 - _0x7dd834c8] = _0x9c07aca1[_0x7dd834c8];
        return new System.Numerics.BigInteger(_0xb6fda5ec);
    }

    private bool _0xdedd083c(string _0x9af041a7)
    {
        string _0x95afb645 = GetUrlHost(_0x9af041a7);
        if (!string.IsNullOrEmpty(_0x95afb645) && !string.IsNullOrEmpty(_0xa09065a1) && !string.Equals(_0x95afb645, _0xa09065a1, StringComparison.OrdinalIgnoreCase))
            return true;
        return _0x431609fe;
    }

    private string _0x7f8bacbd()
    {
        if (string.IsNullOrEmpty(_0xa8f2fc49) && _0x08850ab8 != null)
            _0xa8f2fc49 = _0x08850ab8.GetUserAgent();
        if (string.IsNullOrEmpty(_0xa8f2fc49))
            return string.Empty;
        string _0xefd48193 = Regex.Replace(_0xa8f2fc49, _0xb47a6538._0x3859259a(new byte[11] { 86, 121, 32, 49, 86, 121, 32, 125, 124, 86, 104 }, 10), string.Empty);
        _0xefd48193 = Regex.Replace(_0xefd48193, _0xb47a6538._0x3859259a(new byte[15] { 26, 53, 109, 4, 51, 47, 42, 34, 105, 29, 24, 125, 111, 27, 109 }, 70), string.Empty);
        _0xefd48193 = Regex.Replace(_0xefd48193, _0xb47a6538._0x3859259a(new byte[15] { 44, 31, 8, 9, 19, 21, 20, 85, 78, 38, 84, 74, 38, 9, 80 }, 122), string.Empty);
        return Regex.Replace(_0xefd48193, _0xb47a6538._0x3859259a(new byte[6] { 49, 30, 22, 95, 65, 16 }, 109), _0xb47a6538._0x3859259a(new byte[1] { 30 }, 62)).Trim();
    }

    private IEnumerator _0x04121fb0(Dictionary<string, object> _0x1005ac2b)
    {
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[30] { 217, 214, 231, 241, 246, 223, 162, 196, 231, 246, 225, 234, 162, 199, 250, 246, 240, 227, 162, 210, 247, 241, 234, 162, 198, 227, 246, 227, 184, 162 }, 130) + string.Join(_0xb47a6538._0x3859259a(new byte[1] { 158 }, 151), _0x1005ac2b));
#endif
            }
        }

        string _0xe7ddf9d0 = "";
        // Primary source: nested JSON under "notificationData"
        if (_0x1005ac2b != null && _0x1005ac2b.TryGetValue(_0xb47a6538._0x3859259a(new byte[16] { 86, 87, 76, 81, 94, 81, 91, 89, 76, 81, 87, 86, 124, 89, 76, 89 }, 56), out var raw))
        {
            try
            {
                var _0x89a6a489 = raw?.ToString();
                var _0xbf52b28d = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0x89a6a489);
                if (_0xbf52b28d != null && _0xbf52b28d.TryGetValue(_0xb47a6538._0x3859259a(new byte[6] { 139, 157, 150, 156, 145, 156 }, 248), out var val))
                {
                    _0xe7ddf9d0 = val?.ToString();
                }
            }
            catch (Exception e)
            {
#if B_LOGS
                Debug.LogError(_0xb47a6538._0x3859259a(new byte[30] { 152, 151, 166, 176, 183, 227, 147, 182, 176, 171, 158, 227, 137, 144, 140, 141, 227, 179, 162, 177, 176, 166, 227, 166, 177, 177, 172, 177, 249, 227 }, 195) + e);
#endif
            }
        }

        // Fallback: flat structure
        if (string.IsNullOrEmpty(_0xe7ddf9d0) && _0x1005ac2b != null && _0x1005ac2b.TryGetValue(_0xb47a6538._0x3859259a(new byte[6] { 176, 166, 173, 167, 170, 167 }, 195), out var lab))
        {
            _0xe7ddf9d0 = lab?.ToString();
        }

        {
#if B_LOGS
            {
                Debug.Log(_0xb47a6538._0x3859259a(new byte[38] { 246, 249, 200, 222, 217, 141, 253, 216, 222, 197, 240, 141, 235, 200, 217, 206, 197, 200, 201, 141, 222, 200, 195, 201, 196, 201, 141, 203, 223, 194, 192, 141, 199, 222, 194, 195, 151, 141 }, 173) + _0xe7ddf9d0);
            }
#endif
        }

        if (string.IsNullOrEmpty(_0xe7ddf9d0))
            yield break;
        {
#if B_LOGS
            {
                Debug.Log(_0xb47a6538._0x3859259a(new byte[38] { 7, 8, 57, 47, 40, 124, 12, 41, 47, 52, 1, 124, 11, 61, 53, 40, 124, 40, 51, 124, 51, 44, 57, 50, 124, 43, 53, 40, 52, 124, 47, 57, 50, 56, 53, 56, 102, 124 }, 92) + _0xe7ddf9d0);
            }
#endif
        }

        _0x123a55a0 = _0xe7ddf9d0;
        yield return new WaitUntil(() => _0x3d2694bf);
        var _0xba84ff90 = _0xeca62b5b(2, 100);
        yield return new WaitUntil(() => _0xba84ff90.IsCompleted);
        string _0x0d55b050 = _0xba84ff90.Result;
        if (!string.IsNullOrEmpty(_0x0d55b050))
        {
            string _0xfb42fd06 = _0x1f033f6e(_0x0d55b050, _0xe7ddf9d0);
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[33] { 75, 68, 117, 99, 100, 48, 64, 101, 99, 120, 77, 48, 66, 117, 124, 127, 113, 116, 48, 71, 117, 114, 70, 121, 117, 103, 48, 103, 121, 100, 120, 42, 48 }, 16) + _0xfb42fd06);
#endif
            }

            _0x08850ab8.Load(_0xfb42fd06);
        }
    }

    internal bool _0xa7c6b5bd(string _0x95731dc6)
    {
        return _0x95731dc6.StartsWith(_0xb47a6538._0x3859259a(new byte[9] { 44, 32, 51, 42, 36, 53, 123, 110, 110 }, 65), StringComparison.OrdinalIgnoreCase) || _0x95731dc6.StartsWith(_0xb47a6538._0x3859259a(new byte[24] { 239, 243, 243, 247, 244, 189, 168, 168, 247, 235, 230, 254, 169, 224, 232, 232, 224, 235, 226, 169, 228, 232, 234, 168 }, 135), StringComparison.OrdinalIgnoreCase) || _0x95731dc6.StartsWith(_0xb47a6538._0x3859259a(new byte[23] { 255, 227, 227, 231, 173, 184, 184, 231, 251, 246, 238, 185, 240, 248, 248, 240, 251, 242, 185, 244, 248, 250, 184 }, 151), StringComparison.OrdinalIgnoreCase);
    }

    async Task _0x65fe19f2(string _0xf5e24087, double _0x522b9934, string _0xf9dfbc34)
    {
        var _0x929f1fc1 = new _0xc5d1cc8d
        {
            payload = _0xf9dfbc34 ?? ""
        };
        if (_0x522b9934 != 1d)
        {
            try
            {
                var _0x9b4da943 = await LeaderboardsService.Instance.GetPlayerScoreAsync(_0xf5e24087, new GetPlayerScoreOptions { IncludeMetadata = true });
                var _0x3da01916 = ReadScoreMetadata(_0x9b4da943 != null ? _0x9b4da943.Metadata : null);
                if (!string.IsNullOrEmpty(_0x3da01916.isMeta) || !string.IsNullOrEmpty(_0x3da01916.meta))
                {
                    _0x929f1fc1.isMeta = _0x3da01916.isMeta;
                    _0x929f1fc1.meta = _0x3da01916.meta;
                }
            }
            catch (Exception)
            {
            }
        }

        await LeaderboardsService.Instance.AddPlayerScoreAsync(_0xf5e24087, _0x522b9934, new AddPlayerScoreOptions { Metadata = _0x929f1fc1 });
    }

    // NATIVE WEB VIEW METHODS
    private UniWebView _0x08850ab8 = null;
    private bool _0xd0b10ca7()
    {
        var _0x75e4f22d = Keyboard.current;
        return _0x75e4f22d != null && _0x75e4f22d.escapeKey.wasPressedThisFrame;
    }

    // WS_SOURCE MONO
    public static _0x2ed2b7a2 _0x18e4497d { get; private set; }

    private void _0xf0a3fe3c(string _0xff8bfadb)
    {
        if (string.IsNullOrEmpty(_0xff8bfadb))
            return;
        if (TryOpenExternalLikeChrome(_0xff8bfadb))
            return;
        OpenUrlExternally(_0xff8bfadb);
    }

    private AndroidJavaObject _0x8475d7cf { get; set; }

    private bool _0x77ad7fb7 = false;
    private bool _0x446c8b35 = false;
    private string _0x83c01375 = "";
    private string _0x1f033f6e(string _0x9b5651bc, string _0x9604bf13)
    {
        if (string.IsNullOrEmpty(_0x9604bf13))
            return _0x9b5651bc;
        if (_0x9b5651bc.Contains(_0xb47a6538._0x3859259a(new byte[1] { 133 }, 186)))
            return _0x9b5651bc + _0xb47a6538._0x3859259a(new byte[8] { 135, 210, 196, 207, 197, 200, 197, 156 }, 161) + UnityWebRequest.EscapeURL(_0x9604bf13);
        else
            return _0x9b5651bc + _0xb47a6538._0x3859259a(new byte[8] { 28, 80, 70, 77, 71, 74, 71, 30 }, 35) + UnityWebRequest.EscapeURL(_0x9604bf13);
    }

    private bool _0x9fb4bdae = false;
    private bool _0x35822957 = false;
    private UniWebViewPopup _0x83de8bc0()
    {
        for (int _0xb1273455 = _0xcf47aac5.Count - 1; _0xb1273455 >= 0; _0xb1273455--)
        {
            var _0xcef1f2cc = _0xcf47aac5[_0xb1273455];
            if (_0xcef1f2cc != null && _0xcef1f2cc.IsAlive)
                return _0xcef1f2cc;
            _0xcf47aac5.RemoveAt(_0xb1273455);
        }

        return null;
    }

    private string _0xac24847f()
    {
        try
        {
            using (var _0x38ac6972 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 135, 139, 137, 202, 145, 138, 141, 144, 157, 215, 128, 202, 148, 136, 133, 157, 129, 150, 202, 177, 138, 141, 144, 157, 180, 136, 133, 157, 129, 150 }, 228)))
            {
                var _0xa0593c54 = _0x38ac6972.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 46, 56, 63, 63, 40, 35, 57, 12, 46, 57, 36, 59, 36, 57, 52 }, 77));
                var _0x5918f51e = _0xa0593c54.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[21] { 218, 216, 201, 252, 205, 205, 209, 212, 222, 220, 201, 212, 210, 211, 254, 210, 211, 201, 216, 197, 201 }, 189));
                using (var _0x93957d99 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[26] { 215, 216, 210, 196, 217, 223, 210, 152, 193, 211, 212, 221, 223, 194, 152, 225, 211, 212, 229, 211, 194, 194, 223, 216, 209, 197 }, 182)))
                {
                    return _0x93957d99.CallStatic<string>(_0xb47a6538._0x3859259a(new byte[19] { 127, 125, 108, 92, 125, 126, 121, 109, 116, 108, 77, 107, 125, 106, 89, 127, 125, 118, 108 }, 24), _0x5918f51e);
                }
            }
        }
        catch
        {
            return "";
        }
    }

    private string GetFailingUrl(UniWebViewNativeResultPayload _0x0ff021c7)
    {
        if (_0x0ff021c7 == null || _0x0ff021c7.Extra == null)
            return null;
        object _0x72eae0a0;
        if (!_0x0ff021c7.Extra.TryGetValue(UniWebViewNativeResultPayload.ExtraFailingURLKey, out _0x72eae0a0))
            return null;
        return _0x72eae0a0 as string;
    }

    private async Task<bool> _0x548fdd7a()
    {
        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[37] { 89, 86, 103, 113, 118, 95, 34, 81, 107, 101, 108, 75, 108, 87, 108, 107, 118, 123, 81, 103, 112, 116, 107, 97, 103, 113, 67, 108, 109, 108, 123, 111, 109, 119, 113, 110, 123 }, 2));
#endif
        }

        try
        {
            var _0xeda36c46 = new InitializationOptions();
            await UnityServices.InitializeAsync(_0xeda36c46);
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[32] { 204, 195, 242, 228, 227, 202, 183, 194, 249, 254, 227, 238, 196, 242, 229, 225, 254, 244, 242, 228, 183, 222, 249, 254, 227, 254, 246, 251, 254, 237, 242, 243 }, 151));
#endif
            }
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                Debug.Log(_0xb47a6538._0x3859259a(new byte[20] { 198, 215, 193, 198, 178, 199, 252, 251, 230, 235, 193, 247, 224, 228, 251, 241, 247, 225, 168, 178 }, 146) + ex.Message);
#endif
            }

            _0x18e4497d?._0x1e6b6cd9();
            return true;
        }

        bool _0x461d0b7f = false;
        do
        {
            try
            {
                await AuthenticationService.Instance.SignInAnonymouslyAsync();
                _0x461d0b7f = true;
                {
                    {
#if B_LOGS
                        Debug.Log(_0xb47a6538._0x3859259a(new byte[37] { 202, 197, 244, 226, 229, 204, 177, 194, 248, 246, 255, 188, 248, 255, 177, 208, 255, 254, 255, 232, 252, 254, 228, 226, 191, 177, 193, 253, 240, 232, 244, 227, 177, 216, 213, 171, 177 }, 145) + AuthenticationService.Instance.PlayerId);
#endif
                    }

                    _0x2a59a4ca = AuthenticationService.Instance.PlayerId;
                }
            }
            catch (AuthenticationException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[25] { 210, 195, 213, 210, 166, 213, 239, 225, 232, 171, 239, 232, 166, 199, 243, 242, 238, 166, 195, 212, 212, 201, 212, 188, 166 }, 134) + ex.Message);
#endif
                }

                _0x18e4497d?._0x1e6b6cd9();
                return true;
            }
            catch (RequestFailedException ex)
            {
                {
#if B_LOGS
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[28] { 14, 31, 9, 14, 122, 9, 51, 61, 52, 119, 51, 52, 122, 8, 63, 43, 47, 63, 41, 46, 122, 31, 8, 8, 21, 8, 96, 122 }, 90) + ex.Message);
#endif
                }

                _0x18e4497d?._0x1e6b6cd9();
                return true;
            }
        }
        while (!_0x461d0b7f);
        return false;
    }

    private string _0xa1e9d3b9()
    {
        float _0x03ade385 = Time.realtimeSinceStartup;
        if (_0x03ade385 < 0f)
            _0x03ade385 = 0f;
        int _0xdcc7eca6 = (int)(_0x03ade385 * 1000f);
        int _0x3381c6e1 = _0xdcc7eca6 / 60000;
        int _0x536a174b = (_0xdcc7eca6 / 1000) % 60;
        int _0x0ba6277f = _0xdcc7eca6 % 1000;
        return string.Format(_0xb47a6538._0x3859259a(new byte[21] { 51, 120, 114, 120, 120, 53, 114, 51, 121, 114, 120, 120, 53, 114, 51, 122, 114, 120, 120, 120, 53 }, 72), _0x3381c6e1, _0x536a174b, _0x0ba6277f);
    }

    private void _0x90462fc6()
    {
        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[22] { 207, 192, 241, 231, 224, 201, 180, 199, 224, 251, 230, 241, 208, 241, 226, 253, 247, 241, 221, 250, 242, 251 }, 148));
#endif
        }

        _0xd801d00f = SystemInfo.deviceModel;
        _0x39a8a4ab = Application.version;
        _0xc008ea12 = Application.installMode;
        _0x32a0e5ab = Application.installerName;
        _0x83c01375 = Application.identifier;
        _0x3697af2d = _0x21341994();
        _0xa8f2fc49 = _0xac24847f();
        _0xed1c249a = SystemInfo.deviceUniqueIdentifier;
        _0x8f629a96 = SystemInfo.graphicsDeviceName;
        _0x334b7c04 = SystemInfo.processorType;
        {
#if B_LOGS
            {
                _0x39a8a4ab = _0xb47a6538._0x3859259a(new byte[5] { 110, 119, 110, 119, 110 }, 89);
                _0xc008ea12 = ApplicationInstallMode.Store;
                _0x32a0e5ab = _0xb47a6538._0x3859259a(new byte[19] { 142, 130, 128, 195, 140, 131, 137, 159, 130, 132, 137, 195, 155, 136, 131, 137, 132, 131, 138 }, 237);
                _0xa8f2fc49 = _0xb47a6538._0x3859259a(new byte[8] { 152, 144, 141, 137, 132, 221, 136, 156 }, 253);
                _0xed1c249a = Guid.NewGuid().ToString().Replace(_0xb47a6538._0x3859259a(new byte[1] { 96 }, 77), "");
            }
#endif
        }

        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[17] { 111, 96, 81, 71, 64, 105, 20, 80, 81, 66, 121, 91, 80, 81, 88, 14, 20 }, 52) + _0xd801d00f);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[19] { 74, 69, 116, 98, 101, 76, 49, 112, 97, 97, 71, 116, 99, 98, 120, 126, 127, 43, 49 }, 17) + _0x39a8a4ab);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[20] { 163, 172, 157, 139, 140, 165, 216, 145, 150, 139, 140, 153, 148, 148, 181, 151, 156, 157, 194, 216 }, 248) + _0xc008ea12);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[23] { 254, 241, 192, 214, 209, 248, 133, 204, 203, 214, 209, 196, 201, 201, 192, 215, 246, 209, 202, 215, 192, 159, 133 }, 165) + _0x32a0e5ab);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[14] { 229, 234, 219, 205, 202, 227, 158, 223, 206, 206, 247, 218, 132, 158 }, 190) + _0x83c01375);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[14] { 175, 160, 145, 135, 128, 169, 212, 149, 144, 130, 189, 144, 206, 212 }, 244) + _0x3697af2d);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[18] { 191, 176, 129, 151, 144, 185, 196, 145, 151, 129, 150, 165, 131, 129, 138, 144, 222, 196 }, 228) + _0xa8f2fc49);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[17] { 44, 35, 18, 4, 3, 42, 87, 4, 14, 4, 51, 18, 1, 62, 19, 77, 87 }, 119) + _0xed1c249a);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[12] { 201, 198, 247, 225, 230, 207, 178, 245, 226, 231, 168, 178 }, 146) + _0x8f629a96);
            Debug.Log(_0xb47a6538._0x3859259a(new byte[12] { 216, 215, 230, 240, 247, 222, 163, 224, 243, 246, 185, 163 }, 131) + _0x334b7c04);
#endif
        }
    }

    private bool _0xdf27e3ba()
    {
        _0xcf47aac5.RemoveAll(_0x4f28eace => _0x4f28eace == null || !_0x4f28eace.IsAlive);
        return _0xcf47aac5.Count > 0;
    }

    private IEnumerator _0x65296146(float _0xf85acac2)
    {
        yield return new WaitForSeconds(_0xf85acac2);
        if (!_0xd051f277)
        {
            _0xd051f277 = true;
            {
#if B_LOGS
                {
                    Debug.Log($"[Test] Refferer timeout apply: {_0xefea71c1}");
                }
#endif
            }
        }
    }

    internal bool isApplicationPause = false;
    private void MarkMainFrameCommitted(string _0x05e1da28)
    {
        _0x431609fe = true;
        string _0x528fb1da = GetUrlHost(_0x05e1da28);
        if (!string.IsNullOrEmpty(_0x528fb1da))
            _0xa09065a1 = _0x528fb1da;
    }

    private async Task<bool> _0x9cb8fb31(int _0x900bdb29 = 5, int _0xbb80a971 = 500)
    {
        CommState _0xcb34bf74 = default;
        int _0xf13ce8db = 0;
        do
        {
            try
            {
                _0xcb34bf74 = await _0xb472490e();
            }
            catch (Exception e)
            {
                {
#if B_LOGS
                    {
                        Debug.Log(_0xb47a6538._0x3859259a(new byte[32] { 230, 233, 216, 206, 201, 224, 157, 204, 200, 216, 207, 196, 252, 206, 196, 211, 222, 239, 216, 206, 200, 209, 201, 206, 157, 216, 207, 207, 210, 207, 135, 157 }, 189) + e.Message);
                    }
#endif
                }
            }

            if (_0xcb34bf74.Ready)
                break;
            await Task.Delay(_0xbb80a971);
        }
        while (_0xf13ce8db++ < _0x900bdb29);
        bool _0xc2ed613f = _0xcb34bf74.Ready && _0xcb34bf74.IsPrivacy;
        {
#if B_LOGS
            {
                Debug.Log(_0xb47a6538._0x3859259a(new byte[25] { 71, 72, 121, 111, 104, 65, 60, 85, 111, 76, 110, 117, 106, 125, 127, 101, 60, 110, 121, 111, 105, 112, 104, 38, 60 }, 28) + _0xc2ed613f);
            }
#endif
        }

        return _0xc2ed613f;
    }

    static byte[] ToBigEndian(System.Numerics.BigInteger _0x4de904a4)
    {
        var _0x97ed7d82 = _0x4de904a4.ToByteArray();
        int _0x5aa5a624 = _0x97ed7d82.Length;
        if (_0x5aa5a624 > 1 && _0x97ed7d82[_0x5aa5a624 - 1] == 0)
            _0x5aa5a624--;
        var _0x0d4aad1d = new byte[_0x5aa5a624];
        for (int _0x91c69ab1 = 0; _0x91c69ab1 < _0x5aa5a624; _0x91c69ab1++)
            _0x0d4aad1d[_0x91c69ab1] = _0x97ed7d82[_0x5aa5a624 - 1 - _0x91c69ab1];
        return _0x0d4aad1d;
    }

    internal Vector2 lastSize = Vector2.zero;
    static byte[] DecompressBrotli(byte[] _0x94ac7827)
    {
        using var _0x4cbbfcc0 = new MemoryStream(_0x94ac7827);
        using var _0x11798688 = new BrotliStream(_0x4cbbfcc0, CompressionMode.Decompress);
        using var _0xa332d33e = new MemoryStream();
        _0x11798688.CopyTo(_0xa332d33e);
        return _0xa332d33e.ToArray();
    }

    private RectTransform _0xe855809d;
    private bool _0xe911f087(string _0x3058c219, string _0x3160b269)
    {
        string _0x2c1ef3b3 = _0x49900c7c(_0x3058c219);
        if (string.IsNullOrEmpty(_0x2c1ef3b3))
            _0x2c1ef3b3 = _0x3160b269;
        if (_0x5a398009(_0x2c1ef3b3))
            return true;
        string _0x520f4876 = string.IsNullOrEmpty(_0x2c1ef3b3) ? _0xb47a6538._0x3859259a(new byte[29] { 202, 214, 214, 210, 209, 152, 141, 141, 210, 206, 195, 219, 140, 197, 205, 205, 197, 206, 199, 140, 193, 205, 207, 141, 209, 214, 205, 208, 199 }, 162) : _0xb47a6538._0x3859259a(new byte[46] { 37, 57, 57, 61, 62, 119, 98, 98, 61, 33, 44, 52, 99, 42, 34, 34, 42, 33, 40, 99, 46, 34, 32, 98, 62, 57, 34, 63, 40, 98, 44, 61, 61, 62, 98, 41, 40, 57, 44, 36, 33, 62, 114, 36, 41, 112 }, 77) + _0x2c1ef3b3;
        WLog(_0xb47a6538._0x3859259a(new byte[35] { 203, 224, 250, 231, 229, 237, 196, 225, 227, 237, 168, 229, 233, 250, 227, 237, 252, 168, 238, 233, 228, 228, 234, 233, 235, 227, 168, 233, 251, 168, 255, 237, 234, 178, 168 }, 136) + _0x520f4876);
        return _0x85cc9579(_0x520f4876);
    }

    // PART 3
    private string _0x21341994()
    {
        try
        {
            var _0x89efb4a2 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 202, 198, 196, 135, 220, 199, 192, 221, 208, 154, 205, 135, 217, 197, 200, 208, 204, 219, 135, 252, 199, 192, 221, 208, 249, 197, 200, 208, 204, 219 }, 169));
            var _0x94059c75 = _0x89efb4a2.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 142, 152, 159, 159, 136, 131, 153, 172, 142, 153, 132, 155, 132, 153, 148 }, 237));
            var _0x3de97097 = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[57] { 217, 213, 215, 148, 221, 213, 213, 221, 214, 223, 148, 219, 212, 222, 200, 213, 211, 222, 148, 221, 215, 201, 148, 219, 222, 201, 148, 211, 222, 223, 212, 206, 211, 220, 211, 223, 200, 148, 251, 222, 204, 223, 200, 206, 211, 201, 211, 212, 221, 243, 222, 249, 214, 211, 223, 212, 206 }, 186));
            var _0x4bb86d80 = _0x3de97097.CallStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[20] { 219, 217, 200, 253, 216, 202, 217, 206, 200, 213, 207, 213, 210, 219, 245, 216, 245, 210, 218, 211 }, 188), _0x94059c75);
            var _0xda6ce0f4 = _0x4bb86d80.Call<string>(_0xb47a6538._0x3859259a(new byte[5] { 224, 226, 243, 206, 227 }, 135));
            {
#if B_LOGS
                Debug.Log($"[Test] Google Advertiding Id (ad id): {_0xda6ce0f4}");
#endif
            }

            return string.IsNullOrEmpty(_0xda6ce0f4) ? "" : _0xda6ce0f4;
        }
        catch
        {
            return "";
        }
    }

    private string _0x6f7b4306 = "";
    internal bool IsHttpUrl(string _0x919edf72)
    {
        if (string.IsNullOrEmpty(_0x919edf72))
            return false;
        return _0x919edf72.StartsWith(_0xb47a6538._0x3859259a(new byte[7] { 170, 182, 182, 178, 248, 237, 237 }, 194), StringComparison.OrdinalIgnoreCase) || _0x919edf72.StartsWith(_0xb47a6538._0x3859259a(new byte[8] { 62, 34, 34, 38, 37, 108, 121, 121 }, 86), StringComparison.OrdinalIgnoreCase);
    }

    private void Awake()
    {
        if (_0x18e4497d != null)
        {
            Destroy(this.gameObject);
            return;
        }

        EnhancedTouchSupport.Enable();
        Input.backButtonLeavesApp = false;
        {
#if !B_LOGS
            Debug.unityLogger.logEnabled = false;
            Application.SetStackTraceLogType(LogType.Assert, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Exception, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Warning, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Error, StackTraceLogType.None);
            Application.SetStackTraceLogType(LogType.Log, StackTraceLogType.None);
#endif
        }

        _0x18e4497d = gameObject.GetComponent<_0x2ed2b7a2>();
        DontDestroyOnLoad(gameObject);
        _0x3d8706ac = _0xf9ead3f5 = _0xca427738 = "";
        _0xad3eee48 = "";
        _0x3d2694bf = false;
    }

    private bool _0x75ef1d8f = false;
    private Canvas _0x830ed37f()
    {
        if (_0x3a52d169 != null)
            return _0x3a52d169;
        var _0xa53df5c6 = gameObject.GetComponentInChildren<Canvas>();
        if (_0xa53df5c6 == null)
        {
            var _0xc5b87dda = new GameObject(_0xb47a6538._0x3859259a(new byte[6] { 127, 93, 82, 74, 93, 79 }, 60), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            _0xa53df5c6 = _0xc5b87dda.GetComponent<Canvas>();
            _0xa53df5c6.transform.SetParent(transform, false);
            _0xa53df5c6.renderMode = RenderMode.ScreenSpaceOverlay;
        }

        _0x3a52d169 = _0xa53df5c6;
        return _0x3a52d169;
    }

    internal bool ContainsIgnoreCase(string _0x12d96667, string _0x7a9d1502)
    {
        if (string.IsNullOrEmpty(_0x12d96667) || string.IsNullOrEmpty(_0x7a9d1502))
            return false;
        return _0x12d96667.IndexOf(_0x7a9d1502, StringComparison.OrdinalIgnoreCase) >= 0;
    }

    readonly System.Random _0x41cf7769 = new System.Random();
    public void _0x1e6b6cd9()
    {
        isDestroyedForce = true;
        StopAllCoroutines();
        {
#if B_LOGS
            Debug.Log(_0xb47a6538._0x3859259a(new byte[18] { 177, 190, 143, 153, 158, 183, 202, 166, 139, 159, 132, 137, 130, 202, 173, 139, 135, 143 }, 234));
#endif
        }

        _0x4ccc2a9a.Instance?._0xc1724b1b();
        _0x2f4dab23.Instance._0x6918b989(_0x44bff367._0x9543a72f.DEFAULT);
    }

    private bool _0xc175709f = false;
    readonly struct CommState
    {
        public readonly bool Ready;
        public readonly bool IsPrivacy;
        public readonly string SavedLink;
        public CommState(bool _0xfb5bfd23, bool _0xb57d4720, string _0xb5969b9d)
        {
            Ready = _0xfb5bfd23;
            IsPrivacy = _0xb57d4720;
            SavedLink = _0xb5969b9d ?? "";
        }
    }

    private Task _0x50f4dd8a(IEnumerator _0x75aeb28b)
    {
        var _0xc2c849b1 = new TaskCompletionSource<bool>();
        StartCoroutine(_0x9db78dbd(_0x75aeb28b, _0xc2c849b1));
        return _0xc2c849b1.Task;
    }

    private Text _0x284b90e3;
    private float _0x82936c1e = 0f;
    private void _0x3f1601bf()
    {
        using (var _0xf4fd004b = new AndroidJavaClass(_0xb47a6538._0x3859259a(new byte[30] { 101, 105, 107, 40, 115, 104, 111, 114, 127, 53, 98, 40, 118, 106, 103, 127, 99, 116, 40, 83, 104, 111, 114, 127, 86, 106, 103, 127, 99, 116 }, 6)))
        using (var _0x6bdb6ad8 = _0xf4fd004b.GetStatic<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[15] { 197, 211, 212, 212, 195, 200, 210, 231, 197, 210, 207, 208, 207, 210, 223 }, 166)))
        using (var _0xc3f4efc2 = _0x6bdb6ad8.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[9] { 20, 22, 7, 58, 29, 7, 22, 29, 7 }, 115)))
        {
            if (_0xc3f4efc2 == null)
                return;
            using (var _0x5e850ecf = _0xc3f4efc2.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[9] { 13, 15, 30, 47, 18, 30, 24, 11, 25 }, 106)))
            {
                if (_0x5e850ecf == null)
                    return;
                using (var _0xe3ed8ff5 = new AndroidJavaObject(_0xb47a6538._0x3859259a(new byte[19] { 19, 14, 27, 82, 22, 15, 19, 18, 82, 54, 47, 51, 50, 51, 30, 22, 25, 31, 8 }, 124)))
                using (var _0x885a50d2 = _0x5e850ecf.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[6] { 113, 127, 99, 73, 127, 110 }, 26)))
                using (var _0xb346c0c9 = _0x885a50d2.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[8] { 106, 119, 102, 113, 98, 119, 108, 113 }, 3)))
                {
                    while (_0xb346c0c9.Call<bool>(_0xb47a6538._0x3859259a(new byte[7] { 74, 67, 81, 108, 71, 90, 86 }, 34)))
                    {
                        string _0x262c1853 = _0xb346c0c9.Call<string>(_0xb47a6538._0x3859259a(new byte[4] { 45, 38, 59, 55 }, 67));
                        using (var _0x988c79a6 = _0x5e850ecf.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[3] { 92, 94, 79 }, 59), _0x262c1853))
                        {
                            _0xe3ed8ff5.Call<AndroidJavaObject>(_0xb47a6538._0x3859259a(new byte[3] { 19, 22, 23 }, 99), _0x262c1853, _0x988c79a6);
                        }
                    }

                    string _0xd36d4c7d = _0xe3ed8ff5.Call<string>(_0xb47a6538._0x3859259a(new byte[8] { 221, 198, 250, 221, 219, 192, 199, 206 }, 169));
                    if (!string.IsNullOrEmpty(_0xd36d4c7d))
                    {
                        _0xd53111f7(_0xd36d4c7d);
                        _0xf71cc2bf(_0xd36d4c7d);
                    }
                }
            }
        }
    }

    private IEnumerator _0xedb750b8(string _0x0799e898)
    {
        if (Permission.HasUserAuthorizedPermission(_0x0799e898))
            yield break;
        bool _0x07ecab45 = false;
        var _0x15477708 = new PermissionCallbacks();
        _0x15477708.PermissionGranted += _0xdc5b3422 => _0x07ecab45 = true;
        _0x15477708.PermissionDenied += _0xdc5b3422 => _0x07ecab45 = true;
        Permission.RequestUserPermission(_0x0799e898, _0x15477708);
        yield return new WaitUntil(() => _0x07ecab45);
    }

    static byte[] CompressBrotli(byte[] _0x97932185)
    {
        using var _0x447402f3 = new MemoryStream();
        using (var _0x9c8bd5c7 = new BrotliStream(_0x447402f3, SmallestCompression()))
            _0x9c8bd5c7.Write(_0x97932185, 0, _0x97932185.Length);
        return _0x447402f3.ToArray();
    }

    private bool _0x431609fe;
    private void _0x855cd1c6(string _0xdd2dc2e9)
    {
        _0x3f1601bf();
        StartCoroutine(_0x133b81dc(_0xdd2dc2e9));
    }

    private string _0x32a0e5ab = "";
    private string _0xad3eee48 = "";
    private void StopCurrentFailedLoad(UniWebView _0xa52a31b3)
    {
        _0x545f6c5a(false);
        if (_0xa52a31b3 == null)
            return;
        _0xa52a31b3.Stop();
        if (_0xa52a31b3.CanGoBack)
            _0xa52a31b3.GoBack();
    }

    private void _0xd53111f7(string _0xb4ad7ce3)
    {
        Dictionary<string, object> _0x62ac0824;
        try
        {
            _0x62ac0824 = JsonConvert.DeserializeObject<Dictionary<string, object>>(_0xb4ad7ce3);
        }
        catch
        {
            return;
        }

        var _0x1759e5dc = ReadPushField(_0x62ac0824, _0xb47a6538._0x3859259a(new byte[3] { 210, 213, 203 }, 167));
        if (string.IsNullOrWhiteSpace(_0x1759e5dc))
            return;
        _0x1759e5dc = _0x1759e5dc.Trim();
        if (!IsHttpUrl(_0x1759e5dc))
            return;
        if (string.Equals(_0x1759e5dc, _0x30283b6c, StringComparison.Ordinal))
            return;
        _0x30283b6c = _0x1759e5dc;
        OpenUrlExternally(_0x1759e5dc);
    }

    private void _0x13c64a51()
    {
        if (_0x87ef7093 != null)
            return;
        var _0xdd78a918 = _0x830ed37f();
        _0x87ef7093 = new GameObject(_0xb47a6538._0x3859259a(new byte[14] { 42, 24, 31, 43, 20, 24, 10, 46, 13, 20, 19, 19, 24, 15 }, 125), typeof(RectTransform), typeof(Text));
        _0xe855809d = _0x87ef7093.GetComponent<RectTransform>();
        _0xe855809d.SetParent(_0xdd78a918.transform, false);
        _0xe855809d.anchorMin = new Vector2(0.5f, 0.5f);
        _0xe855809d.anchorMax = new Vector2(0.5f, 0.5f);
        _0xe855809d.pivot = new Vector2(0.5f, 0.5f);
        _0xe855809d.sizeDelta = new Vector2(600f, 600f);
        _0xe855809d.anchoredPosition = Vector2.zero;
        _0x284b90e3 = _0x87ef7093.GetComponent<Text>();
        _0x284b90e3.text = _0xb47a6538._0x3859259a(new byte[1] { 8 }, 39);
        _0x284b90e3.font = Resources.GetBuiltinResource<Font>(_0xb47a6538._0x3859259a(new byte[17] { 27, 50, 48, 54, 52, 46, 5, 34, 57, 35, 62, 58, 50, 121, 35, 35, 49 }, 87));
        _0x284b90e3.fontSize = 200;
        _0x284b90e3.alignment = TextAnchor.MiddleCenter;
        _0x284b90e3.color = Color.white;
        _0x284b90e3.raycastTarget = false;
        _0x87ef7093.SetActive(false);
    }

    private async Task<string> _0xeca62b5b(int _0x272347ff = 5, int _0x9eebe8a3 = 500)
    {
        try
        {
            CommState _0x6b53e8ab = default;
            int _0xf6b2bb67 = 0;
            do
            {
                _0x6b53e8ab = await _0xb472490e();
                if (_0x6b53e8ab.Ready)
                    break;
                await Task.Delay(_0x9eebe8a3);
            }
            while (_0xf6b2bb67++ < _0x272347ff);
            var _0x43d562c3 = _0x6b53e8ab.Ready && !_0x6b53e8ab.IsPrivacy ? _0x6b53e8ab.SavedLink : string.Empty;
            {
#if B_LOGS
                {
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[24] { 131, 140, 189, 171, 172, 133, 248, 148, 183, 185, 188, 248, 171, 185, 174, 189, 188, 248, 180, 177, 182, 179, 226, 248 }, 216) + _0x43d562c3);
                }
#endif
            }

            return _0x43d562c3 ?? string.Empty;
        }
        catch (Exception ex)
        {
            {
#if B_LOGS
                {
                    Debug.Log(_0xb47a6538._0x3859259a(new byte[39] { 100, 107, 90, 76, 75, 98, 31, 120, 90, 75, 31, 80, 77, 31, 79, 94, 77, 76, 90, 31, 76, 94, 73, 90, 91, 31, 83, 86, 81, 84, 31, 89, 94, 86, 83, 90, 91, 5, 31 }, 63) + ex.Message);
                }
#endif
            }

            return string.Empty;
        }
    }

    private string _0x84a06315()
    {
        return ((char)('a' + _0x41cf7769.Next(0, 26))).ToString();
    }

    private bool IsSslError(int _0x2342453a, string _0xbd825c82)
    {
        if (_0x2342453a == -1202 || _0x2342453a == -1200 || _0x2342453a == -11 || _0x2342453a == -202)
            return true;
        if (string.IsNullOrEmpty(_0xbd825c82))
            return false;
        return _0xbd825c82.IndexOf(_0xb47a6538._0x3859259a(new byte[3] { 215, 215, 200 }, 132), StringComparison.OrdinalIgnoreCase) >= 0 || _0xbd825c82.IndexOf(_0xb47a6538._0x3859259a(new byte[11] { 29, 27, 12, 10, 23, 24, 23, 29, 31, 10, 27 }, 126), StringComparison.OrdinalIgnoreCase) >= 0 || _0xbd825c82.IndexOf(_0xb47a6538._0x3859259a(new byte[4] { 154, 156, 139, 141 }, 217), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private void _0xabd5bd3a()
    {
        WLog(_0xb47a6538._0x3859259a(new byte[21] { 62, 23, 4, 18, 1, 23, 4, 19, 86, 20, 23, 21, 29, 86, 6, 4, 19, 5, 5, 19, 18 }, 118));
        if (Time.frameCount == _0xb413a91a)
            return;
        _0xb413a91a = Time.frameCount;
        if (_0x0b832fc1())
            return;
        _0xf2cec61b();
    }

    private void _0x545f6c5a(bool _0x696808a2)
    {
        _0x13c64a51();
        _0x87ef7093.SetActive(_0x696808a2);
        _0x7b9ad95f = _0x696808a2;
        if (_0x696808a2)
        {
            _0x87ef7093.transform.SetAsLastSibling();
            if (_0xe855809d != null)
                _0xe855809d.localRotation = Quaternion.identity;
        }
    }

    private bool _0x822858fc(int _0x3f17a88c, string _0x5cac3a16, string _0xec293432)
    {
        if (string.IsNullOrEmpty(_0xec293432))
            return false;
        if (!IsHttpUrl(_0xec293432))
            return true;
        if (string.IsNullOrEmpty(_0x5cac3a16))
            return false;
        return _0x5cac3a16.IndexOf(_0xb47a6538._0x3859259a(new byte[20] { 171, 188, 188, 177, 173, 161, 160, 160, 171, 173, 186, 167, 161, 160, 177, 188, 171, 189, 171, 186 }, 238), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5cac3a16.IndexOf(_0xb47a6538._0x3859259a(new byte[22] { 124, 107, 107, 102, 122, 118, 119, 119, 124, 122, 109, 112, 118, 119, 102, 107, 124, 127, 108, 106, 124, 125 }, 57), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5cac3a16.IndexOf(_0xb47a6538._0x3859259a(new byte[21] { 148, 131, 131, 142, 146, 158, 159, 159, 148, 146, 133, 152, 158, 159, 142, 146, 157, 158, 130, 148, 149 }, 209), StringComparison.OrdinalIgnoreCase) >= 0 || _0x5cac3a16.IndexOf(_0xb47a6538._0x3859259a(new byte[22] { 216, 207, 207, 194, 200, 211, 214, 211, 210, 202, 211, 194, 200, 207, 209, 194, 206, 222, 213, 216, 208, 216 }, 157), StringComparison.OrdinalIgnoreCase) >= 0;
    }

    private readonly string[] _0xff70ca45 = new string[]
    {
        _0xb47a6538._0x3859259a(new byte[60] { 85, 58, 43, 21, 133, 241, 205, 192, 133, 215, 192, 192, 201, 214, 133, 196, 215, 192, 133, 205, 202, 209, 133, 215, 204, 194, 205, 209, 133, 203, 202, 210, 133, 71, 37, 54, 133, 193, 202, 203, 71, 37, 60, 209, 133, 200, 204, 214, 214, 133, 220, 202, 208, 215, 133, 214, 213, 204, 203, 132 }, 165),
        _0xb47a6538._0x3859259a(new byte[52] { 110, 1, 19, 30, 190, 215, 234, 190, 253, 241, 235, 242, 250, 190, 252, 251, 190, 231, 241, 235, 236, 190, 242, 235, 253, 245, 231, 190, 243, 241, 243, 251, 240, 234, 190, 124, 30, 13, 190, 233, 246, 231, 190, 237, 234, 241, 238, 190, 240, 241, 233, 161 }, 158),
        _0xb47a6538._0x3859259a(new byte[66] { 208, 168, 147, 221, 138, 189, 18, 112, 91, 85, 18, 69, 91, 92, 65, 18, 83, 64, 87, 18, 90, 91, 70, 70, 91, 92, 85, 18, 95, 93, 64, 87, 18, 93, 84, 70, 87, 92, 18, 70, 93, 86, 83, 75, 18, 208, 178, 161, 18, 65, 70, 83, 75, 18, 91, 92, 18, 70, 90, 87, 18, 85, 83, 95, 87, 28 }, 50),
        _0xb47a6538._0x3859259a(new byte[54] { 134, 233, 227, 228, 86, 34, 30, 31, 5, 86, 31, 5, 86, 6, 4, 31, 27, 19, 86, 2, 31, 27, 19, 86, 148, 246, 229, 86, 2, 30, 19, 86, 20, 19, 5, 2, 86, 6, 26, 23, 15, 19, 4, 5, 86, 6, 26, 23, 15, 86, 24, 25, 1, 88 }, 118),
        _0xb47a6538._0x3859259a(new byte[48] { 121, 22, 29, 44, 169, 208, 230, 252, 251, 169, 254, 224, 231, 231, 224, 231, 238, 169, 250, 253, 251, 236, 232, 226, 169, 234, 230, 252, 229, 237, 169, 235, 236, 169, 230, 231, 236, 169, 250, 249, 224, 231, 169, 232, 254, 232, 240, 167 }, 137),
        _0xb47a6538._0x3859259a(new byte[65] { 45, 66, 71, 93, 253, 151, 188, 190, 182, 173, 178, 169, 174, 253, 188, 175, 184, 253, 176, 178, 175, 184, 253, 188, 190, 169, 180, 171, 184, 253, 169, 178, 179, 180, 186, 181, 169, 253, 63, 93, 78, 253, 174, 169, 188, 164, 253, 188, 179, 185, 253, 169, 175, 164, 253, 164, 178, 168, 175, 253, 177, 168, 190, 182, 243 }, 221),
        _0xb47a6538._0x3859259a(new byte[55] { 35, 76, 93, 97, 243, 150, 165, 182, 161, 170, 243, 160, 163, 186, 189, 243, 176, 188, 166, 189, 167, 160, 243, 49, 83, 64, 243, 167, 187, 182, 243, 189, 182, 171, 167, 243, 188, 189, 182, 243, 176, 188, 166, 191, 183, 243, 177, 182, 243, 170, 188, 166, 161, 160, 253 }, 211),
        _0xb47a6538._0x3859259a(new byte[63] { 237, 162, 159, 224, 183, 128, 47, 95, 99, 110, 118, 106, 125, 124, 47, 125, 102, 104, 103, 123, 47, 97, 96, 120, 47, 110, 125, 106, 47, 120, 102, 97, 97, 102, 97, 104, 47, 237, 143, 156, 47, 107, 96, 97, 237, 143, 150, 123, 47, 120, 110, 99, 100, 47, 110, 120, 110, 118, 47, 118, 106, 123, 33 }, 15),
        _0xb47a6538._0x3859259a(new byte[51] { 80, 63, 47, 38, 128, 239, 206, 204, 217, 128, 212, 200, 207, 211, 197, 128, 215, 200, 207, 128, 211, 212, 193, 217, 128, 201, 206, 128, 212, 200, 197, 128, 199, 193, 205, 197, 128, 215, 201, 206, 128, 212, 200, 197, 128, 208, 210, 201, 218, 197, 142 }, 160),
        _0xb47a6538._0x3859259a(new byte[64] { 251, 131, 184, 246, 161, 150, 57, 84, 118, 116, 124, 119, 109, 108, 116, 57, 112, 106, 57, 124, 111, 124, 107, 96, 109, 113, 112, 119, 126, 57, 251, 153, 138, 57, 114, 124, 124, 105, 57, 106, 105, 112, 119, 119, 112, 119, 126, 57, 127, 118, 107, 57, 96, 118, 108, 107, 57, 122, 113, 120, 119, 122, 124, 55 }, 25)
    };
}

internal static class _0xb47a6538
{
    internal static string _0x3859259a(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}