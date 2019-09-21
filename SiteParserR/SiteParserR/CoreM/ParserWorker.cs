using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Core
{
    class ParserWorker<T> where T : class
    {
        IParser<T> parser;
        IParserSettings parserSettings;

        HtmlLoader loader;


        #region Properties

        public IParser<T> Parser
        {
            get
            {
                return parser;
            }
            set
            {
                parser = value;
            }
        }

        public IParserSettings Settings
        {
            get
            {
                return parserSettings;
            }
            set
            {
                parserSettings = value;
                loader = new HtmlLoader(value);
            }
        }


        #endregion

        public event Action<object, List<T>> OnNewData;
        public event Action<object> OnCompleted;

        public ParserWorker(IParser<T> parser)
        {
            this.parser = parser;
        }

        public ParserWorker(IParser<T> parser, IParserSettings parserSettings) : this(parser)
        {
            this.parserSettings = parserSettings;
            loader = new HtmlLoader(parserSettings);
        }

        public void StartW()
        {
            Worker();
        }
        public void StartWWP(string[] s)
        {
            WorkerWithPages(s);
        }

        private async void Worker()
        {
            var source = await loader.GetSourcePage();
            var domParser = new HtmlParser();

            var document = await domParser.ParseDocumentAsync(source);

            var result = parser.Parse(document);
            List<T> temp = new List<T>();
            temp.Add(result);
            OnNewData?.Invoke(this, temp);
            OnCompleted?.Invoke(this);
        }
        private async void WorkerWithPages(string[] s)
        {
            List<T> weapSkins = new List<T>();
            for(int i = 0; i < s.Length; ++i)
            {
                var source = await loader.GetSourceByPageId(s[i]);
                var domParser = new HtmlParser();

                var document = await domParser.ParseDocumentAsync(source);

                var result = parser.Parse(document);
                weapSkins.Add(result);
            }
            OnNewData?.Invoke(this, weapSkins);
            OnCompleted?.Invoke(this);
        }

    }
}
