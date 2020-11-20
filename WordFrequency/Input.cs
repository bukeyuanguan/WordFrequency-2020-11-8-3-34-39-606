namespace WordFrequency
{
    public class Input
    {
        private string value;
        private int count;

        public Input(string value, int count)
        {
            this.value = value;
            this.count = count;
        }

        public string Value
        {
            get { return this.value; }
        }

        public int WordCount
        {
            get { return this.count; }
        }
    }
}
