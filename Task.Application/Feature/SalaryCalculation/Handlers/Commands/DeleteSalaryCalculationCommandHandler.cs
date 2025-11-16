using AutoMapper;
using MediatR;
using Task.Application.Contracts;
using Task.Application.Feature.SalaryCalculation.Requests.Commands;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Handlers.Commands
{
    public class DeleteSalaryCalculationCommandHandler : IRequestHandler<DeleteSalaryCalculationCommandRequest, SalaryCalculationDto>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSalaryCalculationCommandHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<SalaryCalculationDto> Handle(DeleteSalaryCalculationCommandRequest request, CancellationToken cancellationToken)
        {

            var entity = await _unitOfWork.SalariesCalculation.GetAsync(request.Id);

            if (entity == null)
                return null;

            await _unitOfWork.SalariesCalculation.DeleteAsync(entity);

            await _unitOfWork.SaveChangesAsync();

            var dto = _mapper.Map<SalaryCalculationDto>(entity);

            return dto;
        }
    }
}
