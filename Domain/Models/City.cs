using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class City
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int DistrictId {  get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }
        public string Tz { get; set; }
        public string TimeZone {  get; set; }
        public string TimeZone2 {  get; set; }  


    }
}
