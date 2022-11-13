using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class Produto
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int quantidade { get; set; }
        public float precoUnitario { get; set; }
        public string fornecedor { get; set; }
        public DateTime dataHoraInsercao { get; set; }
        public DateTime dataHoraExclusao { get; set; }
    }
