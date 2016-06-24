using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Emotible.Model
{
    public class EmoteModel
    {
        [Key()]
        public int Id { get; set; }
        [MaxLength(64)]
        public string Name { get; set; }
        public string Content { get; set; }
        public int TimesUsed { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public DateTime LastUsed { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
