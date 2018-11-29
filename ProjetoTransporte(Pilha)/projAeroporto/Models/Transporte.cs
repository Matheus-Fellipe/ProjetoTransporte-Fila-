using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAeoroporto.Models
{
    public class Transporte
    {
        private Veiculo veiculo;
        private int qtdeTrasnportada;

        public Transporte(Veiculo veiculo, int qtdeTransportada)
        {
            this.veiculo = veiculo;
            this.qtdeTrasnportada = qtdeTransportada;
        }

        public Veiculo Veiculo { get { return veiculo; } }
        public int QtdeTrasnportada { get { return qtdeTrasnportada; } set { qtdeTrasnportada = value; } }
    }
}
