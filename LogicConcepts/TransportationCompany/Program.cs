using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
Console.WriteLine("::: EJERCICIO EMPRESA TRANSPORTADORA :::");
Console.WriteLine("::::::::::::::::::::::::::::::::::::::::");
do
{
    try
    {
        Console.WriteLine("*** DATOS DE ENTRADA ***");
        var routeOptions = new List<string> { "1", "2", "3", "4" };
        var route = string.Empty;
        do
        {
            route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4]...............................: ", routeOptions);
        }
        while (!routeOptions.Any(x => x == route));
        var trips = ConsoleExtension.GetInt("Número de viajes................................: ");
        var passengers = ConsoleExtension.GetInt("Número de pasajeros total.......................: ");
        var packages10 = ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg..........: ");
        var packages10_20 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg: ");
        var packages20 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg............: ");
        Console.WriteLine();
        var incomePassengers = GetIncomePassengers(route, passengers, trips);
        var incomePackages = GetIncomePackages(route, packages10, packages10_20, packages20);
        var incomes = incomePassengers + incomePackages;
        var valueHelper = GetValueHelper(incomes);
        var valueSure = GetValueSure(incomes);
        var fuelValue = GetFuelValue(route, trips, passengers, packages10, packages10_20, packages20);
        var deductions = valueHelper + valueSure + fuelValue;
        var totalToPay = incomes - deductions;
        Console.WriteLine("*** CÁLCULOS ***");
        Console.WriteLine($"Ingresos por Pasajeros..........................: {incomePassengers,20:C2} ");
        Console.WriteLine($"Ingresos por Encomiendas........................: {incomePackages,20:C2} ");
        Console.WriteLine($"                                                  --------------------");
        Console.WriteLine($"TOTAL INGRESOS..................................: {incomes,20:C2}");
        Console.WriteLine($"Pago Ayudante...................................: {valueHelper,20:C2} ");
        Console.WriteLine($"Pago Seguro.....................................: {valueSure,20:C2} ");
        Console.WriteLine($"Pago Combustible................................: {fuelValue,20:C2} ");
        Console.WriteLine($"                                                  --------------------");
        Console.WriteLine($"TOTAL DEDUCCIONES...............................: {deductions,20:C2} ");
        Console.WriteLine($"                                                  ====================");
        Console.WriteLine($"TOTAL A LIQUIDAR................................: {totalToPay,20:C2}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Desea continuar [S]í, [N]o?....................: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("::::: GAME OVER :::::");

decimal GetFuelValue(string? route, int passengers, int packages10, int packages10_20, int packages20, int trips)
{
    float kms;
    switch (route)
    {
        case "1":
            kms = 150 * trips;

            break;

        case "2":
            kms = 167 * trips;
            break;

        case "3":
            kms = 184 * trips;
            break;

        default:
            kms = 203 * trips;
            break;
    }
    var gallons = kms / 39;
    var value = (decimal)gallons * 8860;
    var weight = passengers * 60 + packages10 * 10 + packages10_20 * 15 + packages20 * 20;
    if (weight < 5000) return value;
    if (weight <= 10000) return value * 1.1m;
    return value * 1.25m;
}

decimal GetValueSure(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.05m;
    if (incomes <= 2000000) return incomes * 0.08m;
    if (incomes < 4000000) return incomes * 0.08m;
    return incomes * 0.13m;
}

decimal GetValueHelper(decimal incomes)
{
    if (incomes < 1000000) return incomes * 0.03m;
    if (incomes <= 2000000) return incomes * 0.04m;
    if (incomes < 4000000) return incomes * 0.06m;
    return incomes * 0.9m;
}

decimal GetIncomePackages(string? route, int packages10, int packages10_20, int packages20)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
        case "2":
            if (packages10 <= 50) value += packages10 * 100m;
            else if (packages10 <= 100) value += packages10 * 120m;
            else if (packages10 <= 130) value += packages10 * 150m;
            else value += packages10 * 160m;

            var packagesGreather10 = packages10_20 + packages20;
            if (packagesGreather10 <= 50) value += packagesGreather10 * 120m;
            else if (packagesGreather10 <= 100) value += packagesGreather10 * 140m;
            else if (packagesGreather10 <= 130) value += packagesGreather10 * 160m;
            else value += packagesGreather10 * 180m;
            return value;

        default:
            if (packages10 <= 50) value += packages10 * 130m;
            else if (packages10 <= 100) value += packages10 * 160m;
            else if (packages10 <= 130) value += packages10 * 175m;
            else value += packages10 * 200m;

            if (packages10_20 <= 50) value += packages10_20 * 140m;
            else if (packages10_20 <= 100) value += packages10_20 * 180m;
            else if (packages10_20 <= 130) value += packages10_20 * 200m;
            else value += packages10_20 * 250m;

            if (packages20 <= 50) value += packages20 * 170m;
            else if (packages20 <= 100) value += packages20 * 210m;
            else if (packages20 <= 130) value += packages20 * 250m;
            else value += packages20 * 300m;

            return value;
    }
}

decimal GetIncomePassengers(string? route, int passengers, int trips)
{
    decimal value = 0;
    switch (route)
    {
        case "1":
            value = 500000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.05m;
            if (passengers <= 150) return value * 1.06m;
            if (passengers <= 200) return value * 1.07m;
            return value * 1.07m + (passengers - 200) * 50m;

        case "2":
            value = 600000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.07m;
            if (passengers <= 150) return value * 1.08m;
            if (passengers <= 200) return value * 1.09m;
            return value * 1.09m + (passengers - 200) * 60m;

        case "3":
            value = 800000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.10m;
            if (passengers <= 150) return value * 1.13m;
            if (passengers <= 200) return value * 1.15m;
            return value * 1.15m + (passengers - 200) * 100m;

        default:
            value = 1000000m * trips;
            if (passengers <= 50) return value;
            if (passengers <= 100) return value * 1.125m;
            if (passengers <= 150) return value * 1.15m;
            if (passengers <= 200) return value * 1.17m;
            return value * 1.17m + (passengers - 200) * 150m;
    }
}