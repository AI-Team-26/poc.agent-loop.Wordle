namespace WordleJudge;

/// <summary>
/// Scores a 5-letter guess against an answer. Returns a 5-char pattern:
/// 'G' exact match, 'Y' right letter wrong position, '.' absent.
/// Uses the standard two-pass algorithm (resolve exact matches first,
/// then count remaining letters) so duplicate letters are scored correctly.
/// </summary>
public static class Judge
{
    public static string Score(string answer, string guess)
    {
        var result = new char[answer.Length];
        var remaining = new int[26];

        // Pass 1: mark exact matches and count non-exact answer letters.
        for (var i = 0; i < answer.Length; i++)
        {
            if (guess[i] == answer[i])
                result[i] = 'G';
            else
                remaining[answer[i] - 'A']++;
        }

        // Pass 2: for non-exact positions, determine Y or .
        // A position gets 'Y' only if the letter exists in the answer
        // beyond exact matches. If the guess has more of a letter than
        // the answer, extra positions get '.'.
        for (var i = 0; i < answer.Length; i++)
        {
            if (result[i] != 'G')
            {
                var idx = guess[i] - 'A';
                if (remaining[idx] > 0)
                {
                    result[i] = 'Y';
                    remaining[idx]--;
                }
                else
                {
                    result[i] = '.';
                }
            }
        }

        return new string(result);
    }
}