using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAeoroporto.Models;

namespace ProjetoAeoroporto.Controllers
{
    class Viagens
    {
        private Queue<Viagem> queueViagens;

        public Viagens()
        {
            this.queueViagens = new Queue<Viagem>();
        }

        public Queue<Viagem> QueueViagens { get { return queueViagens; } }

        public void incluir(Viagem viagem)
        {
            queueViagens.Enqueue(viagem);
        }
    }
}
