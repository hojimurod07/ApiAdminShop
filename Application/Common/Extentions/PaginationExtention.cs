using Microsoft.EntityFrameworkCore;
using Application.Common.Helpers;
using Application.Common.Utils;
using Newtonsoft.Json;

namespace Application.Common.Extentions;

public static class PaginationExtention
{
    public static async Task<IEnumerable<T>> ToPagedListAsync<T>(this IQueryable<T> source,
                                                            PaginationParams @params)
    {
        if (@params.PageIndex == 0 || @params.PageSize == 0)
            @params = new PaginationParams(1, 10);

        var count = await source.CountAsync();

        var metadata = new PaginationMetadata(count, @params.PageIndex, @params.PageSize);

        HttpContextHelper.ResponseHeaders.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

        return source.Skip(@params.SkipCount())
                            .Take(@params.PageSize);
    }
}
