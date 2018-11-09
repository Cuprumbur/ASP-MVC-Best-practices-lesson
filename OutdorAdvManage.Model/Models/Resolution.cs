using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Разрешение на установку рекламной конструкции
    /// </summary>
    public class Resolution
    {
        public int ResolutionId { get; set; }
        public int Number { get; set; }

        /// <summary>
        /// Дата договора
        /// </summary>
        public DateTime Time { get; set; }

        public int СounterpartyId { get; set; }

        /// <sumary>
        ///  Рекламораспостранитель
        /// </summary>
        [ForeignKey(nameof(СounterpartyId))]
        public virtual Counterparty Сounterparty { get; set; }

        public int OwnerId { get; set; }

        /// <summary>
        // Собственник земельного участка.Здания или иного недвижимого имущества,
        // к которому присоединена рекламная конструкция
        /// </summary>
        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; }

        public int AdvertisingConstructionId { get; set; }

        [ForeignKey(nameof(AdvertisingConstructionId))]
        public virtual AdvertisingConstruction AdvertisingConstruction { get; set; }

        /// <summary>
        /// Содержание рекламы
        /// </summary>
        public string AdvertisingContent { get; set; }

        //Срок действия разрешения
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ContractPermitionId { get; set; }

        /// <summary>
        /// Основание выдачи
        /// </summary>
        [ForeignKey(nameof(ContractPermitionId))]
        public virtual ContractPermition ContractPermition { get; set; }
    }
}