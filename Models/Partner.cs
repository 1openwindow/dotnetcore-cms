using System;
using System.Collections.Generic;

namespace Sky.SelfServe.Models
{
    public partial class Partner
    {
        public int PartnerId { get; set; }
        public string Url { get; set; }
        public string TileName { get; set; }
        public string TileImageUrl { get; set; }
        public string TileLink { get; set; }
        public string TileDescription { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
