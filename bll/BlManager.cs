﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BlManager
    {


        public BlManager()

         {   ServiceCollection collections = new ServiceCollection();


            var serviceprovider = collections.BuildServiceProvider();


        }
    }
}
