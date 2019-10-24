using System;
using System.Collections.ObjectModel;

namespace EasyQuiz.Infrastructure
{
	public static class RandomExtensions
	{
		public static void Shuffle<T>(this Random rng, ObservableCollection<T> array)
		{
			int size = array.Count;
			while (size > 1)
			{
				int randomNum = rng.Next(size--);
				T temp = array[size];
				array[size] = array[randomNum];
				array[randomNum] = temp;
			}
		}
	}
}
