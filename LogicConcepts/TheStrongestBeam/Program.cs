using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE LA VIGA MAS RESISTENTE ::::::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var beam = ConsoleExtension.GetString("Ingrese la viga: ");
        if (IsValid(beam))
        {
            if (SupportsWeight(beam))
            {
                Console.WriteLine("La viga soporta el peso!");
            }
            else
            {
                Console.WriteLine("La viga no soporta el peso!");
            }
        }
        else
        {
            Console.WriteLine("La viga esta mal construida!");
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

static bool IsValid(string beam)
{
    var beamSupport = beam.Substring(0, 1);
    if (!(beamSupport.Equals("#") || beamSupport.Equals("%") || beamSupport.Equals("&")))
    {
        return false;
    }

    var n = beam.Length;
    var connectionCounter = 0;
    for (int i = 1; i < n; i++)
    {
        var part = beam.Substring(i, 1);
        if (!(part.Equals("=") || part.Equals("*")))
        {
            return false;
        }

        if (part.Equals("*"))
        {
            connectionCounter++;
        }
        else
        {
            connectionCounter = 0;
        }

        if (connectionCounter == 2)
        {
            return false;
        }
    }
    return true;
}

static bool SupportsWeight(string beam)
{
    var beamSupport = beam.Substring(0, 1);

    var n = beam.Length;
    var totalWeight = 0;
    var segmentWeight = 0;
    for (int i = 1; i < n; i++)
    {
        var part = beam.Substring(i, 1);
        if (part.Equals("="))
        {
            segmentWeight++;
        }
        else
        {
            totalWeight += segmentWeight * 3;
            segmentWeight = 0;
        }
    }

    totalWeight += segmentWeight;

    var beamSupportWeight = 0;
    switch (beamSupport)
    {
        case "%":
            beamSupportWeight = 10;
            break;

        case "&":
            beamSupportWeight = 30;
            break;

        case "#":
            beamSupportWeight = 90;
            break;
    }
    return beamSupportWeight >= totalWeight;
}