using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Собственник рекламной конструкции
    /// </summary>
    public class Owner
    {
        public int OwnerId { get; set; }

        public int? CounterpartyId { get; set; }

        /// <summary>
        /// Собственик
        /// </summary>
        [ForeignKey(nameof(CounterpartyId))]
        public Counterparty Сounterparty { get; set; }

        public int? ConstructionId { get; set; }

        [ForeignKey(nameof(ConstructionId))]
        public AdvertisingConstruction Construction { get; set; }

        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}