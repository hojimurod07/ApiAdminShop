using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Application.Common.Helpers;

public class HttpContextHelper
{
    public static IHttpContextAccessor Accessor;
    public static HttpContext HttpContext => Accessor.HttpContext;
    public static IHeaderDictionary RequestHeaders => HttpContext.Request.Headers;
    public static IHeaderDictionary ResponseHeaders => HttpContext.Response.Headers;
    public static int UserId => int.Parse(HttpContext.User.FindFirst("Id")!.Value);
}