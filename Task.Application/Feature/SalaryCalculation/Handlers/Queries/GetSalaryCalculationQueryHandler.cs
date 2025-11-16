using AutoMapper;
using MediatR;
using Task.Application.Common;
using Task.Application.Contracts;
using Task.Application.Feature.SalaryCalculation.Requests.Queries;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Handlers.Queries
{
    public class GetSalaryCalculationQueryHandler : IRequestHandler<GetSalaryCalculationQueryRequest, SalaryCalculationDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataParser _dataParser;

        public GetSalaryCalculationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataParser dataParser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dataParser = dataParser;
        }
        public async Task<SalaryCalculationDto> Handle(GetSalaryCalculationQueryRequest request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.salaryCalculationDapperRepository.GetSalaryCalculationAsync(request.Id);
            var dto = _mapper.Map<SalaryCalculationDto>(entity);
            return dto;
        }
    }
}
