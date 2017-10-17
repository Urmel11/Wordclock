using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.Utils
{
	class EmbeddedResourceService : IResourceService
	{
		private const string ASSEMBLY_NAME = "Wordclock.App";
		private const string RESOURCE_LOCATION = "Wordclock.App.EmbeddedResources.";

		public List<FileContent> GetEmbeddedResources()
		{
			var result = new List<FileContent>();
			var resourceNames = GetResourceNames();

			foreach(var resourceName in resourceNames)
			{
				result.Add(GetEmbeddedResource(resourceName));
			}

			return result;
		}

		private FileContent GetEmbeddedResource(string resourceName)
		{
			var stream = GetCurrentAssembly().GetManifestResourceStream(resourceName);
			var memoryStream = new MemoryStream();

			stream.CopyTo(memoryStream);

			var result = new FileContent
			{
				Content = memoryStream.ToArray(),
				FileName = GetResourceFileName(resourceName)
			};

			return result;
		}

		private string GetResourceFileName(string resourceName)
		{
			return resourceName.Replace(RESOURCE_LOCATION, "");
		}

		private string[] GetResourceNames()
		{
			var resourceNames = GetCurrentAssembly().GetManifestResourceNames();
			
			return resourceNames;
		}

		private Assembly GetCurrentAssembly()
		{
			var assemblyName = new AssemblyName(ASSEMBLY_NAME);
			
			return Assembly.Load(assemblyName);
		}
		
	}
}
