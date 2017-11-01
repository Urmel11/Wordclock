using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	class XMLTimeSlotStore : ITimeSlotStore
	{
		private List<PowerTimeSlot> _timeSlots;
		private ITimeSlotStoreObserver _observer;

		private const string FILE_NAME = "TimeSlotConfig.xml";
		private const string SUB_DIRECTORY = "data";
		
		/// <summary>
		/// Returns all time slots
		/// </summary>
		/// <returns></returns>
		public List<PowerTimeSlot> GetTimeSlots()
		{
			if(_timeSlots == null)
			{
				_timeSlots = GetInitialTimeSlots();
			}

			return _timeSlots;
		}

		/// <summary>
		/// Saves the given time slots
		/// </summary>
		/// <param name="timeSlotsToSave"></param>
		public void SaveTimeSlots(IEnumerable<PowerTimeSlot> timeSlotsToSave)
		{
			SaveToFile(timeSlotsToSave);
			_timeSlots = timeSlotsToSave.ToList();

			NotifyStoreValuesChanged();
		}
		
		/// <summary>
		/// Reads the time slots either from config file (if existing) or create default time slots
		/// </summary>
		/// <returns></returns>
		private List<PowerTimeSlot> GetInitialTimeSlots()
		{
			List<PowerTimeSlot> result;

			if (IsConfigFileExisting())
			{
				result = ReadFromFile();
			}
			else
			{
				result = GetDefaultTimeSlots();
			}

			return result;
		}
				
		private List<PowerTimeSlot> ReadFromFile()
		{
			var serializer = new XmlSerializer(typeof(List<PowerTimeSlot>));
			using (var reader = new StreamReader(GetFilePath()))
			{
				var result = serializer.Deserialize(reader);
				reader.Close();

				return (result as List<PowerTimeSlot>);
			}
		}

		private void SaveToFile(IEnumerable<PowerTimeSlot> timeSlotsToSave)
		{
			EnsureConfigDirectoryExist();

			var serializer = new XmlSerializer(typeof(List<PowerTimeSlot>));
			using (var writer = new StreamWriter(GetFilePath()))
			{
				serializer.Serialize(writer, timeSlotsToSave.ToList());
				writer.Flush();
				writer.Close();
			}
		}

		private void EnsureConfigDirectoryExist()
		{
			if(IsConfigDirectoryExisting() == false)
			{
				System.IO.Directory.CreateDirectory(GetDirectoryPath());
			}
		}

		private bool IsConfigFileExisting()
		{
			return System.IO.File.Exists(GetFilePath());
		}

		private bool IsConfigDirectoryExisting()
		{
			return Directory.Exists(GetDirectoryPath());
		}

		private List<PowerTimeSlot> GetDefaultTimeSlots()
		{
			var result = new List<PowerTimeSlot>();

			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Monday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Tuesday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Wednesday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Thursday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Friday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Saturday });
			result.Add(new PowerTimeSlot() { DayOfWeek = DayOfWeek.Sunday });

			return result;
		}

		private void NotifyStoreValuesChanged()
		{
			_observer?.StoreValuesChanged();
		}

		private string GetFilePath()
		{			
			return System.IO.Path.Combine(SUB_DIRECTORY, FILE_NAME);
		}
		
		private string GetDirectoryPath()
		{
			return SUB_DIRECTORY;
		}

		public void RegisterForStoreValuesChanged(ITimeSlotStoreObserver observer)
		{
			_observer = observer;
		}
	}
}
