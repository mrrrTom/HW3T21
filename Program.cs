// Задача 21
// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

var dimension = 3;
Console.WriteLine($"Welcome to the {dimension}D distance resolver!");
var errors = new List<string>();
Console.WriteLine($"Please, insert first point coordinates ({dimension} digits separated by whitspace):");
var firstPointInput = Console.ReadLine();
var firstPoint = default(int[]);
if (!string.IsNullOrWhiteSpace(firstPointInput))
{
    firstPoint = firstPointInput.Split().Select(i => { TryParse(i, errors, out var number); return number; }).ToArray();
}
else
{
    errors.Add("You did not insert first point!");
}

Console.WriteLine($"Please, insert second point coordinates ({dimension} digits separated by whitspace):");
var secondPointInput = Console.ReadLine();
var secondPoint = default(int[]);
if (!string.IsNullOrWhiteSpace(secondPointInput))
{
    secondPoint = secondPointInput.Split().Select(i => { TryParse(i, errors, out var number); return number; }).ToArray();
}
else
{
    errors.Add("You did not insert second point!");
}

if (firstPoint?.Length != dimension)
{
    errors.Add($"Number of coordinates for the first point is different from required {dimension}");
}

if (secondPoint?.Length != dimension)
{
    errors.Add($"Number of coordinates for the second point is different from required {dimension}");
}

if (errors.Count != 0)
{
    foreach (var error in errors)
    {
        Console.WriteLine(error);
    }

    return;
}

var squaresSumm = default(double);
for (var j = 0; j < dimension; j++)
{
    squaresSumm += Math.Pow(secondPoint[j] - firstPoint[j], 2);
}

var result = Math.Sqrt(squaresSumm);
Console.WriteLine(Math.Round(result, 2));

static bool TryParse(string input, List<string> errors, out int result)
{
    result = default(int);
    if (!int.TryParse(input, out result))
    {
        errors.Add($"Inserted value {input} is not an integer");
        return false;
    }

    return true;
}