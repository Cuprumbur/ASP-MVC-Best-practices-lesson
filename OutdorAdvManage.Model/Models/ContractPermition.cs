using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Заявление на выдачу разрешения
    /// </summary>
    public class ContractPermition
    {
        public int ContractPermitionsId { get; set; }
        public int Number { get; set; }
        public DateTime Time { get; set; }
    }
}