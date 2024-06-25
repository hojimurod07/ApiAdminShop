using Application.Common.ReportModels;
using Application.Interfaces;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class ReportService(IUnitOfWork unitOfWork): IReportService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<ReportResult> GetAnnualReportAsync(AnnualReport annualReport)
        {
            var orders  =await _unitOfWork.Order.GetAllOrdersAsync();
            var totalAmounts = orders
            .Where(o => o.OrderDate.Year == annualReport.Year.Year).Sum(o => o.TodtalAmount);
            return new ReportResult()
            {
                StartDate = new DateOnly(annualReport.Year.Year-1, 1, 1),
                Summa = totalAmounts,
                EndDate = new DateOnly(annualReport.Year.Year, 1, 1)

            };
            


        }

        public  async Task<ReportResult> GetDailyReportAsync(DailyReport annualReport)
        {
            var orders = await _unitOfWork.Order.GetAllOrdersAsync();
            var totalAmounts = orders
            .Where(o => o.OrderDate.Day == annualReport.Day.Day).Sum(o => o.TodtalAmount);
            return new ReportResult()
            {
                StartDate = new DateOnly(annualReport.Day.Year, annualReport.Day.Month, annualReport.Day.Day),
                Summa = totalAmounts,
                EndDate = new DateOnly(annualReport.Day.Year, annualReport.Day.Month, annualReport.Day.Day)

            };
        }

        public async Task<ReportResult> GetMonthlyReportAsync(MonthlyReport annualReport)
        {
            var orders = await _unitOfWork.Order.GetAllOrdersAsync();
            var totalAmounts = orders
            .Where(o => o.OrderDate.Month == annualReport.Monthly.Month).Sum(o => o.TodtalAmount);
            return new ReportResult()
            {
                StartDate = new DateOnly(annualReport.Monthly.Year - 1, annualReport.Monthly.Month, 1),
                Summa = totalAmounts,
                EndDate = new DateOnly(annualReport.Monthly.Year - 1, annualReport.Monthly.Month, 31)

            };
        }

        public async Task<ReportResult> GetRengeReportAsync(RangeReport rangeReport)
        {
            var orders = await _unitOfWork.Order.GetAllOrdersAsync();
            var totalAmounts = orders
            .Where(o => o.OrderDate >= rangeReport.StartDate && o.OrderDate <= rangeReport.EndDate)
            .Sum(o => o.TodtalAmount);

            return new ReportResult()
            {
                StartDate = rangeReport.StartDate,
                Summa = totalAmounts,
                EndDate = rangeReport.EndDate

            };
        }

        public async Task<ReportResult> GetWeeeklReportAsync(RangeReport rangeReport)
        {
            var orders = await _unitOfWork.Order.GetAllOrdersAsync();
            var totalAmounts = orders
            .Where(o => o.OrderDate >= rangeReport.StartDate && o.OrderDate <= rangeReport.EndDate)
            .Sum(o => o.TodtalAmount);
            return new ReportResult()
            {
                StartDate = rangeReport.StartDate,
                Summa = totalAmounts,
                EndDate = rangeReport.EndDate

            };
        }
    }
}
