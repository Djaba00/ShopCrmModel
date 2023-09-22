﻿using ShopCRM.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmWinForm.VIewModels
{
    public class SellerViewModel
    {
        public int SellerId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CheckViewModel> Checks { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
