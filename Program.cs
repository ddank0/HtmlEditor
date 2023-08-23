using System.Diagnostics;

namespace HtmlEditor;

class Program
{
	public static string savePath 		= "/mnt/c/dev/c#/HtmlEditor/saves/"; //global variable to static method
	public static string fileExtension 	= ".txt"; 

	static void Main(string[] args)
	{
		CheckDir(savePath, false);
		Menu.Show();
	}
	public static void CheckDir(string dir, bool log = true)
	{
		if (!Directory.Exists(dir)) {
			Shellexec($"rm -r {dir.TrimEnd('/')} 2> /dev/null");
			DirectoryInfo create = Directory.CreateDirectory(dir);
			if (log) {
				Console.WriteLine("Pasta criada com sucesso em {0}.", Directory.GetCreationTime(dir));
			}
		}
	}

	public static void Shellexec(string comando) {

		// Criação de um processo
		Process processo 				= new Process();

		processo.StartInfo.FileName 			= "/bin/bash"; 		// Shell no Linux
		processo.StartInfo.Arguments 			= $"-c \"{comando}\""; 	// Passando o comando como argumento
		processo.StartInfo.RedirectStandardOutput 	= true; 		// Redirecionando a saída padrão
		processo.StartInfo.UseShellExecute 		= false; 		// Não usar o shell padrão
		processo.StartInfo.CreateNoWindow 		= true; 		// Não criar janela de console

		// Iniciar o processo e aguardar a conclusão
		processo.Start();
		// string resultado = processo.StandardOutput.ReadToEnd();
		processo.WaitForExit();

		// Exibir a saída do comando
		// Console.WriteLine(resultado);
	}
}
