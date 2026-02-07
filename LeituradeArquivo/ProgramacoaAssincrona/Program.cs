// A classe Task representa uma operação assíncrona em execução.
// Ela é usada para executar métodos que rodam de forma não bloqueante.
// 'await' é utilizado para aguardar a conclusão de um método que retorna Task ou Task<T>. 
// O código após o 'await' só continua quando a operação assíncrona termina.
// 'async' é usado para indicar que o método é assíncrono e pode conter 'await'. // Tipos assíncronos mais comuns: // - Task ou Task<T> // - ValueTask ou ValueTask<T> // - void (somente para event handlers; evitar em outros casos) // Abaixo, simulamos operações assíncronas usando Task.Delay, 
// que representa uma espera não bloqueante.

Console.WriteLine("\nIniciando a operaçao assincrona...");
await MetodoSemRetornoAsync();

Console.WriteLine("Meotodo com retorno ");
var resultado = await MetodoconRetornooAsnyc(20);
Console.WriteLine($"Resultado: {resultado}");


static async ValueTask MetodoSemRetornoAsync()
{
    Console.WriteLine("Metodo que nao retorna valor");
    await Task.Delay(10000);
}

static async ValueTask<int> MetodoconRetornooAsnyc(int valor)
{
    Console.WriteLine("Metodo wue retorna valor");
    await Task.Delay(100);
    // Delay seira o tempo de resposta ;
    return valor * 2;

}