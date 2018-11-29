using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAeoroporto.Models
{
    public class Viagem
    {
        private int id;
        private Garagem origem;
        private Garagem destino;
        private Veiculo veiculo;

        public Viagem(int id, Garagem origem, Garagem destino, Veiculo veiculo) {
            this.id = id;
            this.origem = origem;
            this.destino = destino;
            this.veiculo = veiculo;
        }

        public int Id { get { return id; } }
        public Garagem Origem { get { return origem; } }
        public Garagem Destino { get { return destino; } }
        public Veiculo Veiculo { get { return veiculo; } }
    }
}
