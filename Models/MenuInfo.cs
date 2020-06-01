using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzApp.Models
{
    public class MenuInfo
    {

        public int MenuId { get; set; }
        public int ParentMenuId { get; set; }
        public String PageName { get; set; }
        public String MenuName { get; set; }
        public String IconName { get; set; }
    }
}
