// O "Exercicio1" está no arquivo "Exercicio1.md"

#region Exercicio2

// sbyte: Representa um inteiro de 8 bits com sinal (de -128 a 127).
sbyte mySByte = 42;
Console.WriteLine($"MySByte: {mySByte}");

// byte: Representa um inteiro de 8 bits sem sinal (de 0 a 255).
byte myByte = 255;
Console.WriteLine($"MyByte: {myByte}");

// short: Representa um inteiro de 16 bits com sinal (de -32,768 a 32,767).
short myShort = 1000;
Console.WriteLine($"MyShort: {myShort}");

//ushort: Representa um inteiro de 16 bits sem sinal (de 0 a 65,535).
ushort myUShort = 60000;
Console.WriteLine($"MyUShort: {myUShort}");

// int: Representa um inteiro de 32 bits com sinal (de -2.147.483.648 a 2.147.483.647).
int myInt = 2147483647;
Console.WriteLine($"MyInt: {myInt}");

// uint: Representa um inteiro de 32 bits sem sinal (de 0 a 4.294.967.295).
uint myUInt = 4000000000;
Console.WriteLine($"MyUInt: {myUInt}");

// long: Representa um inteiro de 64 bits com sinal (de -9.223.372.036.854.775.808 a 9.223.372.036.854.775.807).
long myLong = 9000000000000000000;
Console.WriteLine($"MyLong: {myLong}");

// ulong: Representa um inteiro de 64 bits sem sinal (de 0 a 18.446.744.073.709.551.615).
ulong myULong = 18000000000000000000;
Console.WriteLine($"MyULong: {myULong}");

Console.WriteLine("------------------------------");
#endregion

#region Exercicio3
/**Não é possível converter um valor do tipo long implicitamente para um valor do tipo int
pois existe uma hierarquia que deve ser respeitada para que haja uma conversão implicita (casting implícito).
Essa hierarquia **/
double A = 3.14;
Console.WriteLine(A);

int B = (int)A; //conversao explícita utilizando cast.
Console.WriteLine(B); //Dessa forma, porém, a parte fracionária é cortada.

Console.WriteLine("------------------------------");
Console.WriteLine("\n");

#endregion

#region Exercicio4

int x = 10;
int y = 3;

Console.WriteLine("========== Calculadora automática em C#! ==========");

Console.WriteLine($"Soma: {x} + {y} = {x + y}");
Console.WriteLine($"Subtração: {x} - {y} = {x - y}");
Console.WriteLine($"Multiplicação: {x} * {y} = {x * y}");
Console.WriteLine($"Subtração: {x} / {y} = {x / y}");

Console.WriteLine("------------------------------");
Console.WriteLine("\n");

#endregion

#region Exercicio5

int a = 5;
int b = 8;

if (a > b)
{
    Console.WriteLine($"{a} é maior que {b}.");
}
else
{
    Console.WriteLine($"{a} não é maior que {b}.");
}

Console.WriteLine("------------------------------");
Console.WriteLine("\n");

#endregion

#region Exercicio6

string str1 = "Hello";
string str2 = "World";

if (str1 == str2)
{
    Console.WriteLine($"{str1} é igual a {str2}");
}
else
{
    Console.WriteLine($"{str1} não é igual a {str2}");
}

Console.WriteLine("------------------------------");
Console.WriteLine("\n");

#endregion

#region Exercicio7

bool condicao1 = true;
bool condicao2 = false;

if (condicao1 & condicao2)
{
    Console.WriteLine($"{condicao1} e {condicao2}. Ambas são condições verdadeiras.");
}
else
{
    Console.WriteLine($"{condicao1} e {condicao2}. Uma ou nenhuma das condições não são verdadeiras.");
}

Console.WriteLine("------------------------------");
Console.WriteLine("\n");

#endregion

#region Exercicio8

int num1 = 7;
int num2 = 3;
int num3 = 10;

bool ehMaior()
{

    if (num1 > num2)
    {
        return true;
    }
    else
    {
        return false;
    }
}

bool ehIgual()
{
    if (num3 == (num1 + num2))
    {
        return true;
    }
    else
    {
        return false;
    }
}

if (ehMaior() && ehIgual())
{
    Console.WriteLine($"{num1} é maior que {num2} e {num3} é igual a {num1} + {num2}");
}
else if (ehMaior() || ehIgual())
{
    if (ehMaior())
    {
        Console.WriteLine($"{num1} é maior que {num2}, mas {num3} não é igual a {num1} + {num2}");
    }
    else if (ehIgual())
    {
        Console.WriteLine($"{num1} não é maior que {num2}, mas {num3} é igual a {num1} + {num2}");
    }
}
else
{
    Console.WriteLine($"{num1} não é maior que {num2} e {num3} não é igual a {num1} + {num2}");
}

#endregion