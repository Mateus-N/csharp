﻿internal class ComparadorMinusculo : IComparer<string>
{
    public int Compare(string x, string y)
    {
        return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase);
    }
}