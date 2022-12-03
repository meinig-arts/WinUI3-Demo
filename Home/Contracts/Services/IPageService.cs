using System;

namespace Home.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
