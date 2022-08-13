using EventsApplication.Common.Mappings;
using EventsApplication.Commands.CreateEvent;
using AutoMapper;

namespace EventsWebApi.Models
{
    public class CreateEventDto : IMapWith<CreateEventCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public DateTime Time { get; set; }
        public string Venue { get; set; }
        public string Speaker { get; set; }
        public string Sponsor { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateEventDto, CreateEventCommand>()
                .ForMember(eventCommand => eventCommand.Speaker,
                    opt => opt.MapFrom(eventDto => eventDto.Speaker))
                .ForMember(eventCommand => eventCommand.Sponsor,
                    opt => opt.MapFrom(eventDto => eventDto.Sponsor))
                .ForMember(eventCommand => eventCommand.Venue,
                    opt => opt.MapFrom(eventDto => eventDto.Venue))
                .ForMember(eventCommand => eventCommand.Title,
                    opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Time,
                    opt => opt.MapFrom(eventDto => eventDto.Time))
                .ForMember(eventCommand => eventCommand.Description,
                    opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.Plan,
                    opt => opt.MapFrom(eventDto => eventDto.Plan));
        }
    }
}
