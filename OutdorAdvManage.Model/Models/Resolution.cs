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
        public Counterparty Сounterparty { get; set; }

        public int OwnerId { get; set; }

        /// <summary>
        // Собственник земельного участка.Здания или иного недвижимого имущества,
        // к которому присоединена рекламная конструкция
        /// </summary>
        [ForeignKey(nameof(OwnerId))]
        public Owner Owner { get; set; }

        public int ConstructionId { get; set; }

        [ForeignKey(nameof(ConstructionId))]
        public AdvertisingConstruction Construction { get; set; }

        /// <summary>
        /// Содержание рекламы
        /// </summary>
        public string AdvertisingContent { get; set; }

        //Срок действия разрешения
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        public int ContractPermitionsId { get; set; }

        /// <summary>
        /// Основание выдачи
        /// </summary>
        [ForeignKey(nameof(ContractPermitionsId))]
        public ContractPermition ContractPermitions { get; set; }
    }
}