using UnityEngine;

/// Colour tokens for the walled-garden puzzle.
/// Surface colours and text colours are deliberately separated: the whole app shares one
/// font material with one dark outline, so every colour used for TEXT below is light.
public static class _0x47f8534e
{
    public static readonly Color Wheat = new Color(0.847f, 0.7882f, 0.6588f, 1f);
    public static readonly Color PineDeep = new Color(0.2235f, 0.3216f, 0.2353f, 1f);
    /// Same hue, different alpha. Used for scrims, plates and disabled states.
    public static Color Fade(Color _0xb7020d07, float _0x2bc014af)
    {
        return new Color(_0xb7020d07.r, _0xb7020d07.g, _0xb7020d07.b, _0x2bc014af);
    }

    public static readonly Color Pine = new Color(0.302f, 0.4196f, 0.3137f, 1f);
    public static readonly Color LeafLight = new Color(0.6078f, 0.8627f, 0.4941f, 1f);
    public static readonly Color Sand = new Color(0.9098f, 0.8667f, 0.7686f, 1f);
    public static readonly Color Cream = new Color(1f, 0.9647f, 0.898f, 1f);
    public static readonly Color Plum = new Color(0.553f, 0.4039f, 0.7804f, 1f);
    public static readonly Color Gold = new Color(0.9608f, 0.7686f, 0.3176f, 1f);
    /// Tint of one of the five produce types; surface use only, never a text colour.
    public static Color Produce(int _0xde698701)
    {
        if (_0xde698701 == 0)
        {
            return Coral;
        }

        if (_0xde698701 == 1)
        {
            return Leaf;
        }

        if (_0xde698701 == 2)
        {
            return Plum;
        }

        if (_0xde698701 == 3)
        {
            return Gold;
        }

        return Pine;
    }

    public static readonly Color Linen = new Color(0.949f, 0.918f, 0.847f, 1f);
    public static readonly Color Bark = new Color(0.1647f, 0.2275f, 0.1647f, 1f);
    public static readonly Color Coral = new Color(0.9333f, 0.4196f, 0.3333f, 1f);
    public static readonly Color Leaf = new Color(0.4863f, 0.7961f, 0.3569f, 1f);
    public static readonly Color GoldDeep = new Color(0.851f, 0.6627f, 0.2235f, 1f);
}