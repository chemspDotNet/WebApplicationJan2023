﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Layer;

namespace BLL_Layer
{
    public class BLL_LayerClass
    {

        public DataSet GetEmployee_BLL()
        {
            return new DAL_LayerClass().GetEmployees();
        }
    }
}
