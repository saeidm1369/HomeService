using AutoMapper;
using HomeService.Domain.Core.PaymentAgg.AppServices;
using HomeService.Domain.Core.PaymentAgg.Data;
using HomeService.Domain.Core.PaymentAgg.DTOs;
using HomeService.Domain.Core.PaymentAgg.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.AppServices.PaymentAgg
{
    public class PaymentStatusAppService : IPaymentStatusAppService
    {
        private readonly IPaymentStatusRepository _paymentStatusRepository;
        private readonly IMapper _mapper;

        public PaymentStatusAppService(IPaymentStatusRepository paymentStatusRepository, IMapper mapper)
        {
            _paymentStatusRepository = paymentStatusRepository;
            _mapper = mapper;
        }

        public async Task<PaymentStatusDTO> GetPaymentStatusByIdAsync(int id)
        {
            var paymentStatus = await _paymentStatusRepository.GetByIdAsync(id);
            return _mapper.Map<PaymentStatusDTO>(paymentStatus);
        }

        public async Task<IEnumerable<PaymentStatusDTO>> GetAllPaymentStatusesAsync()
        {
            var paymentStatuses = await _paymentStatusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PaymentStatusDTO>>(paymentStatuses);
        }

        public async Task CreatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto)
        {
            var paymentStatus = _mapper.Map<PaymentStatus>(paymentStatusDto);
            await _paymentStatusRepository.AddAsync(paymentStatus);
        }

        public async Task UpdatePaymentStatusAsync(PaymentStatusDTO paymentStatusDto)
        {
            var paymentStatus = _mapper.Map<PaymentStatus>(paymentStatusDto);
            await _paymentStatusRepository.UpdateAsync(paymentStatus);
        }

        public async Task DeletePaymentStatusAsync(int id)
        {
            await _paymentStatusRepository.DeleteAsync(id);
        }

        public async Task<PaymentStatusDTO> GetPaymentStatusByNameAsync(string name)
        {
            var paymentStatus = await _paymentStatusRepository.GetByNameAsync(name);
            return _mapper.Map<PaymentStatusDTO>(paymentStatus);
        }
    }
}
