using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.data.db.prejectsEF.CodeFirst.models
{
    class Project
    {
        public int Id { get; set; }
        [Column(TypeName = "NVARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        
        public decimal Budget { get; set; }
        
        [Column(TypeName = "NVARCHAR")]
        [StringLength(300)]
        public string Description { get; set; }
    }
}
