using AutoMapper;
using GentilCareBack.Dto;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GentilCareBack.Services.AutoMapper
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() {
            CreateMap<AddressesDto, Addresses>();
            CreateMap<Addresses, AddressesDto>();

            CreateMap<AparatoRespiratorioDto, AparatoRespiratorio>();
            CreateMap<AparatoRespiratorio, AparatoRespiratorioDto>();

            CreateMap<AuthsDto, Auths>()
                .ForMember(dest => dest.AuthsId, opt => opt.MapFrom(src => src.AuthsId))
                //.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.acceso))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password))
                .ForMember(dest => dest.verified, opt => opt.MapFrom(src => src.verified))
                .ForMember(dest => dest.Roles, opt=> opt.MapFrom(src=> src.Roles))
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.created_at));

            CreateMap<Auths, AuthsDto>()
                .ForMember(dest => dest.AuthsId, opt => opt.MapFrom(src => src.AuthsId))
                //.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.acceso, opt => opt.MapFrom(src => src.username))
                .ForMember(dest => dest.password, opt => opt.MapFrom(src => src.password))
                .ForMember(dest => dest.verified, opt => opt.MapFrom(src => src.verified))
                .ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.created_at, opt => opt.MapFrom(src => src.created_at));

            CreateMap<CardioVascularDto, CardioVascular>();
            CreateMap<CardioVascular, CardioVascularDto>();

            CreateMap<ColaboradorsDto, Colaboradors>();
            CreateMap<Colaboradors, ColaboradorsDto>();

            CreateMap<Esfera_PsiquicaDto, Esfera_Psiquica>();
            CreateMap<Esfera_Psiquica, Esfera_PsiquicaDto>();

            CreateMap<EspecialidadsDto, Especialidads>();
            CreateMap<Especialidads, EspecialidadsDto>();

            CreateMap<EstudiosDto, Estudios>();
            CreateMap<Estudios, EstudiosDto>();

            CreateMap<FarmacosDto, Farmacos>();
            CreateMap<Farmacos, FarmacosDto>();

            CreateMap<InterrogatoriosDto, Interrogatorios>();
            CreateMap<Interrogatorios, InterrogatoriosDto>();

            CreateMap<MotivosDto, Motivos>();
            CreateMap<Motivos, MotivosDto>();

            CreateMap<PielTegumentosDto, PielTegumentos>();
            CreateMap<PielTegumentos, PielTegumentosDto>();

            CreateMap<PreguntasDto, Preguntas>();
            CreateMap<Preguntas, PreguntasDto>();

            CreateMap<RecetasDto, Recetas>();
            CreateMap<Recetas, RecetasDto>();

            CreateMap<RolesDto, Roles>()
                .ForMember(dest => dest.role, opt => opt.MapFrom(src => src.role))
                .ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.RolesId));

            CreateMap<Roles, RolesDto>()
               .ForMember(dest => dest.role, opt => opt.MapFrom(src => src.role))
               .ForMember(dest => dest.RolesId, opt => opt.MapFrom(src => src.RolesId))
               .ForMember(dest => dest.rol, opt => opt.MapFrom(src => src.role));

            CreateMap<SentidosDto, Sentidos>();
            CreateMap<Sentidos, SentidosDto>();

            CreateMap<ServiciosDto, Servicios>()
                .ForMember(dest => dest.costo, opt => opt.MapFrom(src => Convert.ToDecimal( src.costo)))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.ServiciosId, opt => opt.MapFrom(src => src.ServiciosId));
            CreateMap<Servicios, ServiciosDto>()
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.ServiciosId, opt => opt.MapFrom(src => src.ServiciosId))
                .ForMember(dest => dest.descripcion, opt => opt.MapFrom(src => src.descripcion))
                .ForMember(dest => dest.costo, opt => opt.MapFrom(src => src.costo));

            CreateMap<SignosvitalesDto, Signosvitales>();
            CreateMap<Signosvitales, SignosvitalesDto>();

            CreateMap<SintomasGeneralesDto, SintomasGenerales>();
            CreateMap<SintomasGenerales, SintomasGeneralesDto>();

            CreateMap<SistemaDigestivoDto, SistemaDigestivo>();
            CreateMap<SistemaDigestivo, SistemaDigestivoDto>();

            CreateMap<SistemaEmatopoyeticoDto, SistemaEmatopoyetico>();
            CreateMap<SistemaEmatopoyetico, SistemaEmatopoyeticoDto>();

            CreateMap<SistemaEndocrinoDto, SistemaEndocrino>();
            CreateMap<SistemaEndocrino, SistemaEndocrinoDto>();

            CreateMap<SistemaMusculoEsqueleticoDto, SistemaMusculoEsqueletico>();
            CreateMap<SistemaMusculoEsqueletico, SistemaMusculoEsqueleticoDto>();

            CreateMap<SistemaNerviosoDto, SistemaNervioso>();
            CreateMap<SistemaNervioso, SistemaNerviosoDto>();

            CreateMap<UsersDto, Users>()
                .ForMember(dest => dest.UsersId, opt => opt.MapFrom(src => src.UsersId))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.cellphone, opt => opt.MapFrom(src => src.cellphone))
                .ForMember(dest => dest.customerID, opt => opt.MapFrom(src => src.customerID))
                .ForMember(dest => dest.parentezco, opt => opt.MapFrom(src => src.parentezco))
                .ForMember(dest => dest.gender, opt => opt.MapFrom(src => src.sexo))
                .ForMember(dest => dest.firsname, opt => opt.MapFrom(src => src.A_P))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.A_M))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.nombre))
                .ForMember(dest => dest.Auths, opt => opt.MapFrom(src => src.auth))
                .ForMember(dest => dest.pin, opt => opt.MapFrom(src => src.pin))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.fecha_nac));


            CreateMap<Users, UsersDto>()
                .ForMember(dest => dest.UsersId, opt => opt.MapFrom(src => src.UsersId))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.cellphone, opt => opt.MapFrom(src => src.cellphone))
                .ForMember(dest => dest.customerID, opt => opt.MapFrom(src => src.customerID))
                .ForMember(dest => dest.parentezco, opt => opt.MapFrom(src => src.parentezco))
                .ForMember(dest => dest.sexo, opt => opt.MapFrom(src => src.gender))
                .ForMember(dest => dest.nombre, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.auth, opt => opt.MapFrom(src => src.Auths))
                .ForMember(dest => dest.A_P, opt => opt.MapFrom(src => src.firsname))
                .ForMember(dest => dest.A_M, opt => opt.MapFrom(src => src.lastname))
                .ForMember(dest => dest.pin, opt => opt.MapFrom(src => src.pin))
                .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                .ForMember(dest => dest.fecha_nac, opt => opt.MapFrom(src => src.birthday));

            CreateMap<PlanesDto, Planes>();
            CreateMap<Planes, PlanesDto>();

            CreateMap<MedicamentoDto, Medicamento>();
            CreateMap<Medicamento, MedicamentoDto>();

            CreateMap<ProveedorDto, Proveedor>()
                .ForMember(dest => dest.cellphone, opt => opt.MapFrom(src => src.cellphone))
                .ForMember(dest => dest.costo, opt => opt.MapFrom(src => src.costo))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.estudio, opt => opt.MapFrom(src => src.estudio))
                .ForMember(dest => dest.provedor, opt => opt.MapFrom(src => src.provedor))
                .ForMember(dest => dest.Addresses, opt => opt.MapFrom(src => src.address))
                .ForMember(dest => dest.ProveedorId, opt => opt.MapFrom(src => src.ProveedorId));
            CreateMap<Proveedor, ProveedorDto>()
                .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.Addresses))
                .ForMember(dest => dest.cellphone, opt => opt.MapFrom(src => src.cellphone))
                .ForMember(dest => dest.costo, opt => opt.MapFrom(src => src.costo))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.email))
                .ForMember(dest => dest.estudio, opt => opt.MapFrom(src => src.estudio))
                .ForMember(dest => dest.provedor, opt => opt.MapFrom(src => src.provedor))
                .ForMember(dest => dest.ProveedorId, opt => opt.MapFrom(src => src.ProveedorId));

            CreateMap<SemanaDto, Semana>();
            CreateMap<Semana, SemanaDto>();

            CreateMap<HorasDto, Horas>();
            CreateMap<Horas, HorasDto>();
        }
    }
}
