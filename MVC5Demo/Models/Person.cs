using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class Person
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "請輸入姓名")]
        [DisplayName("姓名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "請輸入年紀")]
        [Range(18, 99, ErrorMessage = "年紀限制{1}~{2}")]
        [DisplayName("年紀")]
        public int Age { get; set; }
    }
}