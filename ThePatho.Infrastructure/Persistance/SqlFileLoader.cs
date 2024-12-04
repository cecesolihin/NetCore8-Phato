
using Microsoft.Extensions.Configuration;

namespace ThePatho.Infrastructure.Persistance
{
    public class SqlQueryLoader
    {
        private readonly string _rootPath;

        public SqlQueryLoader(IConfiguration configuration)
        {
            _rootPath = configuration["SqlPaths:Root"];
        }

        public async Task<string> LoadQueryAsync(string relativePath)
        {
            var fullPath = Path.Combine(_rootPath, relativePath.Replace("/", "\\") + ".sql");

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"SQL file not found at: {fullPath}");

            return await File.ReadAllTextAsync(fullPath);
        }
    }
}
