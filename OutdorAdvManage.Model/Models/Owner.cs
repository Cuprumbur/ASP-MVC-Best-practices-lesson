using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Собственник рекламной конструкции
    /// </summary>
    public class Owner
    {
        public int OwnerId { get; set; }

        /// <summary>
        /// Собственик
        /// </summary>
        public virtual Counterparty Сounterparty { get; set; }

        public virtual AdvertisingConstruction Construction { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}