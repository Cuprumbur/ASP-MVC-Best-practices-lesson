using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Договоры с городом на аренду только на отдельно стоящие рекламные конструкции
    /// </summary>
    public class Contract
    {
        public int ContractId { get; set; }
        public string NumberContract { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}