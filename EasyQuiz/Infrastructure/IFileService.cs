using EasyQuiz.Models;

namespace EasyQuiz.Infrastructure
{
	public interface IFileService
	{
		Quiz Open(string filename);
		void Save(string filename, Quiz savingQuiz);
	}
}
