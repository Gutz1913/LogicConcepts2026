using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::::::: EJERCICIO PUENTES DE MADISON :::::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Clear();
        var bridge = ConsoleExtension.GetString("Ingrese el puente: ");

        if (IsValid(bridge))
        {
            Console.WriteLine("VALIDO");
        }
        else 
        {
            Console.WriteLine("INVALIDO");
        }        
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

static bool IsValid(string bridge)
{
    if (string.IsNullOrEmpty(bridge) || bridge.Length < 2)
        return false;

    return HasValidBorders(bridge)
        && HasValidMiddleChars(bridge)
        && HasSymmetricReinforcement(bridge);
}

static bool HasValidBorders(string bridge)
{
    var n = bridge.Length;
    return bridge[0] == '*' && bridge[n - 1] == '*';
}

static bool HasValidMiddleChars(string bridge)
{
    var n = bridge.Length;
    var consecutiveEquals = 0;
    for (int i = 1; i < n - 1; i++)
    {
        var ch = bridge[i];
        if (ch != '=' && ch != '+')
            return false;

        if (ch == '=')
            consecutiveEquals++;
        else
            consecutiveEquals = 0;

        if (consecutiveEquals == 4)
            return false;
    }

    return true;
}

static bool HasSymmetricReinforcement(string bridge)
{
    var n = bridge.Length;
    var consecutivePlus = 0;
    for (int i = 1; i < n / 2; i++)
    {
        var left = bridge[i];
        var right = bridge[n - i - 1];
        if (left != right)
            return false;

        if (left == '+')
            consecutivePlus++;
        else
            consecutivePlus = 0;

        if (consecutivePlus == 3)
            return false;
    }

    return true;
}

