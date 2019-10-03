using System.IO;
using System.Runtime.Serialization.Json;

using EasyQuiz.Models;

namespace EasyQuiz.Infrastructure
{
	public class JsonFileService : IFileService
	{
		public Quiz Open(string filename)
		{
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Quiz));

			using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
			{
				return (Quiz)jsonSerializer.ReadObject(fs);
			}
		}

		public void Save(string filename, Quiz savingQuiz)
		{
			DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Quiz));

			using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
			{
				jsonSerializer.WriteObject(fs, savingQuiz);
			}
		}
	}
}
