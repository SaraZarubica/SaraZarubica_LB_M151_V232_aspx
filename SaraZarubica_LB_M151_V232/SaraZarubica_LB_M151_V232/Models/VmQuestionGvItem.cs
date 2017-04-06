using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaraZarubica_LB_M151_V232.Models
{
    public class VmQuestionGvItem
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public int CategoryId { get; set; }
        public string CategoryText { get; set; }
    }
}