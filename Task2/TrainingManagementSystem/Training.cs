
namespace TrainingManagementSystem
{
    internal class Training : TrainingComponent
    {
        private const int DefaultSize = 10;
        TrainingComponent[] _components;
        public Training()
        {
            _components = new TrainingComponent[DefaultSize];
        }

        public TrainingComponent[] TrainingsAndExercises => _components;

        public bool Add(TrainingComponent trainingComponent)
        {
            if (IsValidType(trainingComponent))
            {
                for (int i = 0; i < _components.Length; i++)
                {
                    if (_components[i] == null)
                    {
                        _components[i] = trainingComponent;
                        return true;
                    }
                }

                TrainingComponent[] newArray = new TrainingComponent[_components.Length * 2];
                Array.Copy(_components, newArray, _components.Length);
                newArray[_components.Length] = trainingComponent;
                _components = newArray;
                return true;
            }

            return false;
        }

        private bool IsValidType(TrainingComponent trainingComponent)
        {
            return trainingComponent.GetType() == typeof(Lecture) || trainingComponent.GetType() == typeof(PracticalLesson);
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

        public override object Clone()
        {
            Training clone = new Training { Description = this.Description };

            foreach (var component in _components)
            {
                if (component != null)
                {
                    clone.Add((TrainingComponent)component.Clone());
                }
            }

            return clone;
        }
    }
}