using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Enums
{
    public enum VendaStatus
    {
        Unknown = 0,
        Active,
        Inactive,
        Suspended,
        [EnumMember(Value = "Não Cancelada")]
        NaoCancelada
    }
}
