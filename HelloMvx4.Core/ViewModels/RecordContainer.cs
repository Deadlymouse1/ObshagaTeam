using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HelloMvx4.Core
{
	public class RecordContainer
	{
		public RecordContainer()
		{
		}

		private List<Record> allRecord = new List<Record>();
		public int getCountRecords
		{
			get { return allRecord.Count; }
		}
		public string GetRecordDate(int index)
		{
			return allRecord[index].RecordDate;
		}
		public void AddRecord(Record record)
		{
			allRecord.Add(record);
		}

		public void Remove(int index)
		{
			allRecord.RemoveAt(index);
		}

		public Record GetRecord(int index)
		{
			return allRecord[index];
		}

		private void SortByDate()
		{
			allRecord = allRecord.OrderBy((arg) => DateTime.Parse(arg.RecordDate)).ToList();
		}
	}
}
