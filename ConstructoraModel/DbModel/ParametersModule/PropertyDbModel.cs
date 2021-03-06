using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

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

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int valor;

        public int Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private BlockDbModel block;

        public BlockDbModel Block
        {
            get { return block; }
            set { block = value; }
        }

        private int blockId;

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private IEnumerable<BlockDbModel> blockList;

        public IEnumerable<BlockDbModel> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }



    }
}
