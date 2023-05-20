using MyECommerce.Entity.Enum;
using MyECommerce.Entity.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyECommerce.Entity.Base
{
    public class BaseEntity : IEntity<Guid>
    {      
        
        public BaseEntity()
        {
            IsActive = true;
            Status = Status.Created;
            CreatedDate = DateTime.Now;
            MasterId = Guid.NewGuid();
        }

        public int Id { get; set; }        
        public Guid MasterId { get; set; }

        //Created
        public DateTime CreatedDate { get; set; }
        [StringLength(255)]
        public string? CreatedComputerName { get; set; }
        [StringLength(255)]
        public string? CreatedAdUsername { get; set; }
        [StringLength(255)]
        public string? CreatedIpAddress { get; set; }

        //Updated
        public DateTime UpdatedDate { get; set; }
        [StringLength(255)]
        public string? UpdatedComputerName { get; set; }
        [StringLength(255)]
        public string? UpdatedAdUsername { get; set; }
        [StringLength(255)]
        public string? UpdatedIpAddress { get; set; }

        public bool IsActive { get; set; }
        public Status Status { get; set; }
    }
}
