using System.Collections.Generic;
using System.Drawing;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Рекламная конструкция
    /// </summary>
    public class AdvertisingConstruction
    {
        public int AdvertisingConstructionId { get; set; }
        public string Description { get; set; }
        public string TypeContsruction { get; set; }
        public Size Size { get; set; }
        public int NumberSides { get; set; }
        // public System.Device.Location.CivicAddressResolver Address { get; set; }
        // public System.Device.Location.GeoCoordinate Coordinate { get; set; }
        public virtual List<Counterparty> Photos { get; set; }
        public int NumberInSheme { get; set; }

        //Дополнительное описание Адреса?
        //Координаты фундамента?
        //Другие характеристики7
    }
}