﻿using System.Collections.Generic;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Models.Base;

namespace TransactionDataUpload.Domain.Automapper.Base
{
    public static class MappingExtension
    {
        public static TTo To<TTo>(this BasicEntity entity)
        {
            return AutoMapperConfiguration.Mapper.Map<TTo>(entity);
        }

        public static TTo To<TTo>(this IMappable model)
        {
            return AutoMapperConfiguration.Mapper.Map<TTo>(model);
        }

        public static TTo To<TTo>(this IMappable dto, TTo entity)
        {
            return AutoMapperConfiguration.Mapper.Map(dto, entity);
        }

        public static TTo To<TTo>(this TTo model, TTo entity)
        {
            return AutoMapperConfiguration.Mapper.Map(model, entity);
        }

        public static IEnumerable<TTo> To<TTo>(this IEnumerable<BasicEntity> model)
        {
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<TTo>>(model);
        }

        public static IEnumerable<TTo> To<TTo>(this IEnumerable<IMappable> model)
        {
            return AutoMapperConfiguration.Mapper.Map<IEnumerable<TTo>>(model);
        }
    }
}
