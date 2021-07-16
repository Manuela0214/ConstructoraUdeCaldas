using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Constructora.Models.ParametersModule
{
    public class PropertyModel
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string code;

        [DisplayName("Codigo")]
        [Required()]
        [MaxLength(50)]
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private string name;

        [DisplayName("Nombre")]
        [Required()]
        [MaxLength(50)]
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

        [DisplayName("Bloque")]
        [Required()]
        public int BlockId
        {
            get { return blockId; }
            set { blockId = value; }
        }


        private BlockModel block;

        public BlockModel Block
        {
            get { return block; }
            set { block = value; }
        }


        private IEnumerable<BlockModel> blockList;

        public IEnumerable<BlockModel> BlockList
        {
            get { return blockList; }
            set { blockList = value; }
        }
    }
}