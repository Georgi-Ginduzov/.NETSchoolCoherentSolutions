namespace TrainingManagementSystem
{
    internal abstract class TrainingComponent : ICloneable
    {
        public String Description { get; set; }

        public abstract object Clone();
    }
}
