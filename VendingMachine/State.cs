﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    interface State
    {
        void BuyProduct(VendingMachine machine);
    }
}
