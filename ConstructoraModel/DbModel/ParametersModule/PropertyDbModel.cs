using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructoraModel.DbModel.ParametersModule
{
    public class PropertyDbModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string identifier;

        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        private int blockId;

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }


    }
}
