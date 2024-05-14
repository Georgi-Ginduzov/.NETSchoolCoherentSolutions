namespace TrainingManagementSystem
{
    internal class PracticalLesson : TrainingComponent
    {
        private string linkToCondition;
        private string linkToSolution;

        public PracticalLesson(string linkToCondition, string linkToSolution)
        {
            LinkToCondition = linkToCondition;
            LinkToSolution = linkToSolution;
        }

        public string LinkToCondition { get => linkToCondition; set => linkToCondition = value; }
        public string LinkToSolution { get => linkToSolution; set => linkToSolution = value; }

        public override object Clone()
        {
            return new PracticalLesson(LinkToCondition, LinkToSolution) { Description = Description };
        }
    }
}