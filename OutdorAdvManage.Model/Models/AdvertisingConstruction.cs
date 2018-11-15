using System.Data.Entity.Spatial;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Рекламная конструкция
    /// </summary>
    public class AdvertisingConstruction
    {
        //public static DbGeography CreatePoint(double lat, double lon, int srid = 4326)
        //{
        //    string wkt = string.Format("POINT({0} {1})", lon, lat);
        //    return DbGeography.PointFromText(wkt, srid);
        //}
        public int AdvertisingConstructionId { get; set; }

        public string Description { get; set; }
        public string TypeContsruction { get; set; }

        //public Size Size { get; set; }
        public int NumberSides { get; set; }

        // public System.Device.Location.CivicAddressResolver Address { get; set; }
        // public System.Device.Location.GeoCoordinate Coordinate { get; set; }
        //public virtual List<Counterparty> Photos { get; set; }
        /// <summary>
        /// Номер в
        /// </summary>
        public int NumberInSheme { get; set; }

        //


        //public DbGeography Geography { get; set; }

        //Дополнительное описание Адреса?
        //Координаты фундамента?
        //Другие характеристики7
    }
}