using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wordclock.Shared.Services;

namespace Wordclock.App.Utils
{
	public interface IResourceService
	{
		List<FileContent> GetEmbeddedResources();
	}
}
