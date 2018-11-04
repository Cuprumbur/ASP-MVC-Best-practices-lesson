using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Разрешение на установку рекламной конструкции
    /// </summary>
    public class Resolution
    {
        public int ResolutionId { get; set; }
        public int Number { get; set; }
        public DateTime Time { get; set; }

        /// <summary>
        ///  Рекламораспостранитель
        /// </summary>
        public virtual Counterparty Сounterparty { get; set; }

        /// <summary>
        // Собственник земельного участка.Здания или иного недвижимого имущества,
        // к которому присоединена рекламная конструкция
        /// </summary>
        public virtual Owner Owner { get; set; }

        public virtual AdvertisingConstruction Construction { get; set; }

        /// <summary>
        /// Содержание рекламы
        /// </summary>
        public string AdvertisingContent { get; set; }

        //Срок действия разрешения
        public DateTime Start { get; set; }

        public DateTime Finish { get; set; }

        /// <summary>
        /// Основание выдачи
        /// </summary>
        public virtual ContractPermition ContractPermitions { get; set; }
    }
}