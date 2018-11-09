using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Описывает запсь журнала выдачи разрешений
    /// </summary>
    public class IssuancePermit

    {
        public int IssuancePermitId { get; set; }

        [ForeignKey(nameof(ResolutionId))]
        public  Resolution Resolution { get; set; }

        public int ResolutionId { get; set; }

        /// <summary>
        /// Госпошлина оплачена
        /// </summary>
        public bool IsStateDutyPaid { get; set; }

        /// <summary>
        /// Отметка от получении
        /// </summary>
        public bool Received { get; set; }

        /// <summary>
        /// Дата выдачи разрешения
        /// </summary>
        public DateTime IssueDate { get; set; }

        public  int ContractId { get; set; }

        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }
    }
}