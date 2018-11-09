using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OutdorAdvManage.Web.ViewModels
{
    public class MainViewModel
    {
        public  List<Data> Datas { get; set; }
    }

    public class Data
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
    }
}