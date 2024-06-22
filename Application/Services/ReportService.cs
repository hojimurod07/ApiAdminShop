using Application.Common.ReportModels;
using Application.Interfaces;
using Data.Interfaces;

namespace Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork): IReportService
    {
        public Task<ReportResult> GetAnnualReportAsync(AnnualReport annualReport)
        {
            throw new NotImplementedException();
        }

        public Task<ReportResult> GetDailyReportAsync(DailyReport annualReport)
        {
            throw new NotImplementedException();
        }

        public Task<ReportResult> GetMonthlyReportAsync(MonthlyReport annualReport)
        {
            throw new NotImplementedException();
        }

        public Task<ReportResult> GetRengeReportAsync(RangeReport rangeReport)
        {
            throw new NotImplementedException();
        }

        public Task<ReportResult> GetWeeeklReportAsync(ReportResult resrtResult)
        {
            throw new NotImplementedException();
        }
    }
}
