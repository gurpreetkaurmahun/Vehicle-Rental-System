using System;
namespace OOPCoursework
{
	public interface IOverlappable
	{
		public bool Overlaps(List<Schedule> schedules, Schedule S);
	}
}

