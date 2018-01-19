namespace PlantIt.Common.Mapping
{
    using AutoMapper;

    public interface IHaveCustomMapping
    {
        void Configure(Profile profile);
    }
}
