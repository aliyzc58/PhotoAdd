using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class PhotoModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Tags { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string? Storage { get; set; }
        public IFormFile File { get; set; }
    }
}
