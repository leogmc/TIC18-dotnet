
#region Exercicio 1

string[] colecao = {"Item1", "Item2", "Item3", "Item4",};

foreach (string item in colecao)
{
    Console.WriteLine(item);
}

Console.WriteLine("--------------------------");

#endregion

#region Exercicio 2


double divisivel = 0;
for (int i = 0; i <=30; i++){

    if (divisivel % 3 == 0 || divisivel % 4 == 0)
    {
        Console.WriteLine(divisivel);
        
    }
    divisivel++;
}

Console.WriteLine("--------------------------");

#endregion

#region Exercicio 3

int fib1 = 0;
int fib2 = 1;
int fib3 = fib1 + fib2;

Console.WriteLine(fib1);
Console.WriteLine(fib2);

while (fib3 <= 100){
    Console.WriteLine(fib3);
    fib1 = fib2;
    fib2 = fib3;
    fib3 = fib1 + fib2;

}

Console.WriteLine("--------------------------");

#endregion

