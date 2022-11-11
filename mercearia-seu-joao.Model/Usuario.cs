using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Usuario
{
    public int id { get; set; }
    public string email { get; set; }
    public string senha { get; set; }
    public string nome { get; set; }
    public string tipoUsuario { get; set; }
    public DateTime dataHoraInsercao { get; set; }
    public DateTime dataHoraExclusao { get; set; }
}
