using AutoMapper;
using MediatR;
using Task.Application.Common;
using Task.Application.Contracts;
using Task.Application.Feature.SalaryCalculation.Requests.Queries;
using Task.Shared.DTOs.SalaryCalculation;

namespace Task.Application.Feature.SalaryCalculation.Handlers.Queries
{
    public class GetRengeSalaryCalculationQueryHandler : IRequestHandler<GetRengeSalaryCalculationQueryRequest, List<SalaryCalculationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDataParser _dataParser;

        public GetRengeSalaryCalculationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IDataParser dataParser)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _dataParser = dataParser;
        }
        public async Task<List<SalaryCalculationDto>> Handle(GetRengeSalaryCalculationQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.salaryCalculationDapperRepository.GetRangeSalariesCalculationAsync(request.FromDate, request.ToDate);
            var dtos = _mapper.Map<List<SalaryCalculationDto>>(entities);
            return dtos;
        }
    }
}
