namespace TrainingManagementSystem
{
    internal class Lecture : TrainingComponent
    {
        private string topic;

        public Lecture(string topic)
        {
            Topic = topic;
        }

        public string Topic { get => topic; set => topic = value; }

        public override object Clone()
        {
            return new Lecture(Topic) { Description = Description };
        }
    }
}