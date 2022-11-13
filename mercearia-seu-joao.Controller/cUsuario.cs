using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class cUsuario
{
	public static Usuario ObterUsuarioPeloEmailSenha(string email, string senha)
    {
        return ConsultaUsuario.ObterUsuarioPeloEmailSenha(email, senha);
    }
}
