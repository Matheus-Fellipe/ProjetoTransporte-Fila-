using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAeoroporto.Models;

namespace ProjetoAeoroporto.Controllers
{
    public class Veiculos
    {
        private List<Veiculo> listVeiculos;

        public Veiculos()
        {
            this.listVeiculos = new List<Veiculo>();
        }

        public List<Veiculo> ListVeiculos { get { return listVeiculos; } }

        public void incluir(Veiculo veiculo)
        {
            listVeiculos.Add(veiculo);
        }
    }
}
