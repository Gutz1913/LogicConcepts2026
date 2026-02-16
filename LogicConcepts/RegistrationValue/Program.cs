using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::::: EJERCICIO DE VALOR DE MATRÍCULA :::::");
Console.WriteLine(":::::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        var credits = ConsoleExtension.GetInt("Número de créditos...............: ");
        var creditValue = ConsoleExtension.GetDecimal("Valor por crédito................: ");
        var stratum = ConsoleExtension.GetInt("Estrato del estudiante...........: ");

        var registrationValue = CalculateRegistrationValue(credits, creditValue, stratum);
        var subsidy = CalculateSubsidy(stratum);

        Console.WriteLine($"Costo de la matrícula............: {registrationValue,20:C2}");
        Console.WriteLine($"Valor del subsidio...............: {subsidy,20:C2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?.....: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

decimal CalculateSubsidy(int stratum)
{
    if (stratum == 1)
    {
        return 200000m;
    }
    if (stratum == 2)
    {
        return 100000m;
    }
    return 0;
}

decimal CalculateRegistrationValue(int credits, decimal creditValue, int stratum)
{
    decimal value;
    if (credits <= 20)
    {
        value = credits * creditValue;
    }
    else
    {
        value = (20 * creditValue) + ((credits - 20) * creditValue * 2m);
    }

    if (stratum == 1)
    {
        return value * 0.2m;
    }
    if (stratum == 2)
    {
        return value * 0.5m;
    }
    if (stratum == 3)
    {
        return value * 0.7m;
    }
    return value;
}