using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace TODO.API.Models.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }


        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);

        }

        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {

            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();


            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        public static PagedList<TDestination> ToMappedPagedList<TSource, TDestination>(PagedList<TSource> list, IMapper mapper)
        {
            List<TDestination> sourceList = mapper.Map<List<TSource>, List<TDestination>>(list);
            PagedList<TDestination> pagedResult = new PagedList<TDestination>(sourceList,list.TotalCount,list.CurrentPage,list.PageSize);
            return pagedResult;

        }
    }


}