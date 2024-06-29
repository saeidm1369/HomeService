﻿using BaseFramework;
using HomeService.Domain.Core.ServiceAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.ServiceAgg.Data
{
    public interface IServiceRequestImageRepository : IRepository<ServiceRequestImage>
    {
        Task<IEnumerable<ServiceRequestImage>> GetByServiceRequestIdAsync(int serviceRequestId);
    }
}
