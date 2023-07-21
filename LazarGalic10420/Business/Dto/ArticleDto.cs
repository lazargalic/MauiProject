using LazarGalic10420.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Dto
{
    public class ArticleResponse : BaseViewModel
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        public int PagesCount { get; set; }
        public IEnumerable<GetArticlesDto> Data { get; set; }
    }

    public class GetArticlesDto
    {
        public int Id { get; set; }
        public string NameArticle { get; set; }
        public string MainPicturePath { get; set; }
        public string Description { get; set; }
        public DateTime Beggin { get; set; }
        public DateTime End { get; set; }
        public int CategoryDimensionId { get; set; }
        public int EmotionsNumber { get; set; }
        public AuthorDto Author { get; set; }
        public TownshipDto Township { get; set; }

    }

    public class AuthorDto
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
    public class TownshipDto
    {
        public int Id { get; set; }
        public string NameTownship { get; set; }
        public int IdCountry { get; set; }
        public string NameCountry { get; set; }
    }


 
}
