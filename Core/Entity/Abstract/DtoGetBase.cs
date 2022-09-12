using Core.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Abstract
{
    public abstract class DtoGetBase : IDto
    {
        public virtual ResultStatus ResultStatus { get; set; }
        public virtual string Message { get; set; } = string.Empty;
    }
}
