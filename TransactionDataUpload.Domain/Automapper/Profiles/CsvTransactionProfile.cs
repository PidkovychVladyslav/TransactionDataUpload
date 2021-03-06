﻿using AutoMapper;
using System;
using TransactionDataUpload.Data.Entities;
using TransactionDataUpload.Models.Domain;
using static TransactionDataUpload.Core.Helpers.AppConstants;

namespace TransactionDataUpload.Domain.Profiles
{
    public class CsvTransactionProfile : Profile
    {
        public CsvTransactionProfile()
        {
            CreateMap<TransactionCsvUnit, TransactionData>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Identificator, src => src.MapFrom(m => m.Id))
                .ForMember(dest => dest.Amount, src => src.MapFrom(m => m.Amount))
                .ForMember(dest => dest.CurrencyCode, src => src.MapFrom(m => m.CurrencyCode))
                .ForMember(dest => dest.TransactionDate, src => src.MapFrom(m => m.TransactionDate))
                .ForMember(dest => dest.Status, src => src.MapFrom(m => MapStatus(m.Status)));

            CreateMap<CsvTransactions, Transaction>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.FileName, src => src.Ignore())
                .ForMember(dest => dest.Created, src => src.MapFrom(m => DateTime.Now))
                .ForMember(dest => dest.Updated, src => src.MapFrom(m => DateTime.Now))
                .ForMember(dest => dest.Data, src => src.MapFrom(m => m.TransactionCsvUnits));
        }

        private TransactionStatus MapStatus(string source)
        {
            switch (source)
            {
                case CsvStatuses.Approved:
                    return TransactionStatus.A;
                case CsvStatuses.Failed:
                    return TransactionStatus.R;
                case CsvStatuses.Finished:
                    return TransactionStatus.D;
                default:
                    throw new ArgumentException();
            }
        }
    }
}
