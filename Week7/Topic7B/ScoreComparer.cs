using System;
using System.Collections.Generic;

public class ScoreComparer : IComparer<ScoreEntry>
{
    public int Compare(ScoreEntry? x, ScoreEntry? y)
    {
        if (x == null && y == null)
        {
            return 0;
        }

        if (x == null)
        {
            return -1;
        }

        if (y == null)
        {
            return 1;
        }

        var scoreResult = x.Score.CompareTo(y.Score);

        if (scoreResult != 0)
        {
            return scoreResult;
        }

        return x.StageReached.CompareTo(y.StageReached);
    }
}