using NUnit.Framework;

using Swensen.Unquote;
using WordleJudge;

namespace WordleJudge.Tests;

[TestFixture]
public class JudgeTests
{
    [Test]
    public void AllExactMatches()
    {
        // HELLO vs HELLO: every position identical -> GGGGG
        var actual = Judge.Score("HELLO", "HELLO");
        Assertions.op_EqualsBang("GGGGG", actual);
    }

    [Test]
    public void AllAbsent()
    {
        // ABCDE vs PQRST: no shared letters -> .....
        var actual = Judge.Score("ABCDE", "PQRST");
        Assertions.op_EqualsBang(".....", actual);
    }

    [Test]
    public void BasicWrongPosition()
    {
        // HEART vs RATES: R,A,T,E all present but shifted; S absent -> YYYY.
        var actual = Judge.Score("HEART", "RATES");
        Assertions.op_EqualsBang("YYYY.", actual);
    }

    [Test]
    public void BooksVsToots()
    {
        // BOOKS vs TOOTS (by hand): T not in answer -> . ;
        // O,O exact -> GG ; third O has no remaining O in answer -> . ;
        // S exact -> G  => .GG.G
        var actual = Judge.Score("BOOKS", "TOOTS");
        Assertions.op_EqualsBang(".GG.G", actual);
    }

    [Test]
    public void AnswerHasMoreOfALetterThanGuess()
    {
        // AAAAA vs AAAAB (by hand): first four A's exact -> GGGG ; B absent -> .
        var actual = Judge.Score("AAAAA", "AAAAB");
        Assertions.op_EqualsBang("GGGG.", actual);
    }

    [Test]
    public void GuessHasMoreOfALetterThanAnswer()
    {
        // PLEAS vs APPLE (by hand): no exact matches.
        // Answer holds one each of P,L,E,A,S. Guess uses P twice, so only the
        // first P may score Y; second P is '.'. A,P,Y... order: A->Y, P->Y,
        // P->., L->Y, E->Y  => YY.YY
        var actual = Judge.Score("PLEAS", "APPLE");
        Assertions.op_EqualsBang("YY.YY", actual);
    }
}
