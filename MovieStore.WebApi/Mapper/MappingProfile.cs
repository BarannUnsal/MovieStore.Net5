using System.Linq;
using AutoMapper;
using MovieStore.WebApi.Application.ActorOperations.Commands.Create;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActorDetials;
using MovieStore.WebApi.Application.ActorOperations.Queries.GetActors;
using MovieStore.WebApi.Application.CustomerOpretaions.Commands.Create;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomerDetails;
using MovieStore.WebApi.Application.CustomerOpretaions.Queries.GetCustomers;
using MovieStore.WebApi.Application.DirectorOperations.Commands.Create;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectorDetails;
using MovieStore.WebApi.Application.DirectorOperations.Queries.GetDirectors;
using MovieStore.WebApi.Application.GenreOperations.Command.Create;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenreDetails;
using MovieStore.WebApi.Application.GenreOperations.Queries.GetGenres;
using MovieStore.WebApi.Application.MovieOperations.Command.Create;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovieDetails;
using MovieStore.WebApi.Application.MovieOperations.Queries.GetMovies;
using MovieStore.WebApi.Entities;

namespace MovieStore.WebApi.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Actor
            CreateMap<CreateActorViewModel, Actor>();
            CreateMap<Actor, GetActorViewModel>().ForMember(dest => dest.Movies, src => src.MapFrom(opt => opt.MovieActors.Select(x => x.Movie.Name)));
            CreateMap<Actor, GetActorDetailsViewModel>().ForMember(dest => dest.Movies, src => src.MapFrom(opt => opt.MovieActors.Select(x => x.Movie.Name)));

            //Customer
            CreateMap<CreateCustomerViewModel, Customer>();
            CreateMap<Customer, GetCustomerDetailsViewModel>().ForMember(dest => dest.FavGenres, src => src.MapFrom(opt => opt.CustomerGenres.Select(x => x.Genre.Name)));
            CreateMap<Customer, GetCustomerViewModel>().ForMember(dest => dest.FavGenres, src => src.MapFrom(opt => opt.CustomerGenres.Select(x => x.Genre.Name)));

            //Director
            CreateMap<CreateDirectorViewModel, Director>();
            CreateMap<Director, GetDirectorDetailsViewModel>().ForMember(dest => dest.Movies, src => src.MapFrom(opt => opt.Movies.Select(x => x.Name)));
            CreateMap<Director, GetDirectorViewModel>().ForMember(dest => dest.Movies, src => src.MapFrom(opt => opt.Movies.Select(x => x.Name)));

            //Genre
            CreateMap<CreateGenreViewModel, Genre>();
            CreateMap<Genre, GetGenreDetailsViewModel>().ForMember(dest => dest.Customers, src => src.MapFrom(opt => opt.GenreCustomers.Select(x => x.Customer.Name + " " + x.Customer.Surname))).ForMember(dest => dest.HowManyCustomerFav, src => src.MapFrom(opt => opt.GenreCustomers.Count())).ForMember(dest => dest.GenreMovies, src => src.MapFrom(opt => opt.GenreMovies.Select(x => x.Name)));
            CreateMap<Genre, GetGenreViewModel>().ForMember(dest => dest.Customers, src => src.MapFrom(opt => opt.GenreCustomers.Select(x => x.Customer.Name + " " + x.Customer.Surname)));

            //Movie
            CreateMap<CreateMovieViewModel, Movie>();
            CreateMap<Movie, GetMovieDetailsViewModel>().ForMember(dest => dest.PublishDate, src => src.MapFrom(opt => opt.PublishDate.ToString("dd.MM.yyyy"))).ForMember(dest => dest.Genre, src => src.MapFrom(opt => opt.Genre.Name)).ForMember(dest => dest.Director, dest => dest.MapFrom(opt => opt.Director.Name + " " + opt.Director.Surname)).ForMember(dest => dest.MovieActors, src => src.MapFrom(opt => opt.MovieActor.Select(x => x.Actor.Name + " " + x.Actor.Surname)));
            CreateMap<Movie, GetMovieViewModel>().ForMember(dest => dest.PublishDate, src => src.MapFrom(opt => opt.PublishDate.ToString("dd.MM.yy"))).ForMember(dest => dest.Genre, src => src.MapFrom(opt => opt.Genre.Name)).ForMember(dest => dest.Director, dest => dest.MapFrom(opt => opt.Director.Name + " " + opt.Director.Surname)).ForMember(dest => dest.MovieActors, src => src.MapFrom(opt => opt.MovieActor.Select(x => x.Actor.Name + " " + x.Actor.Surname)));
        }
    }
}