namespace TrainingManagementSystem
{
    internal class Training : TrainingComponent
    {
        List<TrainingComponent> trainingsAndExercises = new List<TrainingComponent>();

        public Training()
        {
            trainingsAndExercises = new List<TrainingComponent>();
        }

        public List<TrainingComponent> TrainingsAndExercises => trainingsAndExercises;

        public bool Add(TrainingComponent trainingComponent)
        {
            if (trainingComponent.GetType() != GetType() && TrainingsAndExercises.Contains(trainingComponent))
            {
                trainingsAndExercises.Add(trainingComponent);
                return true;
            }

            return false;
        }

        public bool IsPractical()
        {
            foreach (var trainingComponent in TrainingsAndExercises)
            {
                if (trainingComponent.GetType() == typeof(Lecture))
                {
                    return false;
                }
            }

            return true;
        }

        public Training Clone()
        {
            Training clone = new Training{ Description = this.Description };

            foreach (TrainingComponent trainingComponent in TrainingsAndExercises)
            {
                if (trainingComponent is Lecture lecture)
                {
                    Lecture newLecture = new Lecture(lecture.Topic);
                    newLecture.Description = lecture.Description;

                    clone.Add(newLecture);
                }
                else if (trainingComponent is PracticalLesson practicalLesson)
                {
                    PracticalLesson newPracticalLesson = new PracticalLesson(practicalLesson.LinkToCondition, practicalLesson.LinkToSolution);
                    newPracticalLesson.Description = practicalLesson.Description;

                    clone.Add(newPracticalLesson);
                }
            }

            return clone;
        }
    }
}
