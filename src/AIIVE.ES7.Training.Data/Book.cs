namespace AIIVE.ES7.Training.Data
{
    [ElasticSearchIndex("books")]
    public class Book : ElasticTypeBase
    {
        public string Authors { get; set; }

        public string ISBN { get; private set; }

        public int? OriginalPublicationYear { get; private set; }

        public string OriginalTitle { get; private set; }
        public string Title { get; set; }

        public string LanguageCode { get; private set; }

        public float AverageRating { get; private set; }

        public string ImageUrl { get; private set; }

        public string SmallImageUrl { get; private set; }

        public Book()
        {

        }

        public Book(
            string authors,
            string isbn,
            int originalPublicationYear,
            string originalTitle,
            string title,
            string languageCode,
            float averageRating,
            string imageUrl,
            string smallImageUrl)
        {
            Authors = authors;
            ISBN = isbn;
            OriginalPublicationYear = originalPublicationYear;
            OriginalTitle = originalTitle;
            Title = title;
            LanguageCode = languageCode;
            AverageRating = averageRating;
            ImageUrl = imageUrl;
            SmallImageUrl = smallImageUrl;
        }
        public Book(
            long id,
            string authors,
            string isbn,
            int originalPublicationYear,
            string originalTitle,
            string title,
            string languageCode,
            float averageRating,
            string imageUrl,
            string smallImageUrl) : this(
            authors,
            isbn,
            originalPublicationYear,
            originalTitle,
            title,
            languageCode,
            averageRating,
            imageUrl,
            smallImageUrl)
        {
            Id = id;
        }

    }
}
