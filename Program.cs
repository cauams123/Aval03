using System;
using System.IO;

internal class Program              //Cauã Moreira Schmidt
{
    string textoCifrado;
    string textoDecifrado;
    Program()
    {
        textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");
        textoDecifrado = "";

        for (int i = 0; i < textoCifrado.Length; i++)
        {
            int numerosInt;

            if (i % 5 == 0)
            {
                numerosInt = textoCifrado[i] - 8;
            }
            else
            {
                numerosInt = textoCifrado[i] - 16;
            }

            char caracterDecifrado = (char)numerosInt;
            textoDecifrado += caracterDecifrado;
        }
        textoDecifrado = textoDecifrado.Replace('@', '\n');

        MostraConteudoTextoCifrado();
        EncontraPalindromos();
        MostraNumeroCaracteresTextoDecifrado();
        MostraQuantidadePalavrasTextoDecifrado();
        MostraTextoDecifradoEmMaiusculo();
    }
    void MostraConteudoTextoCifrado()
    {
        Console.WriteLine("Conteúdo do texto cifrado:");
        Console.WriteLine(textoCifrado);
    }
    void EncontraPalindromos()
    {
        string[] palindromos = { "gloriosa", "bondade", "passam" };
        string[] palavras = textoDecifrado.Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

        Console.WriteLine("\nPalíndromos encontrados:");
        int indicePalindromo = 0;
        for (int i = 0; i < palavras.Length; i++)
        {
            if (ehPalindromo(palavras[i]))
            {
                if (indicePalindromo < palindromos.Length)
                {
                    Console.WriteLine($"{palavras[i]} -> {palindromos[indicePalindromo]}");
                    indicePalindromo++;
                }
            }
        }
    }
    void MostraNumeroCaracteresTextoDecifrado()
    {
        int numeroCaracteres = textoDecifrado.Length;
        Console.WriteLine($"\nNúmero de caracteres do texto decifrado: {numeroCaracteres}");
    }
    void MostraQuantidadePalavrasTextoDecifrado()
    {
        string[] palavras = textoDecifrado.Split(new[] { ' ', '.', ',', '!', '?', ':', ';' }, StringSplitOptions.RemoveEmptyEntries);
        int numeroPalavras = palavras.Length;
        Console.WriteLine($"Quantidade de palavras no texto decifrado: {numeroPalavras}");
    }
    void MostraTextoDecifradoEmMaiusculo()
    {
        string textoMaiusculo = textoDecifrado.ToUpper();
        Console.WriteLine($"\nTexto decifrado em maiúsculo:\n{textoMaiusculo}");
    }
    static bool ehPalindromo(string palavra)     
    {
        int length = palavra.Length;     
        if (length < 3)  // comando para ignorar as palavras que tem menos de 3 caracteres
        {
            return false; 
        }

        for (int i = 0; i < length / 2; i++)
        {
            if (palavra[i] != palavra[length - i - 1])
            {
                return false;
            }
        }
        return true;
    }
    static void Main(string[] args)
    {
        _ = new Program();

    }
}