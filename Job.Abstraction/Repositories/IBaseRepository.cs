﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job.Abstraction.Repositories
{
    public interface IBaseRepository<T> where T : BaseDataTableEntity
    {
    }
}
