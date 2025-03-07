
namespace slidegrid;

public static class Extensions
{
    /// <summary>
    /// Allows 0 through 9, a single decimal, and backspace only.
    /// </summary>
    public static void ValidateKeyPressDouble(this TextBox txt, KeyPressEventArgs e)
        => ValidateKeyPressNumeric(txt, e);

    /// <summary>
    /// Allows 0 through 9 and backspace only, and optionally a negative prefix.
    /// </summary>
    public static void ValidateKeyPressInt(this TextBox txt, KeyPressEventArgs e, bool allowNegative = false)
        => ValidateKeyPressNumeric(txt, e, AllowDecimal: false, AllowNegative: allowNegative);

    /// <summary>
    /// Swaps two List entries by index.
    /// </summary>
    public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        => (list[indexA], list[indexB]) = (list[indexB], list[indexA]);

    /// <summary>
    /// Swaps two ListBox entries by index.
    /// </summary>
    public static void Swap(this ListBox list, int indexA, int indexB)
        => (list.Items[indexA], list.Items[indexB]) = (list.Items[indexB], list.Items[indexA]);

    /// <summary>
    /// Determines if the filename portion of the pathname contains wildcards.
    /// </summary>
    public static bool IsWildcardPath(this string pathname)
    {
        string fileName = Path.GetFileName(pathname);
        return fileName.EndsWith('*');
    }

    private static void ValidateKeyPressNumeric(TextBox txt, KeyPressEventArgs e, bool AllowDecimal = true, bool AllowNegative = false)
    {
        bool isValid = Char.IsNumber(e.KeyChar);

        if (AllowDecimal && e.KeyChar == '.')
        {
            isValid = !txt.Text.Contains('.');
        }

        if (AllowNegative && e.KeyChar == '-')
        {
            isValid = !txt.Text.Contains('-') && txt.SelectionStart == 0;
        }

        // Allow backspace, tab
        isValid = isValid || e.KeyChar == '\b';

        // Stop the character from being entered into the control
        if (!isValid) e.Handled = true;
    }
}
