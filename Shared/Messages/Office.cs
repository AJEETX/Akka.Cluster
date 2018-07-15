namespace Message
{
    public class Office
    {
        public string ID { get; private set; }

        public string Data { get; private set; }

        public Office(string id, string data)
        {
            this.ID = id;
            this.Data = data;
        }

        public override string ToString()
        {
            return string.Format($"ID : {this.ID} Data : {this.Data} ");
        }
    }
}