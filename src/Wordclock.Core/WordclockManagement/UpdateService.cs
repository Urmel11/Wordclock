using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.Core.WordclockManagement
{
	public partial class WordclockService : IUpdateService
	{
		private const string PATH_TO_UPDATE_FOLDRE = "update";

		public void TransferContent(IEnumerable<FileContent> content, bool clearDestinationDirectory)
		{
			if(clearDestinationDirectory)
			{
				RecreateUpdateFolder();
			}
			
			foreach(var cont in content)
			{
				File.WriteAllBytes(GetFilePath(cont.FileName), cont.Content);
			}
		}

		private void RecreateUpdateFolder()
		{
			DeleteUpdateFolder();
			CreateUpdateFolder();
		}

		private void DeleteUpdateFolder()
		{
			if(Directory.Exists(PATH_TO_UPDATE_FOLDRE))
			{
				Directory.Delete(PATH_TO_UPDATE_FOLDRE, true);
			}
		}

		private void CreateUpdateFolder()
		{
			Directory.CreateDirectory(PATH_TO_UPDATE_FOLDRE);
		}

		private string GetFilePath(string fileName)
		{
			return Path.Combine(PATH_TO_UPDATE_FOLDRE, fileName);
		}

		public bool IsUpdateRequired(string newVersion)
		{
			var currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
			
			return !(currentVersion == newVersion);
		}
	}
}
