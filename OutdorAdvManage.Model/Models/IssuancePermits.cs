using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Описывает запсь журнала выдачи разрешений
    /// </summary>
    public class IssuancePermit

    {
        public int IssuancePermitId { get; set; }

        public virtual Resolution Resolution { get; set; }

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

        public virtual Contract Contract { get; set; }
    }
}