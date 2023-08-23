using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace HtmlEditor;

public static class Viewer {

	public static void Show() {
		Console.Clear();
		// Console.BackgroundColor	= ConsoleColor.White;
		// Console.ForegroundColor	= ConsoleColor.Black;
		var text = OpenFile();
		Console.Clear();
		Console.WriteLine("MODO VISUALIZACAO");
		Console.WriteLine("---------------");
		Replace(text);
		Console.WriteLine("---------------");
		Console.ReadKey();
		Menu.Show();

	}
	public static void Replace(string text) 
	{ 
		var strong 	= new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");	
		var words 	= text.Split(' ');

		for(var i = 0; i < words.Length; i++) 
		{
			if (strong.IsMatch(words[i]))
			{
				Console.ForegroundColor = ConsoleColor.Blue;
				//o substring peg aa quantidade desejada de caracteres apartir de uma posi��o
				//logo abaixo se pega a primeira ocorrencia do ">" e a ultima do "<"
				//e diminue pela primeira ocorrencia do ">" para obter o numero de carateres
				Console.Write(
					words[i].Substring(
						words[i].IndexOf('>') + 1,
						words[i].LastIndexOf('<') - 1 -
						words[i].IndexOf('>')
					)
				);
				Console.Write(' ');
			}
			else 
			{
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(words[i]);
				Console.Write(' ');
			}
		}
		Console.ForegroundColor = ConsoleColor.White;

		Console.WriteLine();

	}
	static string OpenFile() {

		Console.Clear();
		Console.WriteLine("Digite o nome do arquivo que deseja visualizar:");
		var fileName = Console.ReadLine();
		string filePath = $"{Program.savePath}{fileName}{Program.fileExtension}";
		
		if(!File.Exists(filePath)) 
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
			Console.WriteLine("ARQUIVO NAO ENCONTRADO");
			Console.ForegroundColor = ConsoleColor.White;
			Console.ReadKey();
			Menu.Show();
		}
		using(var file = new StreamReader(filePath)) {
			string text = file.ReadToEnd();
			return text;
		}
	}

	
}