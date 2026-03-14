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
    var n = bridge.Length;

    if (!(bridge[0] == '*' && bridge[n - 1] == '*'))
    {
        return false;
    }
    var reinforcementCounter = 0;
    for (int i = 1; i < n - 1; i++)
    {
        var partChar = bridge[i];
        if (!(partChar == '=' || partChar == '+'))
        {
            return false;
        }

        if (partChar == '=')
        {
            reinforcementCounter++;
        }
        else
        {
            reinforcementCounter = 0;
        }

        if (reinforcementCounter == 4)
        {
            return false;
        }
    }

    reinforcementCounter = 0;
    for (int i = 1; i < n / 2; i++)
    {
        var leftChar = bridge[i];
        var rightChar = bridge[n - i - 1];
        if (leftChar != rightChar)
        {
            return false;
        }

        if (leftChar == '+')
        {
            reinforcementCounter++;
        }
        else
        {
            reinforcementCounter = 0;
        }

        if (reinforcementCounter == 3)
        {
            return false;
        }
    }

    return true;
}

