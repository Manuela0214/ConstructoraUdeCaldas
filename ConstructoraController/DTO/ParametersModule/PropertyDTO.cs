using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ConstructoraController.DTO.ParametersModule
{
    public class PropertyDTO : DTOBase
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
        private int blockId;

        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }

        private BlockDTO block;

        public BlockDTO Block
        {
            get { return block; }
            set { block = value; }
        }

        private IEnumerable<BlockDTO> blockList;

        public IEnumerable<BlockDTO> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }

    }
}
