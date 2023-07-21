using LazarGalic10420.Business.Dto;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazarGalic10420.Business.Services
{
    public class ArticleService : BaseService
    {
        public ArticleResponse GetArticles(
                        DateTime beggin,      //opcioni moraju na kraju 
                        DateTime end,
                        string nameArticle = null,
                        string selectionDimension=null,
                        IEnumerable<int> selectedCountries =null
                        )
        {
            int count = 0;
            var endpoint = "/article?";

            if (!string.IsNullOrEmpty(nameArticle))
            {
                _ = count == 0 ? endpoint += "nameArticle=" : endpoint += "&nameArticle=";
                endpoint += nameArticle;
                count++;
            }
            if (!string.IsNullOrEmpty(selectionDimension))
            {
                _ = count == 0 ? endpoint += "categoryDimensionId=" : endpoint+= "&categoryDimensionId=";
                endpoint += selectionDimension;
                count++;
            }

            if (beggin != DateTime.MinValue)
            {
                _ = count == 0 ? endpoint += "Beggin=" : endpoint += "&Beggin=";
                endpoint += beggin.Date;
                count++;
            }

            if (end != DateTime.MinValue)
            {
                _ = count == 0 ? endpoint += "End=" : endpoint += "&End=";
                endpoint += end.Date;
                count++;
            }

            if (selectedCountries !=null && selectedCountries.Count() !=0)
            {
                //selectedCountries = [ 1, 2,3]
                foreach(var item in selectedCountries)
                {
                    _ = count == 0 ? endpoint += "CountriesIds=" : endpoint += "&CountriesIds=";
                    endpoint += item;
                    count++;
                }

            }

            _ = count == 0 ? endpoint += "perPage=20" : endpoint += "&perPage=20";

            // var data = Client.Get<List<Post>>(new RestRequest(endpoint)).Data;
            var data = Client.Get<ArticleResponse>(new RestRequest(endpoint)).Data;



            return data;
        }


    }
}
