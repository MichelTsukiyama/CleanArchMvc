using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; protected set; }

        //Exemplo de atributos que pode ser comuns e usados em uma classe base
        //public DateTime CreatedDate { get; set; }
        //public DateTime? ModifiedDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string ModifiedBy { get; set; }
    }
}
