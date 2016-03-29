using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Amigo
    {
        public int IDAmigo { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
