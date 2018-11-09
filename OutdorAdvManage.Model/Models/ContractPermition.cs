using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Заявление на выдачу разрешения
    /// </summary>
    public class ContractPermition
    {
        public int ContractPermitionId { get; set; }
        public int Number { get; set; }
        public DateTime Time { get; set; }
    }
}