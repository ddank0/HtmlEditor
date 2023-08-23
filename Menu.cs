namespace HtmlEditor;

public static class Menu 
{
	public static void Show() 
	{
		Console.Clear();
		int lineSize		=	30;
		int columnSize		=	10;
		// Console.BackgroundColor	=	ConsoleColor.Blue;
		// Console.ForegroundColor	=	ConsoleColor.Black;

		DrawScreen(lineSize, columnSize);
		WriteOptions(lineSize, columnSize);

		var option = Console.ReadLine();
		HandlerMenuOption(option, columnSize);
	}

	public static void DrawScreen(int lineSize, int columnSize)
	{
		CreateLine(lineSize);
		CreateColumn(lineSize, columnSize);
		CreateLine(lineSize);
	}
	public static void CreateLine(int lineSize, string character = "-", string separator = "+") 
	{
		Console.Write(separator);
		for (int i = 0; i <= lineSize; i++)
		{
			Console.Write(character);
		}
		Console.Write($"{separator}\n");
	}
	public static void CreateColumn(int lineSize, int columnSize, string character = "|")
	{
		for(int column = 0; column <= columnSize; column++) 
		{
			Console.Write(character);
			for (int i = 0; i <= lineSize; i++)
				Console.Write(" ");
			Console.Write($"{character}\n");	
		}
	}
	public static void WriteOptions(int lineSize, int columnSize) 
	{
		Console.SetCursorPosition(3,2);
		Console.WriteLine("Editor HTML");
		Console.SetCursorPosition(1,3);
		CreateLine(lineSize-2, "=", "=");
		Console.SetCursorPosition(3,4);
		Console.WriteLine("Selecione uma opcao abaixo:");
		Console.SetCursorPosition(3,6);
		Console.WriteLine("1 - Novo arquivo");
		Console.SetCursorPosition(3,7);
		Console.WriteLine("2 - Abrir");
		Console.SetCursorPosition(3,8);
		Console.WriteLine("0 - Sair");
		Console.SetCursorPosition(3,columnSize );
		Console.Write("Opcao: ");	
	}
	public static void HandlerMenuOption(string option, int columnSize) 
	{
		switch(option) {
			case "1":
				Editor.Show();
				break;
			case "2":
				Viewer.Show();
				break;
			case "0": 
				Console.Clear();
				Environment.Exit(0);
				break;
			default:
				Show();
				break;	
		}
	}
}