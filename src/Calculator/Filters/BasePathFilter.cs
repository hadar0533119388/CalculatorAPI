using System.Linq;
using System.Text.RegularExpressions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace Calculator.Filters
{
    /// <summary>
    /// BasePath Document Filter sets BasePath property of Swagger and removes it from the individual URL paths
    /// </summary>
    public class BasePathFilter : IDocumentFilter
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="basePath">BasePath to remove from Operations</param>
        public BasePathFilter(string basePath)
        {
            BasePath = basePath;
        }

        /// <summary>
        /// Gets the BasePath of the Swagger Doc
        /// </summary>
        /// <returns>The BasePath of the Swagger Doc</returns>
        public string BasePath { get; }

        /// <summary>
        /// Apply the filter
        /// </summary>
        /// <param name="swaggerDoc">OpenApiDocument</param>
        /// <param name="context">FilterContext</param>
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers.Add(new OpenApiServer() { Url = this.BasePath });

            var pathsToModify = swaggerDoc.Paths.Where(p => p.Key.StartsWith(this.BasePath)).ToList();

            foreach (var path in pathsToModify)
            {
                if (path.Key.StartsWith(this.BasePath))
                {
                    string newKey = Regex.Replace(path.Key, $"^{this.BasePath}", string.Empty);
                    swaggerDoc.Paths.Remove(path.Key);
                    swaggerDoc.Paths.Add(newKey, path.Value);
                }
            }
        }
    }
}
