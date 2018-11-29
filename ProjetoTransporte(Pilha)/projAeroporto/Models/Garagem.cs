using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAeoroporto.Models
{
    public class Garagem
    {
        private int id;
        private string local;
        private Stack<Veiculo> veiculos;

        public Garagem(int id, string local) {
            this.id = id;
            this.local = local;
            this.veiculos = new Stack<Veiculo>();
        }

        public int Id { get { return id; } }
        public string Local { get { return local; } set { local = value; } }
        public Stack<Veiculo> Veiculos { get { return veiculos; } }

        public int qtdeDeVeiculos() {
            return veiculos.Count;
        }

        public int potencialDeTransporte() {
            int potencial = 0;
            foreach (Veiculo veiculo in veiculos)potencial += veiculo.Lotacao;
            return potencial;
        }

        public void adicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Push(veiculo);
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            Garagem garagem = (Garagem)obj;
            return this.id == garagem.id;
        }
    }
}
