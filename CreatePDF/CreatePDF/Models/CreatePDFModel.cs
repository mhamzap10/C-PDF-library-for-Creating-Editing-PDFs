using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CreatePDF.Models
{
    public class CreatePDFModel
    {
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        [DisplayName("Create From URL")]
        public bool isURL { get; set; }
    }
}
