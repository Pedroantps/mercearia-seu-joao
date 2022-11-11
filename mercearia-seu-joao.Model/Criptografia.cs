using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

public static class Criptografia
{
    public static string CriptografarBase64(string senha)
    {
        var txtEmBytes = Encoding.UTF8.GetBytes(senha);
        return Convert.ToBase64String(txtEmBytes);
    }

    public static string CriptografarMD5(string senha)
    {
        MD5 md5 = MD5.Create();

        byte[] txtEmBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));
        StringBuilder stringBuilder = new StringBuilder();
        for (int i = 0; i < txtEmBytes.Length; i++)
        {
            stringBuilder.Append(txtEmBytes[i].ToString("x2"));
        }

        return stringBuilder.ToString();
    }
}
