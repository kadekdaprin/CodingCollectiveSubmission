namespace CodingCollectiveSubmission.Models
{
    public class DataTableResponeModel<T>
    {
        public DataTableResponeModel()
        {

        }

        public DataTableResponeModel(int? start, int? length, int? recordsTotal, int? recordsFiltered, List<T> data)
        {
            this.start = start;
            this.length = length;
            this.recordsTotal = recordsTotal;
            this.recordsFiltered = recordsFiltered;
            this.data = data;
        }

        public int? draw { get; set; }

        public int? start { get; set; }

        public int? length { get; set; }        

        public int? recordsTotal { get; set; }

        public int? recordsFiltered { get; set; }

        public List<T> data { get; set; }
    }
}
