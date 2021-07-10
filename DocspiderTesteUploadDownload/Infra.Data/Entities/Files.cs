using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Entities
{
    public class Files
    {
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] DataFiles { get; set; }

        public Files(string FileName, string ContentType, byte[] DataFiles)
        {
            this.FileName = FileName;
            this.ContentType = ContentType;
            this.DataFiles = DataFiles;
        }
    }

   
}
