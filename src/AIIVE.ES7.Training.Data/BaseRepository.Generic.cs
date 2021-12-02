using Nest;
using System;
using System.Linq;

namespace AIIVE.ES7.Training.Data
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ElasticSearchIndexAttribute : Attribute
    {
        public string Index { get; set; }
        public ElasticSearchIndexAttribute(string index)
        {
            Index = index;
        }
    }

    public static class AttributeExtension
    {
        public static string IndexName(this Type type)
        {
            ElasticSearchIndexAttribute att = (ElasticSearchIndexAttribute)type.GetCustomAttributes(typeof(ElasticSearchIndexAttribute), inherit: true).First();

            return att.Index;
        }
    }
    public abstract class ElasticTypeBase
    {
        public string Id { get; set; }
        public string Codigo { get; set; }
    }

    public  interface IIndiceSettings
    {
        string Url { get; set; }
        string User { get; set; }
        string Password { get; set; }
    }

    public abstract class BaseRepository
    {
        protected IElasticClient client;
        protected string index;
        protected Uri baseUri;
        protected IIndiceSettings settings;

        protected BaseRepository() { }

        public BaseRepository(IIndiceSettings settings, IElasticClient elasticClient)
        {
            this.settings = settings;
            this.baseUri = new Uri(settings.Url);
            this.client = elasticClient;
        }


    }
    public abstract class BaseRepositoryGeneric<T> : BaseRepository where T : ElasticTypeBase
    {
        protected string type;

        protected BaseRepositoryGeneric(IIndiceSettings settings, IElasticClient elasticClient)
            :base(settings, elasticClient)

        {
            this.SetDefaultIndex(settings);            
        }

        public virtual void SetDefaultIndex(IIndiceSettings settings) => this.index = typeof(T).IndexName();
    }
}
