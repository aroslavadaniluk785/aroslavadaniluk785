using UnityEngine;

/// Persisted garden state. The keys are plain strings used INSIDE method bodies only:
/// collecting them into a static array would make them part of a static initialiser, and
/// an encrypted string field can be initialised after whoever reads it.
public static class _0x744cf847
{
    public static bool _0x4d7aec3d
    {
        get
        {
            return PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[10] { 55, 32, 105, 47, 38, 55, 51, 46, 36, 52 }, 71), 1) == 1;
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[10] { 243, 228, 173, 235, 226, 243, 247, 234, 224, 240 }, 131), value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    /// How many trees the player may open: everything grown so far, plus the next one.
    public static int _0xff09096a
    {
        get
        {
            return Mathf.Clamp(_0x5f18a4d3 + 1, 1, TreeCount);
        }
    }

    /// Counts up for every run of the same tree, so a retry is not the same board.
    public static int _0x5fb9f0b9
    {
        get
        {
            return PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[10] { 212, 195, 138, 197, 208, 208, 193, 201, 212, 208 }, 164), 0);
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[10] { 3, 20, 93, 18, 7, 7, 22, 30, 3, 7 }, 115), value);
            PlayerPrefs.Save();
        }
    }

    public static bool _0x856f0ab8
    {
        get
        {
            return PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[8] { 151, 128, 201, 143, 136, 144, 147, 136 }, 231), 0) == 1;
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[8] { 167, 176, 249, 191, 184, 160, 163, 184 }, 215), value ? 1 : 0);
            PlayerPrefs.Save();
        }
    }

    public static int _0x90fc7e1b
    {
        get
        {
            return Mathf.Max(0, PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[9] { 226, 245, 188, 240, 243, 225, 249, 247, 230 }, 146), 0));
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[9] { 135, 144, 217, 149, 150, 132, 156, 146, 131 }, 247), Mathf.Max(0, value));
            PlayerPrefs.Save();
        }
    }

    public static void ResetGarden()
    {
        PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[8] { 135, 144, 217, 155, 146, 129, 146, 155 }, 247), 0);
        PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[8] { 145, 134, 207, 134, 147, 142, 150, 143 }, 225), 0);
        PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[9] { 204, 219, 146, 222, 221, 207, 215, 217, 200 }, 188), 0);
        PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[10] { 50, 37, 108, 35, 54, 54, 39, 47, 50, 54 }, 66), 0);
        PlayerPrefs.Save();
    }

    public static int _0x8ce537ac
    {
        get
        {
            return Mathf.Clamp(PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[8] { 95, 72, 1, 67, 74, 89, 74, 67 }, 47), 0), 0, TreeCount - 1);
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[8] { 105, 126, 55, 117, 124, 111, 124, 117 }, 25), Mathf.Clamp(value, 0, TreeCount - 1));
            PlayerPrefs.Save();
        }
    }

    public static int _0x5f18a4d3
    {
        get
        {
            return Mathf.Clamp(PlayerPrefs.GetInt(_0x92e74875._0x0789b10c(new byte[8] { 181, 162, 235, 162, 183, 170, 178, 171 }, 197), 0), 0, TreeCount);
        }

        set
        {
            PlayerPrefs.SetInt(_0x92e74875._0x0789b10c(new byte[8] { 229, 242, 187, 242, 231, 250, 226, 251 }, 149), Mathf.Clamp(value, 0, TreeCount));
            PlayerPrefs.Save();
        }
    }

    public const int TreeCount = 12;
}

internal static class _0x92e74875
{
    internal static string _0x0789b10c(byte[] data, byte key)
    {
        var buffer = new byte[data.Length];
        for (var i = 0; i < data.Length; i++)
            buffer[i] = (byte)(data[i] ^ key);
        return System.Text.Encoding.UTF8.GetString(buffer);
    }
}