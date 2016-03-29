using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Desejo
    {
        public int IDDesejo { get; set; }
        public Amigo Solicitante { get; set; }
        public Amigo Solicitado { get; set; }
        public double Valor { get; set; }
        public DateTime DataDesejo { get; set; }
        public String Descricao { get; set; }
    }
}
