﻿namespace PlantIt.Web.Infrastructure.Automapper
{
    using AutoMapper;
    using PlantIt.Common.Mapping;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(x => x.FullName.Contains(Constants.SolutionName));

            IEnumerable<Type> types = assemblies
                .SelectMany(a => a.GetTypes().Where(t => t.IsClass && !t.IsAbstract))
                .Where(t => t.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)));

            types
                .Select(t => new
                {
                    Destination = t,
                    Source = t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>))
                    .FirstOrDefault()
                    .GetGenericArguments()
                    .FirstOrDefault()
                })
                .ToList()
                .ForEach(m => this.CreateMap(m.Source, m.Destination));

            IEnumerable<Type> configurationTypes = assemblies
                .SelectMany(a => a.GetTypes()
                .Where(t => typeof(IHaveCustomMapping)
                .IsAssignableFrom(t) && t.IsClass && !t.IsAbstract));

            configurationTypes
                .Select(t => Activator.CreateInstance(t))
                .Cast<IHaveCustomMapping>()
                .ToList()
                .ForEach(t => t.Configure(this));
        }
    }
}
