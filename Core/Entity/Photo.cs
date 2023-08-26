using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class Photo : BaseEntity
    {
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string Storage { get; set; }
    }
}
