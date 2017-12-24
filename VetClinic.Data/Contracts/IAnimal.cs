﻿using VetClinic.Data.Common.Enums;

namespace VetClinic.Data.Contracts
{
    public interface IAnimal
    {
        string Id { get; }

        string Name { get; }

        AnimalType Type { get; }

        AnimalGenderType Gender { get; }
    }
}