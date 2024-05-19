namespace StringHelper;

public static class Soundex
{
    [AllowNull]
    private static Dictionary<string, int> _soundexMapping;

    [AllowNull]
    private static Dictionary<string, string> _soundexMappingForFirstLetter;

    static Soundex()
    {
        SetSoundexMapping();
        SetSoundexMappingForFirstLetters();
    }

    public static bool IsEqualSoundex(
        [AllowNull] this string left, 
        [AllowNull] string right)
        => GetSoundex(left)
        == GetSoundex(right);

    [return: NotNull]
    public static string GetSoundex([AllowNull] this string input)
    {
        StringBuilder soundex = new();

        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        if (!_soundexMappingForFirstLetter.ContainsKey(input[..1]))
            return string.Empty;

        _ = soundex.Append(_soundexMappingForFirstLetter.GetValueOrDefault(input[..1]));

        for (int i = 1; i < input.Length; i++)
        {
            _ = _soundexMapping.TryGetValue(input[i].ToString(),
                out var afterFirstChar);

            _ = soundex.Append(afterFirstChar);
        }

        return soundex.ToString();
    }

    private static void SetSoundexMapping()
        => _soundexMapping = new()
        {
            { "ب", 1 },
            { "پ", 1 },
            { "ف", 1 },
            { "س", 2 },
            { "ص", 2 },
            { "ث", 2 },
            { "ج", 2 },
            { "ز", 2 },
            { "ظ", 2 },
            { "ض", 2 },
            { "ذ", 2 },
            { "ژ", 2 },
            { "چ", 2 },
            { "ک", 2 },
            { "غ", 2 },
            { "ق", 2 },
            { "گ", 2 },
            { "خ", 2 },
            { "ش", 2 },
            { "د", 3 },
            { "ت", 3 },
            { "ط", 3 },
            { "ل", 4 },
            { "م", 5 },
            { "ن", 5 },
            { "ر", 6 }
        };

    private static void SetSoundexMappingForFirstLetters()
        => _soundexMappingForFirstLetter = new()
        {
            { "ب", "B" },
            { "پ", "P" },
            { "ت", "T" },
            { "ط", "T" },
            { "س", "S" },
            { "ث", "S" },
            { "ص", "S" },
            { "ج", "J" },
            { "چ", "C" },
            { "ر", "R" },
            { "ه", "H" },
            { "ح", "H" },
            { "خ", "X" },
            { "د", "D" },
            { "ذ", "Z" },
            { "ظ", "Z" },
            { "ض", "Z" },
            { "ز", "Z" },
            { "ژ", "Z" },
            { "ش", "S" },
            { "غ", "G" },
            { "ک", "K" },
            { "گ", "G" },
            { "ق", "G" },
            { "ف", "F" },
            { "ل", "L" },
            { "م", "M" },
            { "ن", "N" },
            { "و", "V" },
            { "ع", "A" },
            { "ا", "A" },
            { "آ", "A" },
            { "أ", "A" },
            { "إ", "A" },
            { "ء", "A" },
            { "ی", "Y" }
        };
}