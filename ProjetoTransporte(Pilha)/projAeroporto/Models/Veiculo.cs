using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAeoroporto.Models
{
    public class Veiculo
    {
        private int id;
        private string placa;
        private int lotacao;

        public Veiculo(int id, string placa, int lotacao) {
            this.id = id;
            this.placa = placa;
            this.lotacao = lotacao;
        }

        public int Id { get { return id; } }
        public string Placa { get { return placa; } set { placa = value; } }
        public int Lotacao { get { return lotacao; } set { lotacao = value; } }
    }
}
