﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Lab1212_todo_mvc.Models
{
    public partial class ClassIntroduce
    {
        public int InId { get; set; }
        public string InTitle { get; set; }
        public string InContent { get; set; }
        public string InCategory { get; set; }
        public byte[] InPhoto { get; set; }
        public DateTime InDate { get; set; }
        public int EId { get; set; }
        public int CId { get; set; }

        public virtual Class CIdNavigation { get; set; }
        public virtual Employee EIdNavigation { get; set; }
    }
}
