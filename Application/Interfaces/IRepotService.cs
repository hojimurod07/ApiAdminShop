using Application.Common.ReportModels;

namespace Application.Interfaces
{
    public  interface IReportService
    {
        public Task<ReportResult> GetAnnualReportAsync(AnnualReport annualReport);
        public Task<ReportResult> GetDailyReportAsync(DailyReport annualReport);
        public Task<ReportResult> GetMonthlyReportAsync(MonthlyReport annualReport);
        public Task<ReportResult> GetWeeeklReportAsync(ReportResult resrtResult);
        public Task<ReportResult> GetRengeReportAsync(RangeReport rangeReport);

    }
}
