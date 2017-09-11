using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wordclock.Shared.Services;

namespace Wordclock.Core.PowerManagement
{
	class XMLTimeSlotStore : ITimeSlotStore
	{
		private const string CONFIG_FILENAME = "TimeSlotConfig.xml";
		private List<PowerTimeSlot> _timeSlots;
		private ITimeSlotStoreObserver _observer;
		
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

			if (IsConfiFileExisting())
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
			using (var reader = new StreamReader(CONFIG_FILENAME))
			{
				var result = serializer.Deserialize(reader);
				reader.Close();

				return (result as List<PowerTimeSlot>);
			}
		}

		private void SaveToFile(IEnumerable<PowerTimeSlot> timeSlotsToSave)
		{
			var serializer = new XmlSerializer(typeof(List<PowerTimeSlot>));
			using (var writer = new StreamWriter(CONFIG_FILENAME))
			{
				serializer.Serialize(writer, timeSlotsToSave.ToList());
				writer.Flush();
				writer.Close();
			}
		}

		private bool IsConfiFileExisting()
		{
			return System.IO.File.Exists(CONFIG_FILENAME);
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

		public void RegisterForStoreValuesChanged(ITimeSlotStoreObserver observer)
		{
			_observer = observer;
		}
	}
}
