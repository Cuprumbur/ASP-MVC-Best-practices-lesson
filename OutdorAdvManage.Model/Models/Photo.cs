using System;

namespace OutdorAdvManage.Model.Models
{
    /// <summary>
    /// Фото
    /// </summary>
    public class Photo
    {
        public int PhotoId { get; set; }
        public string Image { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}