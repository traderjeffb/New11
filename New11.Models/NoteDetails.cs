﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace New11.Models
{
    public class NoteDetail
    {
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset ModifiedUtc { get; set; }
        public override string ToString() => $"[{NoteId}] {Title }";
   

    }
}
