using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

///<summary>
///
/// / ----------------------------------------------------------------------------- // 
/// Programa de Cadastro e Serialização de Alunos 
/// // ----------------------------------------------------------------------------- 
/// 
/// // Este programa permite registrar múltiplos alunos através do console, 
/// // armazenando seus dados em uma lista interna e, ao final, serializando 
/// // todos os registros para um arquivo XML.  
/// FUNCIONALIDADES PRINCIPAIS: 
/// 1. Entrada de dados pelo usuário (ID, Nome, Email, Idade). 
/// 2. Armazenamento dos alunos em uma lista dentro da classe Aluno. 
/// 3. Prevenção de duplicidade: o programa não adiciona alunos repetidos. 
/// 4. Serialização da lista de alunos para um arquivo XML usando XmlSerializer. 
///  5. Salvamento do arquivo em um caminho definido pelo usuário.

/// </summary>


Aluno aluno1 = new Aluno();



while (true)
{
    Console.WriteLine("voce deseja registrar uma nova pessoa");
    string resposta = Console.ReadLine().ToString(); 
    
    if(resposta == "sim" || resposta == "SIM")
    {
        Console.WriteLine("Digite o id ");
        int idd = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Digite o nome");
        string nomme = Console.ReadLine();
        Console.WriteLine("Digite o email");
        string emmail = Console.ReadLine();
        Console.WriteLine("Digite a idade");
        int iddade = int.Parse(Console.ReadLine());

        aluno1.Lerlista(idd, nomme, emmail, iddade);
        
    } else
    {
        break;
    }
}
var ler = aluno1.retornarvalor();

gravar gravando = new gravar(ler);
//Definição do caminho do arquivo objeto 
string caminhoArquivo = Console.ReadLine(); 
// Utilizacao do regex para validar o caminho passado..
string padrao = @"^[a-zA-Z]:\\(?:[^\\/:*?""<>|\r\n]+\\)*[^\\/:*?""<>|\r\n]*$";
if (Regex.IsMatch(caminhoArquivo, padrao))
{
    Console.WriteLine("Caminho valido!");

    // Cira um XmlSerializer para o tipo Aluno 

    XmlSerializer serializer = new XmlSerializer(typeof(List<Aluno>));

    using (StreamWriter writer = new StreamWriter(caminhoArquivo))
    { serializer.Serialize(writer, gravando.grave); }

    Console.WriteLine("Objeto serializado para XML com sucesso!");
} else
{
    Console.WriteLine("O caminho  nao segue o padrao de formatacao");
}
    Console.ReadLine();
public class Aluno
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Idade;
    public  List<Aluno> aluno = new List<Aluno>();

    public List<Aluno> recebe = new List<Aluno>(); 
    public Aluno() { }

    public Aluno(int id, string name, string email, int idade)
    {
        Id = id;
        Name = name;
        Email = email;
        Idade = idade;



    }
  
    public  void Lerlista(int id, string name, string email, int idade)
    {
         
        if (!aluno.Any(a => 
        a.Id == id && 
        a.Name == name && 
        a.Email == email &&
        a.Idade == idade))
        {
            aluno.Add(new Aluno(id, name, email, idade));
        }
        recebe = aluno;
        retornarvalor();
    }

    public List<Aluno> retornarvalor()
    {
        return recebe ;
    }
}

 

public class gravar
{
    public List<Aluno> grave { set; get; }

    public gravar() { }
    public gravar(List<Aluno> verifica)
    {
        grave = verifica; 
    }

    
    
}
 