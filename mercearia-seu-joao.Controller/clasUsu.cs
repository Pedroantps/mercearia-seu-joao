using System;

public class clasUsu
{
	public static Usuario BuscarDados(string email, string senha)
	{
		return ConsultaUsuario.BuscaDados(email, senha);
	}
}
