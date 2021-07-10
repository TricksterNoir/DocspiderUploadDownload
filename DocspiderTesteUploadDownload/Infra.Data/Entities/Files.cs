using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Entities
{
    public class Files
    {
        public string Name { get; set; }
        public string FileType { get; set; }
        public byte[] DataFiles { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
