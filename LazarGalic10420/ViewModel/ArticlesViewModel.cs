using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using LazarGalic10420.Business.Dto;
using LazarGalic10420.Business.Services;
using LazarGalic10420.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LazarGalic10420.ViewModel
{
    public class ArticlesViewModel : BaseViewModel
    {
        //Pretraga Pocetak
        public MProp<string> SearchNameArticle { get; set; } = new MProp<string>();
        public MProp<string> SelectionDimension { get; set; } = new MProp<string>();
        public MProp<DateTime> ArticleBeggin { get; set; } = new MProp<DateTime>();
        public MProp<DateTime> ArticleEnd { get; set; } = new MProp<DateTime>();

        public IList<int> SelectedIds { get; set; } = new List<int>();
        public MProp<bool> IsCountry1Selected { get; set; } = new MProp<bool>(); 
        public MProp<bool> IsCountry2Selected { get; set; } = new MProp<bool>(); 
        public MProp<bool> IsCountry3Selected { get; set; } = new MProp<bool>(); 
        //Pretraga Kraj

        private ArticleService _articleService;
        private DeleteArticleService _deleteArticleService;
        public ArticleResponse Response { get; set; }
        public ObservableCollection<GetArticlesDto> Articles { get; set; }

        public ICommand SearchCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        public ArticlesViewModel()
        {
            //Pocetne vrednosti
            ArticleBeggin.Value = DateTime.Now.AddYears(-5);
            ArticleEnd.Value = DateTime.Now.AddYears(5);
            //

            _articleService = new ArticleService();
            _deleteArticleService = new DeleteArticleService();

            SearchCommand = new Command(SearchAndGetPosts);
            DeleteCommand = new Command<int>(DeletePost);  //!!
            SearchAndGetPosts();
        }

        private void SearchAndGetPosts()
        {
            SelectedIds = new List<int>();  //Da se ponisti svaki put kad se pretrazi da se skuplja sve 

            if (IsCountry1Selected.Value) SelectedIds.Add(1);
            if (IsCountry2Selected.Value) SelectedIds.Add(2);
            if (IsCountry3Selected.Value) SelectedIds.Add(3);


            this.Response = _articleService.GetArticles(ArticleBeggin.Value,
                                                        ArticleEnd.Value,
                                                        SearchNameArticle.Value, 
                                                        SelectionDimension.Value,
                                                        SelectedIds);

            Articles = new ObservableCollection<GetArticlesDto>(Response.Data); //ObservableCollection ne moze da se kastuje iz IEnumerable-a nego mora preko constructora
            OnPropertyChanged(nameof(Articles)); //Uvek pozivamo iz BaseViewModel
        }

        private async void DeletePost(int idToDelete)
        {
            //Command="{Binding BindingContext.DeleteCommand, Source={x:Reference collectionView}}"
            bool success = _deleteArticleService.DeleteArticle(idToDelete);

            if(success)
            {
                SearchAndGetPosts();
            }
            else
            {
                CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

                var snackbarOptions = new SnackbarOptions
                {
                    BackgroundColor = Colors.LightSkyBlue,
                    TextColor = Colors.Green,
                    ActionButtonTextColor = Colors.Yellow,
                    CornerRadius = new CornerRadius(10),
                };

                string text = "Doslo je do greske prilikom brisanja.";
                string actionButtonText = "U redu.";
                TimeSpan duration = TimeSpan.FromSeconds(3);

                var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

                await snackbar.Show(cancellationTokenSource.Token);
            }
        }

    }
}
