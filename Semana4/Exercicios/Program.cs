
public class Veiculo{

    public string Modelo { get; set; }
    public string Ano { get; set; }
    public string Cor { get; set; }

}

class Program
{
    static void Main(string[] args){

    Veiculo veiculo= new Veiculo();

    veiculo.Modelo="Mustang Shelby";
    veiculo.Cor="Branco";
    veiculo.Ano="2018";


    System.Console.WriteLine(veiculo.Modelo);
    System.Console.WriteLine(veiculo.Cor);
    System.Console.WriteLine(veiculo.Ano);


    }
    
}

