using System.Linq;
using WordleJudge;

if (args.Length != 2 || !IsValid(args[0]) || !IsValid(args[1]))
{
    Console.Error.WriteLine("Usage: WordleJudge <ANSWER> <GUESS>  (each exactly 5 uppercase A-Z letters)");
    return 2;
}

Console.WriteLine(Judge.Score(args[0], args[1]));
return 0;

static bool IsValid(string w) => w.Length == 5 && w.All(c => c >= 'A' && c <= 'Z');
