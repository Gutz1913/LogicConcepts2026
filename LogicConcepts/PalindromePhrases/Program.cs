using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.DarkBlue;
        Console.Clear();
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::");
        Console.WriteLine("::::::::: EJERCICIO DE FRASES PALINDROMAS :::::::::");
        Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::::::::::");
        var phrase = ConsoleExtension.GetString("Ingrese la palabra o frase: ");

        var isPalindrome = IsPaliandrome(phrase);

        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine($"La palabra o frase: '{phrase}' {(isPalindrome ? "Sí" : "No")} es palíndrome.");

        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?..................: ", options);
        Console.WriteLine();
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

bool IsPaliandrome(string? phrase)
{
    phrase = PreparePhrase(phrase);
    var n = phrase!.Length;
    for (var i = 0; i < n / 2; i++)
    {
        if (phrase[i] != phrase[n - i - 1])
        {
            return false;
        }
    }
    return true;
}

string? PreparePhrase(string? phrase)
{
    phrase = phrase!.ToLower();
    var newPhrase = string.Empty;
    var exceptions = new List<char> { ' ', ',', '.', '!', '¡', '¿', '?', ':', ';' };

    foreach (var character in phrase)
    {
        if (!exceptions.Contains(character))
        {
            newPhrase += character;
        }
    }

    newPhrase = newPhrase.Replace("á", "a")
                         .Replace("é", "e")
                         .Replace("í", "i")
                         .Replace("ó", "o")
                         .Replace("ú", "u")
                         .Replace("ü", "u");
    return newPhrase;
}