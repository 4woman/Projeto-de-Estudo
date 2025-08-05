using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zuplae.Aulas.Atv0012.Models
{
    public class BaseModel

    {   
        #region Atributos
          private static int id = 0;
        #endregion

        #region Id
        public int GetId()
        {
            return id;
        }
        #endregion

        #region Construtor
        public BaseModel()
        {
            id++;
        }
        #endregion
    }
}
