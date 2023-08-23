using System;
using System.Text;

namespace HtmlEditor;

public static class Editor 
{
	public static void Show() 
	{
		Console.Clear();
		// Console.BackgroundColor	= ConsoleColor.White;
		// Console.ForegroundColor	= ConsoleColor.Black;
		// Console.Clear();
		Console.WriteLine("MODO EDITOR");
		Console.WriteLine("---------------");
		Start();
	}
	public static void Start() 
	{
		var file = new StringBuilder();
		ConsoleKeyInfo keyInfo;

		do
        	{
			keyInfo = Console.ReadKey();

			if (keyInfo.Key == ConsoleKey.Enter)
			{
				file.AppendLine(); // Adicionar nova linha ao StringBuilder
				Console.WriteLine();
			}
			else if (keyInfo.Key == ConsoleKey.Escape)
			{
				break;
			}
			else if (keyInfo.Key == ConsoleKey.Backspace) 
			{
				if (file.Length > 0)
				{
					file.Remove(file.Length - 1, 1); // Remover o último caractere
					Console.Write("\b \b"); // Apagar o caractere impresso
				}
			}
			else
			{
				file.Append(keyInfo.KeyChar); // Adicionar caractere ao StringBuilder
			}
		} while (true);
		
		Console.WriteLine("\nD");
		Console.WriteLine("------------------------------------");
		Console.WriteLine(" Deseja salvar o Arquivo? (sim/nao)");
		Console.WriteLine("------------------------------------");

		var pergunta = Console.ReadLine();
		if (pergunta !=  null && pergunta.ToUpper().Contains("SIM")) 
		{
			SaveFile(file.ToString());
		}
		else 
		{
			Menu.Show();
		}		
	}
	public static void SaveFile(string text) {

		Console.Clear();

		Console.WriteLine(" Digite o nome do arquivo de texto:");
		Console.Write(" ===>");
		var fileName = Console.ReadLine();
		
		if (File.Exists($"{Program.savePath}{fileName}{Program.fileExtension}")) 
		{
			Console.WriteLine("Existe um arquivo com esse nome deseja sobrescrever? (sim/nao ou 0 para MENU)");
			var pergunta = Console.ReadLine();
			if (pergunta == "0") 
			{
				Menu.Show();
			}
			else if (pergunta !=  null && !pergunta.ToUpper().Contains("SIM")) 
			{
				SaveFile(text);
			}
		}
		
		//Close files automatically
		// using(var file = new StreamWriter($"{Program.savePath}{fileName}{Program.fileExtension}")) {

		// 	file.WriteLine(text);
		// }
		
		Program.Shellexec($"echo '{text.Trim('\n').Trim('\n').Trim('\n')}' > {Program.savePath}{fileName}{Program.fileExtension}");
		Thread.Sleep(2500);

		Console.WriteLine(" Arquivo salvo com sucesso!");
		Thread.Sleep(2500);
		Menu.Show();
	}
}